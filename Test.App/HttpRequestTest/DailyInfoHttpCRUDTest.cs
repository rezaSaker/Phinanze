using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using System;
using System.Linq;

namespace App.Test.HttpRequestTest
{
    // [TestClass]
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
            Assert.AreEqual(100, DailyInfo2.Get.All().Count);

            // Field insertion accuracy test
            Assert.AreEqual(dailyinfoDate_testcase[0].Date, DailyInfo2.Get.One(dailyinfoId_testcase[0]).Date);
            Assert.AreEqual("Note 1", DailyInfo2.Get.One(dailyinfoId_testcase[0]).Note);

            // Lookup test
            Assert.AreEqual(dailyinfoDate_testcase[99].Date, DailyInfo2.Get.One(dailyinfoId_testcase[99]).Date);
            Assert.AreEqual("Note 100", DailyInfo2.Get.One(dailyinfoId_testcase[99]).Note);

            // Get by specific field value test
            Assert.IsNotNull(DailyInfo2.Get.Where("Note", "Note 100").FirstOrDefault());
            Assert.AreEqual("Note 100", DailyInfo2.Get.Where("Note", "Note 100").FirstOrDefault().Note);

            // Update test
            DailyInfo2 d = DailyInfo2.Get.One(dailyinfoId_testcase[0]);
            Assert.IsNotNull(d);
            Assert.AreEqual("Note 1", d.Note);
            d.Note = "Note Updated";
            d.Save();
            d = DailyInfo2.Get.One(dailyinfoId_testcase[0]);
            Assert.AreEqual("Note Updated", d.Note);

            // Delete test
            d = DailyInfo2.Get.One(dailyinfoId_testcase[99]);
            d.Delete();
            Assert.IsNull(DailyInfo2.Get.One(dailyinfoId_testcase[99]));

            // Local copy modification test (should not modify local copy of all dailyinfo entries unless the change is saved using Save() method
            d = DailyInfo2.Get.All().First();
            Assert.IsNotNull(d);
            string note = d.Note;
            d.Note = "New Note";
            Assert.AreEqual(note, DailyInfo2.Get.All().First().Note);

            // Delete multiple
            DeleteAllDailyinfo();
            Assert.AreEqual(0, DailyInfo2.Get.All().Count);
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
