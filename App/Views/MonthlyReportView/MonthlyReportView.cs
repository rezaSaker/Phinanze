using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.monthComboBox.SelectedIndexChanged += delegate { MonthComboBoxSelectedIndexChanged?.Invoke(this, EventArgs.Empty); };
            this.yearComboBox.SelectedIndexChanged += delegate { YearComboBoxSelectedIndexChanged?.Invoke(this, EventArgs.Empty); };
            this.searchTextBox.TextChanged += delegate { SearchTextBoxInputChanged?.Invoke(this, EventArgs.Empty); };
            this.monthlyReportDGV.CellDoubleClick += delegate { MonthlyReportDGVRowDoubleClick?.Invoke(this, EventArgs.Empty); };
            this.editButton.Click += delegate { EditButtonClick?.Invoke(this, EventArgs.Empty); };
            this.deleteButton.Click += delegate { DeleteButtonClick?.Invoke(this, EventArgs.Empty); };
        }

        private static MonthlyReportView _instance;
        public static MonthlyReportView Instance => _instance ?? (_instance = new MonthlyReportView());

        public ComboBox MonthComboBox => this.monthComboBox;

        public ComboBox YearComboBox => this.yearComboBox;

        public TextBox SearchTextBox => this.searchTextBox;

        public DataGridView MonthlyReportDGV => this.monthlyReportDGV;

        public Label TotalTransactionLabel => this.TotalTransactionLabel;

        public Button EditButton => this.editButton;

        public Button DeleteButton => this.deleteButton;

        public bool IsOpen { get; private set; }

        public bool IsHidden { get; private set; }

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
