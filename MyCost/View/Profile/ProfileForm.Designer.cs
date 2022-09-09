namespace MyCost.View
{
    partial class ProfileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.ChangeUsernameLabel = new System.Windows.Forms.Label();
            this.NewUserNameTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmUserNameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordForUsernameChangeTextBox = new System.Windows.Forms.TextBox();
            this.UpdateUsernameButton = new System.Windows.Forms.Button();
            this.UpdatePasswordButton = new System.Windows.Forms.Button();
            this.ConfirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.NewPasswordTextBox = new System.Windows.Forms.TextBox();
            this.CurrentPasswordTextBox = new System.Windows.Forms.TextBox();
            this.ChangePasswordLabel = new System.Windows.Forms.Label();
            this.ReportIssueButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.AboutAppButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.ProfileButton = new System.Windows.Forms.Button();
            this.StatisticsButton = new System.Windows.Forms.Button();
            this.MonthlyReportButton = new System.Windows.Forms.Button();
            this.AddNewDataButton = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ContactButton = new System.Windows.Forms.Button();
            this.VerifyEmailButton = new System.Windows.Forms.Button();
            this.EmailVerificationStatusLabel = new System.Windows.Forms.Label();
            this.DeleteAccountButton = new System.Windows.Forms.Button();
            this.PasswordForEmailTextBox = new System.Windows.Forms.TextBox();
            this.UpdateEmailButton = new System.Windows.Forms.Button();
            this.NewEmailTextBox = new System.Windows.Forms.TextBox();
            this.VideoTutorialButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LogoButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLabel.ForeColor = System.Drawing.Color.Black;
            this.UserNameLabel.Location = new System.Drawing.Point(11, 65);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(113, 25);
            this.UserNameLabel.TabIndex = 46;
            this.UserNameLabel.Text = "Username: ";
            // 
            // ChangeUsernameLabel
            // 
            this.ChangeUsernameLabel.AutoSize = true;
            this.ChangeUsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeUsernameLabel.ForeColor = System.Drawing.Color.Black;
            this.ChangeUsernameLabel.Location = new System.Drawing.Point(4, 13);
            this.ChangeUsernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ChangeUsernameLabel.Name = "ChangeUsernameLabel";
            this.ChangeUsernameLabel.Size = new System.Drawing.Size(177, 25);
            this.ChangeUsernameLabel.TabIndex = 47;
            this.ChangeUsernameLabel.Text = "Change Username";
            // 
            // NewUserNameTextBox
            // 
            this.NewUserNameTextBox.BackColor = System.Drawing.Color.White;
            this.NewUserNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewUserNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewUserNameTextBox.ForeColor = System.Drawing.Color.Gray;
            this.NewUserNameTextBox.Location = new System.Drawing.Point(9, 51);
            this.NewUserNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewUserNameTextBox.Name = "NewUserNameTextBox";
            this.NewUserNameTextBox.Size = new System.Drawing.Size(624, 30);
            this.NewUserNameTextBox.TabIndex = 48;
            this.NewUserNameTextBox.Text = "New Username";
            this.NewUserNameTextBox.Click += new System.EventHandler(this.UsernameTextBoxesClicked);
            // 
            // ConfirmUserNameTextBox
            // 
            this.ConfirmUserNameTextBox.BackColor = System.Drawing.Color.White;
            this.ConfirmUserNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfirmUserNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmUserNameTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ConfirmUserNameTextBox.Location = new System.Drawing.Point(9, 92);
            this.ConfirmUserNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConfirmUserNameTextBox.Name = "ConfirmUserNameTextBox";
            this.ConfirmUserNameTextBox.Size = new System.Drawing.Size(624, 30);
            this.ConfirmUserNameTextBox.TabIndex = 49;
            this.ConfirmUserNameTextBox.Text = "Confirm New Username";
            this.ConfirmUserNameTextBox.Click += new System.EventHandler(this.UsernameTextBoxesClicked);
            // 
            // PasswordForUsernameChangeTextBox
            // 
            this.PasswordForUsernameChangeTextBox.BackColor = System.Drawing.Color.White;
            this.PasswordForUsernameChangeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordForUsernameChangeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordForUsernameChangeTextBox.ForeColor = System.Drawing.Color.Gray;
            this.PasswordForUsernameChangeTextBox.Location = new System.Drawing.Point(9, 130);
            this.PasswordForUsernameChangeTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PasswordForUsernameChangeTextBox.Name = "PasswordForUsernameChangeTextBox";
            this.PasswordForUsernameChangeTextBox.Size = new System.Drawing.Size(624, 30);
            this.PasswordForUsernameChangeTextBox.TabIndex = 50;
            this.PasswordForUsernameChangeTextBox.Text = "Password";
            this.PasswordForUsernameChangeTextBox.Click += new System.EventHandler(this.PasswordTextBoxesClicked);
            // 
            // UpdateUsernameButton
            // 
            this.UpdateUsernameButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.UpdateUsernameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.UpdateUsernameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateUsernameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateUsernameButton.ForeColor = System.Drawing.Color.White;
            this.UpdateUsernameButton.Location = new System.Drawing.Point(428, 185);
            this.UpdateUsernameButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UpdateUsernameButton.Name = "UpdateUsernameButton";
            this.UpdateUsernameButton.Size = new System.Drawing.Size(205, 43);
            this.UpdateUsernameButton.TabIndex = 51;
            this.UpdateUsernameButton.Text = "Update Username";
            this.UpdateUsernameButton.UseVisualStyleBackColor = false;
            this.UpdateUsernameButton.Click += new System.EventHandler(this.SubmitNewUsernameButtonClicked);
            // 
            // UpdatePasswordButton
            // 
            this.UpdatePasswordButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.UpdatePasswordButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.UpdatePasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdatePasswordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePasswordButton.ForeColor = System.Drawing.Color.White;
            this.UpdatePasswordButton.Location = new System.Drawing.Point(434, 185);
            this.UpdatePasswordButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UpdatePasswordButton.Name = "UpdatePasswordButton";
            this.UpdatePasswordButton.Size = new System.Drawing.Size(200, 43);
            this.UpdatePasswordButton.TabIndex = 56;
            this.UpdatePasswordButton.Text = "Update Password";
            this.UpdatePasswordButton.UseVisualStyleBackColor = false;
            this.UpdatePasswordButton.Click += new System.EventHandler(this.SubmitNewPasswordButtonClicked);
            // 
            // ConfirmPasswordTextBox
            // 
            this.ConfirmPasswordTextBox.BackColor = System.Drawing.Color.White;
            this.ConfirmPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfirmPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ConfirmPasswordTextBox.Location = new System.Drawing.Point(9, 85);
            this.ConfirmPasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox";
            this.ConfirmPasswordTextBox.Size = new System.Drawing.Size(625, 30);
            this.ConfirmPasswordTextBox.TabIndex = 55;
            this.ConfirmPasswordTextBox.Text = "Confirm New Password";
            this.ConfirmPasswordTextBox.Click += new System.EventHandler(this.PasswordTextBoxesClicked);
            // 
            // NewPasswordTextBox
            // 
            this.NewPasswordTextBox.BackColor = System.Drawing.Color.White;
            this.NewPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPasswordTextBox.ForeColor = System.Drawing.Color.Gray;
            this.NewPasswordTextBox.Location = new System.Drawing.Point(9, 47);
            this.NewPasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewPasswordTextBox.Name = "NewPasswordTextBox";
            this.NewPasswordTextBox.Size = new System.Drawing.Size(625, 30);
            this.NewPasswordTextBox.TabIndex = 54;
            this.NewPasswordTextBox.Text = "New Password";
            this.NewPasswordTextBox.Click += new System.EventHandler(this.PasswordTextBoxesClicked);
            // 
            // CurrentPasswordTextBox
            // 
            this.CurrentPasswordTextBox.BackColor = System.Drawing.Color.White;
            this.CurrentPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentPasswordTextBox.ForeColor = System.Drawing.Color.Gray;
            this.CurrentPasswordTextBox.Location = new System.Drawing.Point(9, 126);
            this.CurrentPasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CurrentPasswordTextBox.Name = "CurrentPasswordTextBox";
            this.CurrentPasswordTextBox.Size = new System.Drawing.Size(625, 30);
            this.CurrentPasswordTextBox.TabIndex = 53;
            this.CurrentPasswordTextBox.Text = "Current Password";
            this.CurrentPasswordTextBox.Click += new System.EventHandler(this.PasswordTextBoxesClicked);
            // 
            // ChangePasswordLabel
            // 
            this.ChangePasswordLabel.AutoSize = true;
            this.ChangePasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePasswordLabel.ForeColor = System.Drawing.Color.Black;
            this.ChangePasswordLabel.Location = new System.Drawing.Point(4, 13);
            this.ChangePasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ChangePasswordLabel.Name = "ChangePasswordLabel";
            this.ChangePasswordLabel.Size = new System.Drawing.Size(173, 25);
            this.ChangePasswordLabel.TabIndex = 52;
            this.ChangePasswordLabel.Text = "Change Password";
            // 
            // ReportIssueButton
            // 
            this.ReportIssueButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReportIssueButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.ReportIssueButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReportIssueButton.FlatAppearance.BorderSize = 0;
            this.ReportIssueButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.ReportIssueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportIssueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportIssueButton.ForeColor = System.Drawing.Color.White;
            this.ReportIssueButton.Location = new System.Drawing.Point(318, 24);
            this.ReportIssueButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReportIssueButton.Name = "ReportIssueButton";
            this.ReportIssueButton.Size = new System.Drawing.Size(237, 43);
            this.ReportIssueButton.TabIndex = 64;
            this.ReportIssueButton.Text = "Report Issues";
            this.ReportIssueButton.UseVisualStyleBackColor = false;
            this.ReportIssueButton.Click += new System.EventHandler(this.ReportIssueButtonClicked);
            // 
            // HelpButton
            // 
            this.HelpButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HelpButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.HelpButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HelpButton.FlatAppearance.BorderSize = 0;
            this.HelpButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton.ForeColor = System.Drawing.Color.White;
            this.HelpButton.Location = new System.Drawing.Point(81, 24);
            this.HelpButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(229, 42);
            this.HelpButton.TabIndex = 65;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = false;
            this.HelpButton.Click += new System.EventHandler(this.HelpButtonClicked);
            // 
            // AboutAppButton
            // 
            this.AboutAppButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AboutAppButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.AboutAppButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AboutAppButton.FlatAppearance.BorderSize = 0;
            this.AboutAppButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.AboutAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AboutAppButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutAppButton.ForeColor = System.Drawing.Color.White;
            this.AboutAppButton.Location = new System.Drawing.Point(81, 72);
            this.AboutAppButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AboutAppButton.Name = "AboutAppButton";
            this.AboutAppButton.Size = new System.Drawing.Size(229, 44);
            this.AboutAppButton.TabIndex = 66;
            this.AboutAppButton.Text = "About ";
            this.AboutAppButton.UseVisualStyleBackColor = false;
            this.AboutAppButton.Click += new System.EventHandler(this.AboutAppButtonClicked);
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.LogOutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogOutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.LogOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.ForeColor = System.Drawing.Color.White;
            this.LogOutButton.Location = new System.Drawing.Point(1130, 10);
            this.LogOutButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(200, 40);
            this.LogOutButton.TabIndex = 73;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // ProfileButton
            // 
            this.ProfileButton.BackColor = System.Drawing.Color.White;
            this.ProfileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfileButton.Cursor = System.Windows.Forms.Cursors.No;
            this.ProfileButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.ProfileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ProfileButton.Location = new System.Drawing.Point(921, 10);
            this.ProfileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(200, 40);
            this.ProfileButton.TabIndex = 72;
            this.ProfileButton.Text = "Profile";
            this.ProfileButton.UseVisualStyleBackColor = false;
            // 
            // StatisticsButton
            // 
            this.StatisticsButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.StatisticsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StatisticsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.StatisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatisticsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatisticsButton.ForeColor = System.Drawing.Color.White;
            this.StatisticsButton.Location = new System.Drawing.Point(713, 10);
            this.StatisticsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StatisticsButton.Name = "StatisticsButton";
            this.StatisticsButton.Size = new System.Drawing.Size(200, 40);
            this.StatisticsButton.TabIndex = 71;
            this.StatisticsButton.Text = "Statistics";
            this.StatisticsButton.UseVisualStyleBackColor = false;
            this.StatisticsButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // MonthlyReportButton
            // 
            this.MonthlyReportButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.MonthlyReportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MonthlyReportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.MonthlyReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MonthlyReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthlyReportButton.ForeColor = System.Drawing.Color.White;
            this.MonthlyReportButton.Location = new System.Drawing.Point(505, 11);
            this.MonthlyReportButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MonthlyReportButton.Name = "MonthlyReportButton";
            this.MonthlyReportButton.Size = new System.Drawing.Size(200, 40);
            this.MonthlyReportButton.TabIndex = 70;
            this.MonthlyReportButton.Text = "Monthly Report";
            this.MonthlyReportButton.UseVisualStyleBackColor = false;
            this.MonthlyReportButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // AddNewDataButton
            // 
            this.AddNewDataButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.AddNewDataButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddNewDataButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.AddNewDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNewDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewDataButton.ForeColor = System.Drawing.Color.White;
            this.AddNewDataButton.Location = new System.Drawing.Point(297, 10);
            this.AddNewDataButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddNewDataButton.Name = "AddNewDataButton";
            this.AddNewDataButton.Size = new System.Drawing.Size(200, 40);
            this.AddNewDataButton.TabIndex = 69;
            this.AddNewDataButton.Text = "Add daily Info";
            this.AddNewDataButton.UseVisualStyleBackColor = false;
            this.AddNewDataButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.HomeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HomeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.White;
            this.HomeButton.Location = new System.Drawing.Point(89, 10);
            this.HomeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(200, 40);
            this.HomeButton.TabIndex = 68;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(318, 125);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 38);
            this.button2.TabIndex = 85;
            this.button2.Text = "View License";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ContactButton
            // 
            this.ContactButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ContactButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.ContactButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ContactButton.FlatAppearance.BorderSize = 0;
            this.ContactButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.ContactButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContactButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactButton.ForeColor = System.Drawing.Color.White;
            this.ContactButton.Location = new System.Drawing.Point(81, 124);
            this.ContactButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ContactButton.Name = "ContactButton";
            this.ContactButton.Size = new System.Drawing.Size(229, 38);
            this.ContactButton.TabIndex = 84;
            this.ContactButton.Text = "Contact";
            this.ContactButton.UseVisualStyleBackColor = false;
            this.ContactButton.Click += new System.EventHandler(this.ContactButton_Click);
            // 
            // VerifyEmailButton
            // 
            this.VerifyEmailButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.VerifyEmailButton.FlatAppearance.BorderSize = 0;
            this.VerifyEmailButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.VerifyEmailButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VerifyEmailButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifyEmailButton.ForeColor = System.Drawing.Color.White;
            this.VerifyEmailButton.Location = new System.Drawing.Point(843, 60);
            this.VerifyEmailButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VerifyEmailButton.Name = "VerifyEmailButton";
            this.VerifyEmailButton.Size = new System.Drawing.Size(167, 34);
            this.VerifyEmailButton.TabIndex = 83;
            this.VerifyEmailButton.Text = "Verify Email";
            this.VerifyEmailButton.UseVisualStyleBackColor = false;
            this.VerifyEmailButton.Click += new System.EventHandler(this.VerifyEmailButtonClicked);
            // 
            // EmailVerificationStatusLabel
            // 
            this.EmailVerificationStatusLabel.AutoSize = true;
            this.EmailVerificationStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailVerificationStatusLabel.ForeColor = System.Drawing.Color.Black;
            this.EmailVerificationStatusLabel.Location = new System.Drawing.Point(562, 65);
            this.EmailVerificationStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EmailVerificationStatusLabel.Name = "EmailVerificationStatusLabel";
            this.EmailVerificationStatusLabel.Size = new System.Drawing.Size(271, 25);
            this.EmailVerificationStatusLabel.TabIndex = 82;
            this.EmailVerificationStatusLabel.Text = "Email verification Status Label";
            // 
            // DeleteAccountButton
            // 
            this.DeleteAccountButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteAccountButton.BackColor = System.Drawing.Color.Brown;
            this.DeleteAccountButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Crimson;
            this.DeleteAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteAccountButton.ForeColor = System.Drawing.Color.White;
            this.DeleteAccountButton.Location = new System.Drawing.Point(81, 171);
            this.DeleteAccountButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeleteAccountButton.Name = "DeleteAccountButton";
            this.DeleteAccountButton.Size = new System.Drawing.Size(475, 43);
            this.DeleteAccountButton.TabIndex = 81;
            this.DeleteAccountButton.Text = "Permanently Delete My Account";
            this.DeleteAccountButton.UseVisualStyleBackColor = false;
            this.DeleteAccountButton.Click += new System.EventHandler(this.DeleteProfileButtonClicked);
            // 
            // PasswordForEmailTextBox
            // 
            this.PasswordForEmailTextBox.BackColor = System.Drawing.Color.White;
            this.PasswordForEmailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordForEmailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordForEmailTextBox.ForeColor = System.Drawing.Color.Gray;
            this.PasswordForEmailTextBox.Location = new System.Drawing.Point(11, 91);
            this.PasswordForEmailTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PasswordForEmailTextBox.Name = "PasswordForEmailTextBox";
            this.PasswordForEmailTextBox.Size = new System.Drawing.Size(622, 30);
            this.PasswordForEmailTextBox.TabIndex = 80;
            this.PasswordForEmailTextBox.Text = "Passowrd";
            this.PasswordForEmailTextBox.Click += new System.EventHandler(this.PasswordTextBoxesClicked);
            // 
            // UpdateEmailButton
            // 
            this.UpdateEmailButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.UpdateEmailButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.UpdateEmailButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateEmailButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateEmailButton.ForeColor = System.Drawing.Color.White;
            this.UpdateEmailButton.Location = new System.Drawing.Point(428, 147);
            this.UpdateEmailButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UpdateEmailButton.Name = "UpdateEmailButton";
            this.UpdateEmailButton.Size = new System.Drawing.Size(205, 43);
            this.UpdateEmailButton.TabIndex = 77;
            this.UpdateEmailButton.Text = "Update Email";
            this.UpdateEmailButton.UseVisualStyleBackColor = false;
            this.UpdateEmailButton.Click += new System.EventHandler(this.UpdateEmailButtonClicked);
            // 
            // NewEmailTextBox
            // 
            this.NewEmailTextBox.BackColor = System.Drawing.Color.White;
            this.NewEmailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewEmailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewEmailTextBox.ForeColor = System.Drawing.Color.Gray;
            this.NewEmailTextBox.Location = new System.Drawing.Point(11, 51);
            this.NewEmailTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewEmailTextBox.Name = "NewEmailTextBox";
            this.NewEmailTextBox.Size = new System.Drawing.Size(622, 30);
            this.NewEmailTextBox.TabIndex = 76;
            this.NewEmailTextBox.Text = "New Email";
            this.NewEmailTextBox.Click += new System.EventHandler(this.UsernameTextBoxesClicked);
            // 
            // VideoTutorialButton
            // 
            this.VideoTutorialButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.VideoTutorialButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.VideoTutorialButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VideoTutorialButton.FlatAppearance.BorderSize = 0;
            this.VideoTutorialButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.VideoTutorialButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VideoTutorialButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VideoTutorialButton.ForeColor = System.Drawing.Color.White;
            this.VideoTutorialButton.Location = new System.Drawing.Point(319, 73);
            this.VideoTutorialButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VideoTutorialButton.Name = "VideoTutorialButton";
            this.VideoTutorialButton.Size = new System.Drawing.Size(237, 43);
            this.VideoTutorialButton.TabIndex = 75;
            this.VideoTutorialButton.Text = "Video Tutorial";
            this.VideoTutorialButton.UseVisualStyleBackColor = false;
            this.VideoTutorialButton.Click += new System.EventHandler(this.VideoTutorialButtonClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 25);
            this.label1.TabIndex = 58;
            this.label1.Text = "Change Email";
            // 
            // LogoButton
            // 
            this.LogoButton.BackColor = System.Drawing.Color.Transparent;
            this.LogoButton.BackgroundImage = global::MyCost.Properties.Resources.AppIcon;
            this.LogoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.LogoButton.FlatAppearance.BorderSize = 0;
            this.LogoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoButton.ForeColor = System.Drawing.Color.White;
            this.LogoButton.Location = new System.Drawing.Point(13, 10);
            this.LogoButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LogoButton.Name = "LogoButton";
            this.LogoButton.Size = new System.Drawing.Size(65, 40);
            this.LogoButton.TabIndex = 83;
            this.LogoButton.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 46;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 103);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1314, 500);
            this.tableLayoutPanel1.TabIndex = 84;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.ChangeUsernameLabel);
            this.panel2.Controls.Add(this.NewUserNameTextBox);
            this.panel2.Controls.Add(this.ConfirmUserNameTextBox);
            this.panel2.Controls.Add(this.PasswordForUsernameChangeTextBox);
            this.panel2.Controls.Add(this.UpdateUsernameButton);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 244);
            this.panel2.TabIndex = 85;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.UpdatePasswordButton);
            this.panel3.Controls.Add(this.ChangePasswordLabel);
            this.panel3.Controls.Add(this.CurrentPasswordTextBox);
            this.panel3.Controls.Add(this.NewPasswordTextBox);
            this.panel3.Controls.Add(this.ConfirmPasswordTextBox);
            this.panel3.Location = new System.Drawing.Point(660, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(651, 244);
            this.panel3.TabIndex = 85;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.NewEmailTextBox);
            this.panel4.Controls.Add(this.UpdateEmailButton);
            this.panel4.Controls.Add(this.PasswordForEmailTextBox);
            this.panel4.Location = new System.Drawing.Point(3, 253);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(651, 244);
            this.panel4.TabIndex = 85;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.button2);
            this.panel5.Controls.Add(this.ReportIssueButton);
            this.panel5.Controls.Add(this.ContactButton);
            this.panel5.Controls.Add(this.HelpButton);
            this.panel5.Controls.Add(this.DeleteAccountButton);
            this.panel5.Controls.Add(this.AboutAppButton);
            this.panel5.Controls.Add(this.VideoTutorialButton);
            this.panel5.Location = new System.Drawing.Point(660, 253);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(651, 244);
            this.panel5.TabIndex = 85;
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1347, 615);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.LogoButton);
            this.Controls.Add(this.VerifyEmailButton);
            this.Controls.Add(this.EmailVerificationStatusLabel);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.ProfileButton);
            this.Controls.Add(this.StatisticsButton);
            this.Controls.Add(this.MonthlyReportButton);
            this.Controls.Add(this.AddNewDataButton);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MyCost - Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThisFormClosing);
            this.Load += new System.EventHandler(this.ThisFormLoading);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label ChangeUsernameLabel;
        private System.Windows.Forms.TextBox NewUserNameTextBox;
        private System.Windows.Forms.TextBox ConfirmUserNameTextBox;
        private System.Windows.Forms.TextBox PasswordForUsernameChangeTextBox;
        private System.Windows.Forms.Button UpdateUsernameButton;
        private System.Windows.Forms.Button UpdatePasswordButton;
        private System.Windows.Forms.TextBox ConfirmPasswordTextBox;
        private System.Windows.Forms.TextBox NewPasswordTextBox;
        private System.Windows.Forms.TextBox CurrentPasswordTextBox;
        private System.Windows.Forms.Label ChangePasswordLabel;
        private System.Windows.Forms.Button ReportIssueButton;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Button AboutAppButton;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.Button StatisticsButton;
        private System.Windows.Forms.Button MonthlyReportButton;
        private System.Windows.Forms.Button AddNewDataButton;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Button VideoTutorialButton;
        private System.Windows.Forms.Button UpdateEmailButton;
        private System.Windows.Forms.TextBox NewEmailTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordForEmailTextBox;
        private System.Windows.Forms.Button DeleteAccountButton;
        private System.Windows.Forms.Label EmailVerificationStatusLabel;
        private System.Windows.Forms.Button LogoButton;
        private System.Windows.Forms.Button VerifyEmailButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ContactButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
    }
}