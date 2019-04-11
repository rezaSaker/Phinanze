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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DisplayLoginPanel();
        }

        private void btn_loginPanel_Click(object sender, EventArgs e)
        {
            DisplayLoginPanel();
        }

        private void DisplayLoginPanel()
        {
            btn_registerPanel.BackColor = Color.RoyalBlue;
            btn_registerPanel.ForeColor = Color.White;
            btn_loginPanel.BackColor    = Color.White;
            btn_loginPanel.ForeColor    = Color.Black;
            btn_submit.Text             = "Log in";
            btn_submit.Location         = new Point(270, 251);

            tb_confirmPassword.Visible = false;
            tb_confirmPassword.Enabled = false;

            cb_rememberMe.Location = new Point(140, 223);

            lbl_status.Location = new Point(270, 300);

            ResetTextBoxProperties();
        }

        private void btn_registerPanel_Click(object sender, EventArgs e)
        {
            btn_registerPanel.BackColor = Color.White;
            btn_registerPanel.ForeColor = Color.Black;
            btn_loginPanel.BackColor    = Color.RoyalBlue;
            btn_loginPanel.ForeColor    = Color.White;
            btn_submit.Text             = "Register";
            btn_submit.Location         = new Point(270, 299);

            tb_confirmPassword.Visible = true;
            tb_confirmPassword.Enabled = true;

            cb_rememberMe.Location = new Point(140, 269);

            lbl_status.Location = new Point(157, 348);

            ResetTextBoxProperties();
        }

        private void ResetTextBoxProperties()
        {
            lbl_status.ForeColor            = Color.Red;
            lbl_status.Text                 = "";
            tb_username.Text                = "Username";
            tb_username.ForeColor           = Color.DarkGray;
            tb_password.Text                = "Password";
            tb_password.ForeColor           = Color.DarkGray;
            tb_password.PasswordChar        = '\0';
            tb_confirmPassword.Text         = "Confirm Password";
            tb_confirmPassword.ForeColor    = Color.DarkGray;
            tb_confirmPassword.PasswordChar = '\0';
        }

        private void tb_username_MouseClick(object sender, MouseEventArgs e)
        {
            tb_username.Text      = "";
            tb_username.ForeColor = Color.Black;
        }

        private void tb_password_MouseClick(object sender, MouseEventArgs e)
        {
            tb_password.Text         = "";
            tb_password.ForeColor    = Color.Black;
            tb_password.PasswordChar = '*';
        }

        private void tb_confirmPassword_MouseClick(object sender, MouseEventArgs e)
        {
            tb_confirmPassword.Text         = "";
            tb_confirmPassword.ForeColor    = Color.Black;
            tb_confirmPassword.PasswordChar = '*';
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (btn_submit.Text == "Log in")
            {
                LoginUser();
            }
            else
            {
                RegisterUser();
            }
        }

        private void LoginUser()
        {
            string username = tb_username.Text;
            string password = tb_password.Text;

            string result = ServerHandler.AuthenticateUser(username, password);
            string[] data = result.Split('|');

            int userId;

            //if the login succeeds, user's id and a temporary token are returned
            //else, the error message is returned
            if(int.TryParse(data[0], out userId))
            {
                StaticStorage.UserID      = Convert.ToInt16(data[0]);
                StaticStorage.AccessToken = data[1];

                //gets all data for this user from database...
                //...and store them in StaticStorage class
                FetchDailyInfo();
                FetchMonthlyInfo();
                FetchCategories();

                HomePageForm homePage = new HomePageForm();
                homePage.Show();

                //closing MainForm quits the app... 
                //...so making it disbaled and invisible
                this.Visible = false;
                this.Enabled = false;
            }        
            else
            {
                lbl_status.Text = result;
            }
        }

        private void RegisterUser()
        {
            string username = tb_username.Text;
            string password = tb_password.Text;
            string confirmPassword = tb_confirmPassword.Text;

            if(username.Length < 0)
            {
                lbl_status.Text = "Please enter a username";
                return;
            }
            else if(password.Length < 0)
            {
                lbl_status.Text = "Please enter a password";
                return;
            }
            else if (confirmPassword != password)
            {
                lbl_status.Text = "Password does not match";
                return;
            }

            string access_key = RandomString(100);

            //if the register succeeds, user's id and a temporary token are retured
            //else, the error info is returned
            string result = ServerHandler.RegisterNewUser(access_key, username, password);
            string[] data = result.Split('|');

            int userId;

            if(int.TryParse(data[0], out userId))
            {
                Properties.Settings.Default.AccessKey = access_key;
                Properties.Settings.Default.Save();

                StaticStorage.UserID = userId;
                StaticStorage.AccessToken = data[1];          

                //gets all data for this user from database...
                //...and store them in StaticStorage class
                FetchDailyInfo();
                FetchMonthlyInfo();
                FetchCategories();

                HomePageForm homePage = new HomePageForm();
                homePage.Show();

                this.Visible = false;
                this.Enabled = false;
            }
            else
            {
                lbl_status.Text = result;
            }                                      
        }

        private string RandomString(int size)
        {
            string randStr = "";
            string str     = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                             "abcdefghijklmnopqrstuvwxyz1234567890";
            char[] charSet = str.ToCharArray();

            Random rand = new Random();
            
            for(int i = 0; i < size; ++i)
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

            if(rows[0] == "Server connection error" || rows[0] == "")
            {
                //some server error occurred or no data found in the DB for this user
                return;
            }

            foreach(string row in rows)
            {
                string[] cols = row.Split('|');

                int day   = Convert.ToInt16(cols[0]);
                int month = Convert.ToInt16(cols[1]);
                int year  = Convert.ToInt32(cols[2]);

                string note                = cols[3];      
                string[] expenseReasons    = cols[4].Split('~');
                string[] expenseAmounts    = cols[5].Split('~');
                string[] expenseCategories = cols[6].Split('~');
                string[] expenseComments   = cols[7].Split('~');
                string[] earningSources    = cols[8].Split('~');
                string[] earningAmounts    = cols[9].Split('~');
                string[] earningCategories = cols[10].Split('~');
                string[] earningComments   = cols[11].Split('~');
                string totalExpense        = cols[12];
                string totalEarning        = cols[13];

                Daily daily = new Daily();

                daily.Day           = day;
                daily.Month         = month;
                daily.Year          = year;
                daily.Note          = note;
                daily.TotalEarning  = Convert.ToDouble(totalEarning);
                daily.TotalExpense  = Convert.ToDouble(totalExpense);

                if(expenseAmounts[0] != "")
                {
                    for (int i = 0; i < expenseReasons.Length; i++)
                    {
                        double amount   = Convert.ToDouble(expenseAmounts[i]);
                        string reason   = expenseReasons[i];
                        string category = expenseCategories[i];
                        string comment  = expenseComments[i];
                        Expense expense = new Expense(reason, amount, category, comment);

                        daily.Expenses.Add(expense);
                    }
                }

                if(earningAmounts[0] != "")
                {
                    for (int i = 0; i < earningSources.Length; i++)
                    {
                        double amount   = Convert.ToDouble(earningAmounts[i]);
                        string reason   = earningSources[i];
                        string category = earningCategories[i];
                        string comment  = earningComments[i];
                        Earning earning = new Earning(reason, amount, category, comment);

                        daily.Earnings.Add(earning);
                    }
                }

                StaticStorage.DailyInfo.Add(daily);
            }
        }

        private void FetchMonthlyInfo()
        {
            if (StaticStorage.DailyInfo.Count < 1)
            {
                return;
            }

            //we get the info from db order by year in descending
            //so the first year in the list is the most recent
            //and last year in the list is the oldest year
            int recentYear = StaticStorage.DailyInfo[StaticStorage.DailyInfo.Count - 1].Year;
            int oldestYear = StaticStorage.DailyInfo[0].Year;

            for(int year = recentYear; year >= oldestYear; --year)
            {
                for(int month = 1; month <= 12; ++month)
                {
                    double totalEarning = .0;
                    double totalExpense = .0;

                    foreach(Daily daily in StaticStorage.DailyInfo)
                    {
                        if(daily.Year == year && daily.Month == month)
                        {
                            totalEarning += daily.TotalEarning;
                            totalExpense += daily.TotalExpense;
                        }
                    }

                    Monthly monthly = new Monthly(month, year, totalEarning, totalExpense);
                    StaticStorage.MonthlyInfo.Add(monthly);
                }
            }
        }

        private void FetchCategories()
        {

        }
    }
}
