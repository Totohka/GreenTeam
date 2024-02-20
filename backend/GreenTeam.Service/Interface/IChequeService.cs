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
        public Task<List<Cheque>> GetAll();
        public void Create(ChequeCreateViewModel chequeCreateViewModel);
        public void Delete(int id);
        public void Update(ChequeCreateViewModel chequeCreateViewModel);
    }
}
