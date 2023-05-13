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
    public class MDIContainerPresenter : BasePresenter
    {
        private ContainerView _view;
        private bool _moveForm;
        private Point _prevMousePosition;

        public MDIContainerPresenter(BasePresenter mdiChildPresenter = null)
        {     
            _moveForm = false;
            _prevMousePosition = new Point();

            _view = ContainerView.Instance;
            _view.HeaderBar.MouseDown += OnMouseDown;
            _view.HeaderBar.MouseUp += OnMouseUp;
            _view.HeaderBar.MouseMove += OnMouseMove;

            if(mdiChildPresenter == null)
            {
                mdiChildPresenter = new DashboardPresenter();
            }

            Show();
            ShowMDIChild(mdiChildPresenter);
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
        #endregion


        #region Utility Methods
        public override void Show(IView mdiParent = null)
        {
            _view.Show();
        }

        private void ShowMDIChild(BasePresenter presenter)
        {
            presenter.Show(_view);
        }

        #endregion

    }
}
