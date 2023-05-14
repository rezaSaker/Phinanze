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
    public partial class MDIContainerView : Form, IView
    {
        public MDIContainerView()
        {
            InitializeComponent();
        }

        private static MDIContainerView _instance;

        public static MDIContainerView Instance
        {
            get => _instance != null ? _instance : (_instance = new MDIContainerView());
        }

        public Panel HeaderPanel { get => this.headerPanel; }
    }
}
