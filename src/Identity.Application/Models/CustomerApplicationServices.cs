using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity.Application.CQRS.Queries;
using Identity.Application.Interfaces;

namespace Identity.Application.Models
{
    public class CustomerApplicationServices : ICustomerApplicationServices
    {
        private readonly IGetAllCustomersQuery _getAllCustomersQuery;
        private readonly ICustomerCommandOrchestrator _CustomerCommandOrchestrator;

        public IGetAllCustomersQuery GetAllCustomersQuery
        {
            get { return _getAllCustomersQuery; }
            private set { }
        }

        public ICustomerCommandOrchestrator CustomerCommandOrchestrator
        {
            get { return _CustomerCommandOrchestrator; }
            private set { }
        }

        public CustomerApplicationServices
            (
                IGetAllCustomersQuery getAllCustomersQuery
                ,
                ICustomerCommandOrchestrator CustomerCommandOrchestrator
            )
        {
            this._getAllCustomersQuery = getAllCustomersQuery;
            this._CustomerCommandOrchestrator = CustomerCommandOrchestrator;
        }
    }
}
