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
        private string _Name;
        [Required] [MaxLength(50)]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged(() => Name); }
        }

        private string _Descr;
        [MaxLength(50)]
        public string Descr
        {
            get { return _Descr; }
            set { _Descr = value; OnPropertyChanged(() => Descr); }
        }

        public virtual ObservableCollection<Customer> Customers { get; private set; } 

    }
}
