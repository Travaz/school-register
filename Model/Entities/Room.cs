using System;
using System.Collections.Generic;

namespace school_register.Model.Entities
{
    public partial class Room
    {
        public Room()
        {
            Class = new HashSet<Class>();
        }

        public int IdRoom { get; set; }
        public int Floor { get; set; }
        public bool Lim { get; set; }
        public int NumeroAula { get; set; }

        public virtual ICollection<Class> Class { get; set; }
    }
}
