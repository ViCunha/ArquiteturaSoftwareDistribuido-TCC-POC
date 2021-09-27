using Identity.Application.CQRS.Queries;

namespace Identity.Application.Interfaces
{
    public interface ICustomerApplicationServices
    {
        public IGetAllCustomersQuery GetAllCustomersQuery { get; }
        

       public ICreateNewCustomerOrchestrator CreateNewCustomerOrchestrator { get; }

    }
}