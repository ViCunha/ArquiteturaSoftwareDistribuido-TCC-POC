using Identity.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IGetAllCustomersQuery
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
    }
}