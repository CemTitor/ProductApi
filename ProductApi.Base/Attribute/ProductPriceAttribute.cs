using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ProductApi.Base
{
    public class ProductPriceAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        { 
            try
            {
                if (value is null)
                    return new ValidationResult("Invalid Price field.");

                if (Regex.IsMatch(value.ToString(), @"^\d{1,3}(?:[.,]\d{3})*(?:[.,]\d{2})$", RegexOptions.Compiled))
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Invalid Price field.");
            }
            catch
            {
                return new ValidationResult("Invalid Price field.");
            }
        }
    }
}