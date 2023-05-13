using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using System.Linq;

namespace Phinanze.Test.HttpRequests
{
    ///////////////////////////////////////////////////////////
    // UNCOMMENT THE FOLLOWING LINE FOR TESTING HTTP REQUESTS
    // [TestClass]
    ///////////////////////////////////////////////////////////
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
            Assert.AreEqual(Expense.Get.One(expenseId_testcase[0]).DailyInfoId, 1);
            Assert.AreEqual(Expense.Get.One(expenseId_testcase[0]).CategoryId, 1);
            Assert.AreEqual(Expense.Get.One(expenseId_testcase[0]).Amount, 10);
            Assert.AreEqual(Expense.Get.One(expenseId_testcase[0]).Comment, "None");

            //Lookup test
            Assert.AreEqual(Expense.Get.One(expenseId_testcase[0]).DailyInfoId, 1);
            Assert.AreEqual(Expense.Get.One(expenseId_testcase[99]).DailyInfoId, 100);
            Assert.AreEqual(Expense.Get.Where("amount", 11).FirstOrDefault().Amount, 11);

            // Get by specific field value test
            Assert.IsNotNull(Expense.Get.Where("dailyinfo_id", "100").FirstOrDefault());
            Assert.AreEqual(Expense.Get.Where("dailyinfo_id", "100").FirstOrDefault().DailyInfoId, 100);

            //Update test
            Expense e = Expense.Get.One(expenseId_testcase[0]);
            Assert.IsNotNull(e);
            Assert.AreEqual(e.Comment, "None");
            e.Comment = "Update";
            e.Save();
            e = Expense.Get.One(expenseId_testcase[0]);
            Assert.AreEqual(e.Comment, "Update");

            // Delete test
            e = Expense.Get.One(expenseId_testcase[99]);
            e.Delete();
            Assert.IsNull(Expense.Get.One(expenseId_testcase[99]));

            //Delete multiple
            DeleteAllExpenses();
            Assert.AreEqual(Expense.Get.All().Count, 0);
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
