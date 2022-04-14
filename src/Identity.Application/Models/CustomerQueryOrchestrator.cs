using AutoMapper;
using Identity.Application.Interfaces;
using Identity.Domain.Models.APIResponse;
using Identity.Domain.Models.DTO;
using Identity.Infrastructure.Persistence.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Application.Models
{
    public class CustomerQueryOrchestrator : ICustomerQueryOrchestrator
    {
        //
        private readonly ICustomerPersistenceServices _PersistenceServicesCustomer;
        private readonly IMapper _mapper;

        //
        public CustomerQueryOrchestrator
            (
                ICustomerPersistenceServices persistenceServicesCustomer
                ,
                IMapper mapper
            )
        {
            this._PersistenceServicesCustomer = persistenceServicesCustomer;
            this._mapper = mapper;
        }

        public async Task<APIResponseContent> GetCustomerByIdAsync(Guid id)
        {
            var result = await _PersistenceServicesCustomer.GetCustomersByIdAsync(id);
            return new APIResponseContentSuccess(StatusCodes.Status200OK, _mapper.Map<CustomerDTO>(result));
        }

        public async Task<APIResponseContent> GetAllCustomersAsync()
        {
            var result = await _PersistenceServicesCustomer.GetAllCustomersAsync();
            return new APIResponseContentSuccess(StatusCodes.Status200OK, _mapper.Map<IEnumerable<CustomerDTO>>(result));
        }

    }
}