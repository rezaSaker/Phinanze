using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace MyCost
{
    public partial class UserAuthenticationForm : Form
    {
        public UserAuthenticationForm()
        {
            InitializeComponent();
        }

        private void MainFormLoaded(object sender, EventArgs e)
        {
            DisplayLoginPanel();
        }

        private void ShowRegisterPanelButtonClicked(object sender, EventArgs e)
        {
            //reset everything so the panels appears as a register form
            showRegisterPanelButton.BackColor = Color.White;
            showRegisterPanelButton.ForeColor = Color.Black;
            showLoginPanelButton.BackColor = Color.RoyalBlue;
            showLoginPanelButton.ForeColor = Color.White;
            submitButton.Text = "Register";
            submitButton.Location = new Point(270, 299);
            confirmPasswordTextBox.Visible = true;
            confirmPasswordTextBox.Enabled = true;
            rememberMeCheckBox.Location = new Point(140, 269);
            statusLabel.Location = new Point(157, 348);

            ResetTextBoxProperties();
        }

        private void ShowLoginPanelButoonClicked(object sender, EventArgs e)
        {
            DisplayLoginPanel();
        }

        private void UsernameTextBoxClicked(object sender, MouseEventArgs e)
        {
            //removes the placeholder
            usernameTextBox.Text = "";
            usernameTextBox.ForeColor = Color.Black;
        }

        private void PasswordTextboxClicked(object sender, MouseEventArgs e)
        {
            //removes the placeholder
            passwordTextBox.Text = "";
            passwordTextBox.ForeColor = Color.Black;
            passwordTextBox.PasswordChar = '*';
        }

        private void ConfirmPasswordTextBoxClicked(object sender, MouseEventArgs e)
        {
            //removes the placeholder
            confirmPasswordTextBox.Text = "";
            confirmPasswordTextBox.ForeColor = Color.Black;
            confirmPasswordTextBox.PasswordChar = '*';
        }

        private void SubmitButtonClicked(object sender, EventArgs e)
        {
            if (submitButton.Text == "Log in")
            {
                LoginUser();
            }
            else
            {
                RegisterUser();
            }
        }

        private void DisplayLoginPanel()
        {
            //reset everything so the panel appears as a login form
            showRegisterPanelButton.BackColor = Color.RoyalBlue;
            showRegisterPanelButton.ForeColor = Color.White;
            showLoginPanelButton.BackColor = Color.White;
            showLoginPanelButton.ForeColor = Color.Black;
            submitButton.Text = "Log in";
            submitButton.Location = new Point(270, 251);
            confirmPasswordTextBox.Visible = false;
            confirmPasswordTextBox.Enabled = false;
            rememberMeCheckBox.Location = new Point(140, 223);
            statusLabel.Location = new Point(270, 300);

            ResetTextBoxProperties();
        }

        private void ResetTextBoxProperties()
        {
            //reset the placeholders in the textboxes
            statusLabel.ForeColor = Color.Red;
            statusLabel.Text = "";
            usernameTextBox.Text = "Username";
            usernameTextBox.ForeColor = Color.DarkGray;
            passwordTextBox.Text = "Password";
            passwordTextBox.ForeColor = Color.DarkGray;
            passwordTextBox.PasswordChar = '\0';
            confirmPasswordTextBox.Text = "Confirm Password";
            confirmPasswordTextBox.ForeColor = Color.DarkGray;
            confirmPasswordTextBox.PasswordChar = '\0';
        }

        private void LoginUser()
        {
            string username = usernameTextBox.Text;
            string password = this.passwordTextBox.Text;

            string result = ServerHandler.AuthenticateUser(username, password);
            string[] data = result.Split('|');

            int userId;

            //if the login succeeds, user's id and a temporary token are returned
            //else, the error message is returned
            if (int.TryParse(data[0], out userId))
            {
                StaticStorage.UserID = Convert.ToInt16(data[0]);
                StaticStorage.AccessToken = data[1];

                //gets all data for this user from database...
                //...and store them in StaticStorage class
                FetchDailyInfo();
                FetchCategories();

                MainForm homePage = new MainForm();
                homePage.Show();

                //closing MainForm quits the app... 
                //...so making it disbaled and invisible
                this.Visible = false;
                this.Enabled = false;
            }
            else
            {
                statusLabel.Text = result;
            }
        }

        private void RegisterUser()
        {
            string username = usernameTextBox.Text;
            string password = this.passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            if (username.Length < 0)
            {
                statusLabel.Text = "Please enter a username";
                return;
            }
            else if (password.Length < 0)
            {
                statusLabel.Text = "Please enter a password";
                return;
            }
            else if (confirmPassword != password)
            {
                statusLabel.Text = "Password does not match";
                return;
            }

            string access_key = RandomString(100);

            //if the register succeeds, user's id and a temporary token are retured
            //else, the error info is returned
            string result = ServerHandler.RegisterNewUser(access_key, username, password);
            string[] data = result.Split('|');

            int userId;

            if (int.TryParse(data[0], out userId))
            {
                Properties.Settings.Default.AccessKey = access_key;
                Properties.Settings.Default.Save();

                StaticStorage.UserID = userId;
                StaticStorage.AccessToken = data[1];

                //gets all data for this user from database...
                //...and store them in StaticStorage class
                FetchDailyInfo();
                FetchCategories();

                MainForm homePage = new MainForm();
                homePage.Show();

                this.Visible = false;
                this.Enabled = false;
            }
            else
            {
                statusLabel.Text = result;
            }
        }

        private string RandomString(int size)
        {
            string randStr = "";
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                             "abcdefghijklmnopqrstuvwxyz1234567890";
            char[] charSet = str.ToCharArray();

            Random rand = new Random();

            for (int i = 0; i < size; ++i)
            {
                randStr += charSet[rand.Next(0, str.Length)];
            }

            return randStr;
        }

        private void FetchDailyInfo()
        {
            //gets daily expenses and earnings from database
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

                Daily daily = new Daily();

                daily.Day = day;
                daily.Month = month;
                daily.Year = year;
                daily.Note = note;
                daily.TotalEarning = Convert.ToDouble(totalEarning);
                daily.TotalExpense = Convert.ToDouble(totalExpense);

                if (expenseAmounts[0] != "")
                {
                    for (int i = 0; i < expenseReasons.Length; i++)
                    {
                        double amount = Convert.ToDouble(expenseAmounts[i]);
                        string reason = expenseReasons[i];
                        string category = expenseCategories[i];
                        string comment = expenseComments[i];
                        Expense expense = new Expense(reason, amount, category, comment);

                        daily.Expenses.Add(expense);
                    }
                }

                if (earningAmounts[0] != "")
                {
                    for (int i = 0; i < earningSources.Length; i++)
                    {
                        double amount = Convert.ToDouble(earningAmounts[i]);
                        string reason = earningSources[i];
                        string category = earningCategories[i];
                        string comment = earningComments[i];
                        Earning earning = new Earning(reason, amount, category, comment);

                        daily.Earnings.Add(earning);
                    }
                }

                StaticStorage.DailyInfo.Add(daily);
            }
        }

        private void FetchCategories()
        {
            //adds default earning categories
            StaticStorage.EarningCategories.Add("Pay cheque");
            StaticStorage.EarningCategories.Add("Bonus");
            StaticStorage.EarningCategories.Add("Gift");
            StaticStorage.EarningCategories.Add("Refund");
            StaticStorage.EarningCategories.Add("Other");

            //add default expense categories
            StaticStorage.ExpenseCategories.Add("House Rent");
            StaticStorage.ExpenseCategories.Add("Transit");
            StaticStorage.ExpenseCategories.Add("Gas or Fuel");
            StaticStorage.ExpenseCategories.Add("Parking");
            StaticStorage.ExpenseCategories.Add("Groccery");
            StaticStorage.ExpenseCategories.Add("Clothing");
            StaticStorage.ExpenseCategories.Add("Study Material");
            StaticStorage.ExpenseCategories.Add("Hydro");
            StaticStorage.ExpenseCategories.Add("Other Shopping");
            StaticStorage.ExpenseCategories.Add("Restaurant");
            StaticStorage.ExpenseCategories.Add("Other");

            //get custom categories made by user from the database
            string result = ServerHandler.RetrieveCategories();

            if(result == "Server connection error" || result.Length < 1)
            {
                return;
            }

            string[] earningCategories = result.Split('^')[0].Split('|');
            string[] expenseCategories = result.Split('^')[1].Split('|');

            //adds custom earning categories
            foreach(string cat in earningCategories)
            {
                StaticStorage.EarningCategories.Add(cat);
            }

            //adds custom eexpense categories
            foreach (string cat in expenseCategories)
            {
                StaticStorage.ExpenseCategories.Add(cat);
            }
        }

        private void UserAuthenticationFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
