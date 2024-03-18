using GreenTeam.Model.ViewModel;
using GreenTeam.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [Authorize]
        [HttpGet]
        public async Task<string> Get(int id)
        {
            var path = await _fileService.Get(id);
            return path;
        }

        [Authorize]
        [HttpGet("all")]
        public List<string> GetByUserId(int userId)
        {
            var paths = _fileService.GetByUserId(userId);
            return paths;
        }

        [Authorize(Roles = "1C,Admin")]
        [HttpPost]
        public async Task<OkResult> Create([FromForm] FileCreateViewModel fileCreateViewModel)
        {
            await _fileService.Create(fileCreateViewModel);
            return Ok();
        }

        [Authorize(Roles = "1C,Admin")]
        [HttpPut]
        public OkResult Update([FromForm] FileCreateViewModel fileCreateViewModel)
        {
            _fileService.Update(fileCreateViewModel);
            return Ok();
        }

        [Authorize(Roles = "1C,Admin")]
        [HttpDelete]
        public OkResult Delete(int chequeId, int userId)
        {
            _fileService.Delete(chequeId, userId);
            return Ok();
        }
    }
}