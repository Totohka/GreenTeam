using GreenTeam.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Service.Interface
{
    public interface ICategoryService
    {
        public Task<Category> Get(int id);
        public Task<List<Category>> GetAll();
        public void Create(Category product);
        public void Delete(int id);
        public void Update(Category product);
    }
}
