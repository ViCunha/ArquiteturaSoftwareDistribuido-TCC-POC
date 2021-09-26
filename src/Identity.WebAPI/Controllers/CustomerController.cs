using Identity.Application.CQRS.Queries;
using Identity.Domain.Models;
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
        private readonly IGetAllCustomersQuery _getAllCustomersQuery;

        public CustomerController(IGetAllCustomersQuery getAllCustomersQuery)
        {
            this._getAllCustomersQuery = getAllCustomersQuery;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            return Ok(await _getAllCustomersQuery.GetAllCustomers());
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Create([FromBody] Customer customer)
        {

            await Task.Factory.StartNew(() => { });
            return Ok();
        }


    }
}
