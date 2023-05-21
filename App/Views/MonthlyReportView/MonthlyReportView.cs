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
        public MonthlyReportView()
        {
            InitializeComponent();
        }

        private static MonthlyReportView _instance;
        public static MonthlyReportView Instance => _instance != null? _instance : new MonthlyReportView();

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
    }
}
