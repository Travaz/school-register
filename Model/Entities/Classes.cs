using System;
using System.Collections.Generic;

namespace school_register.Model.Entities
{
    public partial class Classes
    {
        public Classes()
        {
            Students = new HashSet<Students>();
        }

        public int IdClass { get; set; }
        public int FkBranch { get; set; }
        public int FkRoom { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Students> Students { get; set; }
        public virtual Branch FkBranchNavigation { get; set; }
        public virtual Rooms FkRoomNavigation { get; set; }
    }
}
