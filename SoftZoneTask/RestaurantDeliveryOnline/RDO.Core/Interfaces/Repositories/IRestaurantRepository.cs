using RDO.Core.Dtos;
using RDO.Infrastructure.Entities;
using System.Threading.Tasks;

namespace RDO.Core.Interfaces.Repositories
{
    public interface IRestaurantRepository
    {

        Task<RestaurantDto> GetAsync(int id);

        //Task<List<RestaurantDto>> GetAllAsync(RestaurantQueryObject queryObject);
        Task<QueryResultDto<RestaurantDto>> GetAllAsync(RestaurantQueryObject queryObject);

    }
}