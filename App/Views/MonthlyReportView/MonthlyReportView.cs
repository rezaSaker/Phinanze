using System;
using System.Windows.Forms;

namespace Phinanze.Views.MonthlyReportView
{
    public partial class MonthlyReportView : Form, IMonthlyReportView
    {
        private MonthlyReportView()
        {
            InitializeComponent();

            this.Load += delegate { ViewLoading?.Invoke(this, EventArgs.Empty); };
            this.Shown += delegate { ViewShown?.Invoke(this, EventArgs.Empty); };
            this.monthComboBox.SelectedIndexChanged += delegate { MonthComboBoxSelectedIndexChanged?.Invoke(this.monthComboBox, EventArgs.Empty); };
            this.yearComboBox.SelectedIndexChanged += delegate { YearComboBoxSelectedIndexChanged?.Invoke(this.yearComboBox, EventArgs.Empty); };
            this.searchTextBox.TextChanged += delegate { SearchTextBoxInputChanged?.Invoke(this.searchTextBox, EventArgs.Empty); };
            this.monthlyReportDGV.CellDoubleClick += delegate { MonthlyReportDGVRowDoubleClick?.Invoke(this.monthlyReportDGV, EventArgs.Empty); };
            this.editButton.Click += delegate { EditButtonClick?.Invoke(this.editButton, EventArgs.Empty); };
            this.deleteButton.Click += delegate { DeleteButtonClick?.Invoke(this.deleteButton, EventArgs.Empty); };
        }

        private static MonthlyReportView _instance;
        public static MonthlyReportView Instance => _instance ?? (_instance = new MonthlyReportView());

        public bool IsOpen { get; private set; }

        public bool IsHidden { get; private set; }

        public int SelectedMonth { get => monthComboBox.SelectedIndex + 1; set => monthComboBox.SelectedIndex = value - 1; }

        public int SelectedYear { get => int.Parse(yearComboBox.SelectedItem.ToString()); set => yearComboBox.SelectedIndex = yearComboBox.Items.IndexOf(value); }

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
            monthlyReportDGV.DataSource = dataSource[0];
        }

        public void ClearData()
        {
            monthlyReportDGV.DataSource = null;
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
