using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RapidPlay.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RapidPlay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult GenToken([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = Generate(userLogin);

                var model = new TokenModel
                {
                    Type = "Bearer",
                    Token = token.ToString()
                };


                return Ok(model);
            }
            return NotFound("User invalid");

        }

        private object Generate(UserLogin user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Code)
            };

            var token = new JwtSecurityToken(
                                            _configuration["JWT:Issuer"],
                                            _configuration["JWT:Audience"],
                                            claims,
                                            expires: DateTime.Now.AddHours(1),
                                            signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private object Authenticate(UserLogin userLogin)
        {
            var currentUser = UserConstants.Users.FirstOrDefault(o =>
                                                                o.Code.ToLower() == userLogin.Code &&
                                                                o.Password == userLogin.Password
                                                                );
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
    }
}
