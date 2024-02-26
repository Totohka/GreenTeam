using GreenTeam.Model.Entities;
using Microsoft.AspNetCore.Http;

namespace GreenTeam.DAL.Repositories.Interface
{
    public interface IImageRepository
    {
        string Get(int productId);
        List<string> GetAll();
        void Create(IFormFile file, int productId);
        void Update(IFormFile file, int productId);
        void Delete(int productId);
    }
}
