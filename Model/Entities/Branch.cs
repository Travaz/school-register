using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace school_register.Model.Entities
{
    public partial class Branch
    {
        public Branch()
        {
            Class = new HashSet<Class>();
        }

        public int ID { get; set; }
        [Required(ErrorMessage = "Branch name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Branch description is required")]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<Class> Class { get; set; }
    }
}
