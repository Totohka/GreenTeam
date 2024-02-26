using GreenTeam.Model.Entities;

namespace GreenTeam.DAL.Repositories.Interface
{
    public interface IChequeProductRepository
    {
        Task<List<ChequeProduct>> GetByChequeId(int chequeId);
        Task<ChequeProduct> Get(int id);
        void Create(ChequeProduct item);
        void Update(ChequeProduct item);
        void Delete(int id);
    }
}
