using System.Windows.Forms;
using System.Collections.Generic;
using MyCost.View;

namespace MyCost.Common
{
    class GlobalSpace
    {
        //if cloned to different machine from remote repository
        //the following feilds have to changed according to the user's server
        public const string ServerAddress = Server.Address;
        public const string AboutAppPath = Server.AboutAppPath;
        public const string HelpPath = Server.HelpPath;
        public const string ReportIssuePath = Server.ReportIssuePath;
        public const string SourceCodePath = Server.SourceCodePath;
        public const string LicensePath = Server.LicensePath;
        //-------------------------------------------------------------------


        public static int? UserID;

        public static string AccessToken;
        public static string CypherKey;
        public static string Username;
        public static string Email;
        public static bool IsEmailVarified;

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
