using school_register.Services.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace school_register.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int? FkBranch { get; set; }
        public int? FkRoom { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual Branch FkBranchNavigation { get; set; }
        public virtual Room FkRoomNavigation { get; set; }
    }
}
