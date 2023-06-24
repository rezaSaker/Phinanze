﻿using Phinanze.Models;
using Phinanze.Models.Validations;
using App.Test.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
                new object[] { new Transaction() { Amount = -10.5, CategoryId = 1, Comment = string.Empty, DailyInfoId = 1 }, false, "Earning amount must be between 0 and 1000000" },

                // Test amount validation
                new object[] { new Transaction() { Amount = 1000000001, CategoryId = 1, Comment = string.Empty, DailyInfoId = 1 }, false, "Earning amount must be between 0 and 1000000" },

                // Test category id validation
                new object[] { new Transaction() { Amount = 150, CategoryId = 0, Comment = string.Empty, DailyInfoId = 1 }, false, "Invalid Category id" },

                // Test category id validation
                new object[] { new Transaction() { Amount = 10000, CategoryId = 1000000001, Comment = string.Empty, DailyInfoId = 1 }, false, "Invalid Category id" },

                // Test comment validation
                new object[] { new Transaction() { Amount = 10006, CategoryId = 1, Comment = string.Empty, DailyInfoId = 1 }, true, string.Empty },

                // Test comment validation
                new object[] { new Transaction() { Amount = 10.5, CategoryId = 1, Comment = StrGenerator.Const(256), DailyInfoId = 0 }, false, "Comment cannot exceed 255 characters" },

                // Test dailyinfo id validation
                new object[] { new Transaction() { Amount = 10.5, CategoryId = 1, Comment = string.Empty, DailyInfoId = 0 }, false, "Invalid DailyInfo id" },

                // Test dailyinfo id validation
                new object[] { new Transaction() { Amount = 10.5, CategoryId = 1, Comment = string.Empty, DailyInfoId = -1 }, false, "Invalid DailyInfo id" },

                // Test dailyinfo id validation
                new object[] { new Transaction() { Amount = 10.5, CategoryId = 1, Comment = string.Empty, DailyInfoId = 1000000001 }, false, "Invalid DailyInfo id" },

                // Test dailyinfo id validation
                new object[] { new Transaction() { Amount = 10.5, CategoryId = 1, Comment = string.Empty, DailyInfoId = 1 }, true, string.Empty },
            };
        }
    }
}
