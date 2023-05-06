using Phinanze.Models.Validations;
using Phinanze.Models;
using Phinanze.Test.Utils;

namespace Phinanze.Test.ValidationTest
{
    public class DailyInfoValidationTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void DailyinfoValidationTest(DateTime date, string note, bool expectValid, string msg)
        {
            DailyInfo2 d = new()
            {
                Date = date,
                Note = note
            };

            EntityValidationResult validationResult = EntityValidator.Validate(d);
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
                //Params: Date, Note, Expected validation result, Expected validation error message              

                //Date validation test cases
                yield return new TestCaseData(null, "None", false, "Invalid date").SetName("Validation Test 1");
                yield return new TestCaseData(null, null, false, "Invalid date").SetName("Validation Test 2");
                yield return new TestCaseData(DateTime.Today, "", true, "").SetName("Validation Test 3");

                //Note validation test cases
                yield return new TestCaseData(DateTime.Today, "", true, "").SetName("Validation Test 4");
                yield return new TestCaseData(DateTime.Today, null, true, "").SetName("Validation Test 5");
                yield return new TestCaseData(DateTime.Today, StrGenerator.Rand(256), false, "Note cannot exceed 255 characters").SetName("Validation Test 6");
            }
        }
    }
}
