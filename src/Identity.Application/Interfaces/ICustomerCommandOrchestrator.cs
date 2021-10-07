using Identity.Domain.Models.DTO;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface ICustomerCommandOrchestrator
    {
        Task<CustomerDTO> CreateNewCustomerAsync (CustomerDTO customer);
    }
}