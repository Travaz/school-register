using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using school_register.Services.Extension;

namespace school_register.Model.Entities
{
    public enum Gender
    {
        Female,
        Male
    }

    public partial class Student
    {
        public int ID { get; set; }

        [Display(Name="Fiscal Code")]
        [Required(ErrorMessage = "Fiscal code is required")]
        [FiscalCodeValidation]
        public string FiscalCode { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Birthday is required")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Class is required")]
        public int? FkClass { get; set; }

        public string Email { get; set; }

        [Display(Name = "Classe")]
        public virtual Class FkClassNavigation { get; set; }

    }
}
