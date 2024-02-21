using GreenTeam.Model.Entities;
using GreenTeam.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Goods.System.Social.Network.Microservice.Posts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<Category> Get(int id)
        {
            var category = await _categoryService.Get(id);
            return category;
        }

        [HttpGet("all")]
        public async Task<List<Category>> GetAll()
        {
            var categories = await _categoryService.GetAll();
            return categories;
        }

        [HttpPost]
        public OkResult Create(Category category)
        {
            _categoryService.Create(category);
            return Ok();
        }

        [HttpPut]
        public OkResult Update(Category category)
        {
            _categoryService.Update(category);
            return Ok();
        }

        [HttpDelete]
        public OkResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
    }
}