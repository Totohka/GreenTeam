using GreenTeam.DAL;
using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Goods.System.Social.Network.DAL.Repository.Realization
{

    public class ImageRepository : IImageRepository
    {
        private readonly IDbContextFactory<ShopContext> _contextFactory;
        public ImageRepository(IDbContextFactory<ShopContext> dbContextFactory)
        {
            _contextFactory = dbContextFactory;
        }

        public async Task Create(IFormFile image, int productId)
        {
            using var db = _contextFactory.CreateDbContext();
            Photo photo = new Photo { Id = 0, Path = "", ProductId = productId };
            db.Photos.Add(photo);
            db.SaveChanges();

            string fileExtension = image.FileName.Substring(image.FileName.LastIndexOf('.') + 1);
            var photoEmpty = db.Photos.Where(p => p.Path == "" && p.ProductId == productId).ToList().First();
            photoEmpty.Path = $"{productId}/{photoEmpty.Id}.{fileExtension}";
            db.Photos.Update(photoEmpty);
            db.SaveChanges();

            string fullPath = $"{Directory.GetCurrentDirectory()}/Products/{productId}/{photoEmpty.Id}.{fileExtension}";

            if (!Directory.Exists($"{Directory.GetCurrentDirectory()}/Products/{productId}"))
            {
                Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/Products/{productId}");
            }

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
        }

        public async Task Delete(int productId, int photoId)
        {
            using var db = _contextFactory.CreateDbContext();
            var photo = await db.Photos.FindAsync(photoId);
            db.Photos.Remove(photo);
            db.SaveChanges();
            string fullPath = $"{Directory.GetCurrentDirectory()}/Products/{photo.Path}";
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public List<string> Get(int productId)
        {
            var files = Directory.GetFiles($"{Directory.GetCurrentDirectory()}/Products/{productId}");

            List<string> filesList = files.ToList();
            for (int i = 0; i < filesList.Count; i++)
            {
                filesList[i] = filesList[i].Substring(filesList[i].LastIndexOf("/") + 1).Replace("\\", "/");
            }

            return filesList;
        }

        public List<string> GetAll()
        {
            string path = $"{Directory.GetCurrentDirectory()}/Products";
            List<string> filesPath = new List<string>();
            var pathsDirectories = Directory.GetDirectories(path).ToList();

            foreach (var item in pathsDirectories)
            {
                var filesInOneDir = Directory.GetFiles(item);
                filesPath.Add(filesInOneDir[0].Substring(filesInOneDir[0].LastIndexOf("/") + 10).Replace("\\", "/"));
            }

            return filesPath;
        }   

        public async Task Update(IFormFile image, int productId, int photoId)
        {
            var filePaths = Directory.GetFiles($"{Directory.GetCurrentDirectory()}/Products/{productId}");
            var filePath = filePaths.Where(p => p.Contains($"/{productId}\\{photoId}.")).First();
            string fileExtensionDelete = filePath.Substring(filePath.LastIndexOf('.') + 1);
            string fullPathDelete = $"{Directory.GetCurrentDirectory()}/Products/{productId}/{photoId}.{fileExtensionDelete}";
            if (File.Exists(fullPathDelete))
            {
                File.Delete(fullPathDelete);
            }

            string fileExtension = image.FileName.Substring(image.FileName.LastIndexOf('.') + 1);
            string fullPath = $"{Directory.GetCurrentDirectory()}/Products/{productId}/{photoId}.{fileExtension}";
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            using var db = _contextFactory.CreateDbContext();
            var photo = await db.Photos.FindAsync(photoId);
            photo.Path = $"{productId}/{photoId}.{fileExtension}";
            db.Update(photo);
            db.SaveChanges();
        }
    }
}