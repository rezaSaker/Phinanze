using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phinanze.Views.MonthlyReportView
{
    public interface IMonthlyReportView : IView
    {
        ComboBox MonthComboBox { get; }

        ComboBox YearComboBox { get; }

        TextBox SearchTextBox { get; }

        DataGridView MonthlyReportDGV { get; }
        
        Label TotalTransactionLabel { get; }
        
        Button EditButton { get; }
        
        Button DeleteButton { get; }

        event EventHandler MonthComboBoxSelectedIndexChanged;
        event EventHandler YearComboBoxSelectedIndexChanged;
        event EventHandler SearchTextBoxInputChanged;
        event EventHandler MonthlyReportDGVRowDoubleClick;
        event EventHandler EditButtonClick;
        event EventHandler DeleteButtonClick;

    }
}
