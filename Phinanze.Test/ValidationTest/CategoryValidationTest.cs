using Phinanze.Models.Validations;
using Phinanze.Models;
using Phinanze.Test.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Test.ValidationTest
{
    public class CategoryValidationTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void DailyinfoValidationTest(string name, string type, bool expectValid, string msg)
        {
            Category c = new()
            {
                CategoryType = type,
                Name = name
            };

            EntityValidationResult validationResult = EntityValidator.Validate(c);
            Assert.That(validationResult.IsValid, Is.EqualTo(expectValid));

            if (!validationResult.IsValid)
            {
                Assert.That(validationResult.Errors[0].ErrorMessage, Is.EqualTo(msg));
            }
        }

        private static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                //Params: Category name, category type, Expected validation result, Expected validation error message              

                //Category name validation test cases
                yield return new TestCaseData(null, "Earning", false, "Category name is required").SetName("Validation Test 1");
                yield return new TestCaseData("", "Earning", false, "Category name is required").SetName("Validation Test 2");
                yield return new TestCaseData(StrGenerator.Rand(51), "Earning", false, "Category name cannot exceed 50 characters").SetName("Validation Test 3");
                yield return new TestCaseData("Groccery", "Expense", true, "").SetName("Validation Test 4");
                yield return new TestCaseData("Salary", "Earning", true, "").SetName("Validation Test 5");

                //Category type validation test cases
                yield return new TestCaseData("Salary", null, false, "Category type is required").SetName("Validation Test 6");
                yield return new TestCaseData("Salary", "", false, "Category type is required").SetName("Validation Test 7");
                yield return new TestCaseData("Salary", "Savings", false, "Invalid category type").SetName("Validation Test 8");
            }
        }
    }
}
