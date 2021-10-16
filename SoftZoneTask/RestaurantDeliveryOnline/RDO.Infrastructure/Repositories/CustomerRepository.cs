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
    public class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        public CustomerRepository(CommandDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(context, mapper, httpContextAccessor)
        {
        }

        public async Task<CustomerDto> GetAsync(int customerId)
        {
            var customer = await commandDb.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == customerId);

            return mapper.Map<CustomerDto>(customer);

        }
        public async Task<CustomerDto> AddAsync(CustomerDto customerDto)
        {
            var entityToAdd = mapper.Map<Customer>(customerDto);
            //entityToAdd.CreatedOn = DateTime.Now;
            entityToAdd.Id = (await commandDb.Customers.IgnoreQueryFilters().MaxAsync(c => (int?)c.Id) ?? 0) + 1;
            await commandDb.Customers.AddAsync(entityToAdd);
            await commandDb.SaveChangesAsync();
            customerDto.Id = entityToAdd.Id;
            return customerDto;
        }
        public async Task<CustomerDto> GetByEmailAsync(string email)
        {
            var _customer = await commandDb.Customers
            .FirstOrDefaultAsync(a => a.Email == email);

            if (_customer != null)
            {
                return mapper.Map<Customer, CustomerDto>(_customer);
            }

            return null;
        }

    }
}