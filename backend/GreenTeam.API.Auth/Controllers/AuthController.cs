using GreenTeam.Model.Entities;
using GreenTeam.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GreenTeam.API.Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly JWTSettings _options;
        private readonly IJWTService _jwtService;
        public AuthController(IOptions<JWTSettings> optAccess, IJWTService jwtService)
        {
            _options = optAccess.Value;
            _jwtService = jwtService;
        }

        [HttpGet("GetToken")]
        public string GetToken()
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Nataly"),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromHours(1)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
             );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        [HttpGet]
        public async Task<string> Auth(string email, string password)
        {
            return await _jwtService.Auth(email, password);
        }

        [HttpPost]
        public async Task<string> Registration(User user)
        {
            return await _jwtService.Registration(user);
        }
    }
}