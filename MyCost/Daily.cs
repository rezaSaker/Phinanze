using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCost
{
    class Daily
    {
        private int _day;
        private int _month;
        private int _year;

        private double _totalExpense;
        private double _totalEarning;

        private string _note;

        private List<Expense> _expenses;
        private List<Earning> _earnings;

        public Daily()
        {
            _expenses = new List<Expense>();
            _earnings = new List<Earning>();
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

        public List<Expense> Expenses
        {
            get { return _expenses; }
            set { _expenses = value; }
        }

        public List<Earning> Earnings
        {
            get { return _earnings; }
            set { _earnings = value; }
        }
    }
}
