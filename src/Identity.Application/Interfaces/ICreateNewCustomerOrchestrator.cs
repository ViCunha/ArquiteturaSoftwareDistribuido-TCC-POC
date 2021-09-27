using Identity.Domain.Models.DTO;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface ICreateNewCustomerOrchestrator
    {
        Task<CustomerDTO> CreateNewCustomer(CustomerDTO customer);
    }
}