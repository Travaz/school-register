using System;
using System.Collections.Generic;

namespace school_register.Model.Entities
{
    public partial class Rooms
    {
        public Rooms()
        {
            Classes = new HashSet<Classes>();
        }

        public int IdRoom { get; set; }
        public int Floor { get; set; }
        public bool Lim { get; set; }
        public string NumeroAula { get; set; }

        public virtual ICollection<Classes> Classes { get; set; }
    }
}
