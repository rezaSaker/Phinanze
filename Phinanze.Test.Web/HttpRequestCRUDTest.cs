using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using System.Linq;

namespace Phinanze.Test.Web
{
    [TestClass]
    public class HttpRequestCRUDTest
    {
        /// <summary>
        /// Earning Model CRUD Test
        /// </summary>
        [TestMethod]
        public void EarningCRUDTest()
        {
            DeleteAllEarnings();

            int[] earningId_testcase = new int[100];

            //Insertion test
            for (int i = 0; i < 100; i++)
            {
                Earning earning = new Earning()
                {
                    Amount = 10 + i,
                    CategoryId = i + 1,
                    Comment = "None",
                    DailyInfoId = i + 1
                };
                earning.Save();
                earningId_testcase[i] = earning.Id;
            }
            Assert.AreEqual(Earning.GetAll().Count, 100);

            // Field insertion accuracy test
            Assert.AreEqual(Earning.Find(earningId_testcase[0]).DailyInfoId, 1);
            Assert.AreEqual(Earning.Find(earningId_testcase[0]).CategoryId, 1);
            Assert.AreEqual(Earning.Find(earningId_testcase[0]).Amount, 10);
            Assert.AreEqual(Earning.Find(earningId_testcase[0]).Comment, "None");

            // Lookup test
            Assert.AreEqual(Earning.Find(earningId_testcase[0]).DailyInfoId, 1);
            Assert.AreEqual(Earning.Find(earningId_testcase[99]).DailyInfoId, 100);

            // Get by specific field value test
            Assert.IsNotNull(Earning.GetBy("dailyinfo_id", "100").FirstOrDefault());

            // Update test
            Earning e = Earning.Find(earningId_testcase[0]);
            Assert.IsNotNull(e);
            Assert.AreEqual(e.Comment, "None");
            e.Comment = "Update";
            e.Save();
            Assert.AreEqual(e.Comment, "Update");

            // Delete test
            e = Earning.Find(earningId_testcase[99]);
            Earning.Delete(ref e);
            Assert.IsNull(e);
            Assert.IsNull(Earning.Find(earningId_testcase[99]));

            //Delete multiple
            e = Earning.Find(earningId_testcase[10]);
            Assert.IsNotNull(e);
            DeleteAllEarnings();
            //Assert.IsNull(e);
            Assert.AreEqual(Earning.GetAll().Count, 0);
        }

        /// <summary>
        /// Expense Model CRUD Test
        /// </summary>
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
            Assert.AreEqual(Expense.GetAll().Count, 100);

            // Field insertion accuracy test
            Assert.AreEqual(Expense.Find(expenseId_testcase[0]).DailyInfoId, 1);
            Assert.AreEqual(Expense.Find(expenseId_testcase[0]).CategoryId, 1);
            Assert.AreEqual(Expense.Find(expenseId_testcase[0]).Amount, 10);
            Assert.AreEqual(Expense.Find(expenseId_testcase[0]).Comment, "None");

            //Lookup test
            Assert.AreEqual(Expense.Find(expenseId_testcase[0]).DailyInfoId, 1);
            Assert.AreEqual(Expense.Find(expenseId_testcase[99]).DailyInfoId, 100);

            // Get by specific field value test
            Assert.IsNotNull(Expense.GetBy("dailyinfo_id", "100").FirstOrDefault());

            //Update test
            Expense e = Expense.Find(expenseId_testcase[0]);
            Assert.IsNotNull(e);
            Assert.AreEqual(e.Comment, "None");
            e.Comment = "Update";
            e.Save();
            Assert.AreEqual(e.Comment, "Update");

            // Delete test
            e = Expense.Find(expenseId_testcase[99]);
            Expense.Delete(ref e);
            Assert.IsNull(e);
            Assert.IsNull(Expense.Find(expenseId_testcase[99]));

            //Delete multiple
            e = Expense.Find(expenseId_testcase[10]);
            Assert.IsNotNull(e);
            DeleteAllExpenses();
            //Assert.IsNull(e);
            Assert.AreEqual(Expense.GetAll().Count, 0);
        }

        private void DeleteAllEarnings()
        {
            foreach (Earning e in Earning.GetAll())
            {
                Earning temp = e;
                Earning.Delete(ref temp);
            }
        }

        private void DeleteAllExpenses()
        {
            foreach (Expense e in Expense.GetAll())
            {
                Expense temp = e;
                Expense.Delete(ref temp);
            }
        }
    }
}
