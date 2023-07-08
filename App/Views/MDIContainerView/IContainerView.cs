using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phinanze.Views
{
    public interface IContainerView : IView
    {
        event EventHandler AddTransactionButtonClicked;
        
        IView ActiveChildView { get; }
    }
}
