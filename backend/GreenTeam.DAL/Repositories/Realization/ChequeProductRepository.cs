using GreenTeam.DAL;
using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Goods.System.Social.Network.DAL.Repository.Realization
{

    public class ChequeProductRepository : IChequeProductRepository
    {
        private readonly IDbContextFactory<ShopContext> _contextFactory;
        public ChequeProductRepository(IDbContextFactory<ShopContext> dbContextFactory)
        {
            _contextFactory = dbContextFactory;
        }

        public void Create(ChequeProduct item)
        {
            using var db = _contextFactory.CreateDbContext();
            db.Add(item);
            db.SaveChanges();
        }

        public async void Delete(int id)
        {
            using var db = _contextFactory.CreateDbContext();
            ChequeProduct item = await Get(id);
            db.ChequeProducts.Remove(item);
            db.SaveChanges();
        }

        public async Task<ChequeProduct> Get(int id)
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.ChequeProducts.FindAsync(id);
        }

        public async Task<List<ChequeProduct>> GetByChequeId(int chequeId)
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.ChequeProducts.Where(cp => cp.ChequeId == chequeId).ToListAsync();
        }

        public void Update(ChequeProduct item)
        {
            using var db = _contextFactory.CreateDbContext();
            db.ChequeProducts.Update(item);
            db.SaveChanges();
        }
    }
}