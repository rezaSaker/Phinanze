using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public Category Category { get; set; }
        public string Comment { get; set; }
    }
}
