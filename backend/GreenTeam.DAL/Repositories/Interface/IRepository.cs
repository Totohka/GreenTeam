
namespace GreenTeam.DAL.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        void Create(T item);
        void Update(T item);
        Task Delete(int id);
    }
}
