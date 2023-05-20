using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        event EventHandler ViewLoading;
        event EventHandler ViewShown;
        event EventHandler YearComboBoxSelectedIndexChanged;

    }
}
