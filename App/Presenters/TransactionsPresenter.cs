using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using Phinanze.Models;
using Phinanze.Models.Statics;
using Phinanze.Models.ViewModels;
using Phinanze.Views;

namespace Phinanze.Presenters
{
    public class TransactionsPresenter : Presenter
    {
        private readonly ITransactionsView _view;
        private readonly IView _containerView;

        private int _selectedMonth;
        private int _selectedYear;

        private bool _loadMonthlyReportData;

        public TransactionsPresenter(ITransactionsView view, IView containerView, int? year = null, int? month = null)
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
            
            _view.SelectedMonth = _selectedMonth;
            _view.SelectedYear = _selectedYear;
            _loadMonthlyReportData = true;

            LoadMonthlyReportData();
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
            LoadMonthlyReportData();
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

        private void LoadMonthlyReportData()
        {
            if (!_loadMonthlyReportData)
            {
                return; // Prevents loading data while initializing the month and year select boxes in the view
            }
    
            List<Transaction> transactionList = Transaction.Get.All().FindAll(t => t.Date.Month == _view.SelectedMonth && t.Date.Year == _view.SelectedYear);

            if (!_view.SearchBoxText.IsNullOrEmpty())
            {
                string searchParam = _view.SearchBoxText.Trim().ToLower();
                transactionList = transactionList.FindAll(t =>
                    t.Date.ToString().Contains(searchParam) ||
                    t.Note.ToLower().Contains(searchParam) ||
                    t.Amount.ToString().Contains(searchParam) ||
                    t.Category().Name.Contains(searchParam)
                );
            }

            double totalEarning = transactionList.FindAll(t => t.Category().CategoryType == CategoryType.EARNING).Sum(t => t.Amount);
            double totalExpense = transactionList.FindAll(t => t.Category().CategoryType == CategoryType.EXPENSE).Sum(t => t.Amount);

            List<TransactionOverview> transactionOverviews = new List<TransactionOverview>();

            foreach(var transaction in transactionList)
            {
                transactionOverviews.Add(new TransactionOverview()
                {
                    Date = transaction.Date,
                    Note = transaction.Note,
                    Category = transaction.Category().Name,
                    Amount = transaction.Amount

                });
            }

            _view.PlotData(transactionOverviews, totalEarning, totalExpense);
        }

        #endregion
    }
}
