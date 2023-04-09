using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phinanze.Models.Model;
using Phinanze.Models.Data;
using System.Windows.Forms;

namespace Phinanze.Models
{
    public class MonthlyInfo : Model<MonthlyInfo>
    {
        public List<DailyInfo> DailyInfoList { get; set; }

        public MonthlyInfo()
        {
            DailyInfoList = new List<DailyInfo>();
        }
        public MonthlyInfo (int id)
        {

        }
    }
}
