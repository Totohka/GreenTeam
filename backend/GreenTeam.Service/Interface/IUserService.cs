using GreenTeam.Model.Entities;

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
