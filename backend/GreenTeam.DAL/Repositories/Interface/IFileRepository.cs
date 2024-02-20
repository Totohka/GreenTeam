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
        Task<string> Get(int chequeId);
        Task<List<string>> GetByUserId(int userId);
        void Create(IFormFile file, int userId, int chequeId);
        void Update(IFormFile file, int userId, int chequeId);
        void Delete(int userId, int chequeId);
    }
}
