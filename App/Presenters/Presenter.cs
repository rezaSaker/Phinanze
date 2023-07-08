using Phinanze.Views;
using System.Windows.Forms;

namespace Phinanze.Presenters
{
    public class Presenter
    {
        protected void Show(IView view, IContainerView containerView = null)
        {
            if (containerView != null)
            {
                if(!containerView.IsOpen)
                {
                    containerView.Show();
                }

                if(containerView.ActiveChildView != null)
                {
                    containerView.ActiveChildView.Close();
                }

                ((Form)view).MdiParent = (Form)containerView;
                ((Form)view).Dock = DockStyle.Fill;
            }
            view.Show();
        }
    }
}
