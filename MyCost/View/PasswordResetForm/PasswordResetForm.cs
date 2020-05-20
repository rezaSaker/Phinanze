using MyCost.Common;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;

namespace MyCost.View
{
    public partial class PasswordResetForm : Form
    {
        private Mailer _mailerObject;

        private delegate void SendMailDelegate();
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
            string email = EmailTextBox.Text;

            if(email.Length < 1)
            {
                EmailTextBox.Text = "Please enter your email here";
                EmailTextBox.ForeColor = Color.Red;
            }
            else if(!IsValidEmail(email))
            {
                EmailTextBox.ForeColor = Color.Red;
            }
            else
            {
                string tempPassword = GenerateRandomPassword();

                WebHandler webHandler = new WebHandler();

                string result = webHandler.WebRequestToResetPassword(email, tempPassword);

                string[] data = result.Split('|');

                if(int.TryParse(data[0], out int userid))
                {
                    GlobalSpace.UserID = userid;
                    GlobalSpace.AccessToken = data[1];
                    GlobalSpace.Username = data[2];
                    GlobalSpace.CypherKey = StringCipher.Decrypt(data[3], email);

                    //the line of code below will encryptthe cipher key with new password and update the cipher key in database
                    
                    if(WebHandler.UpdatePassword(tempPassword, tempPassword) == "SUCCESS")
                    {
                        MailAddress from = new MailAddress("contact@rezasaker.com");
                        MailAddress to = new MailAddress(email);
                        SendVerificationEmail(from, to, tempPassword);
                    }
                    else
                    {
                        MessageBox.Show("Sorry could not complete the procedure. Please check your internet connection and try again.");
                    }
                }
                else
                {
                    MessageBox.Show(result);
                }            
            }
        }

        private void SendVerificationEmail(MailAddress from, MailAddress to, string tempPassword)
        {
            //email subject and body
            string subject = "MyCost Password Reset";
            string message = "Dear MyCost User,\n\n" + 
            "Your MyCost account password has been automatically reset to allow you to recover your account as you requested. \n\n" +
            "Your new password is: " + tempPassword + "\n\n Please use this temporary password to log in to your MyCost account. " +
            "It is highly recommended that you change your password as soon as you log in with this temporary password.\n\n" +
            "For additional help or question, please contact us via help.mycost@rezasaker.com.\n\n" +
            "Thank you\n" +
            "MyCost Team";

            //send verification code to user's email
            Mailer mailer = new Mailer
            {
                From = from,
                To = to,
                Subject = subject,
                Message = message
            };

            mailer.EmailSendingSuccessEventHandler += OnSendingVerificationEmailSuccess; ;
            mailer.EmailSendingFailedEventHandler += OnSendingVerificationEmailFailed; ;
            _mailerObject = mailer;
            mailer.SendVerificationEmail();
        }

        private void OnSendingVerificationEmailSuccess(object sender, EventArgs e)
        {
            this?.Invoke(new SendMailDelegate(ActionUponSendMailSuccess), new object[] { });
        }

        private void OnSendingVerificationEmailFailed(object sender, EventArgs e)
        {
            this?.Invoke(new SendMailDelegate(ActionUponSendMailFailed), new object[] { });
        }

        private void ActionUponSendMailSuccess()
        {
            string message = "A temporary password has been sent to your email address. " +
                "Use the temporary password to log in to your MyCost account. " +
                "Please allow up to 12 hours for the email to be delivered and also check your spam folder. " +
                "Note that it is highly recommended that you change your password as soon as you log in to your account.";

            MessageBox.Show(message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ActionUponSendMailFailed()
        {
            MessageBox.Show("Sorry could not complete the procedure. Please check your internet connection and try again.");
        }

        private void ResetUsernameButtonClicked(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text;

            if (email.Length < 1)
            {
                EmailTextBox.Text = "Please enter your email here";
                EmailTextBox.ForeColor = Color.Red;
            }
            else if (!IsValidEmail(email))
            {
                EmailTextBox.ForeColor = Color.Red;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var correctEmail = new System.Net.Mail.MailAddress(email);
                return correctEmail.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private string GenerateRandomPassword()
        {
            string[] charList = new string[] 
            { 
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",
                "abcdefghijkmnopqrstuvwxyz", 
                "1234567890", 
                "!@#$^&*"
            };

            string randomStr = "";
            int randPos;

            Random random = new Random();

            for (int i = 0; i < 9; i++)
            {
                randPos = random.Next(3);
                randomStr += charList[randPos][random.Next(charList[randPos].Length)];
            }

            return randomStr;
        }
    }
}
