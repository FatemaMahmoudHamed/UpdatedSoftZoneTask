using RDO.Core.Dtos;
using RDO.Core.Models;
using RDO.Infrastructure.Entities;
using System.Threading.Tasks;

namespace RDO.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<ReturnResult<QueryResultDto<ProductDto>>> GetAllAsync(ProductQueryObject queryObject);

    }

}
