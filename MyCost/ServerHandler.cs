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

            requestData.Add("username", username);
            requestData.Add("password", password);

            byte[] resultBytes = www.UploadValues(StaticStorage.SERVER_ADDRESS + "userAuthentication.php", "POST", requestData);
            string resultData = Encoding.UTF8.GetString(resultBytes);

            return resultData;
        }

        public static string RegisterNewUser(string username, string password)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection requestData;
            requestData = new System.Collections.Specialized.NameValueCollection();

            requestData.Add("username", username);
            requestData.Add("password", password);

            byte[] resultBytes = www.UploadValues(StaticStorage.SERVER_ADDRESS + "registerNewUser.php", "POST", requestData);
            string resultData = Encoding.UTF8.GetString(resultBytes);

            return resultData;
        }

        public static string RetrieveDailyInfo()
        {
            return null;
        }

        public static string RetriveMonthlyInfo()
        {
            return null;
        }

        public static string SaveDailyInfo(Daily daily)
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

            int count = 0;

            foreach (Expense expense in daily.Expenses)
            {
                if (count > 0)
                {
                    expenseReasons += "~";
                    expenseAmounts += "~";
                    expenseCategories += "~";
                    expenseComments += "~";
                }
                expenseReasons += expense.Reason;
                expenseAmounts += expense.Amount.ToString();
                expenseCategories += expense.Category;
                expenseComments += expense.Comment;
            }

            foreach (Earning earning in daily.Earnings)
            {
                if (count > 0)
                {
                    earningSources += "~";
                    earningAmounts += "~";
                    earningCategories += "~";
                    earningComments += "~";
                }
                earningSources += earning.Source;
                earningAmounts += earning.Amount.ToString();
                earningCategories += earning.Category;
                earningComments += earning.Comment;
            }

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
            requestData.Add("cearningComments", earningComments);

            try
            {
                byte[] resultBytes = www.UploadValues(StaticStorage.SERVER_ADDRESS + "saveDailyInfo.php", "POST", requestData);
                string result = Encoding.UTF8.GetString(resultBytes);

                return "SUCCESS";
            }
            catch (WebException)
            {
                return "SERVER_ERROR";
            }
        }
    }
}
