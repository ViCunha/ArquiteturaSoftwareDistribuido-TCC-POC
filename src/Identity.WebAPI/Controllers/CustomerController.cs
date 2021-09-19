using Identity.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            await Task.Factory.StartNew(() => { });

            return 
                Ok(
                    new List<Customer>()
                    {
                        new Customer() { Id = System.Guid.NewGuid(), isActive = true, Name = "a" }
                        ,
                        new Customer() { Id = System.Guid.NewGuid(), isActive = true, Name = "b" }
                        ,
                        new Customer() { Id = System.Guid.NewGuid(), isActive = true, Name = "c" }
                });
        }
    }
}
