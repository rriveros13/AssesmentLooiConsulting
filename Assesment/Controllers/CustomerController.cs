using Assesment.DataModel;
using Assesment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("GetCustomerList")]
        public IActionResult GetCustomerList()
        {
            var customers = _customerRepository.GetCustomers();
            return Ok(customers);
        }

        // Other action methods remain the same...

        [HttpDelete]
        [Route("DeleteCustomer/{customerId}")]
        public IActionResult DeleteCustomer(Guid customerId)
        {
            var deletedCustomer = _customerRepository.DeleteCustomer(customerId);

            if (deletedCustomer < 0)
            {
                return NotFound($"Customer with ID {customerId} not found");
            }

            return Ok($"Customer with ID {customerId} has been deleted");
        }
        [HttpGet("{customerId}")]
        public IActionResult GetCustomerById(Guid customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);

            if (customer == null)
            {
                return NotFound($"Customer with ID {customerId} not found");
            }

            return Ok(customer);
        }

        [HttpPost]
        [Route("PostCustomer")]
        public IActionResult PostCustomer(CustomerModel obj)
        {
            try
            {
                _customerRepository.AddCustomer(obj);
                return Ok($"Customer has been added correctly");

            }
            catch 
            (Exception e)
            {
                throw e;
            }
        }

        [HttpPut]
        [Route("UpdateCustomer/{customerId}")]
        public IActionResult UpdateCustomer(Guid customerId, [FromBody] CustomerModel updatedCustomer)
        {
            try
            {
                _customerRepository.UpdateCustomer(customerId, updatedCustomer);
                return Ok($"Customer has been updated correctly");

            }
            catch
            (Exception e)
            {
                throw e;
            }

        }

    }
}
