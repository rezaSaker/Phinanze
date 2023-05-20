using Phinanze.Views;
using System.Windows.Forms;

namespace Phinanze.Presenters
{
    public class Presenter
    {
        public void Show(IView view, IView containerView = null)
        {
            Form viewForm = (Form)view;
            if (containerView != null)
            {
                viewForm.MdiParent = (Form)containerView;
                viewForm.Dock = DockStyle.Fill;
            }
            viewForm.Show();
        }
    }
}
