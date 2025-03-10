using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        // GET: api/<PatientController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PatientController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
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