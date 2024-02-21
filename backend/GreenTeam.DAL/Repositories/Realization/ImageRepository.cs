using GreenTeam.DAL;
using GreenTeam.DAL.Repositories.Interface;
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

        public async void Create(IFormFile image, int productId)
        {
            string fullPath = $"{Directory.GetCurrentDirectory()}/Products/{productId}.jpeg";
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
        }

        public void Delete(int productId)
        {
            string fullPath = $"{Directory.GetCurrentDirectory()}/Products/{productId}.jpeg";
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public string Get(int productId)
        {
            return $"{productId}.jpeg";
        }

        public List<string> GetAll()
        {
            string path = $"{Directory.GetCurrentDirectory()}/Products";
            var paths = Directory.GetFiles(path, "*", SearchOption.AllDirectories).ToList();
            for (int i = 0; i < paths.Count; i++)
            {
                paths[i] = paths[i][(paths[i].LastIndexOf('/') + 1)..];
                var oldString = "\\";
                paths[i] = paths[i].Replace(oldString, "/");
            }
            return paths;
        }   

        public void Update(IFormFile image, int productId)
        {
            Delete(productId);
            Create(image, productId);
        }
    }
}