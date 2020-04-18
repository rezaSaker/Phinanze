namespace MyCost.View
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.UserNameLaabel = new System.Windows.Forms.Label();
            this.ChangeUsernameLabel = new System.Windows.Forms.Label();
            this.CurrentUserNameTextBox = new System.Windows.Forms.TextBox();
            this.NewUserNameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UpdateUsernameButton = new System.Windows.Forms.Button();
            this.UpdatePasswordButton = new System.Windows.Forms.Button();
            this.ConfirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.NewPasswordTextBox = new System.Windows.Forms.TextBox();
            this.CurrentPasswordTextBox = new System.Windows.Forms.TextBox();
            this.ChangePasswordLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ReportIssueButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.AboutAppButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.StatisticsButton = new System.Windows.Forms.Button();
            this.MonthlyReportButton = new System.Windows.Forms.Button();
            this.AddNewDataButton = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ViewSourceButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserNameLaabel
            // 
            this.UserNameLaabel.AutoSize = true;
            this.UserNameLaabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLaabel.ForeColor = System.Drawing.Color.Black;
            this.UserNameLaabel.Location = new System.Drawing.Point(3, 15);
            this.UserNameLaabel.Name = "UserNameLaabel";
            this.UserNameLaabel.Size = new System.Drawing.Size(97, 19);
            this.UserNameLaabel.TabIndex = 46;
            this.UserNameLaabel.Text = "Username: ";
            // 
            // ChangeUsernameLabel
            // 
            this.ChangeUsernameLabel.AutoSize = true;
            this.ChangeUsernameLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeUsernameLabel.ForeColor = System.Drawing.Color.Black;
            this.ChangeUsernameLabel.Location = new System.Drawing.Point(2, 53);
            this.ChangeUsernameLabel.Name = "ChangeUsernameLabel";
            this.ChangeUsernameLabel.Size = new System.Drawing.Size(139, 18);
            this.ChangeUsernameLabel.TabIndex = 47;
            this.ChangeUsernameLabel.Text = "Change Username";
            // 
            // CurrentUserNameTextBox
            // 
            this.CurrentUserNameTextBox.BackColor = System.Drawing.Color.White;
            this.CurrentUserNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentUserNameTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentUserNameTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CurrentUserNameTextBox.Location = new System.Drawing.Point(5, 98);
            this.CurrentUserNameTextBox.Name = "CurrentUserNameTextBox";
            this.CurrentUserNameTextBox.Size = new System.Drawing.Size(346, 26);
            this.CurrentUserNameTextBox.TabIndex = 48;
            this.CurrentUserNameTextBox.Text = "Current username";
            this.CurrentUserNameTextBox.Click += new System.EventHandler(this.UsernameTextBoxesClicked);
            this.CurrentUserNameTextBox.TextChanged += new System.EventHandler(this.UserNameTextBoxesTextChanged);
            // 
            // NewUserNameTextBox
            // 
            this.NewUserNameTextBox.BackColor = System.Drawing.Color.White;
            this.NewUserNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewUserNameTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewUserNameTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.NewUserNameTextBox.Location = new System.Drawing.Point(6, 147);
            this.NewUserNameTextBox.Name = "NewUserNameTextBox";
            this.NewUserNameTextBox.Size = new System.Drawing.Size(345, 26);
            this.NewUserNameTextBox.TabIndex = 49;
            this.NewUserNameTextBox.Text = "New username";
            this.NewUserNameTextBox.Click += new System.EventHandler(this.UsernameTextBoxesClicked);
            this.NewUserNameTextBox.TextChanged += new System.EventHandler(this.UserNameTextBoxesTextChanged);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.White;
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.PasswordTextBox.Location = new System.Drawing.Point(6, 195);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(345, 26);
            this.PasswordTextBox.TabIndex = 50;
            this.PasswordTextBox.Text = "Password";
            this.PasswordTextBox.Click += new System.EventHandler(this.UsernameTextBoxesClicked);
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.UserNameTextBoxesTextChanged);
            // 
            // UpdateUsernameButton
            // 
            this.UpdateUsernameButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.UpdateUsernameButton.Enabled = false;
            this.UpdateUsernameButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.UpdateUsernameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateUsernameButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateUsernameButton.ForeColor = System.Drawing.Color.White;
            this.UpdateUsernameButton.Location = new System.Drawing.Point(6, 249);
            this.UpdateUsernameButton.Name = "UpdateUsernameButton";
            this.UpdateUsernameButton.Size = new System.Drawing.Size(345, 35);
            this.UpdateUsernameButton.TabIndex = 51;
            this.UpdateUsernameButton.Text = "Update Username";
            this.UpdateUsernameButton.UseVisualStyleBackColor = false;
            this.UpdateUsernameButton.Click += new System.EventHandler(this.SubmitNewUsernameButtonClicked);
            // 
            // UpdatePasswordButton
            // 
            this.UpdatePasswordButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.UpdatePasswordButton.Enabled = false;
            this.UpdatePasswordButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.UpdatePasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdatePasswordButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePasswordButton.ForeColor = System.Drawing.Color.White;
            this.UpdatePasswordButton.Location = new System.Drawing.Point(434, 249);
            this.UpdatePasswordButton.Name = "UpdatePasswordButton";
            this.UpdatePasswordButton.Size = new System.Drawing.Size(340, 35);
            this.UpdatePasswordButton.TabIndex = 56;
            this.UpdatePasswordButton.Text = "Update Password";
            this.UpdatePasswordButton.UseVisualStyleBackColor = false;
            this.UpdatePasswordButton.Click += new System.EventHandler(this.SubmitNewPasswordButtonClicked);
            // 
            // ConfirmPasswordTextBox
            // 
            this.ConfirmPasswordTextBox.BackColor = System.Drawing.Color.White;
            this.ConfirmPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfirmPasswordTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.ConfirmPasswordTextBox.Location = new System.Drawing.Point(434, 195);
            this.ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox";
            this.ConfirmPasswordTextBox.Size = new System.Drawing.Size(340, 26);
            this.ConfirmPasswordTextBox.TabIndex = 55;
            this.ConfirmPasswordTextBox.Text = "Confirm new password";
            this.ConfirmPasswordTextBox.Click += new System.EventHandler(this.PasswordTextBoxesClicked);
            this.ConfirmPasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBoxesTextChanged);
            // 
            // NewPasswordTextBox
            // 
            this.NewPasswordTextBox.BackColor = System.Drawing.Color.White;
            this.NewPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewPasswordTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPasswordTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.NewPasswordTextBox.Location = new System.Drawing.Point(435, 147);
            this.NewPasswordTextBox.Name = "NewPasswordTextBox";
            this.NewPasswordTextBox.Size = new System.Drawing.Size(340, 26);
            this.NewPasswordTextBox.TabIndex = 54;
            this.NewPasswordTextBox.Text = "New password";
            this.NewPasswordTextBox.Click += new System.EventHandler(this.PasswordTextBoxesClicked);
            this.NewPasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBoxesTextChanged);
            // 
            // CurrentPasswordTextBox
            // 
            this.CurrentPasswordTextBox.BackColor = System.Drawing.Color.White;
            this.CurrentPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentPasswordTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentPasswordTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CurrentPasswordTextBox.Location = new System.Drawing.Point(433, 98);
            this.CurrentPasswordTextBox.Name = "CurrentPasswordTextBox";
            this.CurrentPasswordTextBox.Size = new System.Drawing.Size(341, 26);
            this.CurrentPasswordTextBox.TabIndex = 53;
            this.CurrentPasswordTextBox.Text = "Current password";
            this.CurrentPasswordTextBox.Click += new System.EventHandler(this.PasswordTextBoxesClicked);
            this.CurrentPasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBoxesTextChanged);
            // 
            // ChangePasswordLabel
            // 
            this.ChangePasswordLabel.AutoSize = true;
            this.ChangePasswordLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePasswordLabel.ForeColor = System.Drawing.Color.Black;
            this.ChangePasswordLabel.Location = new System.Drawing.Point(432, 53);
            this.ChangePasswordLabel.Name = "ChangePasswordLabel";
            this.ChangePasswordLabel.Size = new System.Drawing.Size(137, 18);
            this.ChangePasswordLabel.TabIndex = 52;
            this.ChangePasswordLabel.Text = "Change Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(389, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 198);
            this.label3.TabIndex = 57;
            this.label3.Text = "|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 373);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(782, 18);
            this.label4.TabIndex = 58;
            this.label4.Text = "_________________________________________________________________________________" +
    "_____";
            // 
            // ReportIssueButton
            // 
            this.ReportIssueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportIssueButton.BackColor = System.Drawing.Color.White;
            this.ReportIssueButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.ReportIssueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportIssueButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportIssueButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ReportIssueButton.Location = new System.Drawing.Point(235, 431);
            this.ReportIssueButton.Name = "ReportIssueButton";
            this.ReportIssueButton.Size = new System.Drawing.Size(153, 31);
            this.ReportIssueButton.TabIndex = 64;
            this.ReportIssueButton.Text = "Report Issues";
            this.ReportIssueButton.UseVisualStyleBackColor = false;
            this.ReportIssueButton.Click += new System.EventHandler(this.ReportIssueButtonClicked);
            // 
            // HelpButton
            // 
            this.HelpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpButton.BackColor = System.Drawing.Color.White;
            this.HelpButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.HelpButton.Location = new System.Drawing.Point(15, 431);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(146, 31);
            this.HelpButton.TabIndex = 65;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = false;
            this.HelpButton.Click += new System.EventHandler(this.HelpButtonClicked);
            // 
            // AboutAppButton
            // 
            this.AboutAppButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AboutAppButton.BackColor = System.Drawing.Color.White;
            this.AboutAppButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.AboutAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AboutAppButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutAppButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.AboutAppButton.Location = new System.Drawing.Point(443, 431);
            this.AboutAppButton.Name = "AboutAppButton";
            this.AboutAppButton.Size = new System.Drawing.Size(148, 31);
            this.AboutAppButton.TabIndex = 66;
            this.AboutAppButton.Text = "About";
            this.AboutAppButton.UseVisualStyleBackColor = false;
            this.AboutAppButton.Click += new System.EventHandler(this.AboutAppButtonClicked);
            // 
            // LogOutButton
            // 
            this.LogOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogOutButton.BackColor = System.Drawing.Color.White;
            this.LogOutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogOutButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.LogOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOutButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.LogOutButton.Location = new System.Drawing.Point(662, 12);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(123, 38);
            this.LogOutButton.TabIndex = 73;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.LogOutButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.LogOutButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.ForestGreen;
            this.SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SettingsButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.ForeColor = System.Drawing.Color.White;
            this.SettingsButton.Location = new System.Drawing.Point(535, 12);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(121, 38);
            this.SettingsButton.TabIndex = 72;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = false;
            // 
            // StatisticsButton
            // 
            this.StatisticsButton.BackColor = System.Drawing.Color.White;
            this.StatisticsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StatisticsButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.StatisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatisticsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatisticsButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.StatisticsButton.Location = new System.Drawing.Point(406, 12);
            this.StatisticsButton.Name = "StatisticsButton";
            this.StatisticsButton.Size = new System.Drawing.Size(123, 38);
            this.StatisticsButton.TabIndex = 71;
            this.StatisticsButton.Text = "Statistics";
            this.StatisticsButton.UseVisualStyleBackColor = false;
            this.StatisticsButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.StatisticsButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.StatisticsButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // MonthlyReportButton
            // 
            this.MonthlyReportButton.BackColor = System.Drawing.Color.White;
            this.MonthlyReportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MonthlyReportButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.MonthlyReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MonthlyReportButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthlyReportButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.MonthlyReportButton.Location = new System.Drawing.Point(264, 12);
            this.MonthlyReportButton.Name = "MonthlyReportButton";
            this.MonthlyReportButton.Size = new System.Drawing.Size(136, 38);
            this.MonthlyReportButton.TabIndex = 70;
            this.MonthlyReportButton.Text = "Monthly Report";
            this.MonthlyReportButton.UseVisualStyleBackColor = false;
            this.MonthlyReportButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.MonthlyReportButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.MonthlyReportButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // AddNewDataButton
            // 
            this.AddNewDataButton.BackColor = System.Drawing.Color.White;
            this.AddNewDataButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddNewDataButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.AddNewDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNewDataButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewDataButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.AddNewDataButton.Location = new System.Drawing.Point(135, 12);
            this.AddNewDataButton.Name = "AddNewDataButton";
            this.AddNewDataButton.Size = new System.Drawing.Size(123, 38);
            this.AddNewDataButton.TabIndex = 69;
            this.AddNewDataButton.Text = "Add New";
            this.AddNewDataButton.UseVisualStyleBackColor = false;
            this.AddNewDataButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.AddNewDataButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.AddNewDataButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.White;
            this.HomeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HomeButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.HomeButton.Location = new System.Drawing.Point(10, 12);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(119, 38);
            this.HomeButton.TabIndex = 68;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.HomeButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.HomeButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.UpdatePasswordButton);
            this.panel1.Controls.Add(this.ConfirmPasswordTextBox);
            this.panel1.Controls.Add(this.NewPasswordTextBox);
            this.panel1.Controls.Add(this.CurrentPasswordTextBox);
            this.panel1.Controls.Add(this.ChangePasswordLabel);
            this.panel1.Controls.Add(this.UpdateUsernameButton);
            this.panel1.Controls.Add(this.PasswordTextBox);
            this.panel1.Controls.Add(this.NewUserNameTextBox);
            this.panel1.Controls.Add(this.CurrentUserNameTextBox);
            this.panel1.Controls.Add(this.ChangeUsernameLabel);
            this.panel1.Controls.Add(this.UserNameLaabel);
            this.panel1.Location = new System.Drawing.Point(10, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(783, 312);
            this.panel1.TabIndex = 74;
            // 
            // ViewSourceButton
            // 
            this.ViewSourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewSourceButton.BackColor = System.Drawing.Color.White;
            this.ViewSourceButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.ViewSourceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewSourceButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewSourceButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ViewSourceButton.Location = new System.Drawing.Point(640, 431);
            this.ViewSourceButton.Name = "ViewSourceButton";
            this.ViewSourceButton.Size = new System.Drawing.Size(148, 31);
            this.ViewSourceButton.TabIndex = 75;
            this.ViewSourceButton.Text = "View Source";
            this.ViewSourceButton.UseVisualStyleBackColor = false;
            this.ViewSourceButton.Click += new System.EventHandler(this.ViewSourceButtonClicked);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 487);
            this.Controls.Add(this.ViewSourceButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.StatisticsButton);
            this.Controls.Add(this.MonthlyReportButton);
            this.Controls.Add(this.AddNewDataButton);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.AboutAppButton);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.ReportIssueButton);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MyCost - Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThisFormClosing);
            this.Load += new System.EventHandler(this.ThisFormLoading);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label UserNameLaabel;
        private System.Windows.Forms.Label ChangeUsernameLabel;
        private System.Windows.Forms.TextBox CurrentUserNameTextBox;
        private System.Windows.Forms.TextBox NewUserNameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button UpdateUsernameButton;
        private System.Windows.Forms.Button UpdatePasswordButton;
        private System.Windows.Forms.TextBox ConfirmPasswordTextBox;
        private System.Windows.Forms.TextBox NewPasswordTextBox;
        private System.Windows.Forms.TextBox CurrentPasswordTextBox;
        private System.Windows.Forms.Label ChangePasswordLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ReportIssueButton;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Button AboutAppButton;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button StatisticsButton;
        private System.Windows.Forms.Button MonthlyReportButton;
        private System.Windows.Forms.Button AddNewDataButton;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ViewSourceButton;
    }
}