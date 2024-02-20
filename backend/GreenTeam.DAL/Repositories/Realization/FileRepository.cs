using GreenTeam.DAL;
using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.Entities;
using GreenTeam.Model.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Goods.System.Social.Network.DAL.Repository.Realization
{

    public class FileRepository : IFileRepository
    {
        private readonly IDbContextFactory<ShopContext> _contextFactory;
        public FileRepository(IDbContextFactory<ShopContext> dbContextFactory)
        {
            _contextFactory = dbContextFactory;
        }

        public async void Create(IFormFile file, int userId, int chequeId)
        {
            using var db = _contextFactory.CreateDbContext();
            var uploadPath = $"{Directory.GetCurrentDirectory()}/Cheques/{userId}";
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            string fullPath = $"{uploadPath}/{chequeId}.pdf";
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }

        public void Delete(int userId, int chequeId)
        {
            throw new NotImplementedException();
        }

        public Task<string> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void Update(IFormFile file, int userId, int chequeId)
        {
            throw new NotImplementedException();
        }
    }
}