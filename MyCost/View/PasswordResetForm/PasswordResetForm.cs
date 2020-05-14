using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCost.View
{
    public partial class PasswordResetForm : Form
    {
        public PasswordResetForm()
        {
            InitializeComponent();
        }

        private void ThisFormLoading(object sender, EventArgs e)
        {
            EmailTextBox.Text = "Enter your email";
        }

        private void EmailTextBoxClicked(object sender, MouseEventArgs e)
        {
            if (EmailTextBox.ForeColor != Color.Black)
            {
                EmailTextBox.Text = "";
                EmailTextBox.ForeColor = Color.Black;
            }
        }

        private void ResetPasswordButtonClicked(object sender, EventArgs e)
        {
            //this method will be completed in later version of the app
            this.Close();
        }

        private void ResetUsernameButtonClicked(object sender, EventArgs e)
        {
            //this method will be completed in later version of the app
            this.Close();
        }
    }
}
