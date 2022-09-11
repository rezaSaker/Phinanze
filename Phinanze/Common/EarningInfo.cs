using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Common
{
    class EarningInfo
    {
        private double _amount;

        private string _source;
        private string _category;
        private string _comment;      

        public EarningInfo() { }

        public string Source
        {
            get => _source; 
            set => _source = value; 
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
