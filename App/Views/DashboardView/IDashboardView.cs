using System;

namespace Phinanze.Views
{
    public interface IDashboardView : IView
    {
        string SelectedYearFromYearList { get; set; }

        int? SelectedYearFromOverviewTable { get; }

        string SelectedMonthFromOverviewTable { get; }

        event EventHandler YearComboBoxSelectedIndexChanged;
        event EventHandler OverviewDGVRowDoubleClick;
    }
}
