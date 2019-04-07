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
    }
}
