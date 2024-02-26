using GreenTeam.DAL;
using GreenTeam.DAL.Repositories.Interface;
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

        public void Delete(int chequeId, int userId)
        {
            string fullPath = $"{Directory.GetCurrentDirectory()}/Cheques/{userId}/{chequeId}.pdf";
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public async Task<string> Get(int id)
        {
            using var db = _contextFactory.CreateDbContext();
            var cheque = await db.Cheques.FindAsync(id);
            return $"{cheque.UserId}/{id}.pdf";
        }

        public List<string> GetByUserId(int userId)
        {
            string path = $"{Directory.GetCurrentDirectory()}/Cheques/{userId}";
            var paths = Directory.GetFiles(path, "*", SearchOption.AllDirectories).ToList();
            for (int i = 0; i < paths.Count; i++)
            {
                paths[i] = paths[i][(paths[i].LastIndexOf('/') + 1)..];
                var oldString = "\\";
                paths[i] = paths[i].Replace(oldString, "/");
            }
            return paths;
        }   

        public void Update(IFormFile file, int userId, int chequeId)
        {
            Delete(chequeId, userId);
            Create(file, userId, chequeId);
        }
    }
}