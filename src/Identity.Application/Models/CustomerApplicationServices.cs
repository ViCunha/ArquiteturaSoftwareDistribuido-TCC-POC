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
        private readonly ICreateNewCustomerOrchestrator _createNewCustomerOrchestrator;

        public IGetAllCustomersQuery GetAllCustomersQuery
        {
            get { return _getAllCustomersQuery; }
            private set { }
        }

        public ICreateNewCustomerOrchestrator CreateNewCustomerOrchestrator
        {
            get { return _createNewCustomerOrchestrator; }
            private set { }
        }

        public CustomerApplicationServices
            (
                IGetAllCustomersQuery getAllCustomersQuery
                ,
                ICreateNewCustomerOrchestrator createNewCustomerOrchestrator
            )
        {
            this._getAllCustomersQuery = getAllCustomersQuery;
            this._createNewCustomerOrchestrator = createNewCustomerOrchestrator;
        }
    }
}
