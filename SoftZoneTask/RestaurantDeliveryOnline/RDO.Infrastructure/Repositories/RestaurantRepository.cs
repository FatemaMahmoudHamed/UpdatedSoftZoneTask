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
    public class RestaurantRepository : RepositoryBase, IRestaurantRepository
    {
        public RestaurantRepository(CommandDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(context, mapper, httpContextAccessor)
        {
        }

        public async Task<QueryResultDto<RestaurantDto>> GetAllAsync(RestaurantQueryObject queryObject)
        {
            var result = new QueryResult<Restaurant>();

            var query = commandDb.Restaurants
                .Include(m => m.Menu)
                .AsNoTracking()
                .AsQueryable();
            
            //City
            if (!string.IsNullOrEmpty(queryObject.City))
                query = query.Where(c => (c.City).Contains(queryObject.City));

            if (!string.IsNullOrEmpty(queryObject.SearchText))
            {
                query = query.Where(c => c.City.Contains(queryObject.SearchText));
            }

            if (String.IsNullOrEmpty(queryObject.SortBy))
            {
                query = query.OrderBy(v => v.City);
            }
            else
            {
                var columnsMap = new Dictionary<string, Expression<Func<Restaurant, object>>>()
                {
                    ["name"] = v => v.Name,
                    ["city"] = v => v.City,
                };

                query = query.ApplySorting(queryObject,columnsMap);
            }


            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObject);

            result.Items = await query.ToListAsync();

            return mapper.Map<QueryResult<Restaurant>, QueryResultDto<RestaurantDto>>(result);
        }

        public async Task<RestaurantDto> GetAsync(int restId)
        {
            var user = await commandDb.Restaurants
                .Include(m=>m.Menu)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == restId);

            return mapper.Map<RestaurantDto>(user);
        }
       
    }
}