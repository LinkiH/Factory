namespace Factory.Client.Services
{
    using System.Collections.Generic;

    using Factory.Base.Models;
    using Factory.Base.Repositories;

    public class ClientLayer : IClientLayer
    {
        private readonly ICustomerRepository _custRepository;
        private readonly ICustomerTypeRepository _custTypeRepository;

        public ClientLayer()
        {
            _custRepository = new CustomerRepository();
            _custTypeRepository = new CustomerTypeRepository();
        }

        public ClientLayer(ICustomerRepository custRepository, ICustomerTypeRepository custTypeRepository)
        {
            _custRepository = custRepository;
            _custTypeRepository = custTypeRepository;
        }

        public IList<Customer> GetAllCustomers()
        {
            return _custRepository.GetAll(q => q.CustomerType);
        }

        public IList<CustomerType> GetAllCustomerTypes()
        {
            return _custTypeRepository.GetAll();
        }
        public Customer GetCustomerByName(string customerName)
        {
            return _custRepository.GetSingle(
                d => d.Name.Equals(customerName));
        }

        public Customer GetCustomerById(int customerId)
        {
            return _custRepository.GetSingle(
                d => d.Id == customerId);
        }

        public void AddCustomer(params Customer[] customers)
        {
            /* Validation and error handling omitted */
            _custRepository.Add(customers);
        }

        public void UpdateCustomer(params Customer[] customers)
        {
            /* Validation and error handling omitted */
            _custRepository.Update(customers);
        }

        public void RemoveCustomer(params Customer[] customers)
        {
            /* Validation and error handling omitted */
            _custRepository.Remove(customers);
        }

    }
}
