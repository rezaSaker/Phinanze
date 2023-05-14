using Phinanze.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phinanze.Presenters
{
    public class MDIContainerPresenter
    {
        private MDIContainerView _view;
        private bool _moveForm;
        private Point _prevMousePosition;

        public MDIContainerPresenter()
        {     
            _moveForm = false;
            _prevMousePosition = new Point();

            _view = MDIContainerView.Instance;
            _view.HeaderPanel.MouseDown += OnMouseDown;
            _view.HeaderPanel.MouseUp += OnMouseUp;
            _view.HeaderPanel.MouseMove += OnMouseMove;
            _view.Shown += OnViewShown;

            _view.Show();
        }

        #region EventHandler Methods
        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            _moveForm = true;
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            _moveForm = false;
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_moveForm)
            {
                int xShift = _prevMousePosition.X - Cursor.Position.X;
                int yShift = _prevMousePosition.Y - Cursor.Position.Y;

                _view.Location = new Point(_view.Location.X - xShift, _view.Location.Y - yShift);
            }
            _prevMousePosition = Cursor.Position;
        }

        public void OnViewShown(object sender, EventArgs e)
        {
            DashboardPresenter dashboardPresenter = new DashboardPresenter();
            dashboardPresenter.ShowViewInContainer(_view);
        }
        #endregion


        #region Utility Methods

        #endregion

    }
}
