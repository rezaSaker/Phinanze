using System.Text;
using System.Net;
using MyCost.Common;

namespace MyCost.ServerHandling
{
    class ServerHandler
    {
        public static string AuthenticateUser(string username, string password)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("key", Properties.Settings.Default.AccessKey);
            queryData.Add("username", username);
            queryData.Add("password", password);

            try
            {
                byte[] resultBytes = www.UploadValues(StaticStorage.ServerAddress + "userAuthentication.php", "POST", queryData);
                string resultData  = Encoding.UTF8.GetString(resultBytes);

                return resultData;
            }
            catch
            {
                return "Server connection error";
            }
        }

        public static string RegisterNewUser(string access_key, string username, string password)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("key", access_key);
            queryData.Add("username", username);
            queryData.Add("password", password);

            try
            {
                byte[] resultBytes = www.UploadValues(StaticStorage.ServerAddress + "registerNewUser.php", "POST", queryData);
                string resultData  = Encoding.UTF8.GetString(resultBytes);

                return resultData;
            }
            catch
            {
                return "Server connection error";
            }
        }

        public static string RetrieveDailyInfo()
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("key", Properties.Settings.Default.AccessKey);
            queryData.Add("token", StaticStorage.AccessToken);
            queryData.Add("userid", StaticStorage.UserID.ToString());

           try
           {
                byte[] resultBytes = www.UploadValues(StaticStorage.ServerAddress + "getDailyInfo.php", "POST", queryData);
                string resultData  = Encoding.UTF8.GetString(resultBytes);

                return resultData;
            }
            catch
            {
                return "Server connection error";
            }
        }    

        public static string SaveDailyInfo(DailyInfo daily)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            string expenseReasons    = "";
            string expenseAmounts    = "";
            string expenseCategories = "";
            string expenseComments   = "";
            string earningSources    = "";
            string earningAmounts    = "";
            string earningCategories = "";
            string earningComments   = "";

            bool addSplitChar = false;

            //adds splitting characters between expense properties so...
            //...that we can split the rows when retrieving from db
            foreach (ExpenseInfo expense in daily.Expenses)
            {
                if (addSplitChar)
                {
                    expenseReasons    += "~";
                    expenseAmounts    += "~";
                    expenseCategories += "~";
                    expenseComments   += "~";
                }
                else { addSplitChar = true;  }

                expenseReasons    += expense.Reason;
                expenseAmounts    += expense.Amount.ToString();
                expenseCategories += expense.Category;
                expenseComments   += expense.Comment;
            }

            addSplitChar = false;

            //adds splitting characters between expense properties so...
            //...that we can split the rows when retrieving from db
            foreach (EarningInfo earning in daily.Earnings)
            {
                if (addSplitChar)
                {
                    earningSources    += "~";
                    earningAmounts    += "~";
                    earningCategories += "~";
                    earningComments   += "~";
                }
                else { addSplitChar = true; }

                earningSources    += earning.Source;
                earningAmounts    += earning.Amount.ToString();
                earningCategories += earning.Category;
                earningComments   += earning.Comment;
            }

            queryData.Add("key", Properties.Settings.Default.AccessKey);
            queryData.Add("token", StaticStorage.AccessToken);
            queryData.Add("userid", StaticStorage.UserID.ToString());
            queryData.Add("note", daily.Note);
            queryData.Add("day", daily.Day.ToString());
            queryData.Add("month", daily.Month.ToString());
            queryData.Add("year", daily.Year.ToString());
            queryData.Add("expenseReasons", expenseReasons);
            queryData.Add("expenseAmounts", expenseAmounts);
            queryData.Add("expenseCategories", expenseCategories);
            queryData.Add("expenseComments", expenseComments);
            queryData.Add("earningSources", earningSources);
            queryData.Add("earningAmounts", earningAmounts);
            queryData.Add("earningCategories", earningCategories);
            queryData.Add("earningComments", earningComments);
            queryData.Add("totalExpense", daily.TotalExpense.ToString());
            queryData.Add("totalEarning", daily.TotalEarning.ToString());

            try
            {
                byte[] resultBytes = www.UploadValues(StaticStorage.ServerAddress + "saveDailyInfo.php", "POST", queryData);
                string resultData  = Encoding.UTF8.GetString(resultBytes);

                return resultData;
            }
            catch (WebException)
            {
                return "Server connection error";
            }
        }

        public static string RetrieveCategories()
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("key", Properties.Settings.Default.AccessKey);
            queryData.Add("token", StaticStorage.AccessToken);
            queryData.Add("userid", StaticStorage.UserID.ToString());

            try
            {
                byte[] resultBytes = www.UploadValues(StaticStorage.ServerAddress + "getCategories.php", "POST", queryData);
                string resultData = Encoding.UTF8.GetString(resultBytes);

                return resultData;
            }
            catch
            {
                return "Server connection error";
            }
        }

        public static string SaveCategory(string categoryNames, string categoryType)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("key", Properties.Settings.Default.AccessKey);
            queryData.Add("token", StaticStorage.AccessToken);
            queryData.Add("userid", StaticStorage.UserID.ToString());
            queryData.Add("categoryNames", categoryNames);
            queryData.Add("categoryType", categoryType);

            try
            {
                byte[] resultBytes = www.UploadValues(StaticStorage.ServerAddress + "saveCategories.php", "POST", queryData);
                string resultData = Encoding.UTF8.GetString(resultBytes);

                return resultData;
            }
            catch
            {
                return "Server connection error";
            }
        }

        public static string DeleteDailyInfo(int day, int month, int year)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("key", Properties.Settings.Default.AccessKey);
            queryData.Add("token", StaticStorage.AccessToken);
            queryData.Add("userid", StaticStorage.UserID.ToString());
            queryData.Add("day", day.ToString());
            queryData.Add("month", month.ToString());
            queryData.Add("year", year.ToString());

            try
            {
                byte[] resultBytes = www.UploadValues(StaticStorage.ServerAddress + "deleteDailyInfo.php", "POST", queryData);
                string resultData = Encoding.UTF8.GetString(resultBytes);

                return resultData;
            }
            catch
            {
                return "Server connection error";
            }
        }

        public static string UpdateUsername(string newUsername)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("key", Properties.Settings.Default.AccessKey);
            queryData.Add("token", StaticStorage.AccessToken);
            queryData.Add("userid", StaticStorage.UserID.ToString());
            queryData.Add("newUsername", newUsername);
            queryData.Add("currentUsername", StaticStorage.Username);

            try
            {
                byte[] resultBytes = www.UploadValues(StaticStorage.ServerAddress + "updateUsername.php", "POST", queryData);
                string resultData = Encoding.UTF8.GetString(resultBytes);

                return resultData;
            }
            catch
            {
                return "Server connection error";
            }
        }

        public static string UpdatePassword(string currentPass, string newPass)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("key", Properties.Settings.Default.AccessKey);
            queryData.Add("token", StaticStorage.AccessToken);
            queryData.Add("userid", StaticStorage.UserID.ToString());
            queryData.Add("username", StaticStorage.Username);
            queryData.Add("currentPassword", currentPass);
            queryData.Add("newPassword", newPass);

            try
            {
                byte[] resultBytes = www.UploadValues(StaticStorage.ServerAddress + "updatePassword.php", "POST", queryData);
                string resultData = Encoding.UTF8.GetString(resultBytes);

                return resultData;
            }
            catch
            {
                return "Server connection error";
            }
        }
    }
}
