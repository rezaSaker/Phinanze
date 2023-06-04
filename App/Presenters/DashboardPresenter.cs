using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using Phinanze.Models;
using Phinanze.Models.Statics;
using Phinanze.Models.ViewModels;
using Phinanze.Views;

namespace Phinanze.Presenters
{
    public class DashboardPresenter : Presenter
    {
        private readonly IDashboardView _view;
        private readonly IView _containerView;

        public DashboardPresenter(IDashboardView view, IView containerView = null)
        {
            _view = view;
            _containerView = containerView;

            _view.ViewLoading += OnViewLoad;
            _view.ViewShown += OnViewShown;
            _view.YearComboBoxSelectedIndexChanged += OnYearComboBoxSelectedIndexChanged;
            _view.OverviewDGVRowDoubleClick += OnOverviewDGVRowDoubleClick;

            Show(_view, _containerView);
        }

        #region EventHandler Methods

        private void OnViewLoad(object sender, EventArgs e)
        {
            List<string> years = new List<string>();

            for(int year = DateTime.Today.Year; year >= 2018 ; year--)
            {
                years.Add(year.ToString());
            }
            years.Add("All Years");

            _view.InitializeComponents(years);
        }

        private void OnViewShown(object sender, EventArgs e)
        {
            _view.SelectedYearFromYearList = "All Years";
        }

        private void OnYearComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void OnOverviewDGVRowDoubleClick(object sender, EventArgs e)
        {
            int? year = _view.SelectedYearFromOverviewTable;
            int? month = Month.MonthNumber(_view.SelectedMonthFromOverviewTable);

            MonthlyReportPresenter presenter = new MonthlyReportPresenter(MonthlyReportView.Instance, MDIContainerView.Instance, year, month);
            _view.Hide();
        }
        #endregion


        #region Data Processing Methods

        private void LoadDashboardData()
        {
            _view.ClearData();

            int? selectedYear = Int32.TryParse(_view.SelectedYearFromYearList, out int temp) ? (int?)temp : null;

            double totalEarning = 0.0;
            double totalExpense = 0.0;
            List<MonthlyOverview> monthlyOverviews = new List<MonthlyOverview>();

            if(selectedYear == null) // Show data for all years 
            {
                for(int year = DateTime.Now.Year; year >= 2018; year--)
                {
                    ListMonthlyOverviewsByYear(year, ref monthlyOverviews);
                }

                totalEarning = Earning.Get.All().Sum(e => e.Amount);
                totalExpense = Expense.Get.All().Sum(e => e.Amount);
            }
            else
            {
                ListMonthlyOverviewsByYear((int)selectedYear, ref monthlyOverviews);

                totalEarning = Earning.Get.All().FindAll(e => DailyInfo2.Get.One(e.DailyInfoId)?.Date.Year == selectedYear).Sum(e => e.Amount);
                totalExpense = Expense.Get.All().FindAll(e => DailyInfo2.Get.One(e.DailyInfoId)?.Date.Year == selectedYear).Sum(e => e.Amount);
            }

            List<PieChartPoint> pieChartPoints = new List<PieChartPoint>()
            {
                new PieChartPoint() { X = CategoryType.EARNING, Y = totalEarning, BackColor = Color.Green, ForeColor = Color.White },
                new PieChartPoint() { X = CategoryType.EXPENSE, Y = totalExpense, BackColor = Color.Red, ForeColor = Color.White  },
                new PieChartPoint() 
                { 
                    X = CategoryType.SAVINGS, 
                    Y = totalEarning > totalExpense ? totalEarning - totalExpense : 0.0, 
                    BackColor = Color.YellowGreen, 
                    ForeColor = Color.White  
                }
            };

            Dictionary<string, List<BarChartPoint>> barChartPointsDict = new Dictionary<string, List<BarChartPoint>>()
            {
                [CategoryType.EARNING] = new List<BarChartPoint>(),
                [CategoryType.EXPENSE] = new List<BarChartPoint>()
            };

            for (int month = 1; month <= 12; month++)
            {
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
                barChartPointsDict[CategoryType.EARNING].Add(new BarChartPoint()
                {
                    X = monthName, Y = DailyInfo2.GetTotalEarningsByMonth(month, selectedYear)
                });

                barChartPointsDict[CategoryType.EXPENSE].Add(new BarChartPoint()
                {
                    X = monthName, Y = DailyInfo2.GetTotalExpensesByMonth(month, selectedYear)
                });
            }

            _view.PlotData(monthlyOverviews, pieChartPoints, barChartPointsDict);
            
        }

        private void ListMonthlyOverviewsByYear(int year, ref List<MonthlyOverview> monthlyOverviews)
        {
            for (int month = 12; month > 0; month--)
            {
                if (year == DateTime.Today.Year && month > DateTime.Today.Month)
                {
                    continue;
                }

                double totalEarning = DailyInfo2.GetTotalEarningsByMonth(month, year);
                double totalExpense = DailyInfo2.GetTotalExpensesByMonth(month, year);

                monthlyOverviews.Add(new MonthlyOverview() 
                { 
                    Year = year,
                    Month = Month.MonthName(month),
                    TotalEarning = totalEarning,
                    TotalExpense = totalExpense,
                    Difference = totalEarning - totalExpense,
                });
            }
        }

        #endregion
    }
}
