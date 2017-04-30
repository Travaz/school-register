using school_register.Services.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace school_register.Model.Entities
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int ID { get; set; }
        [ClassNameValidation]
        [Required(ErrorMessage = "Class name required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Branch of the class required")]
        public int? FkBranch { get; set; }
        public int? FkRoom { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual Branch FkBranchNavigation { get; set; }
        public virtual Room FkRoomNavigation { get; set; }
    }
}
