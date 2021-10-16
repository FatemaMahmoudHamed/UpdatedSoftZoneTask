using AutoMapper;
using RDO.Core.Dtos;
using RDO.Core.Entities;

namespace RDO.Core.Mapping
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            #region Order
            CreateMap<OrderDto, Order>()
                    .ForMember(s => s.Id, opt => opt.Ignore())
                    .ForMember(s => s.OrderProducts, opt => opt.Ignore());

            CreateMap<Order, OrderDto>();
            #endregion

            #region OrderProduct
            CreateMap<OrderProductDto, OrderProduct>()
                    .ForMember(s => s.Id, opt => opt.Ignore())
                    .ForMember(s => s.Product, opt => opt.Ignore());

            CreateMap<OrderProduct, OrderProductDto>()
            .ForMember(s => s.Product, opt => opt.Ignore());
            #endregion
        }
    }
}
