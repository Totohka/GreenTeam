using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.Entities;
using GreenTeam.Model.ViewModel;
using GreenTeam.Service.Interface;

namespace GreenTeam.Service.Realization
{
    public class ChequeService : IChequeService
    {
        private readonly IChequeRepository _chequeRepository;

        public ChequeService(IChequeRepository chequeRepository) {
            _chequeRepository = chequeRepository;
        }

        public void Create(Cheque cheque)
        {
            _chequeRepository.Create(cheque);
        }

        public void Delete(int id)
        {
            _chequeRepository.Delete(id);
        }

        public async Task<Cheque> Get(int id)
        {
            return await _chequeRepository.Get(id);
        }

        public Task<List<Cheque>> GetByUserId(int userId)
        {
            return _chequeRepository.GetByUserId(userId);
        }

        public void Update(Cheque cheque)
        {
            _chequeRepository.Update(cheque);
        }
    }
}
