using GreenTeam.Model.Entities;

namespace GreenTeam.Service.Interface
{
    public interface ICategoryService
    {
        public Task<Category> Get(int id);
        public Task<List<Category>> GetAll();
        public void Create(Category product);
        public void Delete(int id);
        public void Update(Category product);
    }
}
