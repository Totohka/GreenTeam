using GreenTeam.Model.Entities;
using GreenTeam.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
