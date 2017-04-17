using System;
using System.Collections.Generic;

namespace school_register.Model.Entities
{
    public partial class Student
    {
        public string FiscalCode { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string FkClass { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual Class FkClassNavigation { get; set; }
    }
}
