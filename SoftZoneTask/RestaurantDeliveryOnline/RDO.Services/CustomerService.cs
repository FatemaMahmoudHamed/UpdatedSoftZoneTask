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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository
            )
        {
            _customerRepository = customerRepository;
        }

        public async Task<ReturnResult<CustomerDto>> GetAsync(int id)
        {
            try
            {
                var entitiy = await _customerRepository.GetAsync(id);

                return new ReturnResult<CustomerDto>
                {
                    IsSuccess = true,
                    StatusCode = HttpStatuses.Status200OK,
                    Data = entitiy
                };
            }
            catch (Exception ex)
            {
                return new ReturnResult<CustomerDto>
                {
                    IsSuccess = false,
                    StatusCode = HttpStatuses.Status500InternalServerError,
                    ErrorList = new List<string> { "Failed to add data" }

                };
            }
        }
        public async Task<ReturnResult<CustomerDto>> AddAsync(CustomerDto model)
        {
            try
            {
                var errors = new List<string>();
                var customerDto = new CustomerDto();
                var validationResult = ValidationResult.CheckModelValidation(new CustomerValidator(), model);
                if (!validationResult.IsValid)
                {
                    errors.AddRange(validationResult.Errors);
                    if (errors.Any())
                    {
                        return new ReturnResult<CustomerDto>
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
                    var customer =await _customerRepository.GetByEmailAsync(model.Email);
                    if (customer != null) 
                    {
                        return new ReturnResult<CustomerDto>
                        {
                            IsSuccess = true,
                            StatusCode = HttpStatuses.Status201Created,
                            Data = customer
                        };
                    }
                  customerDto=await _customerRepository.AddAsync(model);
                }

                return new ReturnResult<CustomerDto>
                {
                    IsSuccess = true,
                    StatusCode = HttpStatuses.Status201Created,
                    Data = customerDto
                };
            }
            catch (Exception ex)
            {

                return new ReturnResult<CustomerDto>
                {
                    IsSuccess = false,
                    StatusCode = HttpStatuses.Status500InternalServerError,
                    ErrorList = new List<string> { "Failed to add data" }
                };
            }
        }


    }
}
