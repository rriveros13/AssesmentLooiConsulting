using Assesment.DataModel;
using Assesment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class CustomerRepository : ICustomerRepository
{
    private readonly MyDataBaseContext _dbContext;

    public CustomerRepository(MyDataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<CustomerDataModel> GetCustomers()
    {
        return _dbContext.Customers.ToList();
    }

    public CustomerDataModel GetCustomerById(Guid customerId)
    {
        return _dbContext.Customers.FirstOrDefault(c => c.Id == customerId);
    }

    public void AddCustomer(CustomerModel customer)
    {

        CustomerDataModel newCustomer = new CustomerDataModel
        {
            Id = Guid.NewGuid(),
            Name = customer.Name,
            DNI = customer.DNI,
            Address = customer.Address,
            Phone = customer.Phone,
            Mobile = customer.Mobile,
            Email = customer.Email,
            State = customer.State,
            City = customer.City
        };
        _dbContext.Customers.Add(newCustomer);
        _dbContext.SaveChanges();
    }

    public void UpdateCustomer(Guid Id, CustomerModel customer)
    {
        var existingCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == Id);
        if (existingCustomer != null)
        {
            // Update properties as needed
            existingCustomer.Name = customer.Name;
            existingCustomer.DNI = customer.DNI;
            existingCustomer.Address = customer.Address;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Mobile = customer.Mobile;
            existingCustomer.Email = customer.Email;
            existingCustomer.State = customer.State;
            existingCustomer.City = customer.City;
            _dbContext.SaveChanges();
        }
    }

    public int DeleteCustomer(Guid customerId)
    {
        var existingCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == customerId);
        try
        {
            if (existingCustomer != null)
            {
                _dbContext.Customers.Remove(existingCustomer);
                _dbContext.SaveChanges();
            }
            return 1;
        }
        catch
        {
            return -1;
        }
        
    }
}
