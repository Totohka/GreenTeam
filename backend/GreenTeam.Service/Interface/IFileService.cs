using GreenTeam.Model.Entities;
using GreenTeam.Model.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Service.Interface
{
    public interface IFileService
    {
        public Task<string> Get(int id);
        public Task<List<string>> GetByUserId(int userId);
        public void Create(FileCreateViewModel fileCreateViewModel);
        public void Delete(int chequeId, int userId);
        public void Update(FileCreateViewModel fileCreateViewModel);
    }
}
