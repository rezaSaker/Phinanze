using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using System.Linq;

namespace App.Test.HttpRequestTest
{
    // [TestClass]
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
            Assert.AreEqual(100, Category.Get.All().Count);

            // Field insertion accuracy test
            Assert.AreEqual("Category 1", Category.Get.One(categoryId_testcase[0]).Name);
            Assert.AreEqual("Earning", Category.Get.One(categoryId_testcase[0]).CategoryType);

            // Lookup test
            Assert.AreEqual("Category 100", Category.Get.One(categoryId_testcase[99]).Name);
            Assert.AreEqual("Expense", Category.Get.One(categoryId_testcase[99]).CategoryType);

            // Get by specific field value test
            Assert.IsNotNull(Category.Get.Where("name", "Category 1").FirstOrDefault());
            Assert.AreEqual(50, Category.Get.Where("category_type", "Earning").Count);
            Assert.AreEqual("Expense", Category.Get.Where("name", "Category 51").FirstOrDefault().CategoryType);

            // Update test
            Category c = Category.Get.One(categoryId_testcase[0]);
            Assert.IsNotNull(c);
            Assert.AreEqual("Category 1", c.Name);
            c.Name = "Category Updated";
            c.Save();
            c = Category.Get.One(categoryId_testcase[0]);
            Assert.AreEqual("Category Updated", c.Name);

            // Delete test
            c = Category.Get.One(categoryId_testcase[99]);
            c.Delete();
            Assert.IsNull(Category.Get.One(categoryId_testcase[99]));

            // Local copy modification test (should not modify local copy of all cateogry entries unless the change is saved using Save() method
            c = Category.Get.All().First();
            Assert.IsNotNull(c);
            string name = c.Name;
            c.Name = "New Name";
            Assert.AreEqual(name, Category.Get.All().First().Name);


            // Delete multiple
            DeleteAllCategories();
            Assert.AreEqual(0, Category.Get.All().Count);
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
