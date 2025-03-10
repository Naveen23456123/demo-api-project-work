using DemoAPI.DBModel;
using DemoAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;  
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            DemoNewDbContext context = new DemoNewDbContext();
             TblEmployee employee = context.TblEmployees.FirstOrDefault(x => x.EmpName.ToLower() == login.userName.ToLower());
            if (employee != null)
            {
                // generate the token
                List<Claim> claims = new List<Claim>() {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //ytrytr-yugf56-yfrd45-tddtdr4,
                        new Claim("UserName",login.userName),
                        new Claim("Email",employee.Email),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));

                var signIn =  new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var  token =  new JwtSecurityToken(
                       _configuration["Jwt:Issuer"],
                       _configuration["Jwt:Audience"],
                       claims,
                       expires: DateTime.UtcNow.AddMinutes(60),
                       signingCredentials: signIn
                    );
                string jwttoken = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(jwttoken);
            }
            else
            {
                return BadRequest("Credential are invalid");
            }
           
        }
    }
}
