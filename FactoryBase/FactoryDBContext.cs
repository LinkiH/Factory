using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Factory.Base.Models;

namespace Factory.Base
{
    public class FactoryDBContext : DbContext
    {
        public FactoryDBContext() : base("name=FactoryDB")
        {
            Database.SetInitializer<FactoryDBContext>(new FactoryDbInitializer());
        }

        //Перечень таблиц
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        

        
    }
}