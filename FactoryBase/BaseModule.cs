
namespace Factory.Base
{
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Unity;

    using Factory.Base.Repositories;

    public class BaseModule : IModule

    {
        public BaseModule(IUnityContainer container, IRegionManager regionManager)
        {
            Container = container;
            RegionManager = regionManager;

            //Database.SetInitializer(new FactoryDbInitializer());

            ICustomerRepository custRepository = new CustomerRepository();
            var findCustomer = custRepository.GetSingle(d => d.Name.Equals("Основной заказчик1"));
            //if (findCustomer == null)
            //{
            //    Customer customer = new Customer();
            //    customer.Name = "Основной заказчик";
            //    customer.Descr = "Создан автоматически";
            //    _custRepository.Add(customer);
            //}
            
        }

        public void Initialize()
        {
            
        }

        public IUnityContainer Container { get; private set; }
        public IRegionManager RegionManager { get; private set; }
    }
}
