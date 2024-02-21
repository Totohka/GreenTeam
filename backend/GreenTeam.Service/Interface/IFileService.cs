using GreenTeam.Model.Entities;
using GreenTeam.Model.ViewModel;

namespace GreenTeam.Service.Interface
{
    public interface IFileService
    {
        public Task<string> Get(int id);
        public List<string> GetByUserId(int userId);
        public void Create(FileCreateViewModel fileCreateViewModel);
        public void Delete(int chequeId, int userId);
        public void Update(FileCreateViewModel fileCreateViewModel);
    }
}
