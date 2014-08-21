using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using Factory.Base.Services;


namespace Factory.Base.Models
{
    public class CustomerType : EntityBase 
    {
        public CustomerType()
        {
            this.Customers = new ObservableCollection<Customer>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Descr { get; set; }

        public virtual ObservableCollection<Customer> Customers { get; private set; } 

    }
}
