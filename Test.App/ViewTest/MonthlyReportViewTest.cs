using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models.ViewModels;
using Phinanze.Views;
using Phinanze.Views.MonthlyReportView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Phinanze.Test.App.ViewTest
{
    [TestClass]
    public class MonthlyReportViewTest
    {
        [TestMethod]
        public void TestMonthlyReportViewInitAndObjectRelations()
        {
            IView view1 = MonthlyReportView.Instance;
            IMonthlyReportView view2 = MonthlyReportView.Instance;

            Assert.AreSame(view1, view2);

            view2 = view1 as IMonthlyReportView;
            Assert.AreSame(view1, view2);

            Assert.IsInstanceOfType(view1, typeof(Form));
        }

        [TestMethod]
        public void TestMonthlyReportDGV()
        {
            PrivateObject pvtObj = new PrivateObject(MonthlyReportView.Instance);
            DataGridView monthlyReportDGV = (DataGridView)pvtObj.GetFieldOrProperty("monthlyReportDGV");

            Assert.AreEqual(0, monthlyReportDGV.ColumnCount);
            Assert.AreEqual(0, monthlyReportDGV.RowCount);
        }

        [TestMethod]
        public void TestPlotData()
        {
            PrivateObject pvtObj = new PrivateObject(MonthlyReportView.Instance);
            DataGridView monthlyReportDGV = (DataGridView)pvtObj.GetFieldOrProperty("monthlyReportDGV");

            Assert.AreEqual(0, monthlyReportDGV.RowCount);
            List<DailyOverview> dgvData = new List<DailyOverview>()
            {
                new DailyOverview() { Date = DateTime.Today.Date, Note = "Note", TotalEarning = 100, TotalExpense = 50 },
                new DailyOverview() { Date = DateTime.Today.Date, Note = null, TotalEarning = 100.5, TotalExpense = -50.7 }
            };
            MonthlyReportView.Instance.PlotData(dgvData);

            Assert.AreEqual(2, monthlyReportDGV.RowCount);
            Assert.AreEqual(4, monthlyReportDGV.ColumnCount);
            Assert.AreEqual(DateTime.Today.Date, monthlyReportDGV.Rows[0].Cells[0].Value);
            Assert.AreEqual("Note", monthlyReportDGV.Rows[0].Cells[1].Value);

            MonthlyReportView.Instance.ClearData();

            Assert.AreEqual(0, monthlyReportDGV.RowCount);
        }
    }
}
