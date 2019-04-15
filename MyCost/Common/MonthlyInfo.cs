using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCost.Common
{
    class MonthlyInfo
    {
        private int _month;
        private int _year;

        private double _earning;
        private double _expense;

        public MonthlyInfo(int month, int year, double earning, double expense)
        {
            _month = month;
            _year = year;
            _earning = earning;
            _expense = expense;
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

        public double Earning
        {
            get { return _earning; }
            set { _earning = value; }
        }

        public double Expense
        {
            get { return _expense; }
            set { _expense = value; }
        }
    }
}
