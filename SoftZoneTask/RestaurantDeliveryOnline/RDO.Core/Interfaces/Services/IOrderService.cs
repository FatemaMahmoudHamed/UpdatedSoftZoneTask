using RDO.Core.Dtos;
using RDO.Core.Models;
using System.Threading.Tasks;

namespace RDO.Core.Interfaces.Services
{
    public interface IOrderService
    {
        Task<ReturnResult<OrderDto>> GetAsync(int id);

        Task<ReturnResult<OrderDto>> AddAsync(OrderDto orderProduct);

    }

}
