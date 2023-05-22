using System;
using System.Drawing;
using System.Windows.Forms;
using Phinanze.Views;

namespace Phinanze.Presenters
{
    public class MDIContainerPresenter : Presenter
    {
        private IContainerView _view;
        private IView _containerView;
        private bool _allowFormMovement;
        private Point _prevMousePosition;

        public MDIContainerPresenter(IContainerView view, IView containerView = null)
        {
            _allowFormMovement = false;
            _prevMousePosition = new Point();

            _view = view;
            _containerView = containerView;
            _view.ViewShown += OnViewShown;

            Show(_view, _containerView);
        }

        #region EventHandler Methods
        

        private void OnViewShown(object sender, EventArgs e)
        {
            DashboardPresenter dashboardPresenter = new DashboardPresenter(DashboardView.Instance, MDIContainerView.Instance);
        }

        #endregion


        #region Utility Methods

        #endregion
    }
}
