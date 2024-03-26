using GreenTeam.Model.Entities;
using Microsoft.AspNetCore.Http;

namespace GreenTeam.DAL.Repositories.Interface
{
    public interface IImageRepository
    {
        List<string> Get(int productId);
        List<string> GetAll();
        Task Create(IFormFile file, int productId);
        Task Update(IFormFile file, int productId, int photoId);
        Task Delete(int productId, int photoId);
    }
}
