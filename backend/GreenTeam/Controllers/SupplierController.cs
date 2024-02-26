using GreenTeam.Model.Entities;
using GreenTeam.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Goods.System.Social.Network.Microservice.Posts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<Supplier> Get(int id)
        {
            var supplier = await _supplierService.Get(id);
            return supplier;
        }

        [HttpGet("all")]
        public async Task<List<Supplier>> GetAll()
        {
            var suppliers = await _supplierService.GetAll();
            return suppliers;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public OkResult Create(Supplier supplier)
        {
            _supplierService.Create(supplier);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public OkResult Update(Supplier supplier)
        {
            _supplierService.Update(supplier);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public OkResult Delete(int id)
        {
            _supplierService.Delete(id);
            return Ok();
        }
    }
}