using Identity.Application.CQRS.Queries;

namespace Identity.Application.Interfaces
{
    public interface ICustomerOrchestrator
    {
        IGetAllCustomersQuery GetAllCustomersQuery { get; }
    }
}