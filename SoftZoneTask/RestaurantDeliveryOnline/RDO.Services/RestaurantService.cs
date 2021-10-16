using RDO.Core.Dtos;
using RDO.Core.Enums;
using RDO.Core.Interfaces.Repositories;
using RDO.Core.Interfaces.Services;
using RDO.Core.Models;
using RDO.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RDO.ServiceInterface
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        //private readonly ILogger<RestaurantService> _logger;

        public RestaurantService(IRestaurantRepository restaurantRepository
            //,ILogger<RestaurantService> logger
            )
        {
            _restaurantRepository = restaurantRepository;
            //_logger = logger;
        }

        public async Task<ReturnResult<QueryResultDto<RestaurantDto>>> GetAllAsync(RestaurantQueryObject queryObject)
        {
            try
            {
                var entities = await _restaurantRepository.GetAllAsync(queryObject);

                return new ReturnResult<QueryResultDto<RestaurantDto>>
                {
                    IsSuccess = true,
                    StatusCode = HttpStatuses.Status200OK,
                    Data = entities
                };
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message, queryObject);

                return new ReturnResult<QueryResultDto<RestaurantDto>>
                {
                    IsSuccess = false,
                    StatusCode = HttpStatuses.Status500InternalServerError,
                    ErrorList = new List<string> { "Failed to add data" }

                };
            }
        }

        public async Task<ReturnResult<RestaurantDto>> GetAsync(int id)
        {
            try
            {
                var entitiy = await _restaurantRepository.GetAsync(id);

                return new ReturnResult<RestaurantDto>
                {
                    IsSuccess = true,
                    StatusCode = HttpStatuses.Status200OK,
                    Data = entitiy
                };
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message, id);

                return new ReturnResult<RestaurantDto>
                {
                    IsSuccess = false,
                    StatusCode = HttpStatuses.Status500InternalServerError,
                    ErrorList = new List<string> { "Failed to add data" }

                };
            }
        }

    }
}
