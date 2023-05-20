using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Net.Mail;
using Phinanze.Utils;

namespace Phinanze.Forms
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
            LoadBasicInformation();
        }

        private void LoadBasicInformation()
        {
            UserNameLabel.Text = "username: " + GlobalSettings.Username;
            UserNameLabel.Text += "     Email: " + GlobalSettings.Email;

            //this label would be placed right after the email
            EmailVerificationStatusLabel.Location =
                new Point(UserNameLabel.Location.X + UserNameLabel.Size.Width,
                            UserNameLabel.Location.Y);

            if (GlobalSettings.IsEmailVarified)
            {
                EmailVerificationStatusLabel.ForeColor = Color.ForestGreen;
                EmailVerificationStatusLabel.Text = "(Verified)";
                VerifyEmailButton.Visible = false;
            }
            else
            {
                EmailVerificationStatusLabel.ForeColor = Color.Red;
                EmailVerificationStatusLabel.Text = "(Not Verified)";
                VerifyEmailButton.Location = new Point(
                    EmailVerificationStatusLabel.Location.X + EmailVerificationStatusLabel.Size.Width + 5,
                    VerifyEmailButton.Location.Y);
                VerifyEmailButton.Visible = true;
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

        private void SubmitNewUsernameButtonClicked(object sender, EventArgs e)
        {
            if(NewUserNameTextBox.ForeColor != Color.Black || NewUserNameTextBox.Text.Length < 1)
            {
                NewUserNameTextBox.Text = "New Username";
                NewUserNameTextBox.ForeColor = Color.Red;
            }
            else if(ConfirmUserNameTextBox.ForeColor != Color.Black || ConfirmUserNameTextBox.Text.Length < 1)
            {
                ConfirmUserNameTextBox.Text = "Confirm New Username";
                ConfirmUserNameTextBox.ForeColor = Color.Red;
            }
            else if(PasswordForUsernameChangeTextBox.ForeColor != Color.Black 
                || PasswordForUsernameChangeTextBox.Text.Length < 1)
            {
                PasswordForUsernameChangeTextBox.ForeColor = Color.Red;
                PasswordForUsernameChangeTextBox.Text = "Password";
                PasswordForUsernameChangeTextBox.PasswordChar = '\0';
            }
            else if(NewUserNameTextBox.Text != ConfirmUserNameTextBox.Text)
            {
                NewUserNameTextBox.ForeColor = ConfirmUserNameTextBox.ForeColor = Color.Red;

                string message = "Usernames do not match.";

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //all fields are correctly filled
            {
                string result = WebHandler.UpdateUsername(ConfirmUserNameTextBox.Text, PasswordForUsernameChangeTextBox.Text);

                if (result == "SUCCESS")
                {
                    string message = "Your username has been successfully changed. " +
                        "We are logging you out of the current session. " +
                        "Log in with the new username to continue. ";

                    MessageBox.Show(message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //log out user from the current session                    
                    GlobalSettings.LogOutUser();
                    _quitAppOnFormClosing = false;
                    this.Close();
                }
                else
                {
                    //if the update doesn't succeed, the error message is returned
                    MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }           
        }

        private void SubmitNewPasswordButtonClicked(object sender, EventArgs e)
        {
            if (NewPasswordTextBox.ForeColor != Color.Black || NewPasswordTextBox.Text.Length < 1)
            {
                NewPasswordTextBox.Text = "New Password";
                NewPasswordTextBox.ForeColor = Color.Red;
                NewPasswordTextBox.PasswordChar = '\0';
            }
            else if (ConfirmPasswordTextBox.ForeColor != Color.Black || ConfirmPasswordTextBox.Text.Length < 1)
            {
                ConfirmPasswordTextBox.Text = "Confirm New Password";
                ConfirmPasswordTextBox.ForeColor = Color.Red;
                ConfirmPasswordTextBox.PasswordChar = '\0';
            }
            else if (CurrentPasswordTextBox.ForeColor != Color.Black || CurrentPasswordTextBox.Text.Length < 1)
            {
                CurrentPasswordTextBox.ForeColor = Color.Red;
                CurrentPasswordTextBox.Text = "Current Password";
                CurrentPasswordTextBox.PasswordChar = '\0';
            }
            else if (NewPasswordTextBox.Text != ConfirmPasswordTextBox.Text)
            {
                NewPasswordTextBox.ForeColor = ConfirmPasswordTextBox.ForeColor = Color.Red;

                string message = "Passwords do not match!";

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //all fields are correctly filled
            {
                string result = WebHandler.UpdatePassword(CurrentPasswordTextBox.Text, NewPasswordTextBox.Text);

                if (result == "SUCCESS")
                {
                    string message = "Your password has been successfully changed. " +
                    "We are logging you out of the current session. " +
                    "Log in with the new password to continue. ";

                    MessageBox.Show(message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //log out user from the current session                   
                    GlobalSettings.LogOutUser();
                    _quitAppOnFormClosing = false;
                    this.Close();
                }
                else
                {
                    //if the update doesn't succeed, error message is returned
                    MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateEmailButtonClicked(object sender, EventArgs e)
        {
            if (NewEmailTextBox.ForeColor != Color.Black || NewEmailTextBox.Text.Length < 1)
            {
                NewEmailTextBox.Text = "New Email";
                NewEmailTextBox.ForeColor = Color.Red;
            }
            else if (PasswordForEmailTextBox.ForeColor != Color.Black || PasswordForEmailTextBox.Text.Length < 1)
            {
                PasswordForEmailTextBox.Text = "Password";
                PasswordForEmailTextBox.ForeColor = Color.Red;
                PasswordForEmailTextBox.PasswordChar = '\0';
            }
            else if (!IsValidEmail(NewEmailTextBox.Text))
            {
                NewEmailTextBox.ForeColor = Color.Red;

                string message = "Invalid Email. Please check your email address again.";

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //disable all controls so that user cannot change anything 
                //after the button is pressed
                DisableAllControls();

                string originalEmail = NewEmailTextBox.Text;
                string emailVerificationCode = GenerateRandomNumberString(6);
                string password = PasswordForEmailTextBox.Text;

                //encrypt the email with the original cypher key
                string encryptedEmail = StringCipher.Encrypt(originalEmail, GlobalSettings.CypherKey);
                string encryptedEmergencyCypherKey = StringCipher.Encrypt(GlobalSettings.CypherKey, originalEmail);

                //show progress bar
                string status = "Updating your email, please wait...";
                ProgressViewerForm progressViewer = new ProgressViewerForm(status);
                progressViewer.Location = new Point(this.Location.X + 98, this.Location.Y + 200);
                progressViewer.Show();
                _progressViewerObject = progressViewer;

                //send webrequest to update email
                WebHandler webRequest = new WebHandler();
                webRequest.WebRequestSuccessEventHandler += OnUpdateEmailSuccess;
                webRequest.WebRequestFailedEventHandler += OnUpdateEmailFailed;
                _webHandlerObject = webRequest;
                webRequest.UpdateEmail(originalEmail, encryptedEmail, emailVerificationCode, password, encryptedEmergencyCypherKey);               
            }          
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
            if(int.TryParse(result, out int emailVerificationCode) && result.Length == 6)
            {
                //change local value of email 
                GlobalSettings.Email = NewEmailTextBox.Text;
                GlobalSettings.IsEmailVarified = false;
                GlobalSettings.EmailVerificationCode = emailVerificationCode.ToString();

                //send verification email to the new email address
                MailAddress from = new MailAddress("Phinanze.noreply@rezasaker.com");
                MailAddress to = new MailAddress(GlobalSettings.Email);
                SendVerificationEmail(from, to, emailVerificationCode.ToString());
            }
            else
            {
                _progressViewerObject.StopProgress();

                MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                EnableAllControls();
            }          
        }

        private void ActionUponUpdateEmailFailed()
        {
            string result = _webHandlerObject.Response;

            _progressViewerObject.StopProgress();

            MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            EnableAllControls();
        }

        private void SendVerificationEmail(MailAddress from, MailAddress to, string verificationCode)
        {
            string status = "Sending verification code, please wait...";
            _progressViewerObject.UpdateStatus(status);

            //email subject and body
            string subject = "Email Verification for Phinanze";
            string message = "Dear User,\n\n" + 
            "Thank you for registering account with Phinanze Finance Management App. " +
            "Please use the following verification code to verify your email from Phinanze app. \n\n" +
            "Your email verification code is: " + verificationCode + ".\n\n" +
            "Verifying your email is important because if you ever forget your password / username, " +
            "you will not be able to recover your password / username without a verified email. \n\n" +
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
            _progressViewerObject.StopProgress();

            string message = "You email has been successfully changed and  a new verification code" +
                " has been sent to your email address. Please allow up to 3 hours to recieve the code" +
                " and check your spam folder as well.";

            MessageBox.Show(message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadBasicInformation();           
            EnableAllControls();
            ResetChangeEmailControlProperties();            
        }

        private void ActionUponSendVerificationEmailFailed()
        {
            //even though the email sending wasn't successful, 
            //we would continue with the next step and
            //prompt the user later to ask for verification code
            LoadBasicInformation();
            _progressViewerObject.StopProgress();
            EnableAllControls();
            ResetChangeEmailControlProperties();
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
                GlobalSettings.LogOutUser();
                _quitAppOnFormClosing = false;
                this.Close();
            }
        }

        new private void HelpButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Process.Start(GlobalSettings.HelpPath);
            }
            catch
            {
                string message = "Sorry, could not open default browser.";

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReportIssueButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Process.Start(GlobalSettings.ReportIssuePath);
            }
            catch
            {
                string message = "Sorry, could not open the default browser.";

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AboutAppButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Process.Start(GlobalSettings.AboutAppPath);
            }
            catch
            {
                string message = "Sorry, could not open the default browser.";

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VideoTutorialButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Process.Start(GlobalSettings.VideoTutorialPath);
            }
            catch
            {
                string message = "Sorry, could not open the default browser!";

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            form.Size = this.Size;
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
        }

        private void DeleteProfileButtonClicked(object sender, EventArgs e)
        {
            string msg = "You will not be able to recover your account once you delete your profile and thus you will lost all saved data" +
                "permanently. Do you still want to delete your account?";

            DialogResult userChoice = MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
            GlobalSettings.LogOutUser();
            _quitAppOnFormClosing = false;
            this.Close();
        }

        private void VerifyEmailButtonClicked(object sender, EventArgs e)
        {
            if (!GlobalSettings.IsEmailVarified)
            {
                EmailVerificationForm form = new EmailVerificationForm();
                form.FormClosingEventHandler += EmailVerificationFormClosed;
                form.Location = new Point(this.Location.X + 153, this.Location.Y + 120);
                form.Show();
            }
        }

        private void EmailVerificationFormClosed(object sender, EventArgs e)
        {
            LoadBasicInformation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "Do you want to see the full license?";

            DialogResult dlgResult = MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    Process.Start(GlobalSettings.LicensePath);
                }
                catch
                {
                    message = "Sorry, could not open your default browser.";

                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ContactButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://rezasaker.com/contact/");
            }
            catch
            {
                string message = "Sorry, could not open your default browser.";

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
