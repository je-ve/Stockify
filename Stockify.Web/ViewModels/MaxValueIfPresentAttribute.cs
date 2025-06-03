using System.ComponentModel.DataAnnotations;
namespace Stockify.Web.ViewModels;
public class MaxValueIfPresentAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var maxProp = validationContext.ObjectType.GetProperty("MaxValue");
        if (maxProp == null)
            return ValidationResult.Success;

        var maxValueObj = maxProp.GetValue(validationContext.ObjectInstance);
        if (maxValueObj is not int max)
            return ValidationResult.Success;

        if (value is not int current)
            return ValidationResult.Success;

        if (current > max)
            return new ValidationResult(ErrorMessage ?? $"De waarde mag niet groter zijn dan {max}.");

        return ValidationResult.Success;
    }
}