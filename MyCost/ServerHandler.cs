using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace MyCost
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

        public static string SaveDailyInfo(Daily daily)
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
            foreach (Expense expense in daily.Expenses)
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
            foreach (Earning earning in daily.Earnings)
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
    }
}
