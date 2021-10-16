using RDO.Core.Dtos;
using RDO.Core.Models;
using RDO.Infrastructure.Entities;
using System.Threading.Tasks;

namespace RDO.Core.Interfaces.Services
{
    public interface IRestaurantService
    {
        Task<ReturnResult<RestaurantDto>> GetAsync(int id);

        Task<ReturnResult<QueryResultDto<RestaurantDto>>> GetAllAsync(RestaurantQueryObject queryObject);

    }

}
