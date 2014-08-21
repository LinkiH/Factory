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
        [Required] [MaxLength(50)] //поле обязательное и ограничено по длине 250
        public string Name { get; set; }

        [MaxLength(50)]
        public string Code { get; set; } 

        [MaxLength(250)] 
        public string Descr { get; set; }

        public Nullable<DateTime> DateCreate { get; set; }  

        public Nullable<DateTime> DateUpdate { get; set; } 

        //Основные контакты
        [MaxLength(50)] 
        public string Phone { get; set; } 

        [MaxLength(50)] 
        public string Email { get; set; }  
    
        [MaxLength(50)] 
        public string Website { get; set; } 

        //Реквизиты бизнес-логики

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