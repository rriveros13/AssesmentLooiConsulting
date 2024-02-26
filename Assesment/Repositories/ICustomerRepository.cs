using Assesment.DataModel;
using Assesment.Models;
using System;
using System.Collections.Generic;

public interface ICustomerRepository
{
    IEnumerable<CustomerDataModel> GetCustomers();
    CustomerDataModel GetCustomerById(Guid customerId);
    void AddCustomer(CustomerModel customer);
    void UpdateCustomer(Guid Id, CustomerModel customer);
    int DeleteCustomer(Guid customerId);
}
