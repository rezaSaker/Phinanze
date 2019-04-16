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

        public static List<DailyInfo> DailyInfo = new List<DailyInfo>();
        public static List<MonthlyInfo> MonthlyInfo = new List<MonthlyInfo>();   

        /// <summary>
        /// Fetch monthly info from the list of daily info and store it in StaticStorage.MonthlyInfo
        /// </summary>
        public static void FetchMonthlyInfo()
        {
            MonthlyInfo.Clear();

            if (DailyInfo.Count < 1)
            {
                //monthly info consists of daily info
                //so, no daily info means no monthly info 
                return;
            }

            //we get the info from db in decsneding order of year
            //so the first year in the list is the most recent
            //and last year in the list is the oldest year
            int recentYear = DailyInfo[0].Year;
            int oldestYear = DailyInfo[DailyInfo.Count - 1].Year;
            double totalEarning = .0;
            double totalExpense = .0;

            for (int year = recentYear; year <= oldestYear; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    totalEarning = .0;
                    totalExpense = .0;

                    foreach (DailyInfo daily in DailyInfo)
                    {
                        if (daily.Year == year && daily.Month == month)
                        {
                            totalEarning += daily.TotalEarning;
                            totalExpense += daily.TotalExpense;
                        }
                    }

                    //if both expense total and earning total are 0 then, no data exists for this month
                    if (totalEarning != 0 || totalExpense != 0)
                    {
                        MonthlyInfo monthly = new MonthlyInfo(month, year, totalEarning, totalExpense);
                        MonthlyInfo.Add(monthly);
                    }
                }
            }
        }
    }
}
