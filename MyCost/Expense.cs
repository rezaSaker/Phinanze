using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCost
{
    class Expense
    {
        private string reason;
        private string category;
        private string comment;

        private double amount;

        public Expense(string reason, double amount, string category, string comment)
        {
            this.reason = reason;
            this.amount = amount;
            this.category = category;
            this.comment = comment;           
        }

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}
