using System;

namespace Phinanze.Views
{
    public interface IDashboardView : IView
    {
        string YearListSelectedItem { get; set; }

        event EventHandler YearComboBoxSelectedIndexChanged;
        event EventHandler OverviewDGVRowDoubleClick;
    }
}
