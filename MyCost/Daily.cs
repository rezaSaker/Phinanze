using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCost
{
    class Daily
    {
        private int id;
        private int day;
        private int month;
        private int year;

        private double totalExpense;
        private double totalEarning;

        private string note;

        private List<Expense> expenses;
        private List<Earning> earnings;

        public Daily()
        {
            expenses = new List<Expense>();
            earnings = new List<Earning>();
        }

        public int Day
        {
            get { return day; }
            set { day = value; }
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

        public double TotalExpense
        {
            get { return totalExpense; }
            set { totalExpense = value; }
        }

        public double TotalEarning
        {
            get { return totalEarning; }
            set { totalEarning = value; }
        }

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        public List<Expense> Expenses
        {
            get { return expenses; }
            set { expenses = value; }
        }

        public List<Earning> Earnings
        {
            get { return earnings; }
            set { earnings = value; }
        }
    }
}
