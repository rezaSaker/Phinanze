using System;
using System.Text;
using System.Collections;
using System.Net;
using System.Threading;

namespace MyCost.Common.WebHandler
{
    class WebHandler
    {
        private string _webResponse;

        public event EventHandler AuthenticationSuccessEventHandler;
        public event EventHandler AuthenticationFailedEventHandler;
        public event EventHandler RegisterSuccessEventHandler;
        public event EventHandler RegisterFailedEventHandler;
        public event EventHandler RetrieveDailyInfoSuccessEventHandler;
        public event EventHandler RetrieveDailyInfoFailedEEventHandler;
        public event EventHandler RetrieveCategoriesSuccessEventhandler;
        public event EventHandler RetrieveCategoriesFailedEventHandler;

        public string Response
        {
            get => _webResponse;
            set => _webResponse = value;
        }

        public void AuthenticateUser(string username, string password)
        {
            Thread thread = new Thread(() => WebRequestToAuthenticateUser(username, password));
            thread.Start();
        }

        public void WebRequestToAuthenticateUser(string username, string password)
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
                _webResponse = resultData;

                OnAuthenticationSuccess();
            }
            catch
            {
                _webResponse = "Server connection error";

                OnAuthenticationFailed();
            }
        }

        private void OnAuthenticationSuccess()
        {
            AuthenticationSuccessEventHandler?.Invoke(this, null);
        }

        private void OnAuthenticationFailed()
        {
            AuthenticationFailedEventHandler?.Invoke(this, null);
        }

        public void RegisterNewUser(string username, string password, string code)
        {
            Thread thread = new Thread(() => WebRequestToRegisterUser(username, password, code));
            thread.Start();
        }

        private void WebRequestToRegisterUser(string username, string password, string code)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("key", Properties.Settings.Default.AccessKey);
            queryData.Add("username", username);
            queryData.Add("password", password);
            queryData.Add("code", code);

            try
            {
                byte[] resultBytes = www.UploadValues(StaticStorage.ServerAddress + "registerNewUser.php", "POST", queryData);
                string resultData = Encoding.UTF8.GetString(resultBytes);
                _webResponse = resultData;

                OnRegisterSuccess();
            }
            catch
            {
                _webResponse = "Server connection error";

                OnRegisterFailed();
            }
        }

        private void OnRegisterSuccess()
        {
            RegisterSuccessEventHandler?.Invoke(this, null);
        }

        private void OnRegisterFailed()
        {
            RegisterFailedEventHandler?.Invoke(this, null);
        }

        public void RetrieveDailyInfo()
        {
            Thread thread = new Thread(() => WebRequestToRetrieveDailyInfo());
            thread.Start();
        }    

        private void WebRequestToRetrieveDailyInfo()
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
                string resultData = Encoding.UTF8.GetString(resultBytes);
                _webResponse = resultData;

                OnRetrieveDailyInfoSuccess();
            }
            catch
            {
                _webResponse = "Server connection error";

                OnRetrieveDailyInfoFailed();
            }
        }

        private void OnRetrieveDailyInfoSuccess()
        {
            RetrieveDailyInfoSuccessEventHandler?.Invoke(this, null);
        }

        private void OnRetrieveDailyInfoFailed()
        {
            RetrieveDailyInfoFailedEEventHandler?.Invoke(this, null);
        }

        public void RetrieveCategories()
        {
            Thread thread = new Thread(() => WebRequestToRetrieveCategories());
            thread.Start();
        }

        private void WebRequestToRetrieveCategories()
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
                _webResponse = resultData;

                OnRetrieveCategoriesSuccess();
            }
            catch
            {
                _webResponse = "Server connection error";

                OnRetrieveCategoriesFailed();
            }
        }

        private void OnRetrieveCategoriesSuccess()
        {
            RetrieveCategoriesSuccessEventhandler?.Invoke(this, null);
        }

        private void OnRetrieveCategoriesFailed()
        {
            RetrieveCategoriesFailedEventHandler?.Invoke(this, null);
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
            foreach (ExpenseInfo expense in daily.ExpenseList)
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
            foreach (EarningInfo earning in daily.EarningList)
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

        public static string UpdateUsername(string newUsername, string password)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("key", Properties.Settings.Default.AccessKey);
            queryData.Add("token", StaticStorage.AccessToken);
            queryData.Add("userid", StaticStorage.UserID.ToString());
            queryData.Add("newUsername", newUsername);
            queryData.Add("currentUsername", StaticStorage.Username);
            queryData.Add("password", password);

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
