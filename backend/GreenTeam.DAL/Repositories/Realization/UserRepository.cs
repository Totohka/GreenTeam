using GreenTeam.DAL;
using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goods.System.Social.Network.DAL.Repository.Realization
{

    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<ShopContext> _contextFactory;
        public UserRepository(IDbContextFactory<ShopContext> dbContextFactory)
        {
            _contextFactory = dbContextFactory;
        }
        public void Delete(int id)
        {
            using var db = _contextFactory.CreateDbContext();
            var user = Get(id);
            db.Remove(user);
            db.SaveChanges();
        }
        public User Get(int id)
        {
            using var db = _contextFactory.CreateDbContext();
            return db.Users.Include(p => p.Roles).ThenInclude(r => r.Users).ToList().Where(p => p.Id == id).First();
        }
        public async Task<List<User>> GetAll()
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.Set<User>().Include(p => p.Roles).ToListAsync();
        }
        public void Create(User user, Role role)
        {
            using var db = _contextFactory.CreateDbContext();
            role = db.Roles.ToList().Where(s => s.Id == role.Id).First();
            var sha1 = SHA1.Create();// SHA1CryptoServiceProvider();
            var shaPass = sha1.ComputeHash(Encoding.Unicode.GetBytes(user.Password));
            user.Password = Encoding.Unicode.GetString(shaPass);
            db.Users.Add(user);
            db.SaveChanges();
            user = db.Users.Include(p => p.Roles).ToList().Where(p => p.Email == user.Email).First();
            user.Roles.Add(role);
            db.SaveChanges();
        }

        public void Update(User user, Role role)
        {
            using var db = _contextFactory.CreateDbContext();
            user = db.Users.Include(p => p.Roles).ToList().Where(p => p.Email == user.Email).First();
            user.Roles.Clear();
            user.Roles.Add(role);
            db.Update(user);
            db.SaveChanges();
        }
    }
}