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
        bool IsOpen { get; }

        bool IsHidden { get; }

        void Show();

        void Hide();

        void InitializeComponents(params object[] data);

        void PlotData(params object[] data);

        void ClearData();

        void Close();

        event EventHandler ViewLoading;
        event EventHandler ViewShown;
    }
}
