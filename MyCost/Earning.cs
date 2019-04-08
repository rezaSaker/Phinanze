using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCost
{
    class Earning
    {
        private string source;
        private string category;
        private string comment;

        private double amount;

        public Earning(string source, double amount, string category, string comment)
        {
            this.source = source;
            this.amount = amount;
            this.category = category;
            this.comment = comment;
        }

        public string Source
        {
            get { return source; }
            set { source = value; }
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
