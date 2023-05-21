using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using Phinanze.Presenters;
using Phinanze.Views;
using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace Test.App.PresenterTest
{
    [TestClass]
    public class DashboardPresenterTest
    {
        static DashboardPresenter presenter = new DashboardPresenter(DashboardView.Instance, MDIContainerView.Instance);

        [TestMethod]
        public void TestDashboardPresenter_InitAndViewShow()
        {
            Assert.IsTrue(MDIContainerView.Instance.IsOpen);
            Assert.IsNotNull(DashboardView.Instance.MdiParent);
            Assert.IsInstanceOfType(DashboardView.Instance.MdiParent, typeof(IContainerView));
            Assert.AreEqual(MDIContainerView.Instance, DashboardView.Instance.MdiParent);
        }

        [TestMethod]
        public void TestDashboardPresenter_OnViewLoad()
        {
            Assert.AreEqual(DateTime.Now.Year-2018+2, DashboardView.Instance.YearComboBox.Items.Count);
            
            for(int i=0, year=2018; year<=DateTime.Now.Year; i++, year++)
            {
                Assert.AreEqual(year.ToString(), DashboardView.Instance.YearComboBox.Items[i]);
            }
            Assert.AreEqual("All Years", DashboardView.Instance.YearComboBox.Items[DashboardView.Instance.YearComboBox.Items.Count-1]);
        }

        [TestMethod]
        public void TestDashboardPresenter_LoadDashboardData()
        {
            PrivateObject pvtObj = new PrivateObject(presenter);

            pvtObj.Invoke("OnViewShown", new object[] { this, null }); // This will trigger LoadDashboardData()

            Assert.AreEqual(12, DashboardView.Instance.OverviewBarChart.Series["Earning"].Points.Count);
            Assert.AreEqual(12, DashboardView.Instance.OverviewBarChart.Series["Expense"].Points.Count);

            Assert.AreEqual(3, DashboardView.Instance.OverviewPieChart.Series["DefaultSeries"].Points.Count);
        }

        [TestMethod]
        public void TestDashboardPresenter_AddDataPointOnViewBarChart()
        {
            PrivateObject pvtObj = new PrivateObject(presenter);

            int earningPointsCount = DashboardView.Instance.OverviewBarChart.Series["Earning"].Points.Count;

            pvtObj.Invoke("AddDataPointOnViewBarChart", new object[] { 1, 10.0, "Earning" });

            int newEarningPointsCount = DashboardView.Instance.OverviewBarChart.Series["Earning"].Points.Count;
            DataPoint point = DashboardView.Instance.OverviewBarChart.Series["Earning"].Points[newEarningPointsCount - 1];

            Assert.AreEqual(earningPointsCount + 1, newEarningPointsCount);
            Assert.AreEqual(10.0, point.YValues[0]);
        }

        [TestMethod]
        public void TestDashboardPresenter_AddRowToViewDGV()
        {
            PrivateObject pvtObj = new PrivateObject(presenter);

            int rowCount = DashboardView.Instance.OverviewDGV.RowCount;
            pvtObj.Invoke("AddRowToViewDGV", DateTime.Now.Year-1);

            int newRowCount = DashboardView.Instance.OverviewDGV.RowCount;
            Assert.AreEqual(rowCount + 12, newRowCount);

            rowCount = newRowCount;
            pvtObj.Invoke("AddRowToViewDGV", DateTime.Now.Year);
            newRowCount = DashboardView.Instance.OverviewDGV.RowCount; 
            Assert.AreEqual(rowCount + DateTime.Now.Month, newRowCount); // Number of added rows should be equal to the number of months passed in the current year

            double totalEarning = DailyInfo2.GetTotalEarningsByMonth(1, DateTime.Now.Year);
            double totalExpense = DailyInfo2.GetTotalExpensesByMonth(1, DateTime.Now.Year);
            
            Assert.AreEqual(DateTime.Now.Year, DashboardView.Instance.OverviewDGV.Rows[newRowCount - 1].Cells[0].Value);
            Assert.AreEqual("January", DashboardView.Instance.OverviewDGV.Rows[newRowCount - 1].Cells[1].Value);
            Assert.AreEqual(totalEarning, DashboardView.Instance.OverviewDGV.Rows[newRowCount - 1].Cells[2].Value);
            Assert.AreEqual(totalExpense, DashboardView.Instance.OverviewDGV.Rows[newRowCount - 1].Cells[3].Value);
            Assert.AreEqual(totalEarning-totalExpense, DashboardView.Instance.OverviewDGV.Rows[newRowCount - 1].Cells[4].Value);
        }
    }
}
