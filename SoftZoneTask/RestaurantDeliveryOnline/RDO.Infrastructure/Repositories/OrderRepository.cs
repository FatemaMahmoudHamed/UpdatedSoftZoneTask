using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RDO.Core.Interfaces.Repositories;
using RDO.Infrastructure.DbContexts;
using RDO.Core.Dtos;
using RDO.Infrastructure.Entities;
using RDO.Core.Entities;
using RDO.Infrastructure.Extensions;

namespace RDO.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        public OrderRepository(CommandDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(context, mapper, httpContextAccessor)
        {
        }

        public async Task<OrderDto> GetAsync(int orderId)
        {
            var user = await commandDb.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == orderId);

            return mapper.Map<OrderDto>(user);

        }
        public async Task AddAsync(OrderDto orderDto)
        {
            List<OrderProduct> entityToAdd = new List<OrderProduct>();
            var products = mapper.Map<ICollection<OrderProduct>>(orderDto.OrderProducts).ToList();
            foreach (var p in products) 
            {
                p.Product = null;
                p.Id = (await commandDb.OrderProducts.IgnoreQueryFilters().MaxAsync(c => (int?)c.Id) ?? 0) + 1;
                entityToAdd.Add(p);
                await commandDb.OrderProducts.AddAsync(p);
                await commandDb.SaveChangesAsync();
            }

            var orderToAdd = mapper.Map<Order>(orderDto);
            orderToAdd.OrderProducts = null;
            orderToAdd.Customer = null;
            orderToAdd.Id = (await commandDb.Orders.IgnoreQueryFilters().MaxAsync(c => (int?)c.Id) ?? 0) + 1;
            await commandDb.Orders.AddAsync(orderToAdd);
            await commandDb.SaveChangesAsync();
        }
    }
}