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
    public interface BasePresenter
    {
        //void ShowView();

        void ShowViewInContainer(Form mdiContainer);
    }
}
