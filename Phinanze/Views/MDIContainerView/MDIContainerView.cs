using System;
using System.Drawing;
using System.Windows.Forms;

namespace Phinanze.Views
{
    public partial class MDIContainerView : Form, IView, IContainerView
    {
        public MDIContainerView()
        {
            InitializeComponent();

            this.Shown += delegate { ViewShown?.Invoke(this, EventArgs.Empty); };
        }

        private static MDIContainerView _instance;

        public static MDIContainerView Instance => _instance != null ? _instance : (_instance = new MDIContainerView());

        public Panel HeaderPanel => this.headerPanel;

        public Point ViewLocation
        {
            get => this.Location;
            set => this.Location = value;
        }


        public event EventHandler ViewShown;
    }
}
