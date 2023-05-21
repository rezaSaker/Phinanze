using System;
using System.Drawing;
using System.Windows.Forms;

namespace Phinanze.Views
{
    public partial class MDIContainerView : Form, IContainerView
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

        public event EventHandler ViewShown;
    }
}
