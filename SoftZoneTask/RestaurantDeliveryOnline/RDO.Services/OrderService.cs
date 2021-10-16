using RDO.Core.Dtos;
using RDO.Core.Enums;
using RDO.Core.Interfaces.Repositories;
using RDO.Core.Interfaces.Services;
using RDO.Core.Models;
using RDO.Infrastructure.Entities;
using RDO.ServiceInterface.Validators.Others;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RDO.ServiceInterface
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrderRepository;

        public OrderService(IOrderRepository OrderRepository
            )
        {
            _OrderRepository = OrderRepository;
        }

        public async Task<ReturnResult<OrderDto>> GetAsync(int id)
        {
            try
            {
                var entitiy = await _OrderRepository.GetAsync(id);

                return new ReturnResult<OrderDto>
                {
                    IsSuccess = true,
                    StatusCode = HttpStatuses.Status200OK,
                    Data = entitiy
                };
            }
            catch (Exception ex)
            {
                return new ReturnResult<OrderDto>
                {
                    IsSuccess = false,
                    StatusCode = HttpStatuses.Status500InternalServerError,
                    ErrorList = new List<string> { "Failed to add data" }


                };
            }
        }
        public async Task<ReturnResult<OrderDto>> AddAsync(OrderDto model)
        {
            try
            {
                var errors = new List<string>();
                var validationResult = ValidationResult.CheckModelValidation(new OrderValidator(), model);
                if (!validationResult.IsValid)
                {
                    errors.AddRange(validationResult.Errors);
                    if (errors.Any())
                    {
                        return new ReturnResult<OrderDto>
                        {
                            IsSuccess = false,
                            StatusCode = HttpStatuses.Status400BadRequest,
                            ErrorList = errors,
                            Data = null
                        };
                    }
                }

                else
                {
                    await _OrderRepository.AddAsync(model);
                }

                return new ReturnResult<OrderDto>
                {
                    IsSuccess = true,
                    StatusCode = HttpStatuses.Status201Created,
                    Data = model
                };
            }
            catch (Exception ex)
            {

                return new ReturnResult<OrderDto>
                {
                    IsSuccess = false,
                    StatusCode = HttpStatuses.Status500InternalServerError,
                    ErrorList = new List<string> { "Failed to add data" }

                };
            }
        }


    }
}
