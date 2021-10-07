using AutoMapper;
using Identity.Application.Interfaces;
using Identity.Domain.Models.DTO;
using Identity.Infrastructure.Persistence.Interfaces;
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

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
        {
            return  _mapper.Map<IEnumerable<CustomerDTO>>(await _PersistenceServicesCustomer.GetAllCustomersAsync());
        }
    }
}
