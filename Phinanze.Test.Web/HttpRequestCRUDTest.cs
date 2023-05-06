using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;
using Phinanze.Models;
using System.Runtime.InteropServices;

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
            Assert.AreEqual(Earning.GetBy("dailyinfo_id", "100").FirstOrDefault().DailyInfoId, 100);

            // Update test
            Earning e = Earning.Find(earningId_testcase[0]);
            Assert.IsNotNull(e);
            Assert.AreEqual(e.Comment, "None");
            e.Comment = "Update";
            e.Save();
            e = Earning.Find(earningId_testcase[0]);
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
            Assert.AreEqual(Expense.GetBy("dailyinfo_id", "100").FirstOrDefault().DailyInfoId, 100);

            //Update test
            Expense e = Expense.Find(expenseId_testcase[0]);
            Assert.IsNotNull(e);
            Assert.AreEqual(e.Comment, "None");
            e.Comment = "Update";
            e.Save();
            e = Expense.Find(expenseId_testcase[0]);
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

        /// <summary>
        /// DailyInfo model CRUD test
        /// </summary>
        [TestMethod]
        public void DailyinfoCRUDTest()
        {
            DeleteAllDailyinfo();

            int[] dailyinfoId_testcase = new int[100];
            DateTime[] dailyinfoDate_testcase = new DateTime[100];

            // Insertion test
            for (int i = 0; i < 100; i++)
            {
                dailyinfoDate_testcase[i] = DateTime.Now;
                DailyInfo2 dailyinfo = new DailyInfo2()
                {
                    Date = dailyinfoDate_testcase[i],
                    Note = "Note " + (i+1)
                };
                dailyinfo.Save();
                dailyinfoId_testcase[i] = dailyinfo.Id;
            }
            Assert.AreEqual(DailyInfo2.GetAll().Count, 100);

            // Field insertion accuracy test
            Assert.AreEqual(DailyInfo2.Find(dailyinfoId_testcase[0]).Date, dailyinfoDate_testcase[0].Date);
            Assert.AreEqual(DailyInfo2.Find(dailyinfoId_testcase[0]).Note, "Note 1");

            // Lookup test
            Assert.AreEqual(DailyInfo2.Find(dailyinfoId_testcase[99]).Date, dailyinfoDate_testcase[99].Date);
            Assert.AreEqual(DailyInfo2.Find(dailyinfoId_testcase[99]).Note, "Note 100");

            // Get by specific field value test
            Assert.IsNotNull(DailyInfo2.GetBy("Note", "Note 100").FirstOrDefault());
            Assert.AreEqual(DailyInfo2.GetBy("Note", "Note 100").FirstOrDefault().Note, "Note 100");

            // Update test
            DailyInfo2 d = DailyInfo2.Find(dailyinfoId_testcase[0]);
            Assert.IsNotNull(d);
            Assert.AreEqual(d.Note, "Note 1");
            d.Note = "Note Updated";
            d.Save();
            d = DailyInfo2.Find(dailyinfoId_testcase[0]);
            Assert.AreEqual(d.Note, "Note Updated");

            // Delete test
            d = DailyInfo2.Find(dailyinfoId_testcase[99]);
            DailyInfo2.Delete(ref d);
            Assert.IsNull(d);
            Assert.IsNull(DailyInfo2.Find(dailyinfoId_testcase[99]));

            // Delete multiple
            d = DailyInfo2.Find(dailyinfoId_testcase[10]);
            Assert.IsNotNull(d);
            DeleteAllDailyinfo();
            //Assert.IsNull(e);
            Assert.AreEqual(DailyInfo2.GetAll().Count, 0);
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

        private void DeleteAllDailyinfo()
        {
            foreach (DailyInfo2 d in DailyInfo2.GetAll())
            {
                DailyInfo2 temp = d;
                DailyInfo2.Delete(ref temp);
            }
        }
    }
}
