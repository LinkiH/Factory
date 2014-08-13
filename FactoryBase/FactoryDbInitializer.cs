using System.Collections.Generic;
using System.Data.Entity;
using Factory.Base.Models;
using System;

namespace Factory.Base
{
    public class FactoryDbInitializer : DropCreateDatabaseIfModelChanges<FactoryDBContext>  //Создаём базу если не создана
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
                new Customer(){Name = "Основной заказчик", Descr = "Создан автоматически", CustomerTypeId = 1,  DateCreate = DateTime.Now, DateUpdate = DateTime.Now, Code = "1", IsOnce = false, PaymentId = 1, PecentDiscount = 0},
            };

            customer.ForEach(client => context.Customers.Add(client));

            context.SaveChanges();

        }
    }

    //CreateDatabaseIfNotExists<FactoryDBContext>
    //DropCreateDatabaseIfModelChanges<FactoryDBContext>

}