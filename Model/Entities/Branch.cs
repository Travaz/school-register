using System;
using System.Collections.Generic;

namespace school_register.Model.Entities
{
    public partial class Branch
    {
        public Branch()
        {
            Class = new HashSet<Class>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }

        public virtual ICollection<Class> Class { get; set; }
    }
}
