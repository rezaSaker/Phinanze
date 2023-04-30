using Phinanze.Models;
using Phinanze.Models.DBContext;
using Phinanze.Models.Repositories.Http;
using System;

namespace Phinanze.Auth
{
    public class Auth
    {
        /// <summary>
        /// Class to represent login credentials
        /// </summary>
        public class LoginCredentials
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public LoginCredentials(string email, string password)
            {
                Email = email;
                Password = password;
            }
        }

        // Fields
        private static User _user;
        private LoginCredentials _loginCredentials;
        private bool _isSuccessful;

        // Constructor
        private Auth(LoginCredentials credentials)
        {
            _user = null;
            _loginCredentials = credentials;
        }

        /// <summary>
        /// Indicates whether an operation (login/logout) was successful
        /// </summary>
        public bool IsSuccessful { get => _isSuccessful; }
        
        /// <summary>
        /// The current authenticated user.
        /// </summary>
        public static User User
        {
            get => _user;
            set
            {
                if(_user == null)
                {
                    _user = value;
                }
                else
                {
                    throw new ArgumentException("User value is already assigned");
                }
            }
        }

        /// <summary>
        /// Credentials used to verify a login request
        /// </summary>
        /// <returns>This Auth object</returns>
        public static Auth Credentials(string email, string password)
        {
            return new Auth(new LoginCredentials(email, password));
        }

        /// <summary>
        /// Attempts login with the associated login credentials
        /// </summary>
        /// <returns>This Auth object</returns>
        public Auth Login()
        {
            if(_loginCredentials == null)
            {
                _isSuccessful = false;
                return this;
            }

            HttpRequest<User> http = HttpRequest<User>.URL(DB.Authentication_Url);
            http.AddQueryParams("email", _loginCredentials.Email);
            http.AddQueryParams("password", _loginCredentials.Password);

            if(http.Post().IsSuccessful)
            {
                Auth.User = http.JsonToObject(http.PostSuccessResponse);
            }

            _isSuccessful = Auth.User != null;
            return this;  
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
