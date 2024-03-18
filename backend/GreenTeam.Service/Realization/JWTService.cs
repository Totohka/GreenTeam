using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.Entities;
using GreenTeam.Service.Interface;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Service.Realization
{
    public class JWTService : IJWTService
    {
        private readonly int RoleUserId = 2;
        private readonly JWTSettings _options;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Role> _roleRepository;  
        public JWTService(IOptions<JWTSettings> optAccess, 
                            IUserRepository userRepository,
                            IRepository<Role> roleRepository)
        {
            _options = optAccess.Value;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public string GetJWT(User user)
        {
            var roles = user.Roles;
            string role = "User";
            foreach (var item in roles)
            {
                if (item.Name == "Admin")
                {
                    role = item.Name; break;
                }
                else if (item.Name == "1C")
                {
                    role = item.Name; break;
                }
                else
                {
                    role = item.Name; break;
                }
            }
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName + ' ' + user.LastName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role)
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

        public async Task<string> Auth(string email, string password)
        {
            var users = await _userRepository.GetAll();
            var user = users.Where(u => u.Email == email).ToList().FirstOrDefault();

            var sha1 = SHA1.Create();
            var shaPass = sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
            if (user is not null && user.Password == Encoding.Unicode.GetString(shaPass))
            {
                return GetJWT(user);
            }
            return "401";
        }

        public async Task<string> Registration(User user)
        {
            Role role = await _roleRepository.Get(RoleUserId); //get role == "User"
            var usersWithoutUser = await _userRepository.GetAll();
            bool metkaEmail = false;
            foreach (var item in usersWithoutUser)
            {
                if (item.Email == user.Email)
                {
                    metkaEmail = true; break;
                }
            }
            if (!metkaEmail)
            {
                _userRepository.Create(user, role);
                var users = await _userRepository.GetAll();
                user = users.Where(u => u.Email == user.Email).ToList().FirstOrDefault();
                return GetJWT(user);
            }
            return "Email занят!";
        }
    }
}
