using System;
using System.ComponentModel.DataAnnotations;
using Phinanze.Models.Repositories;
using Phinanze.Models.Validations;

namespace Phinanze.Models
{
    public class Category: CategoryRepository, IModel
    {
        public Category()  { Model = this; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Category name is required")]
        [StringLength(50, ErrorMessage = "Category name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category type is required")]
        [CustomValidation(typeof(CustomValidations), "ValidCategoryType")]
        public string CategoryType { get; set; }
    }
}
