using GreenTeam.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Service.Interface
{
    public interface IRoleService
    {
        public Task<Role> Get(int id);
        public Task<List<Role>> GetAll();
        public void Create(Role product);
        public void Delete(int id);
        public void Update(Role product);
    }
}
