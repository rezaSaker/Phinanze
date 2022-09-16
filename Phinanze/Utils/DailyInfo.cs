using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Utils
{
    class DailyInfo
    {
        private int _day;
        private int _month;
        private int _year;

        private double _totalExpense;
        private double _totalEarning;

        private string _note;

        private List<ExpenseInfo> _expenseList;
        private List<EarningInfo> _earningList;

        public DailyInfo()
        {
            _expenseList = new List<ExpenseInfo>();
            _earningList = new List<EarningInfo>();
        }

        public int Day
        {
            get => _day;
            set => _day = value;
        }

        public int Month
        {
            get => _month; 
            set => _month = value; 
        }

        public int Year
        {
            get => _year;
            set => _year = value; 
        }

        public double TotalExpense
        {
            get => _totalExpense; 
            set => _totalExpense = value; 
        }

        public double TotalEarning
        {
            get => _totalEarning; 
            set => _totalEarning = value; 
        }

        public string Note
        {
            get => _note; 
            set => _note = value; 
        }

        public List<ExpenseInfo> ExpenseList
        {
            get => _expenseList; 
            set => _expenseList = value; 
        }

        public List<EarningInfo> EarningList
        { 
            get => _earningList; 
            set => _earningList = value; 
        }
    }
}
