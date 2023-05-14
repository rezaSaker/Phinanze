using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models
{
    public interface ITransaction
    {
        int CategoryId { get; set; }

        int DailyInfoId { get; set; }

        double Amount { get; set; }

        string Comment { get; set; }
    }
}
