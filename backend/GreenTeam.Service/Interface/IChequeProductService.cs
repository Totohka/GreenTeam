using GreenTeam.Model.Entities;

namespace GreenTeam.Service.Interface
{
    public interface IChequeProductService
    {
        public Task<ChequeProduct> Get(int id);
        public Task<List<ChequeProduct>> GetByChequeId(int chequeId);
        public void Create(ChequeProduct chequeProduct);
        public void Delete(int id);
        public void Update(ChequeProduct chequeProduct);
    }
}
