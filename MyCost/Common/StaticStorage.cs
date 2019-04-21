using System.Collections.Generic;

namespace MyCost.Common
{
    class StaticStorage
    {
        public const string ServerAddress = "http://localhost/_HOST/MyCost/";
        public const string SourcePath = "https://github.com/rezaSaker/MyCost";
        public const string HelpSourcePath = "https://github.com/rezaSaker/MyCost";
        public const string ReportAppSourcePath = "https://github.com/rezaSaker/MyCost";
        
        public static int UserID;

        public static string AccessToken;
        public static string Username;

        public static List<string> ExpenseCategories = new List<string>();
        public static List<string> EarningCategories = new List<string>();

        public static List<DailyInfo> DailyInfoList = new List<DailyInfo>();
        public static List<MonthlyInfo> MonthlyInfoList = new List<MonthlyInfo>();   

        
    }
}
