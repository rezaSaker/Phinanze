using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Phinanze.Views
{
    public interface IDashboardView : IView
    {
        ComboBox YearComboBox { get; }
        DataGridView OverviewDGV { get; }
        Chart OverviewPieChart { get; }
        Chart OverviewBarChart { get; }

        event EventHandler YearComboBoxSelectedIndexChanged;
        event EventHandler OverviewDGVRowDoubleClick;
    }
}
