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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository
            )
        {
            _productRepository = productRepository;
        }

        public async Task<ReturnResult<QueryResultDto<ProductDto>>> GetAllAsync(ProductQueryObject queryObject)
        {
            try
            {
                var entities = await _productRepository.GetAllAsync(queryObject);

                return new ReturnResult<QueryResultDto<ProductDto>>
                {
                    IsSuccess = true,
                    StatusCode = HttpStatuses.Status200OK,
                    Data = entities
                };
            }
            catch (Exception ex)
            {
                return new ReturnResult<QueryResultDto<ProductDto>>
                {
                    IsSuccess = false,
                    StatusCode = HttpStatuses.Status500InternalServerError,
                    ErrorList = new List<string> { "Failed to add data" }

                };
            }
        }

    }
}
