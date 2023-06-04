using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using Phinanze.Models;
using Phinanze.Models.Statics;
using Phinanze.Models.ViewModels;
using Phinanze.Views;

namespace Phinanze.Presenters
{
    public class MonthlyReportPresenter : Presenter
    {
        private readonly IMonthlyReportView _view;
        private readonly IView _containerView;

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

        #region Event Handler Methods

        private void OnViewLoading(object sender, EventArgs e)
        {
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
            LoadMonthlyReportData(_view.SearchBoxText);
        }

        private void OnYearComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMonthlyReportData(_view.SearchBoxText);
        }

        private void OnSearchTextBoxInputChanged(object sender, EventArgs e)
        {
            LoadMonthlyReportData(_view.SearchBoxText);
        }

        private void OnMonthlyReportDGVRowDoubleClick(object sender, EventArgs e)
        {
            AddNewDailyInfoPresenter presenter = new AddNewDailyInfoPresenter(AddNewDailyInfoView.Instance, MDIContainerView.Instance);
            _view.Hide();
        }

        private void OnEditButtonClick(object sender, EventArgs e)
        {

        }

        private void OnDeleteButtonClick(object sender, EventArgs e)
        {

        }
        #endregion


        #region Data Processing Methods

        private void LoadMonthlyReportData(string searchParam = null)
        {
            if (!_loadMonthlyReportData)
            {
                return; // Prevents loading data while initializing the month and year select boxes in the view
            }
    
            List<DailyInfo2> dailyInfoList = DailyInfo2.Get.All().FindAll(d => d.Date.Month == _view.SelectedMonth && d.Date.Year == _view.SelectedYear);

            if (!searchParam.IsNullOrEmpty())
            {
                searchParam = searchParam.Trim().ToLower();
                dailyInfoList = dailyInfoList.FindAll(d =>
                    d.Date.ToString().Contains(searchParam) ||
                    d.Note.ToLower().Contains(searchParam) ||
                    d.TotalEarning().ToString().Contains(searchParam) ||
                    d.TotalExpense().ToString().Contains(searchParam)
                );
            }
   
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

            _view.PlotData(dailyOverviews);
        }

        #endregion
    }
}
