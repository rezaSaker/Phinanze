using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models.ViewModels
{
    public class DailyOverview
    {
        [DisplayName("Date")]
        public DateTime Date { get; set; }

        [DisplayName("Note")]
        public string Note { get; set; }

        [DisplayName("Total Earning")]
        public double TotalEarning { get; set; }

        [DisplayName("Total Expense")]
        public double TotalExpense { get; set; }
    }
}
