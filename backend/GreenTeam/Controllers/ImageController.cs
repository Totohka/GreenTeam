using GreenTeam.Model.ViewModel;
using GreenTeam.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Goods.System.Social.Network.Microservice.Posts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public List<string> Get(int productId)
        {
            var path = _imageService.Get(productId);
            return path;
        }

        [HttpGet("all")]
        public List<string> GetAllFirstPhoto()
        {
            var paths = _imageService.GetAll();
            return paths;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<OkResult> Create([FromForm] ImageCreateViewModel imageCreateViewModel)
        {
            await _imageService.Create(imageCreateViewModel);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<OkResult> Update([FromForm] ImageUpdateViewModel imageUpdateViewModel)
        {
            await _imageService.Update(imageUpdateViewModel);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<OkResult> Delete(int productId, int photoId)
        {
            await _imageService.Delete(productId, photoId);
            return Ok();
        }
    }
}