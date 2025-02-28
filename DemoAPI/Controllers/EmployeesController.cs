using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // GET: api/<EmployeesController>
        // controller action methods
        Employee employee = new Employee();
        [HttpGet]
        public IActionResult Get()
        {
           
           return Ok(employee.GetEmployees());
        }

        // Cross Origin -> 

        // http://localhost:5266 - .NET API

        // http://localhost:3000  - REact ( Whitelisted)
        // http://localhost:4000  - REact 

        // Status Code
        // 500 - internal server error
        // 404 - resource not found ( entity etc..)
        // 201 created - resource is sent to the server and created 
        // 200 -> we send something to the server and it passed 
        // 400 -> Bad request ( we have something wrong with the API end point data and it is not making call to the server)
        // 204 -> No resource Found 
        // 401 unauthorized
        // 403 Forbidden
        // 405 Method Not Allowed
        // 408 Request Timeout
        // 414 URI Too Long
        // 415 Unsupported Media Type
        // 429 Too Many Requests 


        // HR, Employee, Admin, Payroll, INventory
        // ONe Database ( SQL SERVER)
        // Multiple table for multiple module 
        // Server -> hosted the application 

        // Server -> get down 
        // Server- > Database 
        // Monolithic 

        // Microservices 

        // HR-> API Project -> Server 1  -> Java ,MongoDB HR

        // EMPLOYEE -> API project -> Server 2 -> .net  , SQL server 

        // ADMIN -> API Project  -> server 3 -> python , MYSQL

        // Payroll -> API -> Server 4 -> Node , NOSQL

        [HttpGet]
        [Route("LoadEmployees")]
        //[EnableCors("_MyEmployeePolicy")]
        public Employee employeesFromList(int empId,string gender)
        {
            // Database
            return employee.GetEmployees().FirstOrDefault(x => x.Id == empId);
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
        public void Post([FromBody] int id,[FromQuery] Employee newEmployee)
        {

            

        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee newEmployeeValue)
        {
          Employee emptoUpdate =  employee.GetEmployees().FirstOrDefault(x => x.Id == id);
            emptoUpdate.Name = newEmployeeValue.Name;
            emptoUpdate.Pincode = newEmployeeValue.Pincode;
            emptoUpdate.Address = newEmployeeValue.Address;
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Employee emptoDelete = employee.GetEmployees().FirstOrDefault(x => x.Id == id);
            employee.GetEmployees().Remove(emptoDelete);
        }
    }
}
