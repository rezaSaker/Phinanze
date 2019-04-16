using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using MyCost.Common;
using MyCost.ServerHandling;

namespace MyCost.Forms
{
    public partial class SettingsForm : Form
    {
        private bool _quitAppOnFormCLosing;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsFormLoading(object sender, EventArgs e)
        {
            userNameLaabel.Text = "username: " + StaticStorage.Username;
        }

        private void UsernameTextBoxesClicked(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.ForeColor != Color.Black)
            {
                tb.ForeColor = Color.Black;
                tb.Text = "";
            }
        }

        private void UserNameTextBoxesTextChanged(object sender, EventArgs e)
        {
            if (currentUserNameTextBox.ForeColor == Color.Black
                && currentUserNameTextBox.Text != ""
                && newUserNameTextBox.ForeColor == Color.Black
                && newUserNameTextBox.Text != ""
                && confirmUserNameTextBox.ForeColor == Color.Black
                && confirmUserNameTextBox.Text != "")
            {
                submitUserNameButton.Enabled = true;
            }
            else
            {
                submitUserNameButton.Enabled = false;
            }
        }

        private void PasswordTextBoxesClicked(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if(tb.ForeColor != Color.Black)
            {
                tb.ForeColor = Color.Black;
                tb.Text = "";
            }
        }

        private void PasswordTextBoxesTextChanged(object sender, EventArgs e)
        {
            if (currentPasswordTextBox.ForeColor == Color.Black
               && currentPasswordTextBox.Text != ""
               && newPasswordTextBox.ForeColor == Color.Black
               && newPasswordTextBox.Text != ""
               && confirmPasswordTextBox.ForeColor == Color.Black
               && confirmPasswordTextBox.Text != "")
            {
                submitPasswordButton.Enabled = true;
            }
            else
            {
                submitPasswordButton.Enabled = false;
            }
        }

        private void SubmitNewUsernameButtonClicked(object sender, EventArgs e)
        {
            if (currentUserNameTextBox.Text != StaticStorage.Username)
            {
                MessageBox.Show("Current username is incorrect");
            }
            else if (newUserNameTextBox.Text != confirmUserNameTextBox.Text)
            {
                MessageBox.Show("Username doesn't match");
            }
            else //all feilds are correct
            {
                string result = ServerHandler.UpdateUsername(newUserNameTextBox.Text);

                if (result == "SUCCESS")
                {
                    //log out user from the current session
                    logOutButton.PerformClick();
                }
                else
                {
                    MessageBox.Show(result);
                }
            }
        }

        private void SubmitNewPasswordButtonClicked(object sender, EventArgs e)
        {
            if (newPasswordTextBox.Text != confirmPasswordTextBox.Text)
            {
                MessageBox.Show("Password doesn't match");
            }
            else //all fields are correct
            {
                string result = ServerHandler.UpdatePassword(currentPasswordTextBox.Text, newPasswordTextBox.Text);

                if (result == "SUCCESS")
                {
                    //log out user from the current session
                    logOutButton.PerformClick();
                }
                else
                {
                    MessageBox.Show(result);
                }
            }
        }

        private void AddNewDataButtonClicked(object sender, EventArgs e)
        {
            DailyInfoForm form = new DailyInfoForm();
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormCLosing = false;
            this.Hide();
        }

        private void MonthlyReportButtonClicked(object sender, EventArgs e)
        {
            MonthlyInfoForm form = new MonthlyInfoForm();
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormCLosing = false;
            this.Close();
        }

        private void StatisticalReportButtonClicked(object sender, EventArgs e)
        {
            StatisticalReportForm form = new StatisticalReportForm();
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormCLosing = false;
            this.Close();
        }

        private void HomeButtonClicked(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormCLosing = false;
            this.Close();
        }

        private void LogOutButtonClicked(object sender, EventArgs e)
        {
            //this will opt out from direct login option that occurs when remember me checkbox is checked
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();

            UserAuthenticationForm form = new UserAuthenticationForm();
            form.Show();

            _quitAppOnFormCLosing = false;
            this.Close();
        }

        new private void HelpButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Process.Start(StaticStorage.HelpSourcePath);
            }
            catch
            {
                MessageBox.Show("Could not open default browser");
            }
        }

        private void ReportIssueButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Process.Start(StaticStorage.ReportAppSourcePath);
            }
            catch
            {
                MessageBox.Show("Could not open the default browser");
            }
        }

        private void ViewSourceButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Process.Start(StaticStorage.SourcePath);
            }
            catch
            {
                MessageBox.Show("Could not open the default browser");
            }
        }

        private void SettingsFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_quitAppOnFormCLosing)
            {
                Application.Exit();
            }
        }     

    }
}
