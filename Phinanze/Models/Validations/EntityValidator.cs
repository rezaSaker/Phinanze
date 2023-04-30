using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Phinanze.Models.Validations
{
    /// <summary>
    /// Validator class for Model properties
    /// </summary>
    public class EntityValidator
    {
        public static EntityValidationResult Validate(IModel model)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(model);
            Validator.TryValidateObject(model, validationContext, results, true);
            return new EntityValidationResult(results);
        }

        //public static ValidationResult ValidateProperty(IModel model)
        //{
        //    EntityValidationResult result = Validate(model);
        //    if (!result.IsValid)
        //    {
        //        return new ValidationResult(result.Errors[0].ErrorMessage);
        //    }
        //    return null;
        //}

        // Custom validator for earning category
        //public static ValidationResult ValidateEarningCategory(Category model)
        //{
        //    string errorMessage = "Invalid category";

        //    EntityValidationResult result = Validate(model);

        //    if (!result.IsValid)
        //    {
        //        return new ValidationResult(errorMessage + ": " + result.Errors[0].ErrorMessage);
        //    }
        //    else if(model.CategoryType != CategoryType.EARNING)
        //    {
        //        return new ValidationResult(errorMessage + ": Category type must be Earning");
        //    }
        //    return null;
        //}

    }
}
