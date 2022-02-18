using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laureado_Ejercicio.Validation
{
    public class ValidateDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToDateTime(value) < DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("La fecha no puede ser superior al día actual.");
            }
        }
    }
}