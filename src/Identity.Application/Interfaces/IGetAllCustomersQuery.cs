using Identity.Domain.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IGetAllCustomersQuery
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();
    }
}