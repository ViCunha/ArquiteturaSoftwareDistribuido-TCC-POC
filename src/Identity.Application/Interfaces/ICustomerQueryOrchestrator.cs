using Identity.Domain.Models.APIResponse;
using System;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface ICustomerQueryOrchestrator
    {
        Task<APIResponseContent> GetCustomerByIdAsync(Guid id);

        Task<APIResponseContent> GetAllCustomersAsync();
    }
}