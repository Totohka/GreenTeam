using GreenTeam.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.DAL.Repositories.Interface
{
    public interface IUserRepository
    {
        User Get(int id);
        Task<List<User>> GetAll();
        void Create(User user, Role role);
        void Update(User user, Role role);
        void Delete(int id);
    }
}
