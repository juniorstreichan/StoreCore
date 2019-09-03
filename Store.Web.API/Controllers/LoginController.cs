using System;
using System.Text;
using System.Security.Claims;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Store.Web.API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController:Controller
    {
        private readonly IConfiguration configuration;
        private static readonly string EMAIL = "junior@teste.com";
        private static readonly string PASSWORD = "123456";
        public LoginController(IConfiguration config)
        {
            configuration = config;
        }

        [HttpPost]
        public ActionResult Login([FromBody] User request){
           
           if (request.Email == EMAIL && request.Password == PASSWORD)
           {
               var claims = new[]
               {
                    new Claim(ClaimTypes.Name,request.Email),
                    new Claim(ClaimTypes.Role,"User")
               };

               var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecurityKey"]));
               
               var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

               var token = new JwtSecurityToken(
                   claims:claims,
                   issuer:"StoreCore",
                   expires:DateTime.Now.AddMinutes(30),
                   signingCredentials:creds
               );
               return Ok(new {token = new JwtSecurityTokenHandler().WriteToken(token)});
           }
          return BadRequest(new { message = "Credenciais inválidas"} );
          //https://youtu.be/udp-zH4NEzE
        }
        
        
    }
    public class User {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}