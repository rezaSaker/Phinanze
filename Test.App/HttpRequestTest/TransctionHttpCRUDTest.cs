using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using System.Linq;

namespace App.Test.HttpRequestTest
{
    // [TestClass]
    public class TransctionHttpCRUDTest
    {
        [TestMethod]
        public void TransactionCRUDTest()
        {
            DeleteAllTransacations();

            int[] earningId_testcase = new int[100];

            //Insertion test
            for (int i = 0; i < 100; i++)
            {
                Transaction earning = new Transaction()
                {
                    Amount = 10 + i,
                    CategoryId = i + 1,
                    Comment = "None",
                    DailyInfoId = i + 1
                };
                earning.Save();
                earningId_testcase[i] = earning.Id;
            }
            Assert.AreEqual(100, Transaction.Get.All().Count);

            // Field insertion accuracy test
            Assert.AreEqual(1, Transaction.Get.One(earningId_testcase[0]).DailyInfoId);
            Assert.AreEqual(1, Transaction.Get.One(earningId_testcase[0]).CategoryId);
            Assert.AreEqual(10, Transaction.Get.One(earningId_testcase[0]).Amount);
            Assert.AreEqual("None", Transaction.Get.One(earningId_testcase[0]).Comment);

            // Lookup test
            Assert.AreEqual(1, Transaction.Get.One(earningId_testcase[0]).DailyInfoId);
            Assert.AreEqual(100, Transaction.Get.One(earningId_testcase[99]).DailyInfoId);

            // Get by specific field value test
            Assert.IsNotNull(Transaction.Get.Where("dailyinfo_id", "100").FirstOrDefault());
            Assert.AreEqual(100, Transaction.Get.Where("dailyinfo_id", "100").FirstOrDefault().DailyInfoId);
            Assert.AreEqual(11, Transaction.Get.Where("amount", 11).FirstOrDefault().Amount);

            // Update test
            Transaction e = Transaction.Get.One(earningId_testcase[0]);
            Assert.IsNotNull(e);
            Assert.AreEqual("None", e.Comment);
            e.Comment = "Update";
            e.Save();
            e = Transaction.Get.One(earningId_testcase[0]);
            Assert.AreEqual("Update", e.Comment);

            // Delete test
            e = Transaction.Get.One(earningId_testcase[99]);
            e.Delete();
            Assert.IsNull(Transaction.Get.One(earningId_testcase[99]));

            // Local copy modification test (should not modify local copy of all earning entries unless the change is saved using Save() method
            e = Transaction.Get.All().First();
            Assert.IsNotNull(e);
            string comment = e.Comment;
            e.Comment = "New Comment";
            Assert.AreEqual(comment, Transaction.Get.All().First().Comment);

            //Delete multiple
            DeleteAllTransacations();
            Assert.AreEqual(0, Transaction.Get.All().Count);
        }

        private void DeleteAllTransacations()
        {
            foreach (Transaction e in Transaction.Get.All())
            {
                e.Delete();
            }
        }
    }
}
