using GreenTeam.DAL;
using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Goods.System.Social.Network.DAL.Repository.Realization
{

    public class ChequeRepository : IChequeRepository
    {
        private readonly IDbContextFactory<ShopContext> _contextFactory;
        public ChequeRepository(IDbContextFactory<ShopContext> dbContextFactory)
        {
            _contextFactory = dbContextFactory;
        }

        public void Create(Cheque item)
        {
            using var db = _contextFactory.CreateDbContext();
            db.Cheques.Add(item);
            db.SaveChanges();
        }

        public async void Delete(int id)
        {
            using var db = _contextFactory.CreateDbContext();
            var cheque = await Get(id);
            db.Cheques.Remove(cheque);
            db.SaveChanges();
        }

        public async Task<List<Cheque>> GetByUserId(int userId)
        {
            using var db = _contextFactory.CreateDbContext();
            if (userId != 0)
            {
                var cheque = await db.Cheques.Where(c => c.UserId == userId).ToListAsync();
                return cheque;
            }
            else return await db.Cheques.ToListAsync();

        }

        public async Task<Cheque> Get(int chequeId)
        {
            using var db = _contextFactory.CreateDbContext();
            var cheque = await db.Cheques.FindAsync(chequeId);
            return cheque;
        }

        public void Update(Cheque item)
        {
            using var db = _contextFactory.CreateDbContext();
            db.Cheques.Update(item);
            db.SaveChanges();
        }
    }
}