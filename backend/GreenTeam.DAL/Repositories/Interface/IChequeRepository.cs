using GreenTeam.Model.Entities;
using GreenTeam.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
