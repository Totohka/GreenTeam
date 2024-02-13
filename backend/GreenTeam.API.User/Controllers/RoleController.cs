using GreenTeam.Model.Entities;
using GreenTeam.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Goods.System.Social.Network.Microservice.Posts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<Role> Get(int id)
        {
            var product = await _roleService.Get(id);
            return product;
        }

        [HttpGet("all")]
        public async Task<List<Role>> GetAll()
        {
            var products = await _roleService.GetAll();
            return products;
        }

        [HttpPost]
        public OkResult Create(Role product)
        {
            _roleService.Create(product);
            return Ok();
        }

        [HttpPut]
        public OkResult Update(Role product)
        {
            _roleService.Update(product);
            return Ok();
        }

        [HttpDelete]
        public OkResult Delete(int id)
        {
            _roleService.Delete(id);
            return Ok();
        }
    }
}