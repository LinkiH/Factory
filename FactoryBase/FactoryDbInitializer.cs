

namespace Factory.Base
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Factory.Base.Models;

    //CreateDatabaseIfNotExists<FactoryDBContext>  
    //DropCreateDatabaseIfModelChanges<FactoryDBContext>  
    //MigrateDatabaseToLatestVersion<BlogContext, Configuration>

    public class FactoryDbInitializer : DropCreateDatabaseIfModelChanges<FactoryDBContext> 
    {
        protected override void Seed(FactoryDBContext context)
        {
            var customerType = new List<CustomerType>()
            {
                new CustomerType(){Name = "Заказчик", Descr = "Заказчик"},
                new CustomerType(){Name = "Транспортная компания", Descr = "Транспортная компания"}
            };
            customerType.ForEach(type => context.CustomerTypes.Add(type));
            context.SaveChanges();

            var customer = new List<Customer>()
            {
                new Customer(){Name = "Основной заказчик"
                                , Descr = "Создан автоматически"
                                , CustomerTypeId = 1
                                , DateCreate = DateTime.Now
                                , DateUpdate = DateTime.Now
                                , Code = "1"
                               },
            };
            customer.ForEach(client => context.Customers.Add(client));
            context.SaveChanges();

        }
    }

    

}