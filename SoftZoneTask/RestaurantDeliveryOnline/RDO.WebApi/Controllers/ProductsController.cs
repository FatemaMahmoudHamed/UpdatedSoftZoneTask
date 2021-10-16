using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RDO.Core.Interfaces.Services;
using RDO.Infrastructure.Entities;
using System.Threading.Tasks;

namespace RDO.WebApi.Controllers
{
 
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(ProductQueryObject queryObject)
        {
            var result = await _productService.GetAllAsync(queryObject);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}