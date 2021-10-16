using RDO.Core.Dtos;
using RDO.Core.Models;
using System.Threading.Tasks;

namespace RDO.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<ReturnResult<CustomerDto>> GetAsync(int id);

        Task<ReturnResult<CustomerDto>> AddAsync(CustomerDto customerDto);


    }

}
