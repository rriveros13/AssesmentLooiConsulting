using Assesment.Controllers;
using Assesment.DataBaseContext;
using Assesment.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Assesment.Tests
{
    public class CustomerControllerTests
    {
        private MyDataBaseContext CreateDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<MyDataBaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var dbContext = new MyDataBaseContext(dbContextOptions);

            return dbContext;
        }

        [Fact]
        public void GetCustomerList_ReturnsOkResultWithListOfCustomers()
        {
            // Arrange
            var customers = new List<CustomerDataModel>
            {
                new CustomerDataModel { Id = Guid.NewGuid(), Name = "John Doe" },
                new CustomerDataModel { Id = Guid.NewGuid(), Name = "Jane Smith" }
                // Add more sample customers as needed
            };

            using (var context = CreateDbContext())
            {
                context.customer.AddRange(customers);
                context.SaveChanges();

                var controller = new CustomerController();

                // Act
                var result = controller.GetCustomerList();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<CustomerDataModel>>(okResult.Value);
                Assert.Equal(customers.Count, model.Count());
            }
        }
    }
}