using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    internal class DateRangeAttribute : ValidationAttribute
    {
        private readonly DateTime toDate;
        private readonly DateTime fromDate;

        public DateRangeAttribute(string to = null, string from = null)
        {
            toDate = to is null ? DateTime.UtcNow : DateTime.Parse(to);
            fromDate = from is null ? DateTime.MinValue : DateTime.Parse(from);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isValid = true;
            if (value is null) isValid = false;
            if (value is DateTime == false) isValid = false;
            var date = (DateTime)value;
            if (date > toDate)
                isValid = false;
            if (date < fromDate)
                isValid = false;

            if (isValid)
                return ValidationResult.Success;
            else
                return new ValidationResult($"{validationContext.MemberName} for {validationContext.ObjectType.Name} needs to be a valid date in the past.");
        }
    }
}
