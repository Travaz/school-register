using System;
using System.Collections.Generic;

namespace school_register.Model.Entities
{
    public partial class Students
    {
        public string FiscalCode { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int FkClass { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

        public virtual Classes Class { get; set; }
    }
}
