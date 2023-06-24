using System;

namespace Phinanze.Views
{
    public interface ITransactionsView : IView
    {
        event EventHandler MonthComboBoxSelectedIndexChanged;
        event EventHandler YearComboBoxSelectedIndexChanged;
        event EventHandler SearchTextBoxInputChanged;
        event EventHandler MonthlyReportDGVRowDoubleClick;
        event EventHandler EditButtonClick;
        event EventHandler DeleteButtonClick;

        int SelectedMonth { get; set; }

        int SelectedYear { get; set; }

        string SearchBoxText { get; set; }
    }
}
