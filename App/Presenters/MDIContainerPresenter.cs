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

            _view.HeaderPanel.MouseDown += OnMouseDown;
            _view.HeaderPanel.MouseUp += OnMouseUp;
            _view.HeaderPanel.MouseMove += OnMouseMove;
            _view.ViewShown += OnViewShown;

            Show(_view, _containerView);
        }

        #region EventHandler Methods
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            _allowFormMovement = true;
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            _allowFormMovement = false;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_allowFormMovement)
            {
                int xShift = _prevMousePosition.X - Cursor.Position.X;
                int yShift = _prevMousePosition.Y - Cursor.Position.Y;

                _view.ViewLocation = new Point(_view.ViewLocation.X - xShift, _view.ViewLocation.Y - yShift);
            }
            _prevMousePosition = Cursor.Position;
        }

        private void OnViewShown(object sender, EventArgs e)
        {
            DashboardPresenter dashboardPresenter = new DashboardPresenter(DashboardView.Instance, MDIContainerView.Instance);
        }

        #endregion


        #region Utility Methods

        #endregion
    }
}
