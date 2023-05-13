using Phinanze.Models.Validations;
using Phinanze.Models;
using Phinanze.Test.App.Utils;

namespace Phinanze.Test.App.ValidationTest
{
    public class DailyInfoValidationTest
    {
        [Theory]
        [MemberData(nameof(TestCases))]
        public void TestDailyInfoModelValidations(DateTime date, string note, bool expectValid, string msg)
        {
            DailyInfo2 d = new()
            {
                Date = date,
                Note = note
            };

            EntityValidationResult validationResult = EntityValidator.Validate(d);
            Assert.Equal(expectValid, validationResult.IsValid);

            if (!validationResult.IsValid)
            {
                Assert.Equal(msg, validationResult.Errors[0].ErrorMessage);
            }
        }

        private static IEnumerable<object[]> TestCases()
        {
            return new List<object[]>
            {
                //Params: Date, Note, Expected validation result, Expected validation error message              

                //Date validation test cases
                new object[] { null, "None", false, "Invalid date" },
                new object[] { null, null, false, "Invalid date" },
                new object[] { DateTime.Today, "", true, "" },

                //Note validation test cases
                new object[] { DateTime.Today.Date, "", true, "" },
                new object[] { DateTime.Today, null, true, "" },
                new object[] { DateTime.Today, StrGenerator.Rand(256), false, "Note cannot exceed 255 characters" }
            };
        }
    }
}
