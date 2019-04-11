using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCost
{
    class StaticStorage
    {
        public const string ServerAddress = "http://localhost/_HOST/MyCost/";

        public static int UserID;

        public static string AccessToken;

        public static List<Daily> DailyInfo     = new List<Daily>();
        public static List<Monthly> MonthlyInfo = new List<Monthly>();
    }
}
