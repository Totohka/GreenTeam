using GreenTeam.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Service.Interface
{
    public interface ISupplierService
    {
        public Task<Supplier> Get(int id);
        public Task<List<Supplier>> GetAll();
        public void Create(Supplier product);
        public void Delete(int id);
        public void Update(Supplier product);
    }
}
