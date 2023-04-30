using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Phinanze.Models.Validations
{
    /// <summary>
    /// Class that represents the result of a single validation
    /// </summary>
    public class EntityValidationResult
    {
        public List<ValidationError> Errors { get; set; }
        public bool IsValid { get; set; } 

        public EntityValidationResult(List<ValidationResult> errors)
        {
            Errors = new List<ValidationError>();

            foreach(ValidationResult error in errors)
            {
                Errors.Add(new ValidationError(error));
            }
            IsValid = errors.Count == 0;
        }
    }
}
