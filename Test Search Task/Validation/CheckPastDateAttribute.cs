using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_Search_Task.Validation
{
    public class CheckPastDateAttribute : ValidationAttribute
    {
        public CheckPastDateAttribute()
            : base("{0} must be within the past 30 days.")
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && (DateTime)value != DateTime.MinValue)
            {
                DateTime thirtyDaysAgo = DateTime.Today.AddDays(-30);
                DateTime t = Convert.ToDateTime(value);
                if (t < thirtyDaysAgo || t > DateTime.Today)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }

    }
}