using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RDO.Core.Interfaces.Services;
using RDO.Infrastructure.Entities;
using System.Threading.Tasks;

namespace RDO.WebApi.Controllers
{
 
    [Route("api/restaurants")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(RestaurantQueryObject queryObject)
        {
            var result = await _restaurantService.GetAllAsync(queryObject);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _restaurantService.GetAsync(id);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}