using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestSearchTask.Validation
{
    public class CheckFutureDateAttribute : ValidationAttribute
    {
        public CheckFutureDateAttribute()
            : base("{0} must be a future date.")
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && (DateTime)value != DateTime.MinValue)
            {
                var date = (DateTime)value;
                int result = DateTime.Compare(date, DateTime.Today);
                if (result < 0)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}