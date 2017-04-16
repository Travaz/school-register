using System;
using System.Collections.Generic;

namespace school_register.Model.Entities
{
    public partial class Branch
    {
        public Branch()
        {
            Classes = new HashSet<Classes>();
        }

        public int IdBranch { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime StartDate{ get; set; }

        public virtual ICollection<Classes> Classes { get; set; }
    }
}
