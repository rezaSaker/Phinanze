using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models.Data
{
    public class ExpenseData
    {
        private static ExpenseData _instance;
        private List<Expense> _expenseList;

        private ExpenseData()
        {
            _expenseList = new List<Expense>();
        }

        public static ExpenseData Instance()
        {
            if (_instance == null)
            {
                _instance = new ExpenseData();
            }
            return _instance;
        }
    }
}
