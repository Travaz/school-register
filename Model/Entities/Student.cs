﻿using System;
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
        [Required(ErrorMessage = "Il codice fiscale è richiesto")]
        [FiscalCodeValidation]
        public string FiscalCode { get; set; }

        [Required(ErrorMessage = "Il nome è richiesto")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Il cognome è richiesto")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "L'età è richiesta")]
        public int Age { get; set; }

        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La data di nascita è richiesta")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "La classe è richiesta")]
        public int? FkClass { get; set; }

        public string Email { get; set; }

        [Display(Name = "Classe")]
        public virtual Class FkClassNavigation { get; set; }

    }
}
