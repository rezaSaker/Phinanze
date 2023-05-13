using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using System.Linq;

namespace Phinanze.Test.HttpRequests
{
    ///////////////////////////////////////////////////////////
    // UNCOMMENT THE FOLLOWING LINE FOR TESTING HTTP REQUESTS
    // [TestClass]
    ///////////////////////////////////////////////////////////
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
            Assert.AreEqual(Earning.Get.All().Count, 100);

            // Field insertion accuracy test
            Assert.AreEqual(Earning.Get.One(earningId_testcase[0]).DailyInfoId, 1);
            Assert.AreEqual(Earning.Get.One(earningId_testcase[0]).CategoryId, 1);
            Assert.AreEqual(Earning.Get.One(earningId_testcase[0]).Amount, 10);
            Assert.AreEqual(Earning.Get.One(earningId_testcase[0]).Comment, "None");

            // Lookup test
            Assert.AreEqual(Earning.Get.One(earningId_testcase[0]).DailyInfoId, 1);
            Assert.AreEqual(Earning.Get.One(earningId_testcase[99]).DailyInfoId, 100);

            // Get by specific field value test
            Assert.IsNotNull(Earning.Get.Where("dailyinfo_id", "100").FirstOrDefault());
            Assert.AreEqual(Earning.Get.Where("dailyinfo_id", "100").FirstOrDefault().DailyInfoId, 100);
            Assert.AreEqual(Earning.Get.Where("amount", 11).FirstOrDefault().Amount, 11);

            // Update test
            Earning e = Earning.Get.One(earningId_testcase[0]);
            Assert.IsNotNull(e);
            Assert.AreEqual(e.Comment, "None");
            e.Comment = "Update";
            e.Save();
            e = Earning.Get.One(earningId_testcase[0]);
            Assert.AreEqual(e.Comment, "Update");

            // Delete test
            e = Earning.Get.One(earningId_testcase[99]);
            e.Delete();
            Assert.IsNull(Earning.Get.One(earningId_testcase[99]));

            //Delete multiple
            DeleteAllEarnings();
            Assert.AreEqual(Earning.Get.All().Count, 0);
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
