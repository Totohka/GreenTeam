using GreenTeam.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Service.Interface
{
    public interface IUserService
    {
        public User Get(int id);
        public Task<List<User>> GetAll();
        public void Create(User user, int roleId);
        public void Delete(int id);
        public void Update(User user, int roleId);
    }
}
