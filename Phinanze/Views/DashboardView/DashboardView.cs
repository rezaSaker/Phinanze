using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phinanze.Views
{
    public partial class DashboardView : Form, IView
    {
        private static DashboardView _instance;

        private DashboardView()
        {
            InitializeComponent();
        }

        public static DashboardView Instance
        {
            get => _instance != null ? _instance : new DashboardView(); 
        }
    }
}
