using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace school_register.Services.Extension
{
    public class ClassNameValidation : ValidationAttribute
    {
        private Regex fiscalCode = new Regex(@"^([0-9]{1})([A-Z]{1}|[A-Z]{2}|[A-Z]{3})$");
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (fiscalCode.IsMatch(value.ToString()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("The class name is wrong (Es: '5BI')");
        }

    }
}
