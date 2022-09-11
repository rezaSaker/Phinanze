using Phinanze.Common;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;

namespace Phinanze.View
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

                string result = WebHandler.WebRequestToResetPassword(email, tempPassword);

                string[] data = result.Split('|');

                if(int.TryParse(data[0], out int userid))
                {
                    GlobalSpace.UserID = userid;
                    GlobalSpace.AccessToken = data[1];
                    GlobalSpace.Username = data[2];
                    GlobalSpace.CypherKey = StringCipher.Decrypt(data[3], email);
                    
                    if(WebHandler.UpdatePassword(tempPassword, tempPassword) == "SUCCESS")
                    {
                        MailAddress from = new MailAddress("Phinanze.noreply@rezasaker.com");
                        MailAddress to = new MailAddress(email);
                        SendPasswordResetEmail(from, to, tempPassword);
                    }
                    else
                    {
                        string message = "Sorry could not complete the procedure. " +
                            "Please check your internet connection and try again.";

                        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }            
            }
        }

        private void SendPasswordResetEmail(MailAddress from, MailAddress to, string tempPassword)
        {
            //email subject and body
            string subject = "Phinanze Password Reset";
            string message = "Dear User,\n\n" + 
            "Your Phinanze account password has been automatically reset to allow you to recover your account as you requested. \n\n" +
            "Your new password is: " + tempPassword + "\n\n Please use this temporary password to log in to your Phinanze account. " +
            "It is highly recommended that you change your password as soon as you log in with this temporary password.\n\n" +
            "For additional help or question, please contact us via help.Phinanze@rezasaker.com.\n\n" +
            "Thank you\n" +
            "Phinanze Team";

            //send verification code to user's email
            Mailer mailer = new Mailer
            {
                From = from,
                To = to,
                Subject = subject,
                Message = message
            };

            mailer.EmailSendingSuccessEventHandler += OnSendingPasswordResetEmailSuccess; ;
            mailer.EmailSendingFailedEventHandler += OnSendingPasswordResetEmailFailed; ;
            _mailerObject = mailer;
            mailer.SendEmail();
        }

        private void OnSendingPasswordResetEmailSuccess(object sender, EventArgs e)
        {          
            this?.Invoke(new SendMailDelegate(ActionUponSendPasswordResetEmailSuccess), new object[] {  });
        }

        private void OnSendingPasswordResetEmailFailed(object sender, EventArgs e)
        {         
            this?.Invoke(new SendMailDelegate(ActionUponSendPasswordResetEmailFailed), new object[] {});
        }

        private void ActionUponSendPasswordResetEmailSuccess()
        {
            string message = "A temporary password has been sent to your email address. " +
                "Use the temporary password to log in to your Phinanze account. " +
                "Please allow up to 12 hours for the email to be delivered and also check your spam folder. " +
                "Note that it is highly recommended that you change your password as soon as you log in to your account.";

            MessageBox.Show(message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ActionUponSendPasswordResetEmailFailed()
        {
            string message = "Sorry could not complete the procedure. " +
                "Please check your internet connection and try again.";

            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                string tempUsername = GenerateRandomUsername();

                string result = WebHandler.WebRequestToResetUsername(email, tempUsername);

                if (result == "SUCCESS")
                {
                    MailAddress from = new MailAddress("Phinanze.noreply@rezasaker.com");
                    MailAddress to = new MailAddress(email);
                    SendUsernameResetEmail(from, to, tempUsername);
                }
                else
                {
                    MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SendUsernameResetEmail(MailAddress from, MailAddress to, string tempUsername)
        {
            //email subject and body
            string subject = "Phinanze Username Reset";
            string message = "Dear Phinanze User,\n\n" +
            "Your Phinanze account username has been automatically reset to allow you to recover your account as you requested. \n\n" +
            "Your new username is: " + tempUsername + "\n\n Please use this temporary username to log in to your Phinanze account. " +
            "It is highly recommended that you change your username as soon as you log in with this temporary username.\n\n" +
            "For additional help or question, please contact us via help.Phinanze@rezasaker.com.\n\n" +
            "Thank you\n" +
            "Phinanze Team";

            //send verification code to user's email
            Mailer mailer = new Mailer
            {
                From = from,
                To = to,
                Subject = subject,
                Message = message
            };

            mailer.EmailSendingSuccessEventHandler += OnSendingUsernameResetEmailSuccess; ;
            mailer.EmailSendingFailedEventHandler += OnSendingUsernameResetEmailFailed; ;
            _mailerObject = mailer;
            mailer.SendEmail();
        }

        private void OnSendingUsernameResetEmailSuccess(object sender, EventArgs e)
        {
            this?.Invoke(new SendMailDelegate(ActionUponSendUsernameResetEmailSuccess), new object[] { });
        }

        private void OnSendingUsernameResetEmailFailed(object sender, EventArgs e)
        {
            this?.Invoke(new SendMailDelegate(ActionUponSendUsernameResetEmailFailed), new object[] { });
        }

        private void ActionUponSendUsernameResetEmailSuccess()
        {
            string message = "A temporary username has been sent to your email address. " +
                "Use the temporary username to log in to your Phinanze account. " +
                "Please allow up to 12 hours for the email to be delivered and also check your spam folder. " +
                "Note that it is highly recommended that you change your username as soon as you log in to your account.";

            MessageBox.Show(message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ActionUponSendUsernameResetEmailFailed()
        {
            string message = "Sorry could not complete the procedure. " +
                "Please check your internet connection and try again.";

            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                randPos = random.Next(4);
                randomStr += charList[randPos][random.Next(charList[randPos].Length)];
            }

            return randomStr;
        }

        private string GenerateRandomUsername()
        {
            string[] charList = new string[]
            {
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",
                "abcdefghijkmnopqrstuvwxyz",
                "1234567890"
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
