using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCost.Common
{
    class DailyInfo
    {
        private int _day;
        private int _month;
        private int _year;

        private double _totalExpense;
        private double _totalEarning;

        private string _note;

        private List<ExpenseInfo> _expenses;
        private List<EarningInfo> _earnings;

        public DailyInfo()
        {
            _expenses = new List<ExpenseInfo>();
            _earnings = new List<EarningInfo>();
        }

        public int Day
        {
            get { return _day; }
            set { _day = value; }
        }

        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public double TotalExpense
        {
            get { return _totalExpense; }
            set { _totalExpense = value; }
        }

        public double TotalEarning
        {
            get { return _totalEarning; }
            set { _totalEarning = value; }
        }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        public List<ExpenseInfo> Expenses
        {
            get { return _expenses; }
            set { _expenses = value; }
        }

        public List<EarningInfo> Earnings
        {
            get { return _earnings; }
            set { _earnings = value; }
        }
    }
}
