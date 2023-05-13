using Phinanze.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phinanze.Presenters
{
    public class DashboardPresenter : BasePresenter
    {
        private DashboardView _view;

        public DashboardPresenter() 
        {
            _view = DashboardView.Instance;
        }

        public override void Show(IView mdiParent = null)
        {
            if(mdiParent != null)
            {
                _view.MdiParent = (Form)mdiParent;
            }
            _view.Show();
        }
    }
}
