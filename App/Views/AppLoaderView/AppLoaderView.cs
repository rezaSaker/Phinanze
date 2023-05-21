using Phinanze.Presenters;
using System;
using System.Windows.Forms;
using Phinanze.Views;

namespace Phinanze.Views
{
    public partial class AppLoaderView : Form, IView
    {
        private int _secondsCount;
        private bool _isShown;
        private static AppLoaderView _instance;

        private AppLoaderView()
        {
            InitializeComponent();

            _isShown = false;
            _secondsCount = 0;
        }

        public static AppLoaderView Instance
        {
            get => _instance ?? (_instance = new AppLoaderView());
        }

        public bool IsOpen { get; private set; }

        public bool IsHidden { get; private set; }

        public new void Show()
        {
            this.IsOpen = true;
            this.IsHidden = false;
            if (!_isShown) base.Show(); // Prevent showing this form more than once
        }

        public new void Hide()
        {
            this.IsOpen = false;
            this.IsHidden = true;
            base.Hide();
        }

        private void AppLoaderView_Shown(object sender, EventArgs e)
        {
            _isShown = true;
            Timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(_secondsCount == 2)
            {
                MDIContainerPresenter presenter = new MDIContainerPresenter(MDIContainerView.Instance);
                this.Hide();
            }
            _secondsCount++;
        }
    }
}
