using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Helpers
{
    public class UpperFirstLetter : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(value.ToString())) {
                return ValidationResult.Success;
            }

            var firstLetter = value.ToString()[0].ToString();

            if (firstLetter != firstLetter.ToUpper())
                return new ValidationResult("The first letter has to be in upper case.");

            return ValidationResult.Success;
        }
    }
}
