using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Common
{
    class ExpenseInfo
    {
        private double _amount;

        private string _reason;
        private string _category;
        private string _comment;      

        public ExpenseInfo() { }

        public string Reason
        {
            get => _reason; 
            set => _reason = value; 
        }

        public double Amount
        {
            get => _amount; 
            set => _amount = value; 
        }

        public string Category
        {
            get => _category; 
            set => _category = value; 
        }

        public string Comment
        {
            get => _comment; 
            set => _comment = value; 
        }
    }
}
