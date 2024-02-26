using GreenTeam.Model.Entities;

namespace GreenTeam.Service.Interface
{
    public interface IChequeService
    {
        public Task<Cheque> Get(int id);
        public Task<List<Cheque>> GetByUserId(int userId);
        public void Create(Cheque cheque);
        public void Delete(int id);
        public void Update(Cheque cheque);
    }
}
