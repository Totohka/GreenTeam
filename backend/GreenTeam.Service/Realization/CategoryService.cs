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
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository) {
            _categoryRepository = categoryRepository;
        }
        public void Create(Category category)
        {
            _categoryRepository.Create(category);
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }

        public async Task<Category> Get(int id)
        {
            return await _categoryRepository.Get(id);
        }


        public async Task<List<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
