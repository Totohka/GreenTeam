using GreenTeam.Model.Entities;
using GreenTeam.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Goods.System.Social.Network.Microservice.Posts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChequeProductController : Controller
    {
        private readonly IChequeProductService _chequeProductService;
        public ChequeProductController(IChequeProductService chequeProductService)
        {
            _chequeProductService = chequeProductService;
        }

        [HttpGet]
        public async Task<ChequeProduct> Get(int id)
        {
            var cheque = await _chequeProductService.Get(id);
            return cheque;
        }

        [HttpGet("all")]
        public async Task<List<ChequeProduct>> GetByChequeId(int chequeId)
        {
            var cheques = await _chequeProductService.GetByChequeId(chequeId);
            return cheques;
        }

        [HttpPost]
        public OkResult Create(ChequeProduct chequeProduct)
        {
            _chequeProductService.Create(chequeProduct);
            return Ok();
        }

        [HttpPut]
        public OkResult Update(ChequeProduct chequeProduct)
        {
            _chequeProductService.Update(chequeProduct);
            return Ok();
        }

        [HttpDelete]
        public OkResult Delete(int id)
        {
            _chequeProductService.Delete(id);
            return Ok();
        }
    }
}