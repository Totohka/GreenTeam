using GreenTeam.Model.Entities;
using GreenTeam.Service.Interface;
using Microsoft.AspNetCore.Mvc;

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
            var cheque = await _chequeService.Get(id);
            return cheque;
        }

        [HttpGet("all")]
        public async Task<List<Cheque>> GetByUserId(int userId)
        {
            var cheques = await _chequeService.GetByUserId(userId);
            return cheques;
        }

        [HttpPost]
        public OkResult Create(Cheque cheque)
        {
            _chequeService.Create(cheque);
            return Ok();
        }

        [HttpPut]
        public OkResult Update(Cheque cheque)
        {
            _chequeService.Update(cheque);
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