using System;
using System.Drawing;
using System.Windows.Forms;

namespace Phinanze.Views
{
    public partial class MDIContainerView : Form, IContainerView
    {
        private bool _allowFormMovement;
        private Point _prevMousePosition;

        private MDIContainerView()
        {
            InitializeComponent();

            _allowFormMovement = false;
            _prevMousePosition = new Point();

            this.Shown += delegate { ViewShown?.Invoke(this, EventArgs.Empty); };
            this.Load += delegate { ViewLoading?.Invoke(this, EventArgs.Empty); };
            this.addTransactionButton.Click += delegate { AddTransactionButtonClicked?.Invoke(this, EventArgs.Empty); };
        }

        private static MDIContainerView _instance;
        public static MDIContainerView Instance => _instance ?? (_instance = new MDIContainerView());

        public Panel HeaderPanel => this.headerPanel;

        public bool IsOpen { get; private set; }

        public bool IsHidden { get; private set; }

        public IView ActiveChildView { get => (IView)this.ActiveMdiChild; }

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
        public event EventHandler AddTransactionButtonClicked;

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

        private void HeaderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _allowFormMovement = true;
        }

        private void HeaderPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _allowFormMovement = false;
        }

        private void HeaderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_allowFormMovement)
            {
                int xShift = _prevMousePosition.X - Cursor.Position.X;
                int yShift = _prevMousePosition.Y - Cursor.Position.Y;

                Location = new Point(Location.X - xShift, Location.Y - yShift);
            }
            _prevMousePosition = Cursor.Position;
        }
    }
}
