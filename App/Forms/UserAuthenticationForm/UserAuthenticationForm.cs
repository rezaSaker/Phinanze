using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.Mail;
using System.Collections.Generic;
using Phinanze.Utils;
using Phinanze.Models;
using Phinanze.Models.Repositories;

namespace Phinanze.Forms
{
    public partial class UserAuthenticationForm : Form
    {
        private bool _quitAppOnFormClosing;

        private string _activationCode;

        private WebHandler _webHandlerObject;
        private WebHandler _webHandlerToGetActivationCode;
        private ProgressViewerForm _progressViewerObject;
        private Mailer _mailerObject;

        private delegate void UserAuthenticationDelegate();
        private delegate void UserRegistrationDelegate();
        private delegate void FetchDailyInfoDelegate();
        private delegate void FetchCategoriesDelegate();
        private delegate void GetActivationCodeDelegate();
        private delegate void SendEmailDelegate();

        public UserAuthenticationForm()
        {
            InitializeComponent();

            _quitAppOnFormClosing = true;
        }

        #region UI EventHandler Methods

        private void ThisFormLoading(object sender, EventArgs e)
        {
            VersionLabel.Text = "Version: " + Application.ProductVersion + "  |  Developed by: Reza Hossain";
            DisplayLoginPanel();

            //Earning.DeleteAll();

            //List<Earning> l = Earning.GetAll();

            //Earning earn1 = new Earning()
            //{
            //    Amount = 10,
            //    CategoryId = 1,
            //    DailyInfoId = 1,
            //    Comment = "Hello"
            //};


            //Earning earn2 = new Earning()
            //{
            //    Amount = 12,
            //    CategoryId = 2,
            //    DailyInfoId = 2,
            //    Comment = "Hello 2"
            //};
            //earn1.Save();

            //l = Earning.GetAll();

            //earn2.Save();

            //l = Earning.GetAll();
            //Earning er = EarningRepository.Find(1);
            //Earning.Delete(er);
            //l = Earning.GetAll();
            //List<Earning> l = Earning.GetAll();


        }

        private void ThisFormShown(object sender, EventArgs e)
        {
            string username = Properties.Settings.Default.Username;
            string password = Properties.Settings.Default.Password;

            //if the user opted to auto login by checking the remmeberMeCheckBox during last login
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                //make the text color black so that the login method 
                //doesn't detect the texts as placeholder texts
                UsernameTextBox.ForeColor = Color.Black;
                PasswordTextBox.ForeColor = Color.Black;
                PasswordTextBox.PasswordChar = '*';

                //fills the username and password field with pre-saved info
                UsernameTextBox.Text = Properties.Settings.Default.Username;
                PasswordTextBox.Text = Properties.Settings.Default.Password;

                //attempt login
                LoginUser();
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
            if (UsernameTextBox.ForeColor != Color.Black)
            {
                //remove the placeholder text
                UsernameTextBox.Text = "";
                UsernameTextBox.ForeColor = Color.Black;
            }
        }

        private void PasswordTextboxClicked(object sender, MouseEventArgs e)
        {
            if (PasswordTextBox.ForeColor != Color.Black)
            {
                //remove the placeholder text
                PasswordTextBox.Text = "";
                PasswordTextBox.ForeColor = Color.Black;
                PasswordTextBox.PasswordChar = '*';
            }
        }

        private void ConfirmPasswordTextBoxClicked(object sender, MouseEventArgs e)
        {
            if (ConfirmPasswordTextBox.ForeColor != Color.Black)
            {
                //remove the placeholder text
                ConfirmPasswordTextBox.Text = "";
                ConfirmPasswordTextBox.ForeColor = Color.Black;
                ConfirmPasswordTextBox.PasswordChar = '*';
            }
        }

        private void EmailTextBoxClicked(object sender, MouseEventArgs e)
        {
            if(EmailTextBox.ForeColor != Color.Black)
            {
                //remove the placeholder text
                EmailTextBox.Text = "";
                EmailTextBox.ForeColor = Color.Black;
            }
        }

        private void SubmitButtonClicked(object sender, EventArgs e)
        {          
            if (SubmitButton.Text == "Log in")
            {
                LoginUser();
            }
            else
            {
                RegisterUser();
            }
        }

        private void LicenseLabelClicked(object sender, EventArgs e)
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

        private void ThisFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_quitAppOnFormClosing)
            {
                Application.Exit();
            }
        }

        private void ForgotPasswordTextBoxClicked(object sender, EventArgs e)
        {
            PasswordResetForm form = new PasswordResetForm();
            form.Location = new Point(this.Location.X + 107, this.Location.Y + 158);
            form.Show();
        }
        #endregion

        #region General Private Methods

        private void DisplayLoginPanel()
        {
            //reset everything so the panel appears as a login form 
            ShowRegisterPanelButton.BackColor = Color.RoyalBlue;
            ShowRegisterPanelButton.FlatAppearance.BorderSize = 0;
            ShowRegisterPanelButton.FlatAppearance.MouseOverBackColor = Color.ForestGreen;
            ShowRegisterPanelButton.ForeColor = Color.White;
            ShowRegisterPanelButton.Enabled = true;
            ShowLoginPanelButton.BackColor = Color.White;
            ShowLoginPanelButton.ForeColor = Color.Black;
            ShowLoginPanelButton.FlatAppearance.BorderSize = 1;
            ShowLoginPanelButton.Enabled = false;

            SubmitButton.Text = "Log in";
            SubmitButton.Location = new Point(SubmitButton.Location.X, 340);

            ConfirmPasswordTextBox.Visible = false;
            ConfirmPasswordTextBox.Enabled = false;
            EmailTextBox.Visible = false;
            EmailTextBox.Enabled = false;
            ForgotPasswordTextBox.Visible = true;

            AgreeLicenseLabel.Visible = false;
            AgreeCheckBox.Visible = false;
            RememberMeCheckBox.Location = new Point(RememberMeCheckBox.Location.X, 297);
            VersionLabel.Location = new Point(VersionLabel.Location.X, 450);
            this.Size = new Size(1063, 550);

            ResetTextBoxProperties();
        }

        private void DisplayRegisterPanel()
        {
            //reset everything so the panel appears as a register form
            ShowRegisterPanelButton.BackColor = Color.White;
            ShowRegisterPanelButton.ForeColor = Color.Black;
            ShowRegisterPanelButton.Enabled = false;
            ShowRegisterPanelButton.FlatAppearance.BorderSize = 1;
            ShowRegisterPanelButton.FlatAppearance.MouseOverBackColor = Color.White;
            ShowLoginPanelButton.BackColor = Color.RoyalBlue;
            ShowLoginPanelButton.FlatAppearance.BorderSize = 0;
            ShowLoginPanelButton.ForeColor = Color.White;           
            ShowLoginPanelButton.Enabled = true;
            ShowLoginPanelButton.FlatAppearance.MouseOverBackColor = Color.ForestGreen;

            SubmitButton.Text = "Register";
            SubmitButton.Location = new Point(SubmitButton.Location.X, 466);

            ConfirmPasswordTextBox.Visible = true;
            ConfirmPasswordTextBox.Enabled = true;
            EmailTextBox.Visible = true;
            EmailTextBox.Enabled = true;
            ForgotPasswordTextBox.Visible = false;

            AgreeLicenseLabel.Visible = true;
            AgreeCheckBox.Visible = true;
            RememberMeCheckBox.Location = new Point(RememberMeCheckBox.Location.X, 411);
            VersionLabel.Location = new Point(VersionLabel.Location.X, 548);
            this.Size = new Size(1063, 627);

            ResetTextBoxProperties();
        }

        private void ResetTextBoxProperties()
        {
            //reset the placeholders in the TextBoxes
            StatusLabel.Text = "";
            UsernameTextBox.Text = "Username";
            UsernameTextBox.ForeColor = Color.DarkGray;
            PasswordTextBox.Text = "Password";
            PasswordTextBox.ForeColor = Color.DarkGray;
            PasswordTextBox.PasswordChar = '\0';
            ConfirmPasswordTextBox.Text = "Confirm Password";
            ConfirmPasswordTextBox.ForeColor = Color.DarkGray;
            ConfirmPasswordTextBox.PasswordChar = '\0';
            EmailTextBox.Text = "Email";
            EmailTextBox.ForeColor = Color.DarkGray;
        }

        private void LoginUser()
        {
            //if fore-color of a textBox is not black, that means the textbox 
            //contains the placeholder text and user didn't enter any value
            string username = UsernameTextBox.ForeColor == Color.Black?
                UsernameTextBox.Text : "";
            string password = PasswordTextBox.ForeColor == Color.Black?
                PasswordTextBox.Text : "";

            if(username.Length < 1)
            {
                ShowErrorMessage("Please enter username.");
                return;
            }
            else if(password.Length < 1)
            {
                ShowErrorMessage("Please enter password.");
                return;
            }

            //disable all controls so that the user cannot
            //change anything until the login process ends
            DisableAllControls();

            //show progress bar
            string status = "Verifying your login credentials, please wait...";
            ProgressViewerForm progressViewer = new ProgressViewerForm(status);
            progressViewer.Location = new Point(this.Location.X + 93, this.Location.Y + 175);
            progressViewer.Show();
            _progressViewerObject = progressViewer;

            //send web request to verify user's login credentials
            WebHandler webRequest = new WebHandler();
            webRequest.WebRequestSuccessEventHandler += OnLoginSuccess;
            webRequest.WebRequestFailedEventHandler += OnLoginFailed;
            _webHandlerObject = webRequest;
            webRequest.AuthenticateUser(username, password);           
        }

        private void OnLoginSuccess(object sender, EventArgs e)
        {
            this.Invoke(new UserAuthenticationDelegate(ActionUponAuthSuccess), new object[] { });
        }

        private void OnLoginFailed(object sender, EventArgs e)
        {
            this.Invoke(new UserAuthenticationDelegate(ActionUponAuthFailed), new object[] { });
        }

        private void RegisterUser()
        {
            //if fore-color of a textBox is not black, that means the TextBox 
            //contains the placeholder text and user didn't enter any value
            string username = UsernameTextBox.ForeColor == Color.Black? 
                UsernameTextBox.Text : "";
            string password = PasswordTextBox.ForeColor == Color.Black?
                PasswordTextBox.Text : "";
            string confirmPassword = ConfirmPasswordTextBox.ForeColor == Color.Black?
                ConfirmPasswordTextBox.Text : "";
            string email = EmailTextBox.ForeColor == Color.Black ? EmailTextBox.Text : "";
            string emailVerificationCode = GenerateRandomNumberString(6);


            //make server request to generate a new activation code
            //and assign the new activation code to the private variable _activationCode
            _activationCode = "";
            GetActivationCode();

            if (username.Length < 1)
            {
                ShowErrorMessage("Please enter a username.");
                return;
            }
            else if (password.Length < 1)
            {
                ShowErrorMessage("Please enter a password.");
                return;
            }
            else if (confirmPassword != password)
            {
                ShowErrorMessage("Password does not match.");
                return;
            } 
            else if(_activationCode.Length < 1)
            {
                //error message is already shown when the call to get activation code failed
                return;
            }
            else if(email.Length < 1 || !IsValidEmail(email))
            {
                ShowErrorMessage("The email address you have provided is not vaild.");
                return;
            }
            else if(!AgreeCheckBox.Checked)
            {
                ShowErrorMessage("You need to agree to our terms and policy to register.");
                return;
            }

            //disable all controls so that the user cannot change
            //anything until the registration process ends
            DisableAllControls();

            //show progress bar
            string status = "Creating your account, please wait...";
            ProgressViewerForm progressViewer = new ProgressViewerForm(status);
            progressViewer.Location = new Point(this.Location.X + 93, this.Location.Y + 200);
            progressViewer.Show();
            _progressViewerObject = progressViewer;

            //generate a unique cypher key for this user for encrypting this user's info
            //save the encrypted version of the cypher key in database
            string cypherKey = GenerateRandomString(70);
            string encryptedCypherKey = StringCipher.Encrypt(cypherKey, password);
            string encryptedEmergencyCypherKey = StringCipher.Encrypt(cypherKey, email);

            //encrypt the email with the original cypher key
            string encryptedEmail = StringCipher.Encrypt(email, cypherKey);

            //send web request to create new user account
            WebHandler webRequest = new WebHandler();
            webRequest.WebRequestSuccessEventHandler += OnRegisterSuccess;
            webRequest.WebRequestFailedEventHandler += OnRegisterFailed;
            _webHandlerObject = webRequest;
            webRequest.RegisterNewUser(username, password, _activationCode, encryptedCypherKey, encryptedEmergencyCypherKey, encryptedEmail, email, emailVerificationCode);
        }

        private void OnRegisterSuccess(object sender, EventArgs e)
        {
            this.Invoke(new UserRegistrationDelegate(ActionUponAuthSuccess), new object[] { });
        }

        private void OnRegisterFailed(object sender, EventArgs e)
        {
            this.Invoke(new UserRegistrationDelegate(ActionUponAuthFailed), new object[] { });
        }

        private void ActionUponAuthSuccess()
        {
            string result = _webHandlerObject.Response;

            string[] data = result.Split('|');

            //if the registration process succeeds, 
            //user's id, an unique server access token and 
            //a cypher key for decryption are retured
            //otherwise, the error message is returned
            if (int.TryParse(data[0], out int userId))
            {
                GlobalSettings.Username = UsernameTextBox.Text;
                GlobalSettings.UserID = userId;
                GlobalSettings.AccessToken = data[1];
                GlobalSettings.CypherKey = StringCipher.Decrypt(data[2], PasswordTextBox.Text);
                GlobalSettings.Email = StringCipher.Decrypt(data[3], GlobalSettings.CypherKey);
                GlobalSettings.IsEmailVarified = data[4] == "1" ? true : false;
                

                if (RememberMeCheckBox.Checked)
                {
                    Properties.Settings.Default.Username = UsernameTextBox.Text;
                    Properties.Settings.Default.Password = PasswordTextBox.Text;
                    Properties.Settings.Default.Save();
                }

                GlobalSettings.EmailVerificationCode = data[5];
                
                //if the account has just been registered,
                //send an email verification code to the user's email
                if(data[6] == "New User")
                {
                    MailAddress from = new MailAddress("Phinanze.noreply@rezasaker.com");
                    MailAddress to = new MailAddress(GlobalSettings.Email);
                    SendVerificationEmail(from, to, GlobalSettings.EmailVerificationCode);
                }
                else //if exisitng user logging in
                {
                    //get daily info of this user from database
                    FetchDailyInfo();
                }
            }
            else
            {
                _progressViewerObject.StopProgress();
                ShowErrorMessage(result);

                //enable all controls so that the user can attempt to login again
                EnableAllControls();               
            }
        }

        private void ActionUponAuthFailed()
        {
            _progressViewerObject.StopProgress();
            ShowErrorMessage("Server connection error. Please check your internet connection.");

            //enable all controls so that the user can attempt to login again
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
            this.Invoke(new SendEmailDelegate(ActionUponEmailSendingSuccess), new object[] { });
        }

        private void OnSendingVerificationEmailFailed(object sender, EventArgs e)
        {
            this.Invoke(new SendEmailDelegate(ActionUponEmailSendingFailed), new object[] { });
        }

        private void ActionUponEmailSendingSuccess()
        {
            //get daily info of this user from database
            FetchDailyInfo();
        }

        private void ActionUponEmailSendingFailed()
        {
            //even though the email sending wasn't successful, 
            //we would continue with the next step and
            //log the user in and prompt later to ask for verification code
            //get daily info of this user from database
            FetchDailyInfo();
        }

        private void FetchDailyInfo()
        {
            string status = "Fetching daily information from database, please wait...";
            _progressViewerObject.UpdateStatus(status);

            //get daily expenses and earnings from database
            WebHandler webRequest = new WebHandler();
            webRequest.WebRequestSuccessEventHandler += OnFetchDailyInfoSuccess;
            webRequest.WebRequestFailedEventHandler += OnFetchDailyInfoFailed;
            _webHandlerObject = webRequest;
            webRequest.RetrieveDailyInfo();         
        }

        private void OnFetchDailyInfoSuccess(object sender, EventArgs e)
        {
            this.Invoke(new FetchDailyInfoDelegate(ActionUponFetchDailyInfoSuccess), new object[] { });
        }

        private void OnFetchDailyInfoFailed(object  sender, EventArgs e)
        {
            this.Invoke(new FetchDailyInfoDelegate(ActionUponFetchDailyInfoFailed), new object[] { });
        }

        private void ActionUponFetchDailyInfoSuccess()
        {                  
            string result = _webHandlerObject.Response;

            string[] rows = result.Split('^');

            if (rows[0] == "Server connection error")
            {
                //some server error occurred
                _progressViewerObject.StopProgress();
                ShowErrorMessage("Server connection error. Please check your internet connection.");             
                return;
            }

            //start fetching categories from database on a seperate thread
            //before starting to process the fetched daily info
            FetchCategories();

            if (rows[0] == "")
            {
                //no daily info found for this user in database
                //so no need to process the info
                return;
            }

            //process the fetched daily info and store them in StaticStorage class
            foreach (string row in rows)
            {
                string[] cols = row.Split('|');

                int day = Convert.ToInt16(cols[0]);
                int month = Convert.ToInt16(cols[1]);
                int year = Convert.ToInt16(cols[2]);

                string note = StringCipher.Decrypt(cols[3], GlobalSettings.CypherKey);
                string[] expenseReasons = StringCipher.Decrypt(cols[4], GlobalSettings.CypherKey).Split('~');
                string[] expenseAmounts = StringCipher.Decrypt(cols[5], GlobalSettings.CypherKey).Split('~');
                string[] expenseCategories = StringCipher.Decrypt(cols[6], GlobalSettings.CypherKey).Split('~');
                string[] expenseComments = StringCipher.Decrypt(cols[7], GlobalSettings.CypherKey).Split('~');
                string[] earningSources = StringCipher.Decrypt(cols[8], GlobalSettings.CypherKey).Split('~');
                string[] earningAmounts = StringCipher.Decrypt(cols[9], GlobalSettings.CypherKey).Split('~');
                string[] earningCategories = StringCipher.Decrypt(cols[10], GlobalSettings.CypherKey).Split('~');
                string[] earningComments = StringCipher.Decrypt(cols[11], GlobalSettings.CypherKey).Split('~');
                string totalExpense = StringCipher.Decrypt(cols[12], GlobalSettings.CypherKey);
                string totalEarning = StringCipher.Decrypt(cols[13], GlobalSettings.CypherKey);

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
                GlobalSettings.DailyInfoList.Add(daily);
            }
        }

        private void ActionUponFetchDailyInfoFailed()
        {
            _progressViewerObject.StopProgress();
            ShowErrorMessage("Server connection error. Please check your internet connection.");
        }

        private void FetchCategories()
        {
            string status = "Fetching categories from database, please wait...";
            _progressViewerObject.UpdateStatus(status);

            //get all categories made by user from the database
            WebHandler webRequest = new WebHandler();
            webRequest.WebRequestSuccessEventHandler += OnFetchCategoriesSuccess;
            webRequest.WebRequestFailedEventHandler += OnFetchCategoriesFailed;
            _webHandlerObject = webRequest;
            webRequest.RetrieveCategories();
        }

        private void OnFetchCategoriesSuccess(object sender, EventArgs e)
        {
            this.Invoke(new FetchCategoriesDelegate(ActionUponFetchCategoriesSuccess), new object[] { });
        }

        private void OnFetchCategoriesFailed(object sender, EventArgs e)
        {
            this.Invoke(new FetchCategoriesDelegate(ActionUponFetchCategoriesFailed), new object[] { });
        }

        private void ActionUponFetchCategoriesSuccess()
        {
            string result = _webHandlerObject.Response;

            if (result == "Server connection error")
            {
                //some server error occurred
                _progressViewerObject.StopProgress();
                ShowErrorMessage("Server connection error. Please check your internet connect.");
                return;
            }

            string[] earningCategories = result.Split('^')[0].Split('|');
            string[] expenseCategories = result.Split('^')[1].Split('|');

            foreach (string cat in earningCategories)
            {
                GlobalSettings.EarningCategories.Add(cat);
            }

            foreach (string cat in expenseCategories)
            {
                GlobalSettings.ExpenseCategories.Add(cat);
            }

            _progressViewerObject.StopProgress();

            MainForm form = new MainForm(true);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();
        }

        private void ActionUponFetchCategoriesFailed()
        {
            _progressViewerObject.StopProgress();
            ShowErrorMessage("Server connection error. Please check your internet connection.");
        }

        private void GetActivationCode()
        {
            WebHandler webRequest = new WebHandler();
            webRequest.GetActivationCodeSuccessEventHandler += OnGetActivationCodeSuccess;
            webRequest.GetActivationCodeFailedEventHandler += OnGetActivationCodeFailed;
            _webHandlerToGetActivationCode = webRequest;
            webRequest.GetActivationCode();
        }

        private void OnGetActivationCodeSuccess(object sender, EventArgs e)
        {
            this.Invoke(new GetActivationCodeDelegate(ActionUponGetActivationCodeSuccess), new object[] { });
        }

        private void OnGetActivationCodeFailed(object sender, EventArgs e)
        {
            this.Invoke(new GetActivationCodeDelegate(ActionUponGetActivationCodeFailed), new object[] { });
        }

        private void ActionUponGetActivationCodeSuccess()
        {
            _activationCode = _webHandlerToGetActivationCode.Response;
        }

        private void ActionUponGetActivationCodeFailed()
        {
            string status = "Could not get the required activation code. Please check your internet connection.";

            StatusLabel.Text = status;
        }

        private void EnableAllControls()
        {
            foreach(Control control in this.Controls)
            {
                control.Enabled = true;
            }
        }

        private void DisableAllControls()
        {
            foreach(Control control in this.Controls)
            {
                //disabling AppLogoLabel changes the background color of App Logo 
                //which is unexpected and disabling AppLogoLabel is unnecessary as well
                if (control.Name != "AppLogoLabel")
                {
                    control.Enabled = false;
                }
            }
        }

        private void ShowErrorMessage(string message)
        {
            StatusLabel.Text = message;
            StatusLabel.ForeColor = Color.Red;
        }

        private string GenerateRandomString(int length)
        {
            string charList = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            string randomStr = "";

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                randomStr += charList[random.Next(charList.Length)];
            }

            return randomStr;
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
        #endregion
    }
}
