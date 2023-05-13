using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using System.Linq;

namespace Phinanze.Test.HttpRequests
{
    ///////////////////////////////////////////////////////////
    // UNCOMMENT THE FOLLOWING LINE FOR TESTING HTTP REQUESTS
    // [TestClass]
    ///////////////////////////////////////////////////////////
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
            Assert.AreEqual(Category.Get.All().Count, 100);

            // Field insertion accuracy test
            Assert.AreEqual(Category.Get.One(categoryId_testcase[0]).Name, "Category 1");
            Assert.AreEqual(Category.Get.One(categoryId_testcase[0]).CategoryType, "Earning");

            // Lookup test
            Assert.AreEqual(Category.Get.One(categoryId_testcase[99]).Name, "Category 100");
            Assert.AreEqual(Category.Get.One(categoryId_testcase[99]).CategoryType, "Expense");

            // Get by specific field value test
            Assert.IsNotNull(Category.Get.Where("name", "Category 1").FirstOrDefault());
            Assert.AreEqual(Category.Get.Where("category_type", "Earning").Count, 50);
            Assert.AreEqual(Category.Get.Where("name", "Category 51").FirstOrDefault().CategoryType, "Expense");

            // Update test
            Category c = Category.Get.One(categoryId_testcase[0]);
            Assert.IsNotNull(c);
            Assert.AreEqual(c.Name, "Category 1");
            c.Name = "Category Updated";
            c.Save();
            c = Category.Get.One(categoryId_testcase[0]);
            Assert.AreEqual(c.Name, "Category Updated");

            // Delete test
            c = Category.Get.One(categoryId_testcase[99]);
            c.Delete();
            Assert.IsNull(Category.Get.One(categoryId_testcase[99]));

            // Delete multiple
            DeleteAllCategories();
            Assert.AreEqual(Category.Get.All().Count, 0);
        }

        private void DeleteAllCategories()
        {
            foreach (Category c in Category.Get.All())
            {
                c.Delete();
            }
        }
    }
}
