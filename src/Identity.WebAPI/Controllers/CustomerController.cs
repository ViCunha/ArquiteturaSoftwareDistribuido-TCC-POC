using Identity.Application.CQRS.Queries;
using Identity.Application.Interfaces;
using Identity.Domain.Models;
using Identity.Domain.Models.DTO;
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
        //
        private readonly ICustomerApplicationServices _customerOrchestrator;
        
        //
        public CustomerController(ICustomerApplicationServices customerOrchestrator)
        {
            this._customerOrchestrator = customerOrchestrator;
        }

        //
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomersAsync()
        {

            var result = await _customerOrchestrator.GetAllCustomersQuery.GetAllCustomersAsync();
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDTO))]

        public async Task<ActionResult<Customer>> CreateNewCustomerAsync (CustomerDTO customerDTO)
        {

            var result = await _customerOrchestrator.CreateNewCustomerOrchestrator.CreateNewCustomerAsync(customerDTO);
            return Ok(result);
        }
    }
}
