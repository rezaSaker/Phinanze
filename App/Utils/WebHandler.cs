using System;
using System.Text;
using System.Net;
using System.Threading;

namespace Phinanze.Utils
{
    class WebHandler
    {
        private string _webResponse;

        public event EventHandler WebRequestSuccessEventHandler;
        public event EventHandler WebRequestFailedEventHandler;
        public event EventHandler GetActivationCodeSuccessEventHandler;
        public event EventHandler GetActivationCodeFailedEventHandler;

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

            queryData.Add("username", username);
            queryData.Add("password", password);

            try
            {
                byte[] resultBytes = www.UploadValues(GlobalSettings.ServerAddress + "userAuthentication.php", "POST", queryData);
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
            WebRequestSuccessEventHandler?.Invoke(this, null);
        }

        private void OnAuthenticationFailed()
        {
            WebRequestFailedEventHandler?.Invoke(this, null);
        }

        public void RegisterNewUser(string username, string password, string activationCode, string cypherKey, 
            string emergencyCypherKey, string encryptedEmail, string originalEmail, string emailVerificationCode)
        {
            Thread thread = new Thread(() => WebRequestToRegisterUser(username, password, activationCode,
                cypherKey, emergencyCypherKey, encryptedEmail, originalEmail, emailVerificationCode));
            thread.Start();
        }

        private void WebRequestToRegisterUser(string username, string password, string activationCode, string cypherKey, 
            string emergencyCypherKey, string encryptedEmail, string originalEmail, string emailVerificationCode)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("username", username);
            queryData.Add("password", password);
            queryData.Add("activationCode", activationCode);
            queryData.Add("cipherKey", cypherKey);
            queryData.Add("emergencyCipherKey", emergencyCypherKey);
            queryData.Add("encryptedEmail", encryptedEmail);
            queryData.Add("originalEmail", originalEmail);
            queryData.Add("emailVerificationCode", emailVerificationCode);

            try
            {
                byte[] resultBytes = www.UploadValues(GlobalSettings.ServerAddress + "registerNewUser.php", "POST", queryData);
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
            WebRequestSuccessEventHandler?.Invoke(this, null);
        }

        private void OnRegisterFailed()
        {
            WebRequestFailedEventHandler?.Invoke(this, null);
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

            queryData.Add("token", GlobalSettings.AccessToken);
            queryData.Add("userid", GlobalSettings.UserID.ToString());

            try
            {
                byte[] resultBytes = www.UploadValues(GlobalSettings.ServerAddress + "getDailyInfo.php", "POST", queryData);
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
            WebRequestSuccessEventHandler?.Invoke(this, null);
        }

        private void OnRetrieveDailyInfoFailed()
        {
            WebRequestFailedEventHandler?.Invoke(this, null);
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

            queryData.Add("token", GlobalSettings.AccessToken);
            queryData.Add("userid", GlobalSettings.UserID.ToString());

            try
            {
                byte[] resultBytes = www.UploadValues(GlobalSettings.ServerAddress + "getCategories.php", "POST", queryData);
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
            WebRequestSuccessEventHandler?.Invoke(this, null);
        }

        private void OnRetrieveCategoriesFailed()
        {
            WebRequestFailedEventHandler?.Invoke(this, null);
        }

        public static string SaveDailyInfo(DailyInfo daily)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            string expenseReasons = "";
            string expenseAmounts = "";
            string expenseCategories = "";
            string expenseComments = "";
            string earningSources = "";
            string earningAmounts = "";
            string earningCategories = "";
            string earningComments = "";

            bool addSplitChar = false;

            //adds splitting characters between expense properties so
            //that we can split the rows when retrieving from db
            foreach (ExpenseInfo expense in daily.ExpenseList)
            {
                if (addSplitChar)
                {
                    expenseReasons += "~";
                    expenseAmounts += "~";
                    expenseCategories += "~";
                    expenseComments += "~";
                }
                else
                {
                    addSplitChar = true;
                }

                expenseReasons += expense.Reason;
                expenseAmounts += expense.Amount.ToString();
                expenseCategories += expense.Category;
                expenseComments += expense.Comment;
            }

            addSplitChar = false;

            //adds splitting characters between expense properties so
            //that we can split the rows when retrieving from db
            foreach (EarningInfo earning in daily.EarningList)
            {
                if (addSplitChar)
                {
                    earningSources += "~";
                    earningAmounts += "~";
                    earningCategories += "~";
                    earningComments += "~";
                }
                else
                {
                    addSplitChar = true;
                }

                earningSources += earning.Source;
                earningAmounts += earning.Amount.ToString();
                earningCategories += earning.Category;
                earningComments += earning.Comment;
            }

            queryData.Add("token", GlobalSettings.AccessToken);
            queryData.Add("userid", GlobalSettings.UserID.ToString());
            queryData.Add("note", StringCipher.Encrypt(daily.Note, GlobalSettings.CypherKey));
            queryData.Add("day", daily.Day.ToString());
            queryData.Add("month", daily.Month.ToString());
            queryData.Add("year", daily.Year.ToString());
            queryData.Add("expenseReasons", StringCipher.Encrypt(expenseReasons, GlobalSettings.CypherKey));
            queryData.Add("expenseAmounts", StringCipher.Encrypt(expenseAmounts, GlobalSettings.CypherKey));
            queryData.Add("expenseCategories", StringCipher.Encrypt(expenseCategories, GlobalSettings.CypherKey));
            queryData.Add("expenseComments", StringCipher.Encrypt(expenseComments, GlobalSettings.CypherKey));
            queryData.Add("earningSources", StringCipher.Encrypt(earningSources, GlobalSettings.CypherKey));
            queryData.Add("earningAmounts", StringCipher.Encrypt(earningAmounts, GlobalSettings.CypherKey));
            queryData.Add("earningCategories", StringCipher.Encrypt(earningCategories, GlobalSettings.CypherKey));
            queryData.Add("earningComments", StringCipher.Encrypt(earningComments, GlobalSettings.CypherKey));
            queryData.Add("totalExpense", StringCipher.Encrypt(daily.TotalExpense.ToString(), GlobalSettings.CypherKey));
            queryData.Add("totalEarning", StringCipher.Encrypt(daily.TotalEarning.ToString(), GlobalSettings.CypherKey));

            try
            {
                byte[] resultBytes = www.UploadValues(GlobalSettings.ServerAddress + "saveDailyInfo.php", "POST", queryData);
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

            queryData.Add("token", GlobalSettings.AccessToken);
            queryData.Add("userid", GlobalSettings.UserID.ToString());
            queryData.Add("categoryNames", categoryNames);
            queryData.Add("categoryType", categoryType);

            try
            {
                byte[] resultBytes = www.UploadValues(GlobalSettings.ServerAddress + "saveCategories.php", "POST", queryData);
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

            queryData.Add("token", GlobalSettings.AccessToken);
            queryData.Add("userid", GlobalSettings.UserID.ToString());
            queryData.Add("day", day.ToString());
            queryData.Add("month", month.ToString());
            queryData.Add("year", year.ToString());

            try
            {
                byte[] resultBytes = www.UploadValues(GlobalSettings.ServerAddress + "deleteDailyInfo.php", "POST", queryData);
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

            queryData.Add("token", GlobalSettings.AccessToken);
            queryData.Add("userid", GlobalSettings.UserID.ToString());
            queryData.Add("newUsername", newUsername);
            queryData.Add("currentUsername", GlobalSettings.Username);
            queryData.Add("password", password);

            try
            {
                byte[] resultBytes = www.UploadValues(GlobalSettings.ServerAddress + "updateUsername.php", "POST", queryData);
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

            queryData.Add("token", GlobalSettings.AccessToken);
            queryData.Add("userid", GlobalSettings.UserID.ToString());
            queryData.Add("username", GlobalSettings.Username);
            queryData.Add("currentPassword", currentPass);
            queryData.Add("newPassword", newPass);

            //cipher key for data encryption is encrypted with password when saved to database
            //so when change the password we have to encrypt the key with new password and
            //replace old encrypted key in the database with newly encypted one
            string newCipherKey = StringCipher.Encrypt(GlobalSettings.CypherKey, newPass);
            queryData.Add("newCipherKey", newCipherKey);


            try
            {
                byte[] resultBytes = www.UploadValues(GlobalSettings.ServerAddress + "updatePassword.php", "POST", queryData);
                string resultData = Encoding.UTF8.GetString(resultBytes);

                return resultData;
            }
            catch
            {
                return "Server connection error";
            }
        }

        public void GetActivationCode()
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            try
            {
                byte[] resultBytes = www.UploadValues(GlobalSettings.ServerAddress + "generateActivationCode.php", "POST", queryData);
                string resultData = Encoding.UTF8.GetString(resultBytes);
                _webResponse = resultData;

                if(resultData != "Server connection error")
                {
                    OnGetActivationCodeSuccessful();                   
                }
                else
                {
                    OnGetActivationCodeFailed();
                }               
            }
            catch
            {
                _webResponse = "Server connection error";

                OnGetActivationCodeFailed();
            }
        }

        private void OnGetActivationCodeSuccessful()
        {
            GetActivationCodeSuccessEventHandler?.Invoke(this, null);
        }

        private void OnGetActivationCodeFailed()
        {
            GetActivationCodeFailedEventHandler?.Invoke(this, null);
        }

        public void UpdateEmail(string originalEmail, string encryptedEmail,
            string emailVerificationCode, string password, string emergencyCipherKey)
        {
            Thread thread = new Thread(() =>
            WebRequestToUpdateEmail(originalEmail, encryptedEmail,
            emailVerificationCode, password, emergencyCipherKey));

            thread.Start();
        }

        private void WebRequestToUpdateEmail(string originalEmail, string encryptedEmail,
            string emailVerificationCode, string password, string emergencyCipherKey)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("userid", GlobalSettings.UserID.ToString());
            queryData.Add("token", GlobalSettings.AccessToken);
            queryData.Add("username", GlobalSettings.Username);
            queryData.Add("password", password);
            queryData.Add("encryptedEmail", encryptedEmail);
            queryData.Add("originalEmail", originalEmail);
            queryData.Add("emailVerificationCode", emailVerificationCode);
            queryData.Add("emergencyCipherKey", emergencyCipherKey);

            try
            {
                byte[] resultBytes = www.UploadValues(GlobalSettings.ServerAddress + "updateEmail.php", "POST", queryData);
                string resultData = Encoding.UTF8.GetString(resultBytes);
                _webResponse = resultData;

                OnUpdateEmailSuccess();
            }
            catch
            {
                _webResponse = "Server connection error";

                OnUpdateEmailFailed();
            }
        }

        private void OnUpdateEmailSuccess()
        {
            WebRequestSuccessEventHandler?.Invoke(this, null);
        }

        private void OnUpdateEmailFailed()
        {
            WebRequestFailedEventHandler?.Invoke(this, null);
        }

        public void VerifyEmail(string code)
        {
            Thread thread = new Thread(() => WebRequestToVerifyEmail(code));

            thread.Start();
        }

        private void WebRequestToVerifyEmail(string code)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("userid", GlobalSettings.UserID.ToString());
            queryData.Add("token", GlobalSettings.AccessToken);
            queryData.Add("code", code);

            try
            {
                byte[] resultBytes = www.UploadValues(GlobalSettings.ServerAddress + "verifyEmail.php", "POST", queryData);
                string resultData = Encoding.UTF8.GetString(resultBytes);
                _webResponse = resultData;

                if(resultData == "SUCCESS")
                {
                    OnEmailVerificationSuccess();
                }
                else
                {
                    OnEmaiLVerificationFailed();
                }
            }
            catch
            {
                _webResponse = "Server connection error";

                OnEmaiLVerificationFailed();
            }
        }

        private void OnEmailVerificationSuccess()
        {
            WebRequestSuccessEventHandler?.Invoke(this, null);
        }

        private void OnEmaiLVerificationFailed()
        {
            WebRequestFailedEventHandler?.Invoke(this, null);
        }

        public static string WebRequestToResetPassword(string email, string tempPassword)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("email", email);
            queryData.Add("tempPassword", tempPassword);

            try
            {
                byte[] resultBytes = www.UploadValues(GlobalSettings.ServerAddress + "resetPassword.php", "POST", queryData);
                string resultData = Encoding.UTF8.GetString(resultBytes);

                return resultData;
            }
            catch
            {
                return "Server connection error";
            }
        }

        public static string WebRequestToResetUsername(string email, string tempUsername)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("email", email);
            queryData.Add("tempUsername", tempUsername);

            try
            {
                byte[] resultBytes = www.UploadValues(GlobalSettings.ServerAddress + "resetUsername.php", "POST", queryData);
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
