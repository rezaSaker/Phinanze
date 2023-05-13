using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using System.Linq;
using System;

namespace Phinanze.Test.Web
{
    public class CategoryHttpCRUDTest
    {
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
                    Name = "Category " + (i + 1),
                    CategoryType = i < 50 ? "Earning" : "Expense"
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
            c.Delete();
            Assert.IsNull(Category.Find(categoryId_testcase[99]));

            // Delete multiple
            DeleteAllCategories();
            Assert.AreEqual(Category.GetAll().Count, 0);
        }

        private void DeleteAllCategories()
        {
            foreach (Category c in Category.GetAll())
            {
                c.Delete();
            }
        }
    }
}
