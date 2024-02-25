using GreenTeam.Model.Entities;
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
        public AuthController(IOptions<JWTSettings> optAccess)
        {
            _options = optAccess.Value;
        }

        [HttpGet]
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
    }
}