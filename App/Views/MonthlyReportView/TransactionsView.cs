using Phinanze.Models.Statics;
using Phinanze.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Phinanze.Views
{
    public partial class TransactionsView : Form, ITransactionsView
    {
        private TransactionsView()
        {
            InitializeComponent();

            this.Load += delegate { ViewLoading?.Invoke(this, EventArgs.Empty); };
            this.Shown += delegate { ViewShown?.Invoke(this, EventArgs.Empty); };
            this.monthComboBox.SelectedIndexChanged += delegate { MonthComboBoxSelectedIndexChanged?.Invoke(this.monthComboBox, EventArgs.Empty); };
            this.yearComboBox.SelectedIndexChanged += delegate { YearComboBoxSelectedIndexChanged?.Invoke(this.yearComboBox, EventArgs.Empty); };
            this.searchTextBox.TextChanged += delegate { SearchTextBoxInputChanged?.Invoke(this.searchTextBox, EventArgs.Empty); };
            this.transactionsDGV.CellDoubleClick += delegate { MonthlyReportDGVRowDoubleClick?.Invoke(this.transactionsDGV, EventArgs.Empty); };
            this.editButton.Click += delegate { EditButtonClick?.Invoke(this.editButton, EventArgs.Empty); };
            this.deleteButton.Click += delegate { DeleteButtonClick?.Invoke(this.deleteButton, EventArgs.Empty); };

            CustomViewProps.Placeholder(this.searchTextBox, "Search...");
        }

        private static TransactionsView _instance;
        public static TransactionsView Instance => _instance ?? (_instance = new TransactionsView());

        public bool IsOpen { get; private set; }

        public bool IsHidden { get; private set; }

        public int SelectedMonth 
        { 
            get => monthComboBox.SelectedIndex + 1; 
            set => monthComboBox.SelectedIndex = value - 1; 
        }

        public int SelectedYear 
        { 
            get => int.Parse(yearComboBox.SelectedItem.ToString()); 
            set => yearComboBox.SelectedIndex = yearComboBox.Items.IndexOf(value); 
        }

        public string SearchBoxText
        {
            get => CustomViewProps.HasPlaceholder(this.searchTextBox) ? string.Empty : this.searchTextBox.Text;
            set => searchTextBox.Text = value;
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

        public void InitializeComponents(params object[] dataSource)
        {
            monthComboBox.DataSource = dataSource[0];
            yearComboBox.DataSource = dataSource[1];
        }

        public void PlotData(params object[] dataSource)
        {
            if (dataSource[0].GetType() != typeof(List<TransactionOverview>))
            {
                return;
            }
            List<TransactionOverview> transactionOverviews = (List<TransactionOverview>)dataSource[0];

            transactionsDGV.DataSource = transactionOverviews;

            double totalEarning = dataSource.Length > 1 && dataSource[1] is double ? (double)dataSource[1] : 0;
            double totalExpense = dataSource.Length > 2 && dataSource[2] is double ? (double)dataSource[2] : 0;

            this.totalTransactionLabel.Text = "Earning: $" + totalEarning + "\t Expense: $" + totalExpense;
        }

        public void ClearData()
        {
            transactionsDGV.DataSource = null;
        }

        public event EventHandler ViewLoading;
        public event EventHandler ViewShown;
        public event EventHandler MonthComboBoxSelectedIndexChanged;
        public event EventHandler YearComboBoxSelectedIndexChanged;
        public event EventHandler SearchTextBoxInputChanged;
        public event EventHandler MonthlyReportDGVRowDoubleClick;
        public event EventHandler EditButtonClick;
        public event EventHandler DeleteButtonClick;
    }
}
