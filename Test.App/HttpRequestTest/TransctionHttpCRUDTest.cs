using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using System;
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

            int[] transactionId_testcase = new int[100];

            //Insertion test
            for (int i = 0; i < 100; i++)
            {
                Transaction transaction = new Transaction()
                {
                    Amount = 10 + i,
                    CategoryId = i + 1,
                    Note = "None",
                    Date = DateTime.Today.AddDays(i)
                };
                transaction.Save();
                transactionId_testcase[i] = transaction.Id;
            }
            Assert.AreEqual(100, Transaction.Get.All().Count);

            // Field insertion accuracy test
            Assert.AreEqual(1, Transaction.Get.One(transactionId_testcase[0]).CategoryId);
            Assert.AreEqual(10, Transaction.Get.One(transactionId_testcase[0]).Amount);
            Assert.AreEqual("None", Transaction.Get.One(transactionId_testcase[0]).Note);

            // Lookup test
            Assert.AreEqual(1, Transaction.Get.One(transactionId_testcase[0]).CategoryId);
            Assert.AreEqual(100, Transaction.Get.One(transactionId_testcase[99]).CategoryId);

            // Get by specific field value test
            Assert.IsNotNull(Transaction.Get.Where("category_id", "100").FirstOrDefault());
            Assert.AreEqual(100, Transaction.Get.Where("category_id", "100").First().CategoryId);
            Assert.AreEqual(11, Transaction.Get.Where("amount", 11).First().Amount);

            // Update test
            Transaction e = Transaction.Get.One(transactionId_testcase[0]);
            Assert.IsNotNull(e);
            Assert.AreEqual("None", e.Note);
            e.Note = "Update";
            e.Save();
            e = Transaction.Get.One(transactionId_testcase[0]);
            Assert.AreEqual("Update", e.Note);

            // Delete test
            e = Transaction.Get.One(transactionId_testcase[99]);
            e.Delete();
            Assert.IsNull(Transaction.Get.One(transactionId_testcase[99]));

            // Local copy modification test (should not modify local copy of all earning entries unless the change is saved using Save() method
            e = Transaction.Get.All().First();
            Assert.IsNotNull(e);
            string comment = e.Note;
            e.Note = "New Comment";
            Assert.AreEqual(comment, Transaction.Get.All().First().Note);

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
