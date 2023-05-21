using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phinanze.Views
{
    public interface IView
    {
        void Show();

        void Hide();

        bool IsOpen { get; }

        bool IsHidden { get; }

        event EventHandler ViewLoading;
        event EventHandler ViewShown;
    }
}
