using System;
using System.ComponentModel.DataAnnotations;

namespace school_register.ViewModels
{
    public class BranchViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Branch name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Branch description is required")]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        public string Icon { get; set; }
    }
}