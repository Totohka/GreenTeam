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
        Cheque GetByUserId(int userId);
        Task<List<Cheque>> GetAll();
        void Create(Cheque item);
        void Update(Cheque item);
        Task Delete(int id);
    }
}
