using Phinanze.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Views
{
    public interface IAddTransactionView  :IView
    {
        event EventHandler SaveButtonClicked;
        event EventHandler DeleteButtonClicked;
        event EventHandler ViewVisibilityChanged;

        DateTime Date { get; set; }
        double Amount { get; set; }
        Category Category { get; set; }
        string Note { get; set; }
    }
}
