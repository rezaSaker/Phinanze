using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;
using MyCost.Common;

namespace MyCost.View
{
    public partial class EmailVerificationForm : Form
    {
        private ProgressViewerForm _progressViewerObject;
        private Mailer _mailerObject;
        private WebHandler _webHandlerObject;

        private delegate void SendEmailDelegate();
        private delegate void VerifyEmailDelegate();

        public event EventHandler FormClosingEventHandler;

        public EmailVerificationForm()
        {
            InitializeComponent();
        }

        private void VerifyEmailButtonClicked(object sender, EventArgs e)
        {
            //show progress bar
            string status = "Verifying your email, please wait...";
            ProgressViewerForm progressViewer = new ProgressViewerForm(status);
            progressViewer.Location = new Point(this.Location.X - 55, this.Location.Y + 60);
            progressViewer.Show();
            _progressViewerObject = progressViewer;

            WebHandler webHandler = new WebHandler();
            webHandler.WebRequestSuccessEventHandler += OnEmailVerificationSuccess;
            webHandler.WebRequestFailedEventHandler += OnEmailVerificationFailed;
            _webHandlerObject = webHandler;
            webHandler.VerifyEmail(VerificationCodeTextBox.Text);
        }

        private void OnEmailVerificationSuccess(object sender, EventArgs e)
        {
            this.Invoke(new VerifyEmailDelegate(ActionUponEmailVerificationSuccess), new object[] { });
        }

        private void OnEmailVerificationFailed(object sender, EventArgs e)
        {
            this.Invoke(new VerifyEmailDelegate(ActionUponEmailVerificationFailed), new object[] { });
        }

        private void ActionUponEmailVerificationSuccess()
        {
            _progressViewerObject.StopProgress();

            GlobalSpace.IsEmailVarified = true;

            string message = "Your email address has been successfully verified. Thank you.";

            MessageBox.Show(message, "Thank you", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void ActionUponEmailVerificationFailed()
        {
            _progressViewerObject.StopProgress();

            if (_webHandlerObject.Response == "Server connection error")
            {
                string message = "Could not complete the operation. Please check your internet connection and try again.";

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(_webHandlerObject.Response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //open a new verification form so that user can try again
            EmailVerificationForm newForm = new EmailVerificationForm();
            newForm.Location = this.Location;
            newForm.Show();

            this.Close();
        }

        private void NotNowButtonClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CodeResendButtonClicked(object sender, EventArgs e)
        {
            if (CodeResendButton.Text == "Resend Verification Code")
            {
                MailAddress from = new MailAddress("mycost.noreply@rezasaker.com");
                MailAddress to = new MailAddress(GlobalSpace.Email);
                SendVerificationEmail(from, to, GlobalSpace.EmailVerificationCode);
            }
            else
            {
                HeaderLabel.Visible = false;
                VerificationCodeTextBox.Visible = false;
                VerifyEmailButton.Visible = false;
                NotNowButton.Visible = false;
                GuidelineTextBox.Location = new Point(GuidelineTextBox.Location.X, 8);
                GuidelineTextBox.Visible = true;
                CodeResendButton.Location = new Point(
                    CodeResendButton.Location.X, CodeResendButton.Location.Y + 5);
                CodeResendButton.Text = "Resend Verification Code";
                CodeResendButton.BackColor = Color.RoyalBlue;
                CodeResendButton.ForeColor = Color.White;
            }
        }

        private void SendVerificationEmail(MailAddress from, MailAddress to, string verificationCode)
        {
            //show progress bar
            string status = "Sending new verification code, please wait...";
            ProgressViewerForm progressViewer = new ProgressViewerForm(status);
            progressViewer.Location = new Point(this.Location.X - 55, this.Location.Y + 60);
            progressViewer.Show();
            _progressViewerObject = progressViewer;

            //email subject and body
            string subject = "Email Verification for MyCost";
            string message = "Dear User,\n\n" +
            "Thank you for registering account with MyCost Finance Management App. " +
            "Please use the following verification code to verify your email from MyCost app. \n\n" +
            "Your email verification code is: " + verificationCode + ".\n\n" +
            "Verifying your email is important because if you ever forget your password / username, " +
            "you will not be able to recover your password / username without a verified email. \n\n" +
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
            this.Invoke(new SendEmailDelegate(ActionUponEmailSendingSuccess), new object[] { });
        }

        private void OnSendingVerificationEmailFailed(object sender, EventArgs e)
        {
            this.Invoke(new SendEmailDelegate(ActionUponEmailSendingFailed), new object[] { });
        }

        private void ActionUponEmailSendingSuccess()
        {
            _progressViewerObject.StopProgress();

            string message = "We have sent a new verification code to your email address. " +
                "Please allow up to 12 hours to recieve the code and check your spam folder as well.";

            MessageBox.Show(message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            this.Close();
        }

        private void ActionUponEmailSendingFailed()
        {
            _progressViewerObject.StopProgress();

            string message = "Could not complete the process. Please check your email address " +
                "and your internet connection.";

            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();
        }

        private void EmailVerificationFormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            FormClosingEventHandler?.Invoke(this, null);
        }
    }
}
