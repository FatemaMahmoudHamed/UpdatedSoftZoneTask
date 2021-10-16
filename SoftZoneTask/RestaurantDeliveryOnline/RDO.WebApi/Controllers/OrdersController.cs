using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RDO.Core.Dtos;
using RDO.Core.Interfaces.Services;
using RDO.Infrastructure.Entities;
using System.Threading.Tasks;

namespace RDO.WebApi.Controllers
{
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _orderService.GetAsync(id);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] OrderDto orderDto)
        {
            var result = await _orderService.AddAsync(orderDto);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}