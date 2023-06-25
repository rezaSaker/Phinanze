using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models
{
    public interface ITransaction
    {
        DateTime Date { get; set; }

        int CategoryId { get; set; }

        double Amount { get; set; }

        string Note { get; set; }

    }
}
