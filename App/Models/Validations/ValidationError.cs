using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Phinanze.Models.Validations
{
    /// <summary>
    /// A class that represents Validation error for a single model validation
    /// </summary>
    public class ValidationError
    {
        public string ErrorMessage { get; set; }
        public string MemberName { get; set; }

        public ValidationError(ValidationResult error)
        {
            ErrorMessage = error?.ErrorMessage;
            MemberName = error?.MemberNames.FirstOrDefault();
        }
    }
}
