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
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        public string Icon { get; set; }
    }
}