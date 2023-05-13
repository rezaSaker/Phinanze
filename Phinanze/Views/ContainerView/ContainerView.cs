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
    public partial class ContainerView : Form, IView
    {
        private static ContainerView _instance;

        private ContainerView()
        {
            InitializeComponent();        
        }

        public static ContainerView Instance
        {
            get => _instance != null ? _instance : new ContainerView();
        }

        public Button HeaderBar { get => this.headerBar; }
    }
}
