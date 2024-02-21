using GreenTeam.Model.ViewModel;
using GreenTeam.Service.Interface;
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
        public string Get(int productId)
        {
            var path = _imageService.Get(productId);
            return path;
        }

        [HttpGet("all")]
        public List<string> GetAll()
        {
            var paths = _imageService.GetAll();
            return paths;
        }

        [HttpPost]
        public OkResult Create([FromForm] ImageCreateViewModel imageCreateViewModel)
        {
            _imageService.Create(imageCreateViewModel);
            return Ok();
        }

        [HttpPut]
        public OkResult Update([FromForm] ImageCreateViewModel imageCreateViewModel)
        {
            _imageService.Update(imageCreateViewModel);
            return Ok();
        }

        [HttpDelete]
        public OkResult Delete(int productId)
        {
            _imageService.Delete(productId);
            return Ok();
        }
    }
}