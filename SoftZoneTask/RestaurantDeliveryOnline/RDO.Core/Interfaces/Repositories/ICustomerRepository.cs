using RDO.Core.Dtos;
using System.Threading.Tasks;

namespace RDO.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerDto> GetAsync(int Id);
        Task<CustomerDto> AddAsync(CustomerDto customerDto);
        Task<CustomerDto> GetByEmailAsync(string email);
    }
}