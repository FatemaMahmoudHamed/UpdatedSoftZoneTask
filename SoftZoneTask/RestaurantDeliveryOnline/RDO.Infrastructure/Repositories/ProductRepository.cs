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
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        public ProductRepository(CommandDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(context, mapper, httpContextAccessor)
        {
        }

        public async Task<QueryResultDto<ProductDto>> GetAllAsync(ProductQueryObject queryObject)
        {
            var result = new QueryResult<Product>();

            var query = commandDb.Products
                .Where(x=>x.RestId==queryObject.RestId)
                .AsNoTracking()
                .AsQueryable();
            
            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObject);

            result.Items = await query.ToListAsync();

            return mapper.Map<QueryResult<Product>, QueryResultDto<ProductDto>>(result);
        }

    }
}