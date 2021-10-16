using RDO.Core.Dtos;
using RDO.Infrastructure.Entities;
using System.Threading.Tasks;

namespace RDO.Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<QueryResultDto<ProductDto>> GetAllAsync(ProductQueryObject queryObject);
    }
}