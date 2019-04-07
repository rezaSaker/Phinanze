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
        public static void LoginUser(string username, string password)
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection form;
            form = new System.Collections.Specialized.NameValueCollection();

            form.Add("username", username);
            form.Add("password", password);
        }
    }
}
