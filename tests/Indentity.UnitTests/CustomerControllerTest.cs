using Identity.Domain.Model;
using Identity.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Indentity.UnitTests
{
    public class CustomerControllerTest
    {
        [Fact]
        public async Task GetAllCustomers_CallTheMethod_ExpectedResultOkAndEnumerableOfObjects()
        {
            //Arrange
            var controller = new CustomerController();

            //Act
            var response = await controller.GetAllCustomers();
            var statuscodeOk200Result = response.Result as OkObjectResult;
            var resultObject = GetCollectionResultContent<IEnumerable<Customer>>(statuscodeOk200Result);

            //Assert
            Assert.True(statuscodeOk200Result != null);
            Assert.True(resultObject.Count() > 0);
        }

        private static T GetCollectionResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
