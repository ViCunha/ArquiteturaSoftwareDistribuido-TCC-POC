using Identity.Domain.Models.APIResponse;
using Identity.Domain.Models.DTO;
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