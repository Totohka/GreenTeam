using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.Entities;
using GreenTeam.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Service.Realization
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepository<Supplier> _supplierRepository;
        public SupplierService(IRepository<Supplier> supplierRepository) {
            _supplierRepository = supplierRepository;
        }
        public void Create(Supplier supplier)
        {
            _supplierRepository.Create(supplier);
        }

        public void Delete(int id)
        {
            _supplierRepository.Delete(id);
        }

        public async Task<Supplier> Get(int id)
        {
            return await _supplierRepository.Get(id);
        }


        public async Task<List<Supplier>> GetAll()
        {
            return await _supplierRepository.GetAll();
        }

        public void Update(Supplier supplier)
        {
            _supplierRepository.Update(supplier);
        }
    }
}
