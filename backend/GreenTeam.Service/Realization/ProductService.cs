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
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> productRepository) { 
            _productRepository = productRepository;
        }
        public void Create(Product product)
        {
            _productRepository.Create(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public async Task<Product> Get(int id)
        {
            return await _productRepository.Get(id);
        }


        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}
