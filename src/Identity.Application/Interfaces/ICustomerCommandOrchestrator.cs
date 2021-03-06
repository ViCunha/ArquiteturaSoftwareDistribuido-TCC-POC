using Identity.Domain.Models.APIResponse;
using Identity.Domain.Models.DTO;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface ICustomerCommandOrchestrator
    {
        Task<APIResponseContent> CreateNewCustomerAsync(CustomerDTO customer);
    }
}