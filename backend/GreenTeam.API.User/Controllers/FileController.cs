using GreenTeam.Model.Entities;
using GreenTeam.Model.ViewModel;
using GreenTeam.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Goods.System.Social.Network.Microservice.Posts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<string> Get(int id)
        {
            var path = await _fileService.Get(id);
            return path;
        }

        [HttpGet("all")]
        public async Task<List<string>> GetByUserId(int userId)
        {
            var paths = await _fileService.GetByUserId(userId);
            return paths;
        }

        [HttpPost]
        public OkResult Create([FromForm] FileCreateViewModel fileCreateViewModel)
        {
            _fileService.Create(fileCreateViewModel);
            return Ok();
        }

        [HttpPut]
        public OkResult Update([FromForm] FileCreateViewModel fileCreateViewModel)
        {
            _fileService.Update(fileCreateViewModel);
            return Ok();
        }

        [HttpDelete]
        public OkResult Delete(int chequeId, int userId)
        {
            _fileService.Delete(chequeId, userId);
            return Ok();
        }
    }
}