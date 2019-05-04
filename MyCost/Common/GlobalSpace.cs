using System.Windows.Forms;
using System.Collections.Generic;
using MyCost.View;

namespace MyCost.Common
{
    class GlobalSpace
    {
        public const string ServerAddress = Server.Address;
        public const string AboutAppPath = "https://github.com/rezaSaker/MyCost";
        public const string HelpPath = "https://github.com/rezaSaker/MyCost";
        public const string ReportAppPath = "https://github.com/rezaSaker/MyCost/issues/new";
        
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
