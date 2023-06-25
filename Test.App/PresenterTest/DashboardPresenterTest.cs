using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Models;
using Phinanze.Presenters;
using Phinanze.Views;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Test.App.PresenterTest
{
    [TestClass]
    public class DashboardPresenterTest
    {
        static DashboardPresenter presenter = new DashboardPresenter(DashboardView.Instance, MDIContainerView.Instance);

        [TestMethod]
        public void DashboardPresenter_Constructor_InitializesVariables()
        {
            var presenter = new DashboardPresenter(DashboardView.Instance, MDIContainerView.Instance);

            Assert.IsNotNull(presenter);
            Assert.IsTrue(MDIContainerView.Instance.IsOpen);
            Assert.IsNotNull(DashboardView.Instance.MdiParent);
            Assert.IsInstanceOfType(DashboardView.Instance.MdiParent, typeof(IContainerView));
            Assert.AreEqual(MDIContainerView.Instance, DashboardView.Instance.MdiParent);
        }

        [TestMethod]
        public void DashboardPresenter_OnViewLoad_InitializesComponents()
        {
            PrivateObject pvtObj = new PrivateObject(DashboardView.Instance);
            ComboBox yearCB = (ComboBox)pvtObj.GetFieldOrProperty("yearComboBox");

            Assert.AreEqual(DateTime.Now.Year - 2018 + 2, yearCB.Items.Count);

            for (int i = 0, year = DateTime.Now.Year; year >= 2018; i++, year--)
            {
                Assert.AreEqual(year.ToString(), yearCB.Items[i]);
            }
            Assert.AreEqual("All Years", yearCB.Items[yearCB.Items.Count - 1]);
        }

        [TestMethod]
        public void DashboardPresenter_LoadDashboardData_PopulatesChartsWithData()
        {
            PrivateObject presenterObj = new PrivateObject(presenter);
            presenterObj.Invoke("OnViewShown", new object[] { this, null }); // This will trigger LoadDashboardData()

            PrivateObject viewObj = new PrivateObject(DashboardView.Instance);
            Chart overviewBarChart = (Chart)viewObj.GetFieldOrProperty("overviewBarChart");
            Chart overviewPieChart = (Chart)viewObj.GetFieldOrProperty("overviewPieChart");

            Assert.AreEqual(12, overviewBarChart.Series["Earning"].Points.Count);
            Assert.AreEqual(12, overviewBarChart.Series["Expense"].Points.Count);

            Assert.AreEqual(3, overviewPieChart.Series["DefaultSeries"].Points.Count);
        }

    }
}
