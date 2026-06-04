using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.CustomValidation
{
    public class CustomValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult("Failed to pass custom validation" );
            // Custom validation logic here
            return ValidationResult.Success;
        }
    }
}


