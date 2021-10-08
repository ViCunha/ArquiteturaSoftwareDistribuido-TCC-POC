using AutoMapper;
using Identity.Application.Interfaces;
using Identity.Domain.Models.APIResponse;
using Identity.Domain.Models.DTO;
using Identity.Infrastructure.Persistence.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Application.CQRS.Queries
{
    public class GetAllCustomersQuery : IGetAllCustomersQuery
    {
        private readonly ICustomerPersistenceServices _PersistenceServicesCustomer;
        private readonly IMapper _mapper;

        public GetAllCustomersQuery
            (
                ICustomerPersistenceServices persistenceServicesCustomer
                ,
                IMapper mapper
            )
        {
            this._PersistenceServicesCustomer = persistenceServicesCustomer;
            this._mapper = mapper;
        }

        public async Task<APIResponseContent> GetAllCustomersAsync()
        {
            var result = await _PersistenceServicesCustomer.GetAllCustomersAsync();
            return new APIResponseContentSuccess(StatusCodes.Status200OK, _mapper.Map<IEnumerable<CustomerDTO>>(result));
        }
    }
}
