using GreenTeam.Model.Entities;
using GreenTeam.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Goods.System.Social.Network.Microservice.Posts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<Product> Get(int id)
        {
            var product = await _productService.Get(id);
            return product;
        }

        [HttpGet("all")]
        public async Task<List<Product>> GetAll()
        {
            var products = await _productService.GetAll();
            return products;
        }

        [HttpPost]
        public OkResult Create(Product product)
        {
            _productService.Create(product);
            return Ok();
        }

        [HttpPut]
        public OkResult Update(Product product)
        {
            _productService.Update(product);
            return Ok();
        }

        [HttpDelete]
        public OkResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}