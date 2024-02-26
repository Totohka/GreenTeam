using GreenTeam.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Service.Interface
{
    public interface IJWTService
    {
        public string GetJWT(User user);
        public Task<string> Registration(User user);
        public Task<string> Auth(string email, string password);
    }
}
