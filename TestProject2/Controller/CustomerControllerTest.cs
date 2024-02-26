using Assesment.Controllers;
using Assesment.DataModel;
using Assesment.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Assesment.Tests
{
    public class CustomerControllerTests
    {
        [Fact]
        public void GetCustomerList_ReturnsOkObjectResult()
        {
            // Arrange
            var fakeRepository = A.Fake<ICustomerRepository>();
            var controller = new CustomerController(fakeRepository);

            // Act
            var result = controller.GetCustomerList();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void PostCustomer_ReturnsOkResult()
        {
            // Arrange
            var fakeRepository = A.Fake<ICustomerRepository>();
            var customerModel = new CustomerModel(); // Add your sample data here
            var controller = new CustomerController(fakeRepository);

            // Act
            var result = controller.PostCustomer(customerModel);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UpdateCustomer_ReturnsOkResult()
        {
            // Arrange
            var fakeRepository = A.Fake<ICustomerRepository>();
            var customerId = 1; // ID del cliente a actualizar
            var customerModel = new CustomerModel(); // Datos de cliente actualizados
            var controller = new CustomerController(fakeRepository);

            // Act
            var result = controller.UpdateCustomer(Guid.NewGuid(), customerModel);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteCustomer_ReturnsOkResult()
        {
            // Arrange
            var fakeRepository = A.Fake<ICustomerRepository>();
            var customerId = Guid.NewGuid(); // ID of the customer to delete
            A.CallTo(() => fakeRepository.DeleteCustomer(customerId)).Returns(1); // Simulate successful deletion

            var controller = new CustomerController(fakeRepository);

            // Act
            var result = controller.DeleteCustomer(customerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal($"Customer with ID {customerId} has been deleted", okResult.Value);
        }
    }
}
