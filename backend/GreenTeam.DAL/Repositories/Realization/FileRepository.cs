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

        public async void Create(IFormFile file, string path, int chequeId)
        {
            using var db = _contextFactory.CreateDbContext();
            var uploadPath = $"{Directory.GetCurrentDirectory()}/Cheques/{path}";
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

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cheque> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cheque>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ChequeCreateViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}