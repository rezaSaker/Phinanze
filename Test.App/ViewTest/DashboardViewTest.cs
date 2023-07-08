using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms.DataVisualization.Charting;
using Phinanze.Views;
using System.Windows.Forms;
using Phinanze.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Phinanze.Test.App.ViewTest
{
    [TestClass]
    public class DashboardViewTest
    {
        [TestMethod]
        public void DashboardView_OverviewBarChart_ValidChart()
        {
            DashboardView view = new DashboardView();
            PrivateObject pvtObj = new PrivateObject(view);
            Chart overviewBarChart = (Chart)pvtObj.GetFieldOrProperty("overviewBarChart");

            Assert.IsNotNull(overviewBarChart);
            Assert.AreEqual(2, overviewBarChart.Series.Count);
            Assert.AreEqual("Earning", overviewBarChart.Series[0].Name);
            Assert.AreEqual("Expense", overviewBarChart.Series[1].Name);
            Assert.AreEqual(SeriesChartType.Column, overviewBarChart.Series[0].ChartType);
            Assert.AreEqual(SeriesChartType.Column, overviewBarChart.Series[1].ChartType);
            Assert.AreEqual(0, overviewBarChart.Series["Earning"].Points.Count);
            Assert.AreEqual(0, overviewBarChart.Series["Expense"].Points.Count);
        }

        [TestMethod]
        public void DashboardView_OverviewPieChart_ValidChart()
        {
            DashboardView view = new DashboardView();
            PrivateObject pvtObj = new PrivateObject(view);
            Chart overviewPieChart = (Chart)pvtObj.GetFieldOrProperty("overviewPieChart");

            Assert.IsNotNull(overviewPieChart);
            Assert.AreEqual(1, overviewPieChart.Series.Count);
            Assert.AreEqual("DefaultSeries", overviewPieChart.Series[0].Name);
            Assert.AreEqual(0, overviewPieChart.Series["DefaultSeries"].Points.Count);
            Assert.AreEqual(SeriesChartType.Pie, overviewPieChart.Series[0].ChartType);
        }

        [TestMethod]
        public void DashboardView_OverviewDataGridView_ValidDataGridView()
        {
            DashboardView view = new DashboardView();
            PrivateObject pvtObj = new PrivateObject(view);
            DataGridView overviewDGV = (DataGridView)pvtObj.GetFieldOrProperty("overviewDGV");

            Assert.IsNotNull(overviewDGV);
            Assert.AreEqual(0, overviewDGV.ColumnCount);
            Assert.AreEqual(0, overviewDGV.RowCount);
        }

        [TestMethod]
        public void DashboardView_PlotData_PopulatesControls()
        {
            // Test case for the datagridview
            List<MonthlyOverview> dgvData = new List<MonthlyOverview>()
            {
                new MonthlyOverview(){ Year = 2023, Month = "Januray", TotalEarning = 100.50, TotalExpense = 90.50, Difference = 10.0 },
                new MonthlyOverview(){ Year = 0, Month = "February", TotalEarning = -100.50, TotalExpense = -90.50, Difference = -191.0 }
            };

            // Test case for the bar chart
            Dictionary<string, List<BarChartPoint>> bcData = new Dictionary<string, List<BarChartPoint>>()
            {
                ["Earning"] = new List<BarChartPoint>()
                {
                    new BarChartPoint() { X = "January", Y = 100.5 },
                    new BarChartPoint() { X = "February", Y = -10.5 }
                },
                ["Expense"] = new List<BarChartPoint>()
                {
                    new BarChartPoint() { X = "January", Y = 90.5 }
                }
            };

            // Test case for the pie chart 
            List<PieChartPoint> pcData = new List<PieChartPoint>()
            {
                new PieChartPoint() { X = "Earning", Y = 100.5 },
                new PieChartPoint() { X = "Expense", Y = -10.5 }
            };

            DashboardView view = new DashboardView();
            PrivateObject pvtObj = new PrivateObject(view);
            DataGridView overviewDGV = (DataGridView)pvtObj.GetFieldOrProperty("overviewDGV");
            Chart overviewBarChart = (Chart)pvtObj.GetFieldOrProperty("overviewBarChart");
            Chart overviewPieChart = (Chart)pvtObj.GetFieldOrProperty("overviewPieChart");
            view.PlotData(dgvData, pcData, bcData);

            // DGV test
            Assert.AreEqual(2, overviewDGV.RowCount);
            Assert.AreEqual(5, overviewDGV.ColumnCount);
            Assert.AreEqual("2023", overviewDGV.Rows[0].Cells[0].Value.ToString());
            Assert.AreEqual("0", overviewDGV.Rows[1].Cells[0].Value.ToString());
            Assert.AreEqual("10", overviewDGV.Rows[0].Cells[4].Value.ToString());
            Assert.AreEqual("-191", overviewDGV.Rows[1].Cells[4].Value.ToString());

            // bar chart test
            Assert.AreEqual(2, overviewBarChart.Series.Count);
            Assert.AreEqual("Earning", overviewBarChart.Series[0].Name);
            Assert.AreEqual("Expense", overviewBarChart.Series[1].Name);
            Assert.AreEqual(2, overviewBarChart.Series[0].Points.Count);
            Assert.AreEqual(1, overviewBarChart.Series[1].Points.Count);
            Assert.AreEqual("January", overviewBarChart.Series[0].Points[0].AxisLabel);

            // Pie chart test
            Assert.AreEqual(1, overviewPieChart.Series.Count);
            Assert.AreEqual("DefaultSeries", overviewPieChart.Series.First().Name);
            Assert.AreEqual(2, overviewPieChart.Series.First().Points.Count);
            Assert.AreEqual("Earning", overviewPieChart.Series[0].Points[0].AxisLabel);
            
            // Tests for wrong cases 
            List<MonthlyOverview> dgvBadCase = new List<MonthlyOverview>()
            {
                new MonthlyOverview(){ Year = 2023, Month = null, TotalEarning = 100.50, TotalExpense = 90.50, Difference = 10.0 }
            };
            view.PlotData(dgvBadCase, pcData, bcData);
            Assert.AreEqual(1, overviewDGV.RowCount);

            Dictionary<string, List<BarChartPoint>>  bcBadCase = new Dictionary<string, List<BarChartPoint>>()
            {
                ["Earning"] = new List<BarChartPoint>()
                {
                    new BarChartPoint() { X = null, Y = 100.5 }
                }
            };
            Assert.ThrowsException<ArgumentNullException>(() => view.PlotData(dgvData, pcData, bcBadCase));


            List<PieChartPoint> pcBadCase = new List<PieChartPoint>()
            {
                new PieChartPoint() { X = null, Y = 100.5 }
            };
            Assert.ThrowsException<ArgumentNullException>(() => view.PlotData(dgvData, pcBadCase, bcData));

            view.ClearData();

            Assert.AreEqual(0, overviewDGV.RowCount);
        }
    }
}
