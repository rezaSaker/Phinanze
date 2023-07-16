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

        [TestMethod]
        public void OnViewLoadShouldInitializeComponents()
        {
            DashboardView view = new DashboardView();
            DashboardPresenter presenter = new DashboardPresenter(view, MDIContainerView.Instance);
            PrivateObject presenterObj = new PrivateObject(presenter);
            presenterObj.Invoke("OnViewLoad", new object[] { this, null });

            PrivateObject viewObj = new PrivateObject(view);
            ComboBox yearCB = (ComboBox)viewObj.GetFieldOrProperty("yearComboBox");

            Assert.AreEqual(DateTime.Now.Year - 2018 + 2, yearCB.Items.Count);

            for (int i = 0, year = DateTime.Now.Year; year >= 2018; i++, year--)
            {
                Assert.AreEqual(year.ToString(), yearCB.Items[i]);
            }
            Assert.AreEqual("All Years", yearCB.Items[yearCB.Items.Count - 1]);
        }

        [TestMethod]
        public void LoadDashboardDataShouldPopulateChartsWithData()
        {
            DashboardView view = new DashboardView();
            DashboardPresenter presenter = new DashboardPresenter(view, MDIContainerView.Instance);
            PrivateObject presenterObj = new PrivateObject(presenter);
            presenterObj.Invoke("OnViewShown", new object[] { this, null }); // This will trigger LoadDashboardData()

            PrivateObject viewObj = new PrivateObject(view);
            Chart overviewBarChart = (Chart)viewObj.GetFieldOrProperty("overviewBarChart");
            Chart overviewPieChart = (Chart)viewObj.GetFieldOrProperty("overviewPieChart");

            Assert.AreEqual(12, overviewBarChart.Series["Earning"].Points.Count);
            Assert.AreEqual(12, overviewBarChart.Series["Expense"].Points.Count);

            Assert.AreEqual(3, overviewPieChart.Series["DefaultSeries"].Points.Count);
        }

    }
}
