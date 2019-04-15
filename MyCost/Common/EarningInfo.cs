using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCost.Common
{
    class EarningInfo
    {
        private double _amount;

        private string _source;
        private string _category;
        private string _comment;      

        public EarningInfo(string source, double amount, string category, string comment)
        {
            _source = source;
            _amount = amount;
            _category = category;
            _comment = comment;
        }

        public string Source
        {
            get { return _source; }
            set { _source = value; }
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
