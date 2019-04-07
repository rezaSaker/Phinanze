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
            btn_loginPanel.BackColor = Color.White;
            btn_loginPanel.ForeColor = Color.Black;
            btn_submit.Text = "Log in";
            btn_submit.Location = new Point(270, 251);

            tb_confirmPassword.Visible = false;
            tb_confirmPassword.Enabled = false;

            cb_rememberMe.Location = new Point(140, 234);

            lbl_status.Location = new Point(270, 300);

            ResetTextBoxProperties();
        }

        private void btn_registerPanel_Click(object sender, EventArgs e)
        {
            btn_registerPanel.BackColor = Color.White;
            btn_registerPanel.ForeColor = Color.Black;
            btn_loginPanel.BackColor = Color.RoyalBlue;
            btn_loginPanel.ForeColor = Color.White;
            btn_submit.Text = "Register";
            btn_submit.Location = new Point(270, 299);

            tb_confirmPassword.Visible = true;
            tb_confirmPassword.Enabled = true;

            cb_rememberMe.Location = new Point(140, 269);

            lbl_status.Location = new Point(157, 348);

            ResetTextBoxProperties();
        }

        private void ResetTextBoxProperties()
        {
            lbl_status.ForeColor = Color.Red;
            lbl_status.Text = "";
            tb_username.Text = "Username";
            tb_username.ForeColor = Color.DarkGray;
            tb_password.Text = "Password";
            tb_password.ForeColor = Color.DarkGray;
            tb_password.PasswordChar = '\0';
            tb_confirmPassword.Text = "Confirm Password";
            tb_confirmPassword.ForeColor = Color.DarkGray;
            tb_confirmPassword.PasswordChar = '\0';
        }

        private void tb_username_MouseClick(object sender, MouseEventArgs e)
        {
            tb_username.Text = "";
            tb_username.ForeColor = Color.Black;
        }

        private void tb_password_MouseClick(object sender, MouseEventArgs e)
        {
            tb_password.Text = "";
            tb_password.ForeColor = Color.Black;
            tb_password.PasswordChar = '*';
        }

        private void tb_confirmPassword_MouseClick(object sender, MouseEventArgs e)
        {
            tb_confirmPassword.Text = "";
            tb_confirmPassword.ForeColor = Color.Black;
            tb_confirmPassword.PasswordChar = '*';
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (btn_submit.Text == "Log in")
            {
                UserLogin();
            }
            else
            {
                UserRegister();
            }
        }

        private void UserLogin()
        {
            string username = tb_username.Text;
            string password = tb_password.Text;

            try
            {
                string result = ServerHandler.AuthenticateUser(username, password);

                if(result == "USER_NOT_FOUND")
                {
                    lbl_status.Text = "Invalid username or password";
                }
                else
                {
                    int userid = Convert.ToInt16(result);
                    StaticStorage.userid = userid;

                    //gets all data for this user from database
                    FetchDailyInfo();
                    FetchMonthlyInfo();
                    FetchCategories();

                    HomePageForm homePage = new HomePageForm();
                    homePage.Show();

                    this.Visible = false;
                    this.Enabled = false;
                }
            }
            catch
            {           
                lbl_status.Text = "Server connection error";
            }
        }

        private void UserRegister()
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

            try
            {
                //if the process succeeds, the user id is returned
                //else, the error info is returned
                string result = ServerHandler.RegisterNewUser(username, password);

                int userid;

                if(int.TryParse(result, out userid))
                {
                    StaticStorage.userid = userid;

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
            catch
            {
                lbl_status.Text = "Server connection error";
            }                                       
        }

        private void FetchDailyInfo()
        {
            //get daily expenses and earnings from database
            string result = ServerHandler.RetrieveDailyInfo();
        }

        private void FetchMonthlyInfo()
        {
            //get monthly expenses and earnings from database
            string result = ServerHandler.RetriveMonthlyInfo();
        }

        private void FetchCategories()
        {

        }
    }
}
