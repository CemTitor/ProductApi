using System.ComponentModel.DataAnnotations;

namespace ProductApi.Base
{
    public class ProductCategoryAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (value is null)
                    return ValidationResult.Success;

                if (Enum.IsDefined(typeof(CategoryEnum), value))
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Invalid Category field.");
            }
            catch (Exception)
            {
                return new ValidationResult("Invalid Category field.");
            }
        }
    }
}