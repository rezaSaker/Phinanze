using System;

namespace Phinanze.Views.MonthlyReportView
{
    public interface IMonthlyReportView : IView
    {
        event EventHandler MonthComboBoxSelectedIndexChanged;
        event EventHandler YearComboBoxSelectedIndexChanged;
        event EventHandler SearchTextBoxInputChanged;
        event EventHandler MonthlyReportDGVRowDoubleClick;
        event EventHandler EditButtonClick;
        event EventHandler DeleteButtonClick;

        int SelectedMonth { get; set; }

        int SelectedYear { get; set; }
    }
}
