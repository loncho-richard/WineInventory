using Common.Models;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Services;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WineInventory.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserServices _userServices;


        public AuthenticationController(IConfiguration configuration, IUserServices userServices)
        {
            _configuration = configuration;
            _userServices = userServices;
        }

        [HttpPost]
        public IActionResult AuthUser([FromBody] CredentialsDTO credentialsDTO)
        {
            User? user = _userServices.AuthUser(credentialsDTO);
            if (user == null)
            {
                return Unauthorized("Username or password are incorrect");
            }
            
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            List<Claim> claimsForToken = new List<Claim>()
            {
                new Claim("sub", user.Id.ToString()),
                new Claim("given_name", user.Username)
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Authentication:MinutesToExpire"]!)),
                credentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }
    }
}
