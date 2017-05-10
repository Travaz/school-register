using System.ComponentModel.DataAnnotations;

namespace school_register.ViewModels
{
    public class RoomViewModel
    {
        public int ID {get;set;}
        [Required(ErrorMessage = "Room number is required")]
        public int NumeroAula { get; set; }
        [Required(ErrorMessage = "Room floor is required")]
        public int Floor { get; set; }
        public bool Lim { get; set; }   
    }
}