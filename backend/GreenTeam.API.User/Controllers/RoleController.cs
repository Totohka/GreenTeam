using GreenTeam.Model.Entities;
using GreenTeam.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<Role> Get(int id)
        {
            var role = await _roleService.Get(id);
            return role;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public async Task<List<Role>> GetAll()
        {
            var roles = await _roleService.GetAll();
            return roles;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public OkResult Create(Role role)
        {
            _roleService.Create(role);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public OkResult Update(Role role)
        {
            _roleService.Update(role);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public OkResult Delete(int id)
        {
            _roleService.Delete(id);
            return Ok();
        }
    }
}