using Identity.Application.CQRS.Queries;

namespace Identity.Application.Interfaces
{
    public interface ICustomerApplicationServices
    {
        IGetAllCustomersQuery GetAllCustomersQuery { get; }
    }
}