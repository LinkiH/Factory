namespace Factory.Base.Models
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Microsoft.Practices.Prism.Mvvm;

    using Factory.Base.Services;

    public class Customer : EntityBase
    {
        //Основные поля
        //public int Id { get; set; } Генерится из Entity.cs
        
        //public string Name { get; set; }
        private string _Name;
        [Required] [MaxLength(50)] //поле обязательное и ограничено по длине 250
        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged(() => Name); }
        }

        private string _Code;
        [MaxLength(50)]
        public string Code 
        {
            get { return _Code ; }
            set { _Code = value; OnPropertyChanged(() => Code); }
        }

        private string _Descr;
        [MaxLength(250)] 
        public string Descr 
        {
            get { return _Descr; }
            set { _Descr = value; OnPropertyChanged(() => Descr); }
        }

        private Nullable<DateTime> _DateCreate;
        public Nullable<DateTime> DateCreate 
        {
            get { return _DateCreate; }
            set { _DateCreate = value; OnPropertyChanged(() => DateCreate); }
        }

        private Nullable<DateTime> _DateUpdate;
        public Nullable<DateTime> DateUpdate 
        {
            get { return _DateUpdate; }
            set { _DateUpdate = value; OnPropertyChanged(()=> DateUpdate);} 
        }

        //Основные контакты
        private string _Phone;
        [MaxLength(50)] 
        public string Phone 
        {
            get { return _Phone;}
            set { _Phone = value; OnPropertyChanged(() => Phone); } 
        }

        private string _Email;
        [MaxLength(50)] 
        public string Email 
        {
            get { return _Email;}
            set { _Email = value; OnPropertyChanged(() => Email); } 
        }

        private string _Website;
        [MaxLength(50)] 
        public string Website 
        {
            get { return _Website; }
            set { _Website = value; OnPropertyChanged(() => Website); }
        }

        //Реквизиты бизнес-логики
        public Nullable<int> PaymentId { get; set; }
        public Nullable<decimal> PecentDiscount { get; set; }
        public Nullable<bool> IsOnce { get; set; }

        public int CustomerTypeId { get; set; }
        public virtual CustomerType CustomerType { get; set; } 

        //Позже добавить
        //public Nullable<System.Guid> dealerId { get; set; }
        //public virtual dealer dealer { get; set; }
        //public virtual users users { get; set; }
        //public Nullable<System.Guid> userCreateId { get; set; }
        //public Nullable<System.Guid> userUpdateId { get; set; }
        //public Nullable<System.Guid> userResponsible { get; set; }


        // с апф
        //public Nullable<bool> IsPack { get; set; }
        //public Nullable<decimal> SummBase { get; set; }
        //public Nullable<bool> Corrugated { get; set; }
        //public string PhoneWork { get; set; }
        //public string fax { get; set; }
        //public string city { get; set; }
        //public string shipping { get; set; }
        //public Nullable<bool> emailActive { get; set; }

    }
}