using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Net.Mail;
using MyCost.Common;

namespace MyCost.View
{
    public partial class ProfileForm : Form
    {
        private bool _quitAppOnFormClosing;

        private ProgressViewerForm _progressViewerObject;
        private WebHandler _webHandlerObject;
        private Mailer _mailerObject;

        private delegate void UpdateEmailDelegate();
        private delegate void SendVerificationEmailDelegate();
        private delegate void UserDeleteSuccessDelegate();

        public ProfileForm()
        {
            InitializeComponent();

            _quitAppOnFormClosing = true;
        }

        private void ThisFormLoading(object sender, EventArgs e)
        {
            UserNameLabel.Text = "username: " + GlobalSpace.Username;
            UserNameLabel.Text += "     Email: " + GlobalSpace.Email;

            //this label would be placed right after the email
            EmailVerificationStatusLabel.Location = 
                new Point(UserNameLabel.Location.X + UserNameLabel.Size.Width,
                            UserNameLabel.Location.Y);

            if(GlobalSpace.IsEmailVarified)
            {
                EmailVerificationStatusLabel.ForeColor = Color.ForestGreen;
                EmailVerificationStatusLabel.Text = "(Verified)";
            }
            else
            {
                EmailVerificationStatusLabel.ForeColor = Color.Red;
                EmailVerificationStatusLabel.Text = "(Not Verified)";
            }
        }

        private void UsernameTextBoxesClicked(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.ForeColor != Color.Black)
            {
                //remove the placeholder
                tb.ForeColor = Color.Black;
                tb.Text = "";
            }
        }

        private void UserNameTextBoxesTextChanged(object sender, EventArgs e)
        {
            if (CurrentUserNameTextBox.ForeColor == Color.Black
                && CurrentUserNameTextBox.Text != ""
                && NewUserNameTextBox.ForeColor == Color.Black
                && NewUserNameTextBox.Text != ""
                && PasswordTextBox.ForeColor == Color.Black
                && PasswordTextBox.Text != "")
            {
                UpdateUsernameButton.Enabled = true;
            }
            else
            {
                UpdateUsernameButton.Enabled = false;
            }
        }

        private void PasswordTextBoxesClicked(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if(tb.ForeColor != Color.Black)
            {
                tb.ForeColor = Color.Black;
                tb.Text = "";
                tb.PasswordChar = '*';
            }
        }

        private void PasswordTextBoxesTextChanged(object sender, EventArgs e)
        {
            if (CurrentPasswordTextBox.ForeColor == Color.Black
               && CurrentPasswordTextBox.Text != ""
               && NewPasswordTextBox.ForeColor == Color.Black
               && NewPasswordTextBox.Text != ""
               && ConfirmPasswordTextBox.ForeColor == Color.Black
               && ConfirmPasswordTextBox.Text != "")
            {
                UpdatePasswordButton.Enabled = true;
            }
            else
            {
                UpdatePasswordButton.Enabled = false;
            }
        }

        private void ChangeEmailTextBoxesTextChanged(object sender, EventArgs e)
        {
            if(NewEmailTextBox.ForeColor == Color.Black 
                && NewEmailTextBox.Text != ""
                && PasswordForEmailTextBox.ForeColor == Color.Black
                &&PasswordForEmailTextBox.Text != "")
            {
                UpdateEmailButton.Enabled = true;
            }
            else
            {
                UpdateEmailButton.Enabled = false;
            }
        }

        private void SubmitNewUsernameButtonClicked(object sender, EventArgs e)
        {
            if (CurrentUserNameTextBox.Text != GlobalSpace.Username)
            {
                MessageBox.Show("Current username is incorrect");
                return;
            }
            

            string result = WebHandler.UpdateUsername(NewUserNameTextBox.Text, PasswordTextBox.Text);

            if (result == "SUCCESS")
            {
                MessageBox.Show("Your username has been successfully changed. " +
                    "We are logging you out of the current session. Log in with the new username to continue. ");

                 //log out user from the current session                    
                 GlobalSpace.LogOutUser();
                 _quitAppOnFormClosing = false;
                 this.Close();
            }
            else
            {
                 //if the update doesn't succeed, the error message is returned
                 MessageBox.Show(result);
            }
        }

        private void SubmitNewPasswordButtonClicked(object sender, EventArgs e)
        {
            if (NewPasswordTextBox.Text != ConfirmPasswordTextBox.Text)
            {
                MessageBox.Show("Password doesn't match!");
            }
            else //all fields are correctly filled
            {
                string result = WebHandler.UpdatePassword(CurrentPasswordTextBox.Text, NewPasswordTextBox.Text);

                if (result == "SUCCESS")
                {
                    MessageBox.Show("Your password has been successfully changed. " +
                    "We are logging you out of the current session. Log in with the new password to continue. ");

                    //log out user from the current session                   
                    GlobalSpace.LogOutUser();
                    _quitAppOnFormClosing = false;
                    this.Close();
                }
                else
                {
                    //if the update doesn't succeed, error message is returned
                    MessageBox.Show(result);
                }
            }
        }

        private void UpdateEmailButtonClicked(object sender, EventArgs e)
        {
            //disable all controls so that user cannot change anything 
            //after the button is pressed
            DisableAllControls();

            if(!IsValidEmail(NewEmailTextBox.Text))
            {
                MessageBox.Show("Invalid Email. Please check your email address again.");
                EnableAllControls();
                return;
            }

            string originalEmail = NewEmailTextBox.Text;
            string emailVerificationCode = GenerateRandomNumberString(6);
            string password = PasswordForEmailTextBox.Text;

            //encrypt the email with the original cypher key
            string encryptedEmail = StringCipher.Encrypt(originalEmail, GlobalSpace.CypherKey);

            //show progress bar
            string status = "Updating your email, please wait...";
            ProgressViewerForm progressViewer = new ProgressViewerForm(status);
            progressViewer.Location = new Point(this.Location.X + 70, this.Location.Y + 200);
            progressViewer.Show();
            _progressViewerObject = progressViewer;

            //send webrequest to update email
            WebHandler webRequest = new WebHandler();
            webRequest.WebRequestSuccessEventHandler += OnUpdateEmailSuccess;
            webRequest.WebRequestFailedEventHandler += OnUpdateEmailFailed;
            webRequest.UpdateEmail(originalEmail, encryptedEmail, emailVerificationCode, password);
            _webHandlerObject = webRequest;
        }

        private void OnUpdateEmailSuccess(object sender, EventArgs e)
        {
            this.Invoke(new UpdateEmailDelegate(ActionUponUpdateEmailSuccess), new object[] { });
        }

        private void OnUpdateEmailFailed(object sender, EventArgs e)
        {
            this.Invoke(new UpdateEmailDelegate(ActionUponUpdateEmailFailed), new object[] { });
        }

        private void ActionUponUpdateEmailSuccess()
        {
            string result = _webHandlerObject.Response;

            //if the email was ssuccessfully updated, 
            //the six digit verification code is returned by the server script
            //otherwise the error message is returned
            if(int.TryParse(result, out int emailVerificationCode)
                && emailVerificationCode.ToString().Length == 6)
            {
                //change local value of email
                GlobalSpace.Email = NewEmailTextBox.Text;

                //send verification email to the new email address
                MailAddress from = new MailAddress("contact@rezasaker.com");
                MailAddress to = new MailAddress(GlobalSpace.Email);
                SendVerificationEmail(from, to, emailVerificationCode.ToString());
            }
            else
            {
                _progressViewerObject.StopProgress();
                MessageBox.Show(result);
                EnableAllControls();
            }
        }

        private void ActionUponUpdateEmailFailed()
        {
            string result = _webHandlerObject.Response;
            _progressViewerObject.StopProgress();
            MessageBox.Show(result);
            EnableAllControls();
        }

        private void SendVerificationEmail(MailAddress from, MailAddress to, string verificationCode)
        {
            string status = "Sending verification code, please wait...";
            _progressViewerObject.UpdateStatus(status);

            //email subject and body
            string subject = "Email Verification for MyCost";
            string message = @"Dear User\n,
Thanks for registering account with MyCost Finance Management App. 
Your email verification code is " + verificationCode + ".\n\n" +
            "Pease ignore this email if it is not intended for you.\n\n" +
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

            mailer.EmailSendingSuccessEventHandler += OnSendingVerificationEmailSuccess;
            mailer.EmailSendingFailedEventHandler += OnSendingVerificationEmailFailed;
            _mailerObject = mailer;
            mailer.SendEmail();
        }

        private void OnSendingVerificationEmailSuccess(object sender, EventArgs e)
        {
            this.Invoke(new SendVerificationEmailDelegate(ActionUponSendVerificationEmailSuccess), new object[] { });
        }

        private void OnSendingVerificationEmailFailed(object sender, EventArgs e)
        {
            this.Invoke(new SendVerificationEmailDelegate(ActionUponSendVerificationEmailFailed), new object[] { });
        }

        private void ActionUponSendVerificationEmailSuccess()
        {
            UserNameLabel.Text = "username: " + GlobalSpace.Username;
            UserNameLabel.Text += "     Email: " + GlobalSpace.Email;

            _progressViewerObject.StopProgress();
            EnableAllControls();
            ResetChangeEmailControlProperties();
            
        }

        private void ActionUponSendVerificationEmailFailed()
        {
            //even though the email sending wasn't successful, 
            //we would continue with the next step and
            //prompt the user later to ask for verification code
            UserNameLabel.Text = "username: " + GlobalSpace.Username;
            UserNameLabel.Text += "     Email: " + GlobalSpace.Email;

            _progressViewerObject.StopProgress();
            EnableAllControls();
            ResetChangeEmailControlProperties();
        }

        private void MenuButtonsMouseHovering(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.FlatAppearance.BorderColor = Color.Orange;
        }

        private void MenuButtonsMouseLeaving(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.FlatAppearance.BorderColor = Color.LimeGreen;
        }

        private void MenuButtonsClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Name == "HomeButton")
            {
                OpenNewForm(new MainForm());
            }
            else if (button.Name == "MonthlyReportButton")
            {
                OpenNewForm(new MonthlyReportForm());
            }
            else if (button.Name == "StatisticsButton")
            {
                OpenNewForm(new StatisticsForm());
            }
            else if (button.Name == "AddNewDataButton")
            {
                OpenNewForm(new AddNewDataForm());
            }
            else if (button.Name == "LogOutButton")
            {
                GlobalSpace.LogOutUser();
                _quitAppOnFormClosing = false;
                this.Close();
            }
        }

        new private void HelpButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Process.Start(GlobalSpace.HelpPath);
            }
            catch
            {
                MessageBox.Show("Could not open default browser!");
            }
        }

        private void ReportIssueButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Process.Start(GlobalSpace.ReportIssuePath);
            }
            catch
            {
                MessageBox.Show("Could not open the default browser!");
            }
        }

        private void AboutAppButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Process.Start(GlobalSpace.AboutAppPath);
            }
            catch
            {
                MessageBox.Show("Could not open the default browser!");
            }
        }

        private void ViewSourceButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Process.Start(GlobalSpace.SourceCodePath);
            }
            catch
            {
                MessageBox.Show("Could not open the default browser!");
            }
        }

        private void ThisFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_quitAppOnFormClosing)
            {
                Application.Exit();
            }
        }

        private void OpenNewForm(Form form)
        {
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();
        }

        private string GenerateRandomNumberString(int length)
        {
            string charList = "1234567890";

            string randomStr = "";

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                randomStr += charList[random.Next(charList.Length)];
            }

            return randomStr;
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

        private void EnableAllControls()
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = true;
            }
        }

        private void DisableAllControls()
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
            }
        }

        private void ResetChangeEmailControlProperties()
        {
            NewEmailTextBox.Text = "New Email";
            NewEmailTextBox.ForeColor = Color.DimGray;
            PasswordForEmailTextBox.Text = "Password";
            PasswordForEmailTextBox.ForeColor = Color.DimGray;
            PasswordForEmailTextBox.PasswordChar = '\0';
            UpdateEmailButton.Enabled = false;
        }

        private void DeleteProfileButtonClicked(object sender, EventArgs e)
        {
            string msg = "You will not be able to recover your account once you delete your profile and thus you will lost all saved data" +
                "permanently. Do you still want to delete your account?";

            DialogResult userChoice = MessageBox.Show(msg, "warning", MessageBoxButtons.YesNo);

            if (userChoice == DialogResult.Yes)
            {
                DeleteUserProfileForm form = new DeleteUserProfileForm();

                form.UserDeleteSuccessEventHandler += UserDeleteSuccess;

                form.Location = new Point(this.Location.X + 135, this.Location.Y + 179);
                form.Show();
            }
            else
            {
                return;
            }
        }

        private void UserDeleteSuccess(object sender, EventArgs e)
        {
            this.Invoke(new UserDeleteSuccessDelegate(ActionUponUserDeleteSuccess), new object[] { });
        }

        private void ActionUponUserDeleteSuccess()
        {
            GlobalSpace.LogOutUser();
            _quitAppOnFormClosing = false;
            this.Close();
        }
    }
}
