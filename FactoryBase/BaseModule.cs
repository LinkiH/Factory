using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

using Factory.Base;
using Factory.Base.Repositories;
using Factory.Base.Services;
using Factory.Base.Models;
using System.Data.Entity;

namespace Factory.Base
{
    public class BaseModule : IModule

    {
        public BaseModule(IUnityContainer container, IRegionManager regionManager)
        {
            Container = container;
            RegionManager = regionManager;

            Database.SetInitializer(new FactoryDbInitializer());

            ICustomerRepository _custRepository = new CustomerRepository();
            var findCustomer = _custRepository.GetSingle(d => d.Name.Equals("Основной заказчик"));
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
