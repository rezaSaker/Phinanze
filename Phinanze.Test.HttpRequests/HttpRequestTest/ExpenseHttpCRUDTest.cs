using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using System.Linq;

namespace Phinanze.Test.App.HttpRequestTest
{
    // [TestClass]
    public class ExpenseHttpCRUDTest
    {
        [TestMethod]
        public void ExpenseCRUDTest()
        {
            DeleteAllExpenses();

            int[] expenseId_testcase = new int[100];

            //Insertion test
            for (int i = 0; i < 100; i++)
            {
                Expense expense = new Expense()
                {
                    Amount = 10 + i,
                    CategoryId = i + 1,
                    Comment = "None",
                    DailyInfoId = i + 1
                };
                expense.Save();
                expenseId_testcase[i] = expense.Id;
            }
            Assert.AreEqual(Expense.Get.All().Count, 100);

            // Field insertion accuracy test
            Assert.AreEqual(1, Expense.Get.One(expenseId_testcase[0]).DailyInfoId);
            Assert.AreEqual(1, Expense.Get.One(expenseId_testcase[0]).CategoryId);
            Assert.AreEqual(10, Expense.Get.One(expenseId_testcase[0]).Amount);
            Assert.AreEqual("None", Expense.Get.One(expenseId_testcase[0]).Comment);

            //Lookup test
            Assert.AreEqual(1, Expense.Get.One(expenseId_testcase[0]).DailyInfoId);
            Assert.AreEqual(100, Expense.Get.One(expenseId_testcase[99]).DailyInfoId);
            Assert.AreEqual(11, Expense.Get.Where("amount", 11).FirstOrDefault().Amount);

            // Get by specific field value test
            Assert.IsNotNull(Expense.Get.Where("dailyinfo_id", "100").FirstOrDefault());
            Assert.AreEqual(100, Expense.Get.Where("dailyinfo_id", "100").FirstOrDefault().DailyInfoId);

            //Update test
            Expense e = Expense.Get.One(expenseId_testcase[0]);
            Assert.IsNotNull(e);
            Assert.AreEqual("None", e.Comment);
            e.Comment = "Update";
            e.Save();
            e = Expense.Get.One(expenseId_testcase[0]);
            Assert.AreEqual("Update", e.Comment);

            // Delete test
            e = Expense.Get.One(expenseId_testcase[99]);
            e.Delete();
            Assert.IsNull(Expense.Get.One(expenseId_testcase[99]));

            // Local copy modification test (should not modify local copy of all expense entries unless the change is saved using Save() method
            e = Expense.Get.All().First();
            Assert.IsNotNull(e);
            string comment = e.Comment;
            e.Comment = "New Comment";
            Assert.AreEqual(comment, Expense.Get.All().First().Comment);

            //Delete multiple
            DeleteAllExpenses();
            Assert.AreEqual(0, Expense.Get.All().Count);
        }

        private void DeleteAllExpenses()
        {
            foreach (Expense e in Expense.Get.All())
            {
                e.Delete();
            }
        }
    }
}
