using Identity.Domain.Model;
using Identity.WebAPI.Controllers;
using System;
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
            var prossessing = await controller.GetAllCustomers();

            //Assert
            Assert.True(prossessing.Result.GetType(), Customer);
        }
    }
}
