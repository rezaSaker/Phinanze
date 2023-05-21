using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms.DataVisualization.Charting;
using Phinanze.Views;
using System.Windows.Forms;

namespace Phinanze.Test.App.ViewTest
{
    [TestClass]
    public class DashboardViewTest
    {
        public static IDashboardView view = DashboardView.Instance;

        [TestMethod]
        public void TestDashboardViewInitAndObjectRelations()
        {
            IView view1 = DashboardView.Instance;
            IDashboardView view2 = DashboardView.Instance;

            Assert.AreSame(view1, view2);

            view2 = view1 as IDashboardView;
            Assert.AreSame(view1, view2);

            Assert.IsInstanceOfType(view1, typeof(Form));
        }

        [TestMethod]
        public void TestOverviewBarChart()
        {
            Assert.IsNotNull(view.OverviewBarChart);
            Assert.AreEqual(2, view.OverviewBarChart.Series.Count);
            Assert.AreEqual("Earning", view.OverviewBarChart.Series[0].Name);
            Assert.AreEqual("Expense", view.OverviewBarChart.Series[1].Name);
            Assert.AreEqual(SeriesChartType.Column, view.OverviewBarChart.Series[0].ChartType);
            Assert.AreEqual(SeriesChartType.Column, view.OverviewBarChart.Series[1].ChartType);
            Assert.AreEqual(0, view.OverviewBarChart.Series["Earning"].Points.Count);
            Assert.AreEqual(0, view.OverviewBarChart.Series["Expense"].Points.Count);
        }

        [TestMethod]
        public void TestOverviewPieChart()
        {
            Assert.IsNotNull(view.OverviewPieChart);
            Assert.AreEqual(1, view.OverviewPieChart.Series.Count);
            Assert.AreEqual("DefaultSeries", view.OverviewPieChart.Series[0].Name);
            Assert.AreEqual(0, view.OverviewPieChart.Series["DefaultSeries"].Points.Count);
            Assert.AreEqual(SeriesChartType.Pie, view.OverviewPieChart.Series[0].ChartType);
        }

        [TestMethod]
        public void TestOverviewDataGridView()
        {
            Assert.IsNotNull(view.OverviewDGV);
            Assert.AreEqual(5, view.OverviewDGV.ColumnCount);
            Assert.AreEqual("Year", view.OverviewDGV.Columns[0].HeaderText);
            Assert.AreEqual("Month", view.OverviewDGV.Columns[1].HeaderText);
            Assert.AreEqual("Earning", view.OverviewDGV.Columns[2].HeaderText);
            Assert.AreEqual("Expense", view.OverviewDGV.Columns[3].HeaderText);
            Assert.AreEqual("Overview", view.OverviewDGV.Columns[4].HeaderText);
            Assert.AreEqual(0, view.OverviewDGV.RowCount);
        }
    }
}
