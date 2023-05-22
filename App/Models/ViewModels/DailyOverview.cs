using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models.ViewModels
{
    public class DailyOverview
    {
        public DateTime Date { get; set; }

        public string Note { get; set; }

        public double TotalEarning { get; set; }

        public double TotalExpense { get; set; }
    }
}
