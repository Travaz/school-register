using System;
using System.Collections.Generic;

namespace school_register.Model.Entities
{
    public partial class Class
    {
        public Class()
        {
            Student = new HashSet<Student>();
        }

        public int ID { get; set;}
        public string Name { get; set; }
        public int? FkBranch { get; set; }
        public int? FkRoom { get; set; }

        public virtual ICollection<Student> Student { get; set; }
        public virtual Branch FkBranchNavigation { get; set; }
        public virtual Room FkRoomNavigation { get; set; }
    }
}
