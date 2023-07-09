using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using Phinanze.Presenters;
using Phinanze.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.App.PresenterTest
{
    [TestClass]
    public class AddTransactionPresenterTest
    {
        [TestMethod]
        public void OnInitShouldLoadViewWithTransactionOrDefaultData()
        {
            AddTransactionPresenter presenter1 = new AddTransactionPresenter(AddTransactionView.Instance(), null);
            PrivateObject viewObj = new PrivateObject(AddTransactionView.Instance());

            Assert.AreEqual(Category.Get.All().Count, ((ComboBox)viewObj.GetFieldOrProperty("categoryComboBox")).Items.Count);
            Assert.IsTrue(AddTransactionView.Instance().IsOpen);
            Assert.IsNull(AddTransactionView.Instance().Category);
            Assert.AreEqual(0, AddTransactionView.Instance().Amount);
            Assert.AreEqual(string.Empty, AddTransactionView.Instance().Note);

            Transaction transaction = Transaction.Get.All().First();
            AddTransactionPresenter presenter2 = new AddTransactionPresenter(AddTransactionView.Instance(), null, transaction);

            Assert.IsTrue(AddTransactionView.Instance().IsOpen);
            Assert.IsNotNull(AddTransactionView.Instance().Category);
            Assert.AreEqual(transaction.CategoryId, AddTransactionView.Instance().Category.Id);
            Assert.AreEqual(transaction.Amount, AddTransactionView.Instance().Amount);
            Assert.AreEqual(transaction.Note, AddTransactionView.Instance().Note);

        }

        [TestMethod]
        public void OnSaveButtonClickShouldSaveTransactionData()
        {
            Transaction transaction = new Transaction()
            {
                Date = DateTime.Today,
                Amount = 50.10,
                Note = "Test Test",
                CategoryId = Category.Get.All().First().Id
            };

            AddTransactionPresenter presenter = new AddTransactionPresenter(AddTransactionView.Instance(), null, transaction);
            PrivateObject presenterObj = new PrivateObject(presenter);
            presenterObj.Invoke("OnSaveButtonClick", new object[] { this, null });

            Assert.IsNotNull(transaction.Id);
            Assert.IsTrue(transaction.Id >= 1);
            Assert.IsNotNull(Transaction.Get.Where("id", transaction.Id));

            transaction.Delete();
        }
    }
}
