using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models.ViewModels;
using Phinanze.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Phinanze.Test.App.ViewTest
{
    [TestClass]
    public class TransactionsViewTest
    {
        [TestMethod]
        public void TransactionsView_ObjectRelations_ValidRelations()
        {
            IView view1 = TransactionsView.Instance;
            ITransactionsView view2 = TransactionsView.Instance;

            Assert.AreSame(view1, view2);

            view2 = view1 as ITransactionsView;
            Assert.AreSame(view1, view2);

            Assert.IsInstanceOfType(view1, typeof(Form));
        }

        [TestMethod]
        public void TransactionsView_OverviewDataGridView_ValidDataGridView()
        {
            PrivateObject pvtObj = new PrivateObject(TransactionsView.Instance);
            DataGridView transactionsDGV = (DataGridView)pvtObj.GetFieldOrProperty("transactionsDGV");

            Assert.AreEqual(0, transactionsDGV.ColumnCount);
            Assert.AreEqual(0, transactionsDGV.RowCount);
        }

        [TestMethod]
        public void TransactionsView_PlotData_PopulatesControls()
        {
            PrivateObject pvtObj = new PrivateObject(TransactionsView.Instance);
            DataGridView transactionsDGV = (DataGridView)pvtObj.GetFieldOrProperty("transactionsDGV");

            Assert.AreEqual(0, transactionsDGV.RowCount);
            List<TransactionOverview> dgvData = new List<TransactionOverview>()
            {
                new TransactionOverview() { Date = DateTime.Today.Date, Note = "Note", Amount = 100, Category = "Car" },
                new TransactionOverview() { Date = DateTime.Today.Date, Note = "Note", Amount = 100, Category = "Food" }
            };
            TransactionsView.Instance.PlotData(dgvData, 10.0, 15);

            Assert.AreEqual(2, transactionsDGV.RowCount);
            Assert.AreEqual(5, transactionsDGV.ColumnCount);
            Assert.AreEqual(DateTime.Today.Date, transactionsDGV.Rows[0].Cells[1].Value);
            Assert.AreEqual("Note", transactionsDGV.Rows[0].Cells[2].Value);

            TransactionsView.Instance.ClearData();
            Assert.AreEqual(0, transactionsDGV.RowCount);

            TransactionsView.Instance.PlotData(dgvData); // This should not throw any error 
            Assert.AreEqual(2, transactionsDGV.RowCount);

            TransactionsView.Instance.ClearData();
            Assert.AreEqual(0, transactionsDGV.RowCount);
        }
    }
}
