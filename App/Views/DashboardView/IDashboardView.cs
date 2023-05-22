using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Phinanze.Views
{
    public interface IDashboardView : IView
    {
        string SelectedYear { get; }
        event EventHandler YearComboBoxSelectedIndexChanged;
        event EventHandler OverviewDGVRowDoubleClick;
    }
}
