using Identity.Application.Interfaces;
using Identity.Domain.Models;
using Identity.Domain.Models.APIResponse;
using Identity.Domain.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.WebAPI.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/private/[controller]/v{version:apiVersion}")]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(APIResponseContent))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomersAsync()
        {

            var result = await _customerOrchestrator.GetAllCustomersQuery.GetAllCustomersAsync();
            if (result is APIResponseContentFailure)
            {
                BadRequest((APIResponseContentFailure)result);
            }

            return Ok((APIResponseContentSuccess) result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDTO))]

        public async Task<ActionResult<Customer>> CreateNewCustomerAsync (CustomerDTO customerDTO)
        {

            var result = await _customerOrchestrator.CustomerCommandOrchestrator.CreateNewCustomerAsync(customerDTO);
            if (result is APIResponseContentFailure)
            {
                return BadRequest((APIResponseContentFailure)result);
            }


            return Ok((APIResponseContentSuccess)result);
        }
    }
}
