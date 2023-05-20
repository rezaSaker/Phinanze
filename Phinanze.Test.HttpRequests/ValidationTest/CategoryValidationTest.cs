using Phinanze.Models;
using Phinanze.Models.Validations;
using Phinanze.Test.App.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Phinanze.Test.App.ValidationTest
{
    [TestClass]
    public class CategoryValidationTest
    {
        [DataTestMethod]
        [DynamicData(nameof(TestCases), DynamicDataSourceType.Method)]
        public void TestCategoryModelValidations(string name, string type, bool expectValid, string msg)
        {
            Category c = new Category()
            {
                CategoryType = type,
                Name = name
            };

            EntityValidationResult validationResult = EntityValidator.Validate(c);
            Assert.AreEqual(expectValid, validationResult.IsValid);

            if (!validationResult.IsValid)
            {
                Assert.AreEqual(msg, validationResult.Errors[0].ErrorMessage);
            }
        }

        private static IEnumerable<object[]> TestCases()
        {
            return new List<object[]>
            {
                //Params: Category name, category type, Expected validation result, Expected validation error message              

                //Category name validation test cases
                new object[] { null, "Earning", false, "Category name is required" },
                new object[] { "", "Earning", false, "Category name is required" },
                new object[] { StrGenerator.Rand(51), "Earning", false, "Category name cannot exceed 50 characters" },
                new object[] { "Groccery", "Expense", true, "" },
                new object[] { "Salary", "Earning", true, "" },

                //Category type validation test cases
                new object[] { "Salary", null, false, "Category type is required" },
                new object[] { "Salary", "", false, "Category type is required" },
                new object[] { "Salary", "Savings", false, "Invalid category type" }
            };
        }
    }
}
