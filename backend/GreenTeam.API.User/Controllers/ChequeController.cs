using GreenTeam.Model.Entities;
using GreenTeam.Model.ViewModel;
using GreenTeam.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Goods.System.Social.Network.Microservice.Posts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChequeController : Controller
    {
        private readonly IChequeService _chequeService;
        public ChequeController(IChequeService chequeService)
        {
            _chequeService = chequeService;
        }

        [HttpGet]
        public async Task<Cheque> Get(int id)
        {
            var role = await _chequeService.Get(id);
            return role;
        }

        [HttpGet("all")]
        public async Task<List<Cheque>> GetAll()
        {
            var roles = await _chequeService.GetAll();
            return roles;
        }

        [HttpPost]
        public OkResult Create([FromForm] ChequeCreateViewModel chequeCreateViewModel)
        {
            _chequeService.Create(chequeCreateViewModel);
            return Ok();
        }

        [HttpPut]
        public OkResult Update([FromForm] ChequeCreateViewModel chequeCreateViewModel)
        {
            _chequeService.Update(chequeCreateViewModel);
            return Ok();
        }

        [HttpDelete]
        public OkResult Delete(int id)
        {
            _chequeService.Delete(id);
            return Ok();
        }
    }
}