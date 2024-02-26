using GreenTeam.Model.Entities;

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
