using Microsoft.IdentityModel.Tokens;
using Phinanze.Models.Repositories;
using System;

namespace Phinanze.Models
{
    public class User : UserRepository, IModel
    {
        public User() { Model = this; }

        public string Name { get; set; }

        public string Email { get; set; }

        private string _accessToken;
        public string AccessToken
        {
            get => _accessToken;
            set
            {
                if (_accessToken.IsNullOrEmpty())
                {
                    _accessToken = value;
                }
                else
                {
                    throw new ArgumentException("Access token property cannot be changed");
                }
            }
        }
    }
}
