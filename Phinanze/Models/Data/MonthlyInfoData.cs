using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models.Data
{
    public class MonthlyInfoData
    {
        private static MonthlyInfoData _instance = null;
        private List<MonthlyInfo> _monthlyInfoList;

        private MonthlyInfoData() 
        {
            _monthlyInfoList = new List<MonthlyInfo>();
        }

        public static MonthlyInfoData Instance()
        { 
            if(_instance == null)
            {
                _instance = new MonthlyInfoData();
            }
            return _instance;
        }
    }
}
