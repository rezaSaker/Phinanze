using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Phinanze.Models.Statics;
using Phinanze.Models.ViewModels;

namespace Phinanze.Views
{
    public partial class DashboardView : Form, IDashboardView
    {
        private DashboardView()
        {
            InitializeComponent();

            this.Load += delegate { ViewLoading?.Invoke(this, EventArgs.Empty); };
            this.Shown += delegate { ViewShown?.Invoke(this, EventArgs.Empty); };
            this.yearComboBox.SelectedIndexChanged += delegate { YearComboBoxSelectedIndexChanged?.Invoke(this.yearComboBox, EventArgs.Empty); };
            this.overviewDGV.CellDoubleClick += delegate { OverviewDGVRowDoubleClick?.Invoke(this.overviewDGV, EventArgs.Empty); };
        }

        private static DashboardView _instance;
        public static DashboardView Instance => _instance ?? (_instance = new DashboardView());

        public bool IsOpen { get; private set; }

        public bool IsHidden { get; private set; }

        public string YearListSelectedItem
        {  
            get => yearComboBox.SelectedItem.ToString();
            set => yearComboBox.SelectedIndex = yearComboBox.Items.IndexOf(value);
        }

        public new void Show()
        {
            this.IsOpen = true;
            this.IsHidden = false;
            base.Show();
        }

        public new void Hide()
        {
            this.IsOpen = false;
            this.IsHidden = true;
            base.Hide();
        }

        public void InitializeComponents(params object[] dataSources)
        {
            yearComboBox.DataSource = dataSources[0];

            overviewBarChart.Series[CategoryType.EARNING].Color = Color.Green;
            overviewBarChart.Series[CategoryType.EXPENSE].Color = Color.Red;
        }

        public void PlotData(params object[] data)
        {
            List<MonthlyOverview> dgvData = (List<MonthlyOverview>)data[0];
            List<PieChartPoint> pieChartData = (List<PieChartPoint>)data[1];
            Dictionary<string, List<BarChartPoint>> barChartData = (Dictionary<string, List<BarChartPoint>>)data[2];
      
            this.overviewDGV.DataSource = dgvData;

            foreach (PieChartPoint point in pieChartData)
            {
                DataPoint dataPoint = new DataPoint() { Color = point.BackColor, LabelForeColor = point.ForeColor, ToolTip = String.Format("${0:00}", point.Y) };
                dataPoint.SetValueXY(point.X, point.Y);
                overviewPieChart.Series.First().Points.Add(dataPoint);
            }

            if(barChartData.ContainsKey(CategoryType.EARNING))
            {
                PlotOverviewBarChart(CategoryType.EARNING, (List<BarChartPoint>)barChartData[CategoryType.EARNING]);
            }

            if (barChartData.ContainsKey(CategoryType.EXPENSE))
            {
                PlotOverviewBarChart(CategoryType.EXPENSE, (List<BarChartPoint>)barChartData[CategoryType.EXPENSE]);
            }
        }

        public void ClearData()
        {
            overviewPieChart.Series["DefaultSeries"].Points.Clear();
            overviewBarChart.Series[CategoryType.EARNING].Points.Clear();
            overviewBarChart.Series[CategoryType.EXPENSE].Points.Clear();
            overviewDGV.DataSource = null;
        }

        public event EventHandler ViewLoading;
        public event EventHandler ViewShown;
        public event EventHandler YearComboBoxSelectedIndexChanged;
        public event EventHandler OverviewDGVRowDoubleClick;

        private void PlotOverviewBarChart(string seriesName, List<BarChartPoint> points)
        {
            foreach(BarChartPoint point in points)
            {
                DataPoint dataPoint = new DataPoint() { ToolTip = string.Format("${0:00}", point.Y) };
                dataPoint.SetValueXY(point.X, point.Y);
                overviewBarChart.Series[seriesName].Points.Add(dataPoint);
            }
        }
    }
}
