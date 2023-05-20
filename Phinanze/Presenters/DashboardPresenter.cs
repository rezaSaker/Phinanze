using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Phinanze.Models;
using Phinanze.Models.Statics;
using Phinanze.Views;

namespace Phinanze.Presenters
{
    public class DashboardPresenter : Presenter
    {
        private IDashboardView _view;
        private IView _containerView;

        public DashboardPresenter(IView view, IView containerView = null)
        {
            _view = (IDashboardView)view;
            _containerView = containerView;

            _view.ViewLoading += OnViewLoad;
            _view.ViewShown += OnViewShown;
            _view.YearComboBoxSelectedIndexChanged += OnYearComboBoxSelectedIndexChanged;

            Show(_view, _containerView);
        }

        #region EventHandler Methods

        public void OnViewLoad(object sender, EventArgs e)
        {
            for(int year = 2018; year <= DateTime.Today.Year; year++)
            {
                _view.YearComboBox.Items.Add(year.ToString());
            }
            _view.YearComboBox.Items.Add("All Years");
            
            _view.OverviewBarChart.Series[CategoryType.EARNING].Color = Color.Green;
            _view.OverviewBarChart.Series[CategoryType.EXPENSE].Color = Color.Red;
        }

        public void OnViewShown(object sender, EventArgs e)
        {
            _view.YearComboBox.SelectedIndex = _view.YearComboBox.Items.Count - 1;
        }

        public void OnYearComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        #endregion

        #region Utility Methods

        private void LoadDashboardData()
        {
            _view.OverviewPieChart.Series["DefaultSeries"].Points.Clear();
            _view.OverviewBarChart.Series[CategoryType.EARNING].Points.Clear();
            _view.OverviewBarChart.Series[CategoryType.EXPENSE].Points.Clear();
            _view.OverviewDGV.Rows.Clear();

            int? selectedYear = int.TryParse(_view.YearComboBox.SelectedItem.ToString(), out int temp) ? (int?)temp : null; // Null for item "All Years"
            
            for (int month = 1; month <= 12; month++)
            {
                AddDataPointOnViewBarChart(month, DailyInfo2.GetTotalEarningsByMonth(month, selectedYear), CategoryType.EARNING);
                AddDataPointOnViewBarChart(month, DailyInfo2.GetTotalExpensesByMonth(month, selectedYear), CategoryType.EXPENSE);
            }

            double totalEarning = 0.0;
            double totalExpense = 0.0;

            if(selectedYear == null) // If selected item is "All Years"
            {
                for(int i = _view.YearComboBox.Items.Count - 2; i >= 0 ; i--)
                {
                    AddRowToViewDGV(int.Parse(_view.YearComboBox.Items[i].ToString()));
                }

                totalEarning = Earning.Get.All().Sum(e => e.Amount);
                totalExpense = Expense.Get.All().Sum(e => e.Amount);
            }
            else
            {
                AddRowToViewDGV(int.Parse(_view.YearComboBox.SelectedItem.ToString()));

                totalEarning = Earning.Get.All().FindAll(e => DailyInfo2.Get.One(e.DailyInfoId)?.Date.Year == selectedYear).Sum(e => e.Amount);
                totalExpense = Expense.Get.All().FindAll(e => DailyInfo2.Get.One(e.DailyInfoId)?.Date.Year == selectedYear).Sum(e => e.Amount);
            }

            
            double totalSavings = totalEarning > totalExpense ? totalEarning - totalExpense : 0.0;

            _view.OverviewPieChart.Series["DefaultSeries"].Points.AddXY("Earning", totalEarning);
            _view.OverviewPieChart.Series["DefaultSeries"].Points.AddXY("Expense", totalExpense);
            _view.OverviewPieChart.Series["DefaultSeries"].Points.AddXY("Savings", totalSavings);
        }

        private void AddDataPointOnViewBarChart(int month, double value, string seriesName)
        {
            DataPoint point = new DataPoint();
            point.SetValueXY(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month), value);
            point.ToolTip = string.Format("${0:00}", value);
            _view.OverviewBarChart.Series[seriesName].Points.Add(point);
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
