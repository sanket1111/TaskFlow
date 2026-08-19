using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Web.Validation
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue)
            {
                if (dateValue.Date < DateTime.Today)
                {
                    return new ValidationResult(ErrorMessage ?? "The date must be in the future.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
