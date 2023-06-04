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
    public partial class AddNewDailyInfoView : Form, IAddNewDailyInfoView
    {
        private AddNewDailyInfoView()
        {
            InitializeComponent();
        }

        private static AddNewDailyInfoView _instance;

        public event EventHandler ViewLoading;
        public event EventHandler ViewShown;

        public static AddNewDailyInfoView Instance => _instance ?? (_instance = new AddNewDailyInfoView());

        public bool IsOpen => throw new NotImplementedException();

        public bool IsHidden => throw new NotImplementedException();

        public void InitializeComponents(params object[] data)
        {
            throw new NotImplementedException();
        }

        public void PlotData(params object[] data)
        {
            throw new NotImplementedException();
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }
    }
}
