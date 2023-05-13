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
    public abstract class BasePresenter
    {
        public abstract void Show(IView mdiParent = null);


    }
}
