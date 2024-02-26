using GreenTeam.Model.Entities;

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
