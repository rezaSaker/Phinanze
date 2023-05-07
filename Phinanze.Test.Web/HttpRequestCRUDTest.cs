using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;
using Phinanze.Models;
using Phinanze.Models.Statics;
using System.Runtime.InteropServices;
using Phinanze.Utils;

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
            Earning.Delete(e);
            Assert.IsNull(Earning.Find(earningId_testcase[99]));

            //Delete multiple
            DeleteAllEarnings();
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
            Expense.Delete(e);
            Assert.IsNull(Expense.Find(expenseId_testcase[99]));

            //Delete multiple
            DeleteAllExpenses();
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
            DailyInfo2.Delete(d);
            Assert.IsNull(DailyInfo2.Find(dailyinfoId_testcase[99]));

            // Delete multiple
            DeleteAllDailyinfo();
            Assert.AreEqual(DailyInfo2.GetAll().Count, 0);
        }

        /// <summary>
        /// Category model CRUD test
        /// </summary>
        [TestMethod]
        public void categoryCRUDTest()
        {
            DeleteAllCategories();

            int[] categoryId_testcase = new int[100];

            // Insertion test
            for (int i = 0; i < 100; i++)
            {
                Category category = new Category()
                {
                    Name = "Category " + (i+1),
                    CategoryType = i<50? "Earning" : "Expense"
                };
                category.Save();
                categoryId_testcase[i] = category.Id;
            }
            Assert.AreEqual(Category.GetAll().Count, 100);

            // Field insertion accuracy test
            Assert.AreEqual(Category.Find(categoryId_testcase[0]).Name, "Category 1");
            Assert.AreEqual(Category.Find(categoryId_testcase[0]).CategoryType, "Earning");

            // Lookup test
            Assert.AreEqual(Category.Find(categoryId_testcase[99]).Name, "Category 100");
            Assert.AreEqual(Category.Find(categoryId_testcase[99]).CategoryType, "Expense");

            // Get by specific field value test
            Assert.IsNotNull(Category.GetBy("name", "Category 1").FirstOrDefault());
            Assert.AreEqual(Category.GetBy("category_type", "Earning").Count, 50);
            Assert.AreEqual(Category.GetBy("name", "Category 51").FirstOrDefault().CategoryType, "Expense");

            // Update test
            Category c = Category.Find(categoryId_testcase[0]);
            Assert.IsNotNull(c);
            Assert.AreEqual(c.Name, "Category 1");
            c.Name = "Category Updated";
            c.Save();
            c = Category.Find(categoryId_testcase[0]);
            Assert.AreEqual(c.Name, "Category Updated");

            // Delete test
            c = Category.Find(categoryId_testcase[99]);
            Category.Delete(c);
            Assert.IsNull(Category.Find(categoryId_testcase[99]));

            // Delete multiple
            DeleteAllCategories();
            Assert.AreEqual(Category.GetAll().Count, 0);
        }


        private void DeleteAllEarnings()
        {
            foreach (Earning e in Earning.GetAll())
            {
                Earning.Delete(e);
            }
        }

        private void DeleteAllExpenses()
        {
            foreach (Expense e in Expense.GetAll())
            {
                Expense.Delete(e);
            }
        }

        private void DeleteAllDailyinfo()
        {
            foreach (DailyInfo2 d in DailyInfo2.GetAll())
            {
                DailyInfo2.Delete(d);
            }
        }

        private void DeleteAllCategories()
        {
            foreach (Category c in Category.GetAll())
            {
                Category.Delete(c);
            }
        }
    }
}
