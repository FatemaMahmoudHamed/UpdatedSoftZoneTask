using AutoMapper;
using RDO.Core.Dtos;
using RDO.Core.Entities;

namespace RDO.Core.Mapping
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            #region Customer
            CreateMap<CustomerDto, Customer>()
                    .ForMember(s => s.Id, opt => opt.Ignore());

            CreateMap<Customer, CustomerDto>();
            #endregion

        }
    }
}
