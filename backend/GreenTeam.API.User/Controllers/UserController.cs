using GreenTeam.Model.Entities;
using GreenTeam.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Goods.System.Social.Network.Microservice.Posts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public User Get(int id)
        {
            var user = _userService.Get(id);
            return user;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public async Task<List<User>> GetAll()
        {
            var users = await _userService.GetAll();
            return users;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public OkResult Create(User user, int roleId)
        {
            _userService.Create(user, roleId);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public OkResult Update(User user, int roleId)
        {
            _userService.Update(user, roleId);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public OkResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}