using System;
using System.Drawing;
using System.Windows.Forms;
using Phinanze.Views;

namespace Phinanze.Presenters
{
    public class MDIContainerPresenter : Presenter
    {
        private readonly IContainerView _view;
        private readonly IContainerView _containerView;

        public MDIContainerPresenter(IContainerView view, IContainerView containerView = null)
        {
            _view = view;
            _containerView = containerView;
            _view.ViewShown += OnViewShown;
            _view.AddTransactionButtonClicked += OnAddTransactionButtonClicked;

            Show(_view, _containerView);
        }

        #region EventHandler Methods
        

        private void OnViewShown(object sender, EventArgs e)
        {
            DashboardPresenter dashboardPresenter = new DashboardPresenter(new DashboardView(), MDIContainerView.Instance);
        }

        private void OnAddTransactionButtonClicked(object sender, EventArgs e)
        {
            AddTransactionPresenter transactionPresenter = new AddTransactionPresenter(AddTransactionView.Instance(), null);
        }

        #endregion


        #region Utility Methods

        #endregion
    }
}
