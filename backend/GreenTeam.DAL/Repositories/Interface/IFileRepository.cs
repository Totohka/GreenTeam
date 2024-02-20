using GreenTeam.Model.Entities;
using GreenTeam.Model.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.DAL.Repositories.Interface
{
    public interface IFileRepository
    {
        Task<Cheque> Get(int id);
        Task<List<Cheque>> GetAll();
        void Create(IFormFile file, string path, int chequeId);
        void Update(ChequeCreateViewModel item);
        Task Delete(int id);
    }
}
