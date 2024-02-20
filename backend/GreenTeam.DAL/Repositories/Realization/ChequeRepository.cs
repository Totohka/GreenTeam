using GreenTeam.DAL;
using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.Entities;
using GreenTeam.Model.ViewModel;
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

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Cheque GetByUserId(int userId)
        {
            using var db = _contextFactory.CreateDbContext();
            var cheque = db.Cheques.Where(c => c.UserId == userId).ToList().Last();
            return cheque;
        }

        public Task<List<Cheque>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Cheque item)
        {
            using var db = _contextFactory.CreateDbContext();
            db.Cheques.Update(item);
            db.SaveChanges();
        }
    }
}