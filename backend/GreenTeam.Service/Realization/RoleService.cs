using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.Entities;
using GreenTeam.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Service.Realization
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;
        public RoleService(IRepository<Role> roleRepository) {
            _roleRepository = roleRepository;
        }
        public void Create(Role role)
        {
            _roleRepository.Create(role);
        }

        public void Delete(int id)
        {
            _roleRepository.Delete(id);
        }

        public async Task<Role> Get(int id)
        {
            return await _roleRepository.Get(id);
        }


        public async Task<List<Role>> GetAll()
        {
            return await _roleRepository.GetAll();
        }

        public void Update(Role role)
        {
            _roleRepository.Update(role);
        }
    }
}
