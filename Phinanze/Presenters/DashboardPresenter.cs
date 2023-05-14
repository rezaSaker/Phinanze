using Newtonsoft.Json.Linq;
using Phinanze.Models;
using Phinanze.Models.Statics;
using Phinanze.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Phinanze.Presenters
{
    public class DashboardPresenter : BasePresenter
    {
        private DashboardView _view;

        public DashboardPresenter() 
        {
            _view = DashboardView.Instance;

            _view.Load += OnViewLoad;
            _view.Shown += OnViewShown;
            _view.YearComboBox.SelectedIndexChanged += OnViewYearComboBoxChanged;
        }

        public void ShowViewInContainer(Form mdiContainer)
        {
            _view.MdiParent = mdiContainer;
            _view.Dock = DockStyle.Fill;
            _view.Show();
        }


        #region EventHandler Methods

        public void OnViewLoad(object sender, EventArgs e)
        {
            for(int year = 2018; year <= DateTime.Today.Year; year++)
            {
                _view.YearComboBox.Items.Add(year.ToString());
            }
            _view.YearComboBox.Items.Add("Show All Years");
            
            _view.BarChart.Series[CategoryType.EARNING].Color = Color.Green;
            _view.BarChart.Series[CategoryType.EXPENSE].Color = Color.Red;
        }

        public void OnViewShown(object sender, EventArgs e)
        {
            _view.YearComboBox.SelectedIndex = _view.YearComboBox.Items.Count - 1;
        }

        public void OnViewYearComboBoxChanged(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        #endregion

        #region Utility Methods

        private void LoadDashboardData()
        {
            _view.BarChart.Series[CategoryType.EARNING].Points.Clear();
            _view.BarChart.Series[CategoryType.EXPENSE].Points.Clear();
            _view.OverviewDGV.Rows.Clear();

            int? selectedYear = int.TryParse(_view.YearComboBox.SelectedItem.ToString(), out int temp) ? (int?)temp : null; // Null for item "Show All Years"
            
            for (int month = 1; month <= 12; month++)
            {
                AddDataPointOnViewBarChart(month, DailyInfo2.GetTotalEarningsByMonth(month, selectedYear), CategoryType.EARNING);
                AddDataPointOnViewBarChart(month, DailyInfo2.GetTotalExpensesByMonth(month, selectedYear), CategoryType.EXPENSE);
            }

            if(selectedYear == null) // If selected item is "Show All Years"
            {
                for(int i = _view.YearComboBox.Items.Count - 2; i >= 0 ; i--)
                {
                    AddRowToViewDGV(int.Parse(_view.YearComboBox.Items[i].ToString()));
                }
            }
            else
            {
                AddRowToViewDGV(int.Parse(_view.YearComboBox.SelectedItem.ToString()));
            }

            //_view.PieChart.Series.Add("Earning");
            //_view.PieChart.Series.Add("Expense");
            //_view.PieChart.Series[CategoryType.EARNING].Points.AddXY("Earning", 50);
            //_view.PieChart.Series[CategoryType.EXPENSE].Points.AddXY("Expense", 50);
        }

        private void AddDataPointOnViewBarChart(int month, double value, string seriesName)
        {
            DataPoint point = new DataPoint();
            point.SetValueXY(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month), value);
            point.ToolTip = string.Format("${0:00}", value);
            _view.BarChart.Series[seriesName].Points.Add(point);
        }

        private void AddRowToViewDGV(int year)
        {
            for (int month = 12; month > 0; month--)
            {
                if (year == DateTime.Today.Year && month > DateTime.Today.Month)
                {
                    continue;
                }

                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
                double totalEarning = DailyInfo2.GetTotalEarningsByMonth(month, year);
                double totalExpense = DailyInfo2.GetTotalExpensesByMonth(month, year);
                _view.OverviewDGV.Rows.Add(year, monthName, totalEarning, totalExpense, (totalEarning - totalExpense));
            }
        }

        #endregion
    }
}
