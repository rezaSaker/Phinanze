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

            System.Collections.Specialized.NameValueCollection requestData;
            requestData = new System.Collections.Specialized.NameValueCollection();

            requestData.Add("key", Properties.Settings.Default.AccessKey);
            requestData.Add("username", username);
            requestData.Add("password", password);

            try
            {
                byte[] resultBytes = www.UploadValues(StaticStorage.ServerAddress + "userAuthentication.php", "POST", requestData);
                string resultData = Encoding.UTF8.GetString(resultBytes);

                return resultData;
            }
            catch { return "Server connection error";  }
        }

        public static string RegisterNewUser(string access_key, string username, string password)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection requestData;
            requestData = new System.Collections.Specialized.NameValueCollection();

            requestData.Add("key", access_key);
            requestData.Add("username", username);
            requestData.Add("password", password);

            try
            {
                byte[] resultBytes = www.UploadValues(StaticStorage.ServerAddress + "registerNewUser.php", "POST", requestData);
                string resultData = Encoding.UTF8.GetString(resultBytes);

                return resultData;
            }
            catch { return "Server connection error"; }
        }

        public static string RetrieveDailyInfo()
        {
            return null;
        }

        public static string RetriveMonthlyInfo()
        {
            return null;
        }

        public static bool SaveDailyInfo(Daily daily)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection requestData;
            requestData = new System.Collections.Specialized.NameValueCollection();

            string expenseReasons = "";
            string expenseAmounts = "";
            string expenseCategories = "";
            string expenseComments = "";
            string earningSources = "";
            string earningAmounts = "";
            string earningCategories = "";
            string earningComments = "";

            bool addSplitChar = false;

            //adds splitting characters between expense properties so...
            //...that we can split the rows when retrieving from db
            foreach (Expense expense in daily.Expenses)
            {
                if (addSplitChar)
                {
                    expenseReasons += "~";
                    expenseAmounts += "~";
                    expenseCategories += "~";
                    expenseComments += "~";
                }
                else { addSplitChar = true;  }

                expenseReasons += expense.Reason;
                expenseAmounts += expense.Amount.ToString();
                expenseCategories += expense.Category;
                expenseComments += expense.Comment;
            }

            addSplitChar = false;

            //adds splitting characters between expense properties so...
            //...that we can split the rows when retrieving from db
            foreach (Earning earning in daily.Earnings)
            {
                if (addSplitChar)
                {
                    earningSources += "~";
                    earningAmounts += "~";
                    earningCategories += "~";
                    earningComments += "~";
                }
                else { addSplitChar = true; }

                earningSources += earning.Source;
                earningAmounts += earning.Amount.ToString();
                earningCategories += earning.Category;
                earningComments += earning.Comment;
            }

            requestData.Add("key", Properties.Settings.Default.AccessKey);
            requestData.Add("token", StaticStorage.AccessToken);
            requestData.Add("userid", StaticStorage.UserID.ToString());
            requestData.Add("note", daily.Note);
            requestData.Add("day", daily.Day.ToString());
            requestData.Add("month", daily.Month.ToString());
            requestData.Add("year", daily.Year.ToString());
            requestData.Add("expenseReasons", expenseReasons);
            requestData.Add("expenseAmounts", expenseAmounts);
            requestData.Add("expenseCategories", expenseCategories);
            requestData.Add("expenseComments", expenseComments);
            requestData.Add("earningSources", earningSources);
            requestData.Add("earningAmounts", earningAmounts);
            requestData.Add("earningCategories", earningCategories);
            requestData.Add("earningComments", earningComments);

            try
            {
                byte[] resultBytes = www.UploadValues(StaticStorage.ServerAddress + "saveDailyInfo.php", "POST", requestData);
                string result = Encoding.UTF8.GetString(resultBytes);

                if (result == "SUCCESS") return true;
                else return false;
            }
            catch (WebException) { return false; }
        }
    }
}
