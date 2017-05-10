using System.ComponentModel.DataAnnotations;
using school_register.Services.Extension;

namespace school_register.ViewModels
{
    public class ClassViewModel
    {
        public int ID { get; set; }
        [ClassNameValidation]
        [Required(ErrorMessage = "Class name required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Branch of the class required")]
        [Display(Name = "Branch")]
        public int? FkBranch { get; set; }
        [Display(Name = "Room")]
        public int? FkRoom { get; set; }
        
    }
}