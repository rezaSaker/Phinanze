using System.Collections.Generic;
using MyCost.View;

namespace MyCost.Common
{
    class StaticStorage
    {
        public const string ServerAddress = "http://localhost/_HOST/MyCost/";
        public const string SourcePath = "https://github.com/rezaSaker/MyCost";
        public const string HelpSourcePath = "https://github.com/rezaSaker/MyCost";
        public const string ReportAppSourcePath = "https://github.com/rezaSaker/MyCost";
        
        public static int? UserID;

        public static string AccessToken;
        public static string Username;

        public static List<string> ExpenseCategories = new List<string>();
        public static List<string> EarningCategories = new List<string>();

        public static List<DailyInfo> DailyInfoList = new List<DailyInfo>();
        public static List<MonthlyInfo> MonthlyInfoList = new List<MonthlyInfo>();

        public static void LogOutUser()
        {
            //reset auto login properties
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();

            //reset all other static fields
            UserID = null;
            Username = null;
            AccessToken = null;
            ExpenseCategories.Clear();
            EarningCategories.Clear();
            DailyInfoList.Clear();
            MonthlyInfoList.Clear();

            UserAuthenticationForm form = new UserAuthenticationForm();
            form.Show();
        }
    }
}
