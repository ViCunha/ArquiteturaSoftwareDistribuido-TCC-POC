using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity.Application.CQRS.Queries;
using Identity.Application.Interfaces;

namespace Identity.Application.Models
{
    public class CustomerOrchestrator : ICustomerOrchestrator
    {
        private readonly IGetAllCustomersQuery _getAllCustomersQuery;

        public IGetAllCustomersQuery GetAllCustomersQuery
        {
            get { return _getAllCustomersQuery; }
            private set { }
        }

        public CustomerOrchestrator(IGetAllCustomersQuery getAllCustomersQuery)
        {
            this._getAllCustomersQuery = getAllCustomersQuery;
        }
    }
}
