using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using System;
using System.Linq;

namespace Phinanze.Test.HttpRequests
{
    ///////////////////////////////////////////////////////////
    // UNCOMMENT THE FOLLOWING LINE FOR TESTING HTTP REQUESTS
    // [TestClass]
    ///////////////////////////////////////////////////////////
    public class DailyInfoHttpCRUDTest
    {
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
                    Note = "Note " + (i + 1)
                };
                dailyinfo.Save();
                dailyinfoId_testcase[i] = dailyinfo.Id;
            }
            Assert.AreEqual(DailyInfo2.Get.All().Count, 100);

            // Field insertion accuracy test
            Assert.AreEqual(DailyInfo2.Get.One(dailyinfoId_testcase[0]).Date, dailyinfoDate_testcase[0].Date);
            Assert.AreEqual(DailyInfo2.Get.One(dailyinfoId_testcase[0]).Note, "Note 1");

            // Lookup test
            Assert.AreEqual(DailyInfo2.Get.One(dailyinfoId_testcase[99]).Date, dailyinfoDate_testcase[99].Date);
            Assert.AreEqual(DailyInfo2.Get.One(dailyinfoId_testcase[99]).Note, "Note 100");

            // Get by specific field value test
            Assert.IsNotNull(DailyInfo2.Get.Where("Note", "Note 100").FirstOrDefault());
            Assert.AreEqual(DailyInfo2.Get.Where("Note", "Note 100").FirstOrDefault().Note, "Note 100");

            // Update test
            DailyInfo2 d = DailyInfo2.Get.One(dailyinfoId_testcase[0]);
            Assert.IsNotNull(d);
            Assert.AreEqual(d.Note, "Note 1");
            d.Note = "Note Updated";
            d.Save();
            d = DailyInfo2.Get.One(dailyinfoId_testcase[0]);
            Assert.AreEqual(d.Note, "Note Updated");

            // Delete test
            d = DailyInfo2.Get.One(dailyinfoId_testcase[99]);
            d.Delete();
            Assert.IsNull(DailyInfo2.Get.One(dailyinfoId_testcase[99]));

            // Delete multiple
            DeleteAllDailyinfo();
            Assert.AreEqual(DailyInfo2.Get.All().Count, 0);
        }

        private void DeleteAllDailyinfo()
        {
            foreach (DailyInfo2 d in DailyInfo2.Get.All())
            {
                d.Delete();
            }
        }
    }
}
