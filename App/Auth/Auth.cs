using Phinanze.Models;
using Phinanze.Models.DBInfo;
using Phinanze.Models.Repositories.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phinanze.Auth
{
    /// <summary>
    /// Authentication class for all authentication related operations
    /// </summary>
    public class Auth
    {
        /// <summary>
        /// The current authenticated user.
        /// </summary>
        public static User User { get; private set; }

        /// <summary>
        /// Indicates whether the current user is authenticated
        /// </summary>
        public static bool Check { get => User != null; }

        public bool AttemptLogin(string email, string password, Dictionary<string, string> additionalParams = null)
        {
            if(email == null || password == null)
            {
                return false;
            }

            HttpRequest<User> http = HttpRequest<User>.URL(API_URL.Authentication_Url);

            http.RequestParams.Add("email", email);
            http.RequestParams.Add("password", password);

            if(additionalParams != null)
            {
                foreach(string key in additionalParams.Keys)
                {
                    http.RequestParams.Add(key, additionalParams[key]);
                }
            }

            if(http.ResponseType(HttpResponseTypes.SingleIModel()).Post().IsSuccessful)
            {
                Auth.User = http.ResponseModel;
            }

            return Auth.Check; 
        }

        /// <summary>
        /// Attempts logout 
        /// </summary>
        /// <returns>This Auth object</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Auth Logout()
        {
            throw new NotImplementedException("Logout method is not yet implemented");
        }
    }
}
