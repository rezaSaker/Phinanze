using System;
using System.Drawing;
using System.Windows.Forms;
using MyCost.Common;
using MyCost.ServerHandling;

namespace MyCost.View
{
    public partial class UserAuthenticationForm : Form
    {
        private bool _quitAppOnFormClosing;

        public UserAuthenticationForm()
        {
            InitializeComponent();

            _quitAppOnFormClosing = true;
        }

        #region event_handler_methods

        private void ThisFormLoading(object sender, EventArgs e)
        {
            DisplayLoginPanel();
        }

        private void ThisFormShown(object sender, EventArgs e)
        {
            //if user had his rememberme checkbox checked
            string username = Properties.Settings.Default.Username;
            string password = Properties.Settings.Default.Password;
     
            //if the user opted to auto login by checking the remmeberMeCheckBox 
            if (username != ""  && password != "")
            {
                //make the text color black so that the login method 
                //doesn't detect the texts as placeholder
                usernameTextBox.ForeColor = Color.Black;
                passwordTextBox.ForeColor = Color.Black;

                //fille the username and password field with pre-saved info
                usernameTextBox.Text = Properties.Settings.Default.Username;
                passwordTextBox.Text = Properties.Settings.Default.Password;

                //attempt login
                submitButton.PerformClick();
            }
        }

        private void ShowRegisterPanelButtonClicked(object sender, EventArgs e)
        {
            DisplayRegisterPanel();
        }

        private void ShowLoginPanelButoonClicked(object sender, EventArgs e)
        {
            DisplayLoginPanel();
        }

        private void UsernameTextBoxClicked(object sender, MouseEventArgs e)
        {
            if (usernameTextBox.ForeColor != Color.Black)
            {
                //remove the placeholder
                usernameTextBox.Text = "";
                usernameTextBox.ForeColor = Color.Black;
            }
        }

        private void PasswordTextboxClicked(object sender, MouseEventArgs e)
        {
            if (passwordTextBox.ForeColor != Color.Black)
            {
                //remove the placeholder
                passwordTextBox.Text = "";
                passwordTextBox.ForeColor = Color.Black;
                passwordTextBox.PasswordChar = '*';
            }
        }

        private void ConfirmPasswordTextBoxClicked(object sender, MouseEventArgs e)
        {
            if (confirmPasswordTextBox.ForeColor != Color.Black)
            {
                //remove the placeholder
                confirmPasswordTextBox.Text = "";
                confirmPasswordTextBox.ForeColor = Color.Black;
                confirmPasswordTextBox.PasswordChar = '*';
            }
        }

        private void ActivationCodeTextBoxClicked(object sender, MouseEventArgs e)
        {
            if(activationCodeTextBox.ForeColor != Color.Black)
            {
                //remove the placeholder
                activationCodeTextBox.Text = "";
                activationCodeTextBox.ForeColor = Color.Black;
            }
        }

        private void SubmitButtonClicked(object sender, EventArgs e)
        {
            if (submitButton.Text == "Log in")
            {
                statusLabel.Text = "Verifying your login credentials, please wait....";

                LoginUser();
            }
            else
            {
                statusLabel.Text = "Creating your account, please wait....";

                RegisterUser();
            }
        }                    

        private void ThisFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_quitAppOnFormClosing)
            {
                Application.Exit();
            }
        }
        #endregion

        #region non_event_handler_methods

        private void DisplayLoginPanel()
        {
            //reset everything so the panel appears as a login form
            showRegisterPanelButton.BackColor = Color.RoyalBlue;
            showRegisterPanelButton.ForeColor = Color.White;
            showLoginPanelButton.BackColor = Color.White;
            showLoginPanelButton.ForeColor = Color.Black;
            submitButton.Text = "Log in";
            submitButton.Location = new Point(280, 251);
            confirmPasswordTextBox.Visible = false;
            confirmPasswordTextBox.Enabled = false;
            activationCodeTextBox.Visible = false;
            activationCodeTextBox.Enabled = false;
            rememberMeCheckBox.Location = new Point(140, 223);
            statusLabel.Location = new Point(276, 300);
            ResetTextBoxProperties();
        }

        private void DisplayRegisterPanel()
        {
            //reset everything so the panel appears as a register form
            showRegisterPanelButton.BackColor = Color.White;
            showRegisterPanelButton.ForeColor = Color.Black;
            showLoginPanelButton.BackColor = Color.RoyalBlue;
            showLoginPanelButton.ForeColor = Color.White;
            submitButton.Text = "Register";
            submitButton.Location = new Point(280, 344);
            confirmPasswordTextBox.Visible = true;
            confirmPasswordTextBox.Enabled = true;
            activationCodeTextBox.Visible = true;
            activationCodeTextBox.Enabled = true;
            rememberMeCheckBox.Location = new Point(136, 319);
            statusLabel.Location = new Point(276, 395);
            ResetTextBoxProperties();
        }

        private void ResetTextBoxProperties()
        {
            //reset the placeholders in the textboxes
            statusLabel.ForeColor = Color.OrangeRed;
            statusLabel.Text = "";
            usernameTextBox.Text = "Username";
            usernameTextBox.ForeColor = Color.DarkGray;
            passwordTextBox.Text = "Password";
            passwordTextBox.ForeColor = Color.DarkGray;
            passwordTextBox.PasswordChar = '\0';
            confirmPasswordTextBox.Text = "Confirm Password";
            confirmPasswordTextBox.ForeColor = Color.DarkGray;
            confirmPasswordTextBox.PasswordChar = '\0';
            activationCodeTextBox.Text = "Activation Code";
            activationCodeTextBox.ForeColor = Color.DarkGray;
        }

        private void LoginUser()
        {
            //if fore-color of a textBox is not black, that means the textbox 
            //contains the placeholder text and user didn't enter any value
            string username = usernameTextBox.ForeColor == Color.Black?
                usernameTextBox.Text : "";
            string password = passwordTextBox.ForeColor == Color.Black?
                passwordTextBox.Text : "";

            if(username.Length < 1)
            {
                statusLabel.Text = "Please enter username";
                return;
            }
            else if(password.Length < 1)
            {
                statusLabel.Text = "Please enter password";
                return;
            }

            string result = ServerHandler.AuthenticateUser(username, password);
            string[] data = result.Split('|');

            //if the login succeeds, 
            //user's id and a temporary access token are returned
            //otherwise, the error message is returned
            if (int.TryParse(data[0], out int userId))
            {
                StaticStorage.UserID = Convert.ToInt16(data[0]);
                StaticStorage.AccessToken = data[1];
                StaticStorage.Username = usernameTextBox.Text;
               
                ActionUponLoginSuccess();
            }
            else
            {
                statusLabel.Text = result;
            }
        }

        private void RegisterUser()
        {
            //if fore-color of a textBox is not black, that means the textbox 
            //contains the placeholder text and user didn't enter any value
            string username = usernameTextBox.ForeColor == Color.Black? 
                usernameTextBox.Text : "";
            string password = passwordTextBox.ForeColor == Color.Black?
                passwordTextBox.Text : "";
            string confirmPassword = confirmPasswordTextBox.ForeColor == Color.Black?
                confirmPasswordTextBox.Text : "";
            string activationCode = activationCodeTextBox.ForeColor == Color.Black ?
                activationCodeTextBox.Text : "";

            if (username.Length < 1)
            {
                statusLabel.Text = "Please enter a username!";
                return;
            }
            else if (password.Length < 1)
            {
                statusLabel.Text = "Please enter a password!";
                return;
            }
            else if (confirmPassword != password)
            {
                statusLabel.Text = "Password does not match!";
                return;
            }
            else if(activationCode.Length < 1)
            {
                statusLabel.Text = "Please enter the activation code";
                return;
            }

            string result = ServerHandler.RegisterNewUser(username, password, activationCode);
            string[] data = result.Split('|');

            //if the register succeeds, 
            //user's id and a temporary access token are retured
            //otherwise, the error message is returned
            if (int.TryParse(data[0], out int userId))
            {            
                StaticStorage.UserID = userId;
                StaticStorage.AccessToken = data[1];
                StaticStorage.Username = usernameTextBox.Text;

                ActionUponLoginSuccess();
            }
            else
            {
                statusLabel.Text = result;
            }
        }

        private void ActionUponLoginSuccess()
        {
            if (rememberMeCheckBox.Checked)
            {
                Properties.Settings.Default.Username = usernameTextBox.Text;
                Properties.Settings.Default.Password = passwordTextBox.Text;
                Properties.Settings.Default.Save();
            }

            //get all data for this user from database
            //and store them in StaticStorage class
            FetchDailyInfo();
            FetchCategories();

            MainForm form = new MainForm();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();
        }

        private void FetchDailyInfo()
        {
            //get daily expenses and earnings from database
            string result = ServerHandler.RetrieveDailyInfo();

            string[] rows = result.Split('^');

            if (rows[0] == "Server connection error" || rows[0] == "")
            {
                //some server error occurred or no data found in the DB for this user
                return;
            }

            foreach (string row in rows)
            {
                string[] cols = row.Split('|');

                int day = Convert.ToInt16(cols[0]);
                int month = Convert.ToInt16(cols[1]);
                int year = Convert.ToInt32(cols[2]);

                string note = cols[3];
                string[] expenseReasons = cols[4].Split('~');
                string[] expenseAmounts = cols[5].Split('~');
                string[] expenseCategories = cols[6].Split('~');
                string[] expenseComments = cols[7].Split('~');
                string[] earningSources = cols[8].Split('~');
                string[] earningAmounts = cols[9].Split('~');
                string[] earningCategories = cols[10].Split('~');
                string[] earningComments = cols[11].Split('~');
                string totalExpense = cols[12];
                string totalEarning = cols[13];

                DailyInfo daily = new DailyInfo
                {
                    Day = day,
                    Month = month,
                    Year = year,
                    Note = note,
                    TotalEarning = Convert.ToDouble(totalEarning),
                    TotalExpense = Convert.ToDouble(totalExpense)
                };

                if (expenseAmounts[0] != "")
                {
                    for (int i = 0; i < expenseReasons.Length; i++)
                    {
                        double amount = Convert.ToDouble(expenseAmounts[i]);
                        string reason = expenseReasons[i];
                        string category = expenseCategories[i];
                        string comment = expenseComments[i];

                        ExpenseInfo expense = new ExpenseInfo
                        {
                            Reason = reason,
                            Amount = amount,
                            Category = category,
                            Comment = comment
                        };
                        daily.ExpenseList.Add(expense);
                    }
                }

                if (earningAmounts[0] != "")
                {
                    for (int i = 0; i < earningSources.Length; i++)
                    {
                        double amount = Convert.ToDouble(earningAmounts[i]);
                        string source = earningSources[i];
                        string category = earningCategories[i];
                        string comment = earningComments[i];

                        EarningInfo earning = new EarningInfo
                        {
                            Source = source,
                            Amount = amount,
                            Category = category,
                            Comment = comment
                        };
                        daily.EarningList.Add(earning);
                    }
                }
                StaticStorage.DailyInfoList.Add(daily);
            }
        }

        private void FetchCategories()
        {
            //get all categories made by user from the database
            string result = ServerHandler.RetrieveCategories();

            if (result == "Server connection error" || result == "")
            {
                //some server error occurred or no data found in the DB for this user
                return;
            }

            string[] earningCategories = result.Split('^')[0].Split('|');
            string[] expenseCategories = result.Split('^')[1].Split('|');

            foreach (string cat in earningCategories)
            {
                StaticStorage.EarningCategories.Add(cat);
            }

            foreach (string cat in expenseCategories)
            {
                StaticStorage.ExpenseCategories.Add(cat);
            }
        }
        #endregion
    }
}
