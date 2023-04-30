using System;
using System.ComponentModel.DataAnnotations;
using Phinanze.Models.Repositories;

namespace Phinanze.Models
{
    public class Category: CategoryRepository, IModel
    {
        public Category() 
        {
            _id = 0;
            Model = this; 
        }

        private int _id;
        private string _categoryType;
        private string _name;

        [Key]
        public int Id
        {
            get => _id;
            set
            {
                if(_id == 0)
                {
                    _id = value;
                }
                else
                {
                    throw new ArgumentException("Model id property cannot be changed");
                }
            }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Category name is required")]
        [StringLength(50, ErrorMessage = "Category name cannot exceed 50 characters")]
        public string Name
        {
            get => _name; 
            set => _name = value; 
        }

        [Required(ErrorMessage = "Category type is required")]
        [RegularExpression("(" + Statics.CategoryType.EARNING + "|" + Statics.CategoryType.EXPENSE + ")",
                            ErrorMessage = "Invalid category type - neither Earning nor Expense")]
        public string CategoryType
        {
            get => _categoryType;
            set => _categoryType = value;
        }
    }
}
