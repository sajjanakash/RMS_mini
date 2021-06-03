using Authenticate_API.Model;
using Authenticate_API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authenticate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _config;
        public readonly ApplicationDBContext _context;
        public TokenController(IConfiguration config)
        {
            _config = config;
            _context = new ApplicationDBContext();
        }

        [HttpGet]
        public UserInfo GetUser(string empId, string pass , string designation)
        {
            if(designation=="Employee")
            {
                return _context.Employees.Where(u => u.EmpId == empId && u.Password == pass &&(u.Designation!="Admin" && u.Designation!="Project Manager" && u.Designation!="Resource Manager")).FirstOrDefault();
            }
            else
            {
                return _context.Employees.Where(u => u.EmpId == empId && u.Password == pass && u.Designation == designation).FirstOrDefault();
            }
        }


        [HttpPost]
        public IActionResult Post(UserInfoVM userInfo)
        {
            if (userInfo.EmpId != null && userInfo.Password != null && userInfo.Designation!=null)
            {
              /*  if(userInfo.Designation=="Employee")
                {
                    string HrMgr = "HR Manager";
                    var user = GetUser(userInfo.EmpId, userInfo.Password);
                }
                else
                {
                    var user = GetUser(userInfo.EmpId, userInfo.Password, userInfo.Designation);
                }*/
               var user = GetUser(userInfo.EmpId, userInfo.Password,userInfo.Designation);

                if (user != null && user.Designation == "Admin")
                {
                    var claims = new[]
                    {
                        /*new Claim(JwtRegisteredClaimNames.Sub,_config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("CustomerId",user.CustomerId.ToString()),
                        new Claim("EmailId",user.EmailId),
                        new Claim("Password",user.Password)*/
                         new Claim(ClaimTypes.Role,user.Designation)
                    };

                    var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: signIn
                        );

                    //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    var output = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        role = "Admin",
                        id=user.EmpId
                    };
                    return Ok(output);

                }
                else if (user != null && user.Designation == "Resource Manager")
                {
                    var claims = new[]
                    {
                       /* new Claim(JwtRegisteredClaimNames.Sub,_config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("CustomerId",user.CustomerId.ToString()),
                        new Claim("EmailId",user.EmailId),
                        new Claim("Password",user.Password)*/
                        new Claim(ClaimTypes.Role,user.Designation)
                    };

                    var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: signIn
                        );

                    var output = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        role = "Resource Manager",
                        id = user.EmpId

                    };
                   
                    return Ok(output);
                }
                else if (user != null && user.Designation == "Project Manager")
                {
                    var claims = new[]
                    {
                       /* new Claim(JwtRegisteredClaimNames.Sub,_config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("CustomerId",user.CustomerId.ToString()),
                        new Claim("EmailId",user.EmailId),
                        new Claim("Password",user.Password)*/
                        new Claim(ClaimTypes.Role,user.Designation)
                    };

                    var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: signIn
                        );

                    var output = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        role = "Project Manager",
                        id = user.EmpId
                    };

                    return Ok(output);
                }
                
                else if (user != null)
                {
                    var claims = new[]
                    {
                       /* new Claim(JwtRegisteredClaimNames.Sub,_config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("CustomerId",user.CustomerId.ToString()),
                        new Claim("EmailId",user.EmailId),
                        new Claim("Password",user.Password)*/
                        new Claim(ClaimTypes.Role,user.Designation)
                    };

                    var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: signIn
                        );

                    var output = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        role = "Employee",
                        id = user.EmpId
                    };

                    return Ok(output);
                }

                else
                {
                    return BadRequest("Invalid Credentials");
                }

            }
            else
            {
                return BadRequest();
            }


        }
    }
}
