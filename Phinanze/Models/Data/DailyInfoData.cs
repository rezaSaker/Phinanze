using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models.Data
{
    public class DailyInfoData
    {
        private static DailyInfoData _instance;
        private List<DailyInfo> _dailyInfoList;

        private DailyInfoData()
        {
            _dailyInfoList = new List<DailyInfo>();
        }

        public static DailyInfoData Instance()
        {
            if (_instance == null)
            {
                _instance = new DailyInfoData();
            }
            return _instance;
        }
    }
}
