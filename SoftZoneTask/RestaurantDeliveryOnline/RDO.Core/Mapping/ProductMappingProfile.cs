using AutoMapper;
using RDO.Core.Dtos;
using RDO.Core.Entities;

namespace RDO.Core.Mapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            #region Product
            CreateMap<ProductDto, Product>()
                    .ForMember(s => s.Id, opt => opt.Ignore())
                    .ForMember(s => s.CreatedOn, opt => opt.Ignore())
                    .ForMember(s => s.RestId, opt => opt.Ignore());


            CreateMap<Product, ProductDto>();

            #endregion

        }
    }
}
