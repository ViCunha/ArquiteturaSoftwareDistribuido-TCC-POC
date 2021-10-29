using Identity.Application.Interfaces;

namespace Identity.Application.Models
{
    public class CustomerApplicationServices : ICustomerApplicationServices
    {
        private readonly ICustomerQueryOrchestrator _customerQueryOrchestrator;
        private readonly ICustomerCommandOrchestrator _customerCommandOrchestrator;

        public ICustomerQueryOrchestrator CustomerQueryOrchestrator
        {
            get { return _customerQueryOrchestrator; }
            private set { }
        }

        public ICustomerCommandOrchestrator CustomerCommandOrchestrator
        {
            get { return _customerCommandOrchestrator; }
            private set { }
        }

        public CustomerApplicationServices
            (
                ICustomerQueryOrchestrator customerQueryOrchestrator
                ,
                ICustomerCommandOrchestrator CustomerCommandOrchestrator
            )
        {
            this._customerQueryOrchestrator = customerQueryOrchestrator;
            this._customerCommandOrchestrator = CustomerCommandOrchestrator;
        }
    }
}
