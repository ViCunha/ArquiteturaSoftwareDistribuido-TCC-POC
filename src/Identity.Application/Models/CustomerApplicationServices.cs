using Identity.Application.Interfaces;
using Identity.Domain.Models.DTO;

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
                ICustomerCommandOrchestrator customerCommandOrchestrator
            )
        {
            this._customerQueryOrchestrator = customerQueryOrchestrator;
            this._customerCommandOrchestrator = customerCommandOrchestrator;
        }

        public CustomerJWT GenerateJWTToCustomerAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
