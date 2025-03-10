using DemoAPI.DBModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private IConfiguration _configuration;
        DemoNewDbContext context = new DemoNewDbContext();
        public EmployeesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<EmployeesController>
        // controller action methods
        //string connectionString = @"data source=DESKTOP-JVCT4QT\MSSQLSERVER01;integrated security=SSPI;database=DemoNewDB;TrustServerCertificate=true";

        Employee employee = new Employee();
        [HttpGet]
        public IActionResult Get()
        {
            List<Employee> employees = new List<Employee>();
            // data source=[SERVER_NAME];integrated security=SSPI;database=[DATABASE_NAME] -> windows Authentication
            // data source=[SERVER_NAME];user Id=[USER_NAME];password=[PASSWORD];database=[DATABASE_NAME] -> SQL Authentication
            // database or initial catalog
            string address = "UK";
            string connectionString = _configuration.GetConnectionString("demodbCS");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from tblEmployee where emp_address='"+ address + "'", con);
                con.Open();
                // if we are getting multiple record form the database then only use the datareader
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // it is read only forward only 
                    while (reader.Read())
                    {
                        Employee emp = new Employee();
                        emp.Name = reader["emp_name"].ToString();
                        emp.Address = reader["emp_address"].ToString();
                        emp.Age = Convert.ToInt32(reader["age"]);
                        employees.Add(emp);
                    }
                }
            }
           return Ok(employees);
        }

        

        [HttpGet]
        [Route("LoadEmployees")]
        
        //[EnableCors("_MyEmployeePolicy")]
        public List<TblEmployee> employeesFromList()
        {
           
            return context.TblEmployees.Where(x=>x.EmpAddress=="UK").ToList();
            
        }

        [HttpGet]
        [Route("~/LoadEmployees/{id}/{name}")]
        public List<Employee> employees(int id, string name)
        {

            return employee.GetEmployees();
        }

        // GET api/Employees/5
        // Model Binding
        [HttpGet("{id}/{name?}")]
        public IActionResult Get(int id,string name=null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("demodbCS")))
                {
                    //SqlCommand cmd = new SqlCommand("insert into tblEmployee values('"+newEmployee.Name+"',1,"+newEmployee.Salary+",'"+newEmployee.Email+"',"+newEmployee.Age+",'"+newEmployee.Address+"',2,1,'"+DateTime.Now+"',12000)", con);
                    SqlCommand cmd = new SqlCommand("select emp_name from tblEmployee where emp_id=3 ", con);
                 
                    con.Open();
                    object result = cmd.ExecuteScalar();


                }

                //throw new Exception("Custom exception");
                Employee employee = new Employee();
                Employee emp = employee.GetEmployees().FirstOrDefault(x => x.Id == id);
                if (emp != null)
                {
                    return Ok(emp);
                }
                else
                {
                    return NotFound("Employee with Id : " + id + "  not found. ");

                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
          
        }

        // POST api/<EmployeesController>
        [HttpPost]
        //[DisableCors]
        public void Post([FromBody] TblEmployee newEmployee)
        {

            TblEmployee employee = new TblEmployee();
            context.Entry(employee).State = EntityState.Added;

            context.TblEmployees.Add(newEmployee);
            context.SaveChanges();
            
            //using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("demodbCS")))
            //{
            //    //SqlCommand cmd = new SqlCommand("insert into tblEmployee values('"+newEmployee.Name+"',1,"+newEmployee.Salary+",'"+newEmployee.Email+"',"+newEmployee.Age+",'"+newEmployee.Address+"',2,1,'"+DateTime.Now+"',12000)", con);
            //    SqlCommand cmd = new SqlCommand("insert into tblEmployee values(@name,1,@salary,@email,@age,@address,2,1,@date,12000)", con);
            //    cmd.Parameters.AddWithValue("@name", newEmployee.Name);
            //    cmd.Parameters.AddWithValue("@salary", newEmployee.Salary);
            //    cmd.Parameters.AddWithValue("@email", newEmployee.Email);
            //    cmd.Parameters.AddWithValue("@age", newEmployee.Age);
            //    cmd.Parameters.AddWithValue("@address", newEmployee.Address);
            //    cmd.Parameters.AddWithValue("@date", DateTime.Now);

            //    con.Open();
            //     int result = cmd.ExecuteNonQuery();

                
            //}


        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TblEmployee newEmployee)
        {
            TblEmployee employee=  context.TblEmployees.FirstOrDefault(x => x.EmpId == id);
            if(employee!=null)
            {
                employee.EmpName = newEmployee.EmpName;
                employee.MonthlySalary= newEmployee.MonthlySalary;
                context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();  
            }
         

            //using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("demodbCS")))
            //{
            //    //SqlCommand cmd = new SqlCommand("insert into tblEmployee values('"+newEmployee.Name+"',1,"+newEmployee.Salary+",'"+newEmployee.Email+"',"+newEmployee.Age+",'"+newEmployee.Address+"',2,1,'"+DateTime.Now+"',12000)", con);
            //    SqlCommand cmd = new SqlCommand("update  tblEmployee set emp_name=@name, email=@email, monthly_salary=@salary where emp_id=@id ", con);
            //    cmd.Parameters.AddWithValue("@name", newEmployee.Name);
            //    cmd.Parameters.AddWithValue("@salary", newEmployee.Salary);
            //    cmd.Parameters.AddWithValue("@email", newEmployee.Email);
                
            //    cmd.Parameters.AddWithValue("@id", id);

            //    con.Open();
            //    int result = cmd.ExecuteNonQuery();


            //}
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TblEmployee employee = context.TblEmployees.FirstOrDefault(x => x.EmpId == id);
            context.Entry(employee).State = EntityState.Deleted;
            context.SaveChanges();
            //Employee emptoDelete = employee.GetEmployees().FirstOrDefault(x => x.Id == id);
            //employee.GetEmployees().Remove(emptoDelete);
        }
    }
}
