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

        private void btn_login_Click(object sender, EventArgs e)
        {
            DisplayLoginPanel();
        }

        private void DisplayLoginPanel()
        {
            btn_register.BackColor = Color.RoyalBlue;
            btn_register.ForeColor = Color.White;
            btn_login.BackColor = Color.White;
            btn_login.ForeColor = Color.Black;

            tb_confirmPassword.Visible = false;
            tb_confirmPassword.Enabled = false;

            btn_submit.Text = "Log in";
            btn_submit.Location = new Point(269, 236);

            ResetTextBoxProperties();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            btn_register.BackColor = Color.White;
            btn_register.ForeColor = Color.Black;
            btn_login.BackColor = Color.RoyalBlue;
            btn_login.ForeColor = Color.White;

            btn_submit.Text = "Register";
            btn_submit.Location = new Point(269, 284);

            tb_confirmPassword.Visible = true;
            tb_confirmPassword.Enabled = true;

            ResetTextBoxProperties();
        }

        private void ResetTextBoxProperties()
        {
            tb_username.Text = "Username";
            tb_username.ForeColor = Color.DarkGray;
            tb_password.Text = "Password";
            tb_password.ForeColor = Color.DarkGray;
            tb_password.PasswordChar = '\0';
            tb_confirmPassword.Text = "Confirm Password";
            tb_confirmPassword.ForeColor = Color.DarkGray;
            tb_password.PasswordChar = '\0';
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
                
            }
            else
            {
                UserRegister();
            }
        }

        private void UserRegister()
        {

        }

        private void UserLogin()
        {

        }
    }
}
