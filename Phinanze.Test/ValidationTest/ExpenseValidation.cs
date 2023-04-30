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
    public class ExpenseValidation
    {
        [SetUp]
        public void Setup() { }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void ExpenseValidationTest(double amt, int cId, string cmt, int dId, bool expectValid, string msg)
        {
            Expense e = new()
            {
                Amount = amt,
                CategoryId = cId,
                Comment = cmt,
                DailyInfoId = dId
            };
            EntityValidationResult validationResult = EntityValidator.Validate(e);

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
                //Params: Amount, Category name, Category type, Comment, dailyInfoId, Expected validation result, Expected validation error message              

                //Amount validation test cases
                yield return new TestCaseData(-10.5, 1, "", 1, false, "Earning amount must be between 0 and 1000000").SetName("Validation Test 1");
                yield return new TestCaseData(1000000001, 1, "", 1, false, "Earning amount must be between 0 and 1000000").SetName("Validation Test 2");

                //Category Id validation test cases
                yield return new TestCaseData(150, 0, "", 1, false, "Invalid Category id").SetName("Validation Test 3");
                yield return new TestCaseData(10000, 1000000001, "", 1, false, "Invalid Category id").SetName("Validation Test 4");
                yield return new TestCaseData(10006, 1, "", 1, true, "").SetName("Validation Test 5");


                //Comment validation test cases
                yield return new TestCaseData(10.5, 1, StrGenerator.Const(256), 0, false, "Comment cannot exceed 255 characters").SetName("Validation Test 9");

                //DailyInfo Id validation test cases
                yield return new TestCaseData(10.5, 1, "", 0, false, "Invalid DailyInfo id").SetName("Validation Test 10");
                yield return new TestCaseData(10.5, 1, "", -1, false, "Invalid DailyInfo id").SetName("Validation Test 11");
                yield return new TestCaseData(10.5, 1, "", 1000000001, false, "Invalid DailyInfo id").SetName("Validation Test 12");

                //Valid earning test cases
                yield return new TestCaseData(10.5, 1, "", 1, true, "").SetName("Validation Test 13");
            }
        }
    }
}
