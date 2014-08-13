namespace Factory.Client.Services
{
    using System.Collections.Generic;
    using Factory.Base.Models;
    using Factory.Base.Repositories;

    public interface IClientLayer
    {
        IList<Customer> GetAllCustomers();
        IList<CustomerType> GetAllCustomerTypes();
        Customer GetCustomerByName(string customerName);
        Customer GetCustomerById(int customerId);
        void AddCustomer(params Customer[] customers);
        void UpdateCustomer(params Customer[] customers);
        void RemoveCustomer(params Customer[] customers);

    }
}
