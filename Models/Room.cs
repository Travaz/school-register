using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace school_register.Models
{
    public partial class Room
    {
        public Room()
        {
            Classes = new HashSet<Class>();
        }

        public int ID {get;set;}
        public int NumeroAula { get; set; }
        public int Floor { get; set; }
        public bool Lim { get; set; }


        public virtual ICollection<Class> Classes { get; set; }
    }
}
