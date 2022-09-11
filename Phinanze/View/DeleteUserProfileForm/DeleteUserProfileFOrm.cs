﻿using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Phinanze.Common;

namespace Phinanze.View
{
    public partial class DeleteUserProfileForm : Form
    {
        public event EventHandler UserDeleteSuccessEventHandler;

        public DeleteUserProfileForm()
        {
            InitializeComponent();
        }

        private void PasswordTextBoxClicked(object sender, MouseEventArgs e)
        {
            if (PasswordTextBox.ForeColor != Color.Black)
            {
                PasswordTextBox.Text = "";
                PasswordTextBox.ForeColor = Color.Black;
            }
        }

        private void DeleteAccountButtonClicked(object sender, EventArgs e)
        {
            if(PasswordTextBox.ForeColor == Color.Black && PasswordTextBox.Text.Length > 0)
            {
                DeleteUserProfile();
            }
            else
            {
                statusLabel.Text = "Please enter your password.";
            }
        }

        private void DeleteUserProfile()
        {
            WebClient www = new WebClient();

            System.Collections.Specialized.NameValueCollection queryData;
            queryData = new System.Collections.Specialized.NameValueCollection();

            queryData.Add("token", GlobalSpace.AccessToken);
            queryData.Add("password", PasswordTextBox.Text);
            queryData.Add("userid", GlobalSpace.UserID.ToString());

            try
            {
                byte[] resultBytes = www.UploadValues(GlobalSpace.ServerAddress + "deleteUserProfile.php", "POST", queryData);
                string resultData = Encoding.UTF8.GetString(resultBytes);

                if (resultData == "SUCCESS")
                {
                    UserDeleteSuccessEventHandler?.Invoke(this, null);

                    this.Close();
                }
                else
                {
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = resultData;
                }
            }
            catch
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Please check your internet connection and try again.";
            }
        }
    }
}
