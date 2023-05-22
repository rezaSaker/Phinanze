using Phinanze.Models;
using Phinanze.Models.Statics;
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

        private int _selectedMonth;
        private int _selectedYear;

        private bool _loadMonthlyReportData;

        public MonthlyReportPresenter(IMonthlyReportView view, IView containerView, int? year = null, int? month = null)
        {
            _view = view;
            _containerView = containerView;
            _loadMonthlyReportData = false;

            _view.ViewLoading += OnViewLoading;
            _view.ViewShown += OnViewShown;
            _view.MonthComboBoxSelectedIndexChanged += OnMonthComboBoxSelectedIndexChanged;
            _view.YearComboBoxSelectedIndexChanged += OnYearComboBoxSelectedIndexChanged;
            _view.SearchTextBoxInputChanged += OnSearchTextBoxInputChanged;
            _view.MonthlyReportDGVRowDoubleClick += OnMonthlyReportDGVRowDoubleClick;
            _view.EditButtonClick += OnEditButtonClick;
            _view.DeleteButtonClick += OnDeleteButtonClick;

            _selectedMonth = month ?? DateTime.Now.Month;
            _selectedYear = year ?? DateTime.Now.Year;

            Show(_view, _containerView);
        }

        #region Properties


        #endregion

        #region Event Handler Methods

        private void OnViewLoading(object sender, EventArgs e)
        {
            List<string> months = new List<string>();
            List<int> years = new List<int>();

            for(int year = 2018; year <= DateTime.Now.Year; year++)
            {
                years.Add(year);
            }

            _view.InitializeComponents(Month.MonthNames, years);
            _loadMonthlyReportData = true;

            _view.SelectedMonth = _selectedMonth;
            _view.SelectedYear = _selectedYear;
        }

        private void OnViewShown(object sender, EventArgs e) { }

        private void OnMonthComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMonthlyReportData();
        }

        private void OnYearComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
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
            if(!_loadMonthlyReportData)
            {
                return; // Prevents loading data while initializing the month and year select boxes in the view
            }

            List<DailyInfo2> dailyInfoList = DailyInfo2.Get.All().FindAll(d => d.Date.Month == _selectedMonth && d.Date.Year == _selectedYear);
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
            }

            BindingSource source = new BindingSource();
            source.DataSource = dailyOverviews;
            _view.PlotData(source);
        }

        #endregion
    }
}
