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
            get => _instance != null ? _instance : new AppLoaderView();
        }

        public new void Show()
        {
            if (!_isShown) base.Show();
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
                MDIContainerPresenter presenter = new MDIContainerPresenter();
                this.Hide();
            }
            _secondsCount++;
        }
    }
}
