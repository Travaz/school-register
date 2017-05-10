using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using school_register.Services.Extension;

namespace school_register.Models
{
    public enum Gender
    {
        Female,
        Male
    }

    public partial class Student
    {
        public int ID { get; set; }
        public string FiscalCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int? FkClass { get; set; }
        public string Email { get; set; }

        public virtual Class FkClassNavigation { get; set; }

    }
}
