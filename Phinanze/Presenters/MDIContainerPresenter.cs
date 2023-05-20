using System;
using System.Drawing;
using System.Windows.Forms;
using Phinanze.Views;

namespace Phinanze.Presenters
{
    public class MDIContainerPresenter : Presenter
    {
        private IContainerView _view;
        private bool _allowFormMovement;
        private Point _prevMousePosition;

        public MDIContainerPresenter(IView view, IView _containerView = null)
        {
            _allowFormMovement = false;
            _prevMousePosition = new Point();

            _view = (IContainerView)view;
            _view.HeaderPanel.MouseDown += OnMouseDown;
            _view.HeaderPanel.MouseUp += OnMouseUp;
            _view.HeaderPanel.MouseMove += OnMouseMove;
            _view.ViewShown += OnViewShown;

            Show(_view);
        }

        #region EventHandler Methods
        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            _allowFormMovement = true;
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            _allowFormMovement = false;
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_allowFormMovement)
            {
                int xShift = _prevMousePosition.X - Cursor.Position.X;
                int yShift = _prevMousePosition.Y - Cursor.Position.Y;

                _view.ViewLocation = new Point(_view.ViewLocation.X - xShift, _view.ViewLocation.Y - yShift);
            }
            _prevMousePosition = Cursor.Position;
        }

        public void OnViewShown(object sender, EventArgs e)
        {
            DashboardPresenter dashboardPresenter = new DashboardPresenter(DashboardView.Instance, MDIContainerView.Instance);
        }

        #endregion


        #region Utility Methods

        #endregion
    }
}
