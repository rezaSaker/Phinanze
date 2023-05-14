﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Phinanze.Views
{
    public partial class DashboardView : Form, IView
    {
        private static DashboardView _instance;

        private DashboardView()
        {
            InitializeComponent();
        }

        public static DashboardView Instance => _instance != null? _instance : (_instance = new DashboardView());

        public Chart PieChart => this.dashboardPieChart; 

        public Chart BarChart => this.dashboardBarChat; 

        public DataGridView OverviewDGV => this.dashboardDGV; 

        public ComboBox YearComboBox => this.yearComboBox; 
        
    }
}