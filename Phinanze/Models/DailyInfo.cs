using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models
{
    public class DailyInfo 
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public List<Expense> ExpenseList { get; set; }
        public List<Earning> EarningList { get; set; }

        DailyInfo()
        {
            ExpenseList = new List<Expense>();
            EarningList = new List<Earning>();
        }

    }
}
