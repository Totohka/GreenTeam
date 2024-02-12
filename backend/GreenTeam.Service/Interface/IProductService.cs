using GreenTeam.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Service.Interface
{
    public interface IProductService
    {
        public Task<Product> Get(int id);
        public Task<List<Product>> GetAll();
        public void Create(Product product);
        public void Delete(int id);
        public void Update(Product product);
    }
}
