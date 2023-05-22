using Phinanze.Models;
using Phinanze.Models.ViewModels;
using Phinanze.Views;
using Phinanze.Views.MonthlyReportView;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phinanze.Presenters
{
    public class MonthlyReportPresenter : Presenter
    {
        private IMonthlyReportView _view;
        private IView _containerView;

        public MonthlyReportPresenter(IMonthlyReportView view, IView containerView, int? month = null, int? year = null)
        {
            _view = view;
            _containerView = containerView;

            _view.ViewLoading += OnViewLoading;
            _view.ViewShown += OnViewShown;
            _view.MonthComboBoxSelectedIndexChanged += OnMonthComboBoxSelectedIndexChanged;
            _view.YearComboBoxSelectedIndexChanged += OnYearComboBoxSelectedIndexChanged;
            _view.SearchTextBoxInputChanged += OnSearchTextBoxInputChanged;
            _view.MonthlyReportDGVRowDoubleClick += OnMonthlyReportDGVRowDoubleClick;
            _view.EditButtonClick += OnEditButtonClick;
            _view.DeleteButtonClick += OnDeleteButtonClick;

            SelectedMonth = month ?? DateTime.Now.Month;
            SelectedYear = year ?? DateTime.Now.Year;

            Show(_view, _containerView);
        }

        #region Properties

        public int SelectedMonth { get; set; }

        public int SelectedYear { get; set; }

        #endregion

        #region Event Handler Methods

        private void OnViewLoading(object sender, EventArgs e)
        {
            List<string> months = new List<string>();
            List<int> years = new List<int>();

            for(int month = 1; month <= 12; month++)
            {
                months.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month));
            }

            for(int year = 2018; year <= DateTime.Now.Year; year++)
            {
                years.Add(year);
            }

            _view.InitializeComponents(months, years);
        }

        private void OnViewShown(object sender, EventArgs e)
        {
            _view.SelectedMonth = SelectedMonth;
            _view.SelectedYear = SelectedYear;
        }

        private void OnMonthComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedMonth = _view.SelectedMonth;
            LoadMonthlyReportData();
        }

        private void OnYearComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedYear = _view.SelectedYear;
            LoadMonthlyReportData();
        }

        private void OnSearchTextBoxInputChanged(object sender, EventArgs e)
        {

        }

        private void OnMonthlyReportDGVRowDoubleClick(object sender, EventArgs e)
        {

        }

        private void OnEditButtonClick(object sender, EventArgs e)
        {

        }

        private void OnDeleteButtonClick(object sender, EventArgs e)
        {

        }
        #endregion


        #region Data Processing Methods

        private void LoadMonthlyReportData()
        {
            List<DailyInfo2> dailyInfoList = DailyInfo2.Get.All().FindAll(d => d.Date.Month == SelectedMonth && d.Date.Year == SelectedYear);
            List<DailyOverview> dailyOverviews = new List<DailyOverview>();

            foreach(var dailyInfo in dailyInfoList)
            {
                dailyOverviews.Add(new DailyOverview()
                {
                    Date = dailyInfo.Date,
                    Note = dailyInfo.Note,
                    TotalEarning = dailyInfo.TotalEarning(),
                    TotalExpense = dailyInfo.TotalExpense()
                });
                //AddRowToMonthlyReportDGV(dailyInfo.Date.ToString(), dailyInfo.Note, dailyInfo.TotalEarning(), dailyInfo.TotalExpense());
            }

            BindingSource source = new BindingSource();
            source.DataSource = dailyOverviews;
            _view.PlotData(source);
        }

        //private void AddRowToMonthlyReportDGV(string date, string note, double earning, double expense)
        //{
        //    _view.MonthlyReportDGV.Rows.Add(date, note, earning, expense);
        //}

        #endregion
    }
}
