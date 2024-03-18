using GreenTeam.Model.Entities;
using Microsoft.AspNetCore.Http;

namespace GreenTeam.DAL.Repositories.Interface
{
    public interface IFileRepository
    {
        Task<string> Get(int chequeId);
        List<string> GetByUserId(int userId);
        Task Create(IFormFile file, int userId, int chequeId);
        void Update(IFormFile file, int userId, int chequeId);
        void Delete(int userId, int chequeId);
    }
}
