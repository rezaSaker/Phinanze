using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using Phinanze.Models.ViewModels;
using Phinanze.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.App.ViewTest
{
    [TestClass]
    public class AddTransactionViewTest
    {
        [TestMethod]
        public void AddTransactionView_IsSingleton()
        {
            IView view1 = AddTransactionView.Instance();
            AddTransactionView view2 = AddTransactionView.Instance();

            Assert.AreSame(view1, view2);
        }

        [TestMethod]
        public void AddTransactionsView_PlotData_PopulatesControls()
        {
            AddTransactionView view = AddTransactionView.Instance();
            view.InitializeComponents(Category.Get.All());

            Assert.AreEqual(0, view.Amount);
            Assert.AreEqual(string.Empty, view.Note);
            Assert.AreEqual(DateTime.Today.ToShortDateString(), view.Date.ToShortDateString());
            Assert.IsNull(view.Category);

            Transaction transaction = Transaction.Get.All().First();
            AddTransactionView.Instance().PlotData(transaction);

            Assert.AreEqual(transaction.Date, view.Date);
            Assert.AreEqual(transaction.Amount, view.Amount);
            Assert.AreEqual(transaction.Note, view.Note);
            Assert.AreEqual(transaction.CategoryId, view.Category.Id);

            AddTransactionView.Instance().ClearData();

            Assert.AreEqual(0, view.Amount);
            Assert.AreEqual(string.Empty, view.Note);
            Assert.AreEqual(DateTime.Today.ToShortDateString(), view.Date.ToShortDateString());
            Assert.IsNull(view.Category);
        }
    }
}
