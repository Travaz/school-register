using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace school_register.Services.Extension
{
    public class FiscalCodeValidation : ValidationAttribute
    {
        private Regex fiscalCode = new Regex(@"^[A-Za-z]{6}[0-9]{2}[A-Za-z]{1}[0-9]{2}[A-Za-z]{1}[0-9]{3}[A-Za-z]{1}$");
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (fiscalCode.IsMatch(value.ToString()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Il codice fiscale non è corretto (16 caratteri)");
        }

    }
}
