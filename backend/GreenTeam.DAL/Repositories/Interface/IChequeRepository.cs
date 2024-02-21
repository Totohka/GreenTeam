using GreenTeam.Model.Entities;

namespace GreenTeam.DAL.Repositories.Interface
{
    public interface IChequeRepository
    {
        Task<List<Cheque>> GetByUserId(int userId);
        Task<Cheque> Get(int chequeId);
        void Create(Cheque item);
        void Update(Cheque item);
        void Delete(int id);
    }
}
