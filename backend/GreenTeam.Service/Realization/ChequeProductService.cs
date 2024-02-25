using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.Entities;
using GreenTeam.Service.Interface;

namespace GreenTeam.Service.Realization
{
    public class ChequeProductService : IChequeProductService
    {
        private readonly IChequeProductRepository _chequeProductRepository;

        public ChequeProductService(IChequeProductRepository chequeProductRepository) {
            _chequeProductRepository = chequeProductRepository;
        }

        public void Create(ChequeProduct chequeProduct)
        {
            _chequeProductRepository.Create(chequeProduct);
        }

        public void Delete(int id)
        {
            _chequeProductRepository.Delete(id);
        }

        public async Task<ChequeProduct> Get(int id)
        {
            return await _chequeProductRepository.Get(id);
        }

        public async Task<List<ChequeProduct>> GetByChequeId(int chequeId)
        {
            return await _chequeProductRepository.GetByChequeId(chequeId);
        }

        public void Update(ChequeProduct chequeProduct)
        {
            _chequeProductRepository.Update(chequeProduct);
        }
    }
}
