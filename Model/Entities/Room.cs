using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace school_register.Model.Entities
{
    public partial class Room
    {
        public Room()
        {
            Classes = new HashSet<Class>();
        }

        public int ID {get;set;}
        [Required(ErrorMessage = "Room number is required")]
        public int NumeroAula { get; set; }
        [Required(ErrorMessage = "Room floor is required")]
        public int Floor { get; set; }
        public bool Lim { get; set; }


        public virtual ICollection<Class> Classes { get; set; }
    }
}
