using RDO.Core.Dtos;
using System.Threading.Tasks;

namespace RDO.Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<OrderDto> GetAsync(int Id);
        Task AddAsync(OrderDto orderProduct);

    }
}