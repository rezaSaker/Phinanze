using Phinanze.Models;
using Phinanze.Models.Validations;
using App.Test.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace App.Test.ValidationTest
{
    [TestClass]
    public class TransactionValidationTest
    {
        [DataTestMethod]
        [DynamicData(nameof(TestCases), DynamicDataSourceType.Method)]
        public void TransactionModelValidationTest(Transaction e, bool expectValid, string msg)
        {
            EntityValidationResult validationResult = EntityValidator.Validate(e);
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
                // Test amount validation
                new object[] { new Transaction() { Amount = -10.5, CategoryId = 1, Note = string.Empty, Date = DateTime.Today }, false, "Amount must be between 0 and 1000000" },

                // Test amount validation
                new object[] { new Transaction() { Amount = 1000000001, CategoryId = 1, Note = string.Empty, Date = DateTime.Today }, false, "Amount must be between 0 and 1000000" },

                // Test category id validation
                new object[] { new Transaction() { Amount = 150, CategoryId = 0, Note = string.Empty, Date = DateTime.Today }, false, "Invalid Category id" },

                // Test category id validation
                new object[] { new Transaction() { Amount = 10000, CategoryId = 1000000001, Note = string.Empty, Date = DateTime.Today }, false, "Invalid Category id" },

                // Test Note validation
                new object[] { new Transaction() { Amount = 10006, CategoryId = 1, Note = string.Empty, Date = DateTime.Today }, true, string.Empty },

                // Test Note validation
                new object[] { new Transaction() { Amount = 10.5, CategoryId = 1, Note = StrGenerator.Const(256), Date = DateTime.Today }, false, "Note cannot exceed 255 characters" },
            };
        }
    }
}
