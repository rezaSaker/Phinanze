using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCost
{
    class Monthly
    {
        private int month;
        private int year;

        private double earning;
        private double expense;

        public Monthly(int month, int year, double earning, double expense)
        {
            this.month   = month;
            this.year    = year;
            this.earning = earning;
            this.expense = expense;
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double Earning
        {
            get { return earning; }
            set { earning = value; }
        }

        public double Expense
        {
            get { return expense; }
            set { expense = value; }
        }
    }
}
