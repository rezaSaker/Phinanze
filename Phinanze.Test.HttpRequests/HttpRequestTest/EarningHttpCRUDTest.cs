using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using System.Linq;

namespace Phinanze.Test.App.HttpRequestTest
{
    // [TestClass]
    public class EarningHttpCRUDTest
    {
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
            Assert.AreEqual(100, Earning.Get.All().Count);

            // Field insertion accuracy test
            Assert.AreEqual(1, Earning.Get.One(earningId_testcase[0]).DailyInfoId);
            Assert.AreEqual(1, Earning.Get.One(earningId_testcase[0]).CategoryId);
            Assert.AreEqual(10, Earning.Get.One(earningId_testcase[0]).Amount);
            Assert.AreEqual("None", Earning.Get.One(earningId_testcase[0]).Comment);

            // Lookup test
            Assert.AreEqual(1, Earning.Get.One(earningId_testcase[0]).DailyInfoId);
            Assert.AreEqual(100, Earning.Get.One(earningId_testcase[99]).DailyInfoId);

            // Get by specific field value test
            Assert.IsNotNull(Earning.Get.Where("dailyinfo_id", "100").FirstOrDefault());
            Assert.AreEqual(100, Earning.Get.Where("dailyinfo_id", "100").FirstOrDefault().DailyInfoId);
            Assert.AreEqual(11, Earning.Get.Where("amount", 11).FirstOrDefault().Amount);

            // Update test
            Earning e = Earning.Get.One(earningId_testcase[0]);
            Assert.IsNotNull(e);
            Assert.AreEqual("None", e.Comment);
            e.Comment = "Update";
            e.Save();
            e = Earning.Get.One(earningId_testcase[0]);
            Assert.AreEqual("Update", e.Comment);

            // Delete test
            e = Earning.Get.One(earningId_testcase[99]);
            e.Delete();
            Assert.IsNull(Earning.Get.One(earningId_testcase[99]));

            // Local copy modification test (should not modify local copy of all earning entries unless the change is saved using Save() method
            e = Earning.Get.All().First();
            Assert.IsNotNull(e);
            string comment = e.Comment;
            e.Comment = "New Comment";
            Assert.AreEqual(comment, Earning.Get.All().First().Comment);

            //Delete multiple
            DeleteAllEarnings();
            Assert.AreEqual(0, Earning.Get.All().Count);
        }

        private void DeleteAllEarnings()
        {
            foreach (Earning e in Earning.Get.All())
            {
                e.Delete();
            }
        }
    }
}
