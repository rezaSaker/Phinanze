using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Phinanze.Views
{
    public partial class DashboardView : Form, IDashboardView
    {
        private DashboardView()
        {
            InitializeComponent();

            this.Load += delegate { ViewLoading?.Invoke(this, EventArgs.Empty); };
            this.Shown += delegate { ViewShown?.Invoke(this, EventArgs.Empty); };
            this.yearComboBox.SelectedIndexChanged += delegate { YearComboBoxSelectedIndexChanged?.Invoke(this, EventArgs.Empty); };
            this.OverviewDGV.CellDoubleClick += delegate { OverviewDGVRowDoubleClick?.Invoke(this, EventArgs.Empty); };
        }

        private static DashboardView _instance;
        public static DashboardView Instance => _instance ?? (_instance = new DashboardView());

        public Chart OverviewPieChart => this.overviewPieChart; 

        public Chart OverviewBarChart => this.overviewBarChart; 

        public DataGridView OverviewDGV => this.overviewDGV; 

        public ComboBox YearComboBox => this.yearComboBox;

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
        public event EventHandler YearComboBoxSelectedIndexChanged;
        public event EventHandler OverviewDGVRowDoubleClick;
    }
}
