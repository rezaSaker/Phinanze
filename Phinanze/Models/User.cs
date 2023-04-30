using Microsoft.IdentityModel.Tokens;
using Phinanze.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models
{
    public class User : UserRepository, IModel
    {
        public User()
        {
            _id = 0;
            _accessToken = null;
        }

        private int _id;
        private string _accessToken;

        public string Name { get; set; }
        public string Email { get; set; }

        public int Id
        {
            get => _id;
            set
            {
                if (_id == 0)
                {
                    _id = value;
                }
                else
                {
                    throw new ArgumentException("Model id property cannot be changed");
                }
            }
        }

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
