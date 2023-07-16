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
        public void OverviewDataGridShouldLoadAsSpecified()
        {
            PrivateObject pvtObj = new PrivateObject(new TransactionsView());
            DataGridView transactionsDGV = (DataGridView)pvtObj.GetFieldOrProperty("transactionsDGV");

            Assert.AreEqual(0, transactionsDGV.ColumnCount);
            Assert.AreEqual(0, transactionsDGV.RowCount);
        }

        [TestMethod]
        public void PlotDataShouldPopulateControls()
        {
            TransactionsView view = new TransactionsView();
            PrivateObject pvtObj = new PrivateObject(view);
            DataGridView transactionsDGV = (DataGridView)pvtObj.GetFieldOrProperty("transactionsDGV");

            Assert.AreEqual(0, transactionsDGV.RowCount);
            List<TransactionOverview> dgvData = new List<TransactionOverview>()
            {
                new TransactionOverview() { Date = DateTime.Today.Date, Note = "Note", Amount = 100, Category = "Car" },
                new TransactionOverview() { Date = DateTime.Today.Date, Note = "Note", Amount = 100, Category = "Food" }
            };
            view.PlotData(dgvData, 10.0, 15);

            Assert.AreEqual(2, transactionsDGV.RowCount);
            Assert.AreEqual(5, transactionsDGV.ColumnCount);
            Assert.AreEqual(DateTime.Today.Date, transactionsDGV.Rows[0].Cells[1].Value);
            Assert.AreEqual("Note", transactionsDGV.Rows[0].Cells[2].Value);

            view.ClearData();
            Assert.AreEqual(0, transactionsDGV.RowCount);

            view.PlotData(dgvData); // This should not throw any error 
            Assert.AreEqual(2, transactionsDGV.RowCount);

            view.ClearData();
            Assert.AreEqual(0, transactionsDGV.RowCount);
        }
    }
}
