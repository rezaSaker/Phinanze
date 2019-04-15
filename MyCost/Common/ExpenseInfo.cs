using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCost.Common
{
    class ExpenseInfo
    {
        private double _amount;

        private string _reason;
        private string _category;
        private string _comment;      

        public ExpenseInfo(string reason, double amount, string category, string comment)
        {
            _reason = reason;
            _amount = amount;
            _category = category;
            _comment = comment;           
        }

        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
    }
}
