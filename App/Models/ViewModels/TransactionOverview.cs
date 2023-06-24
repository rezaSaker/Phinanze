using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models.ViewModels
{
    public class TransactionOverview
    {
        [DisplayName("Date")]
        public DateTime Date { get; set; }

        [DisplayName("Note")]
        public string Note { get; set; }

        [DisplayName("Category")]
        public string Category { get; set; }

        [DisplayName("Amount")]
        public double Amount { get; set; }
    }
}
