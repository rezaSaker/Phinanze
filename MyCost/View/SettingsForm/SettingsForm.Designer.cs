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
            this.userNameLaabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.currentUserNameTextBox = new System.Windows.Forms.TextBox();
            this.newUserNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.submitUserNameButton = new System.Windows.Forms.Button();
            this.submitPasswordButton = new System.Windows.Forms.Button();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.currentPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.reportIssueButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.viewSourceButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.monthlyReportButton = new System.Windows.Forms.Button();
            this.addNewDataButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userNameLaabel
            // 
            this.userNameLaabel.AutoSize = true;
            this.userNameLaabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLaabel.ForeColor = System.Drawing.Color.Black;
            this.userNameLaabel.Location = new System.Drawing.Point(3, 15);
            this.userNameLaabel.Name = "userNameLaabel";
            this.userNameLaabel.Size = new System.Drawing.Size(97, 19);
            this.userNameLaabel.TabIndex = 46;
            this.userNameLaabel.Text = "Username: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(2, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 18);
            this.label1.TabIndex = 47;
            this.label1.Text = "Change username";
            // 
            // currentUserNameTextBox
            // 
            this.currentUserNameTextBox.BackColor = System.Drawing.Color.White;
            this.currentUserNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentUserNameTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentUserNameTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.currentUserNameTextBox.Location = new System.Drawing.Point(5, 98);
            this.currentUserNameTextBox.Name = "currentUserNameTextBox";
            this.currentUserNameTextBox.Size = new System.Drawing.Size(346, 26);
            this.currentUserNameTextBox.TabIndex = 48;
            this.currentUserNameTextBox.Text = "Current username";
            this.currentUserNameTextBox.Click += new System.EventHandler(this.UsernameTextBoxesClicked);
            this.currentUserNameTextBox.TextChanged += new System.EventHandler(this.UserNameTextBoxesTextChanged);
            // 
            // newUserNameTextBox
            // 
            this.newUserNameTextBox.BackColor = System.Drawing.Color.White;
            this.newUserNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newUserNameTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUserNameTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.newUserNameTextBox.Location = new System.Drawing.Point(6, 147);
            this.newUserNameTextBox.Name = "newUserNameTextBox";
            this.newUserNameTextBox.Size = new System.Drawing.Size(345, 26);
            this.newUserNameTextBox.TabIndex = 49;
            this.newUserNameTextBox.Text = "New username";
            this.newUserNameTextBox.Click += new System.EventHandler(this.UsernameTextBoxesClicked);
            this.newUserNameTextBox.TextChanged += new System.EventHandler(this.UserNameTextBoxesTextChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.White;
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.passwordTextBox.Location = new System.Drawing.Point(6, 195);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(345, 26);
            this.passwordTextBox.TabIndex = 50;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.Click += new System.EventHandler(this.UsernameTextBoxesClicked);
            this.passwordTextBox.TextChanged += new System.EventHandler(this.UserNameTextBoxesTextChanged);
            // 
            // submitUserNameButton
            // 
            this.submitUserNameButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.submitUserNameButton.Enabled = false;
            this.submitUserNameButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.submitUserNameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitUserNameButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitUserNameButton.ForeColor = System.Drawing.Color.White;
            this.submitUserNameButton.Location = new System.Drawing.Point(6, 249);
            this.submitUserNameButton.Name = "submitUserNameButton";
            this.submitUserNameButton.Size = new System.Drawing.Size(345, 35);
            this.submitUserNameButton.TabIndex = 51;
            this.submitUserNameButton.Text = "Submit";
            this.submitUserNameButton.UseVisualStyleBackColor = false;
            this.submitUserNameButton.Click += new System.EventHandler(this.SubmitNewUsernameButtonClicked);
            // 
            // submitPasswordButton
            // 
            this.submitPasswordButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.submitPasswordButton.Enabled = false;
            this.submitPasswordButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.submitPasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitPasswordButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitPasswordButton.ForeColor = System.Drawing.Color.White;
            this.submitPasswordButton.Location = new System.Drawing.Point(434, 249);
            this.submitPasswordButton.Name = "submitPasswordButton";
            this.submitPasswordButton.Size = new System.Drawing.Size(340, 35);
            this.submitPasswordButton.TabIndex = 56;
            this.submitPasswordButton.Text = "Submit";
            this.submitPasswordButton.UseVisualStyleBackColor = false;
            this.submitPasswordButton.Click += new System.EventHandler(this.SubmitNewPasswordButtonClicked);
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.BackColor = System.Drawing.Color.White;
            this.confirmPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.confirmPasswordTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(434, 195);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(340, 26);
            this.confirmPasswordTextBox.TabIndex = 55;
            this.confirmPasswordTextBox.Text = "Confirm new password";
            this.confirmPasswordTextBox.Click += new System.EventHandler(this.PasswordTextBoxesClicked);
            this.confirmPasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBoxesTextChanged);
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.BackColor = System.Drawing.Color.White;
            this.newPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newPasswordTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPasswordTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.newPasswordTextBox.Location = new System.Drawing.Point(435, 147);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.Size = new System.Drawing.Size(340, 26);
            this.newPasswordTextBox.TabIndex = 54;
            this.newPasswordTextBox.Text = "New password";
            this.newPasswordTextBox.Click += new System.EventHandler(this.PasswordTextBoxesClicked);
            this.newPasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBoxesTextChanged);
            // 
            // currentPasswordTextBox
            // 
            this.currentPasswordTextBox.BackColor = System.Drawing.Color.White;
            this.currentPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentPasswordTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPasswordTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.currentPasswordTextBox.Location = new System.Drawing.Point(433, 98);
            this.currentPasswordTextBox.Name = "currentPasswordTextBox";
            this.currentPasswordTextBox.Size = new System.Drawing.Size(341, 26);
            this.currentPasswordTextBox.TabIndex = 53;
            this.currentPasswordTextBox.Text = "Current password";
            this.currentPasswordTextBox.Click += new System.EventHandler(this.PasswordTextBoxesClicked);
            this.currentPasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBoxesTextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(432, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 18);
            this.label2.TabIndex = 52;
            this.label2.Text = "Change username";
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
            // reportIssueButton
            // 
            this.reportIssueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reportIssueButton.BackColor = System.Drawing.Color.White;
            this.reportIssueButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.reportIssueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportIssueButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportIssueButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.reportIssueButton.Location = new System.Drawing.Point(164, 431);
            this.reportIssueButton.Name = "reportIssueButton";
            this.reportIssueButton.Size = new System.Drawing.Size(153, 31);
            this.reportIssueButton.TabIndex = 64;
            this.reportIssueButton.Text = "Report Issues";
            this.reportIssueButton.UseVisualStyleBackColor = false;
            this.reportIssueButton.Click += new System.EventHandler(this.ReportIssueButtonClicked);
            // 
            // helpButton
            // 
            this.helpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.helpButton.BackColor = System.Drawing.Color.White;
            this.helpButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.helpButton.Location = new System.Drawing.Point(12, 431);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(146, 31);
            this.helpButton.TabIndex = 65;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.HelpButtonClicked);
            // 
            // viewSourceButton
            // 
            this.viewSourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.viewSourceButton.BackColor = System.Drawing.Color.White;
            this.viewSourceButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.viewSourceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewSourceButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewSourceButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.viewSourceButton.Location = new System.Drawing.Point(323, 431);
            this.viewSourceButton.Name = "viewSourceButton";
            this.viewSourceButton.Size = new System.Drawing.Size(148, 31);
            this.viewSourceButton.TabIndex = 66;
            this.viewSourceButton.Text = "View Source";
            this.viewSourceButton.UseVisualStyleBackColor = false;
            this.viewSourceButton.Click += new System.EventHandler(this.ViewSourceButtonClicked);
            // 
            // logOutButton
            // 
            this.logOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logOutButton.BackColor = System.Drawing.Color.White;
            this.logOutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logOutButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.logOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logOutButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.logOutButton.Location = new System.Drawing.Point(662, 12);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(123, 38);
            this.logOutButton.TabIndex = 73;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.logOutButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.logOutButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.ForestGreen;
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settingsButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.Location = new System.Drawing.Point(535, 12);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(121, 38);
            this.settingsButton.TabIndex = 72;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = false;
            // 
            // statisticsButton
            // 
            this.statisticsButton.BackColor = System.Drawing.Color.White;
            this.statisticsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statisticsButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.statisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statisticsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.statisticsButton.Location = new System.Drawing.Point(406, 12);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(123, 38);
            this.statisticsButton.TabIndex = 71;
            this.statisticsButton.Text = "Statistics";
            this.statisticsButton.UseVisualStyleBackColor = false;
            this.statisticsButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.statisticsButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.statisticsButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // monthlyReportButton
            // 
            this.monthlyReportButton.BackColor = System.Drawing.Color.White;
            this.monthlyReportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.monthlyReportButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.monthlyReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.monthlyReportButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthlyReportButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.monthlyReportButton.Location = new System.Drawing.Point(264, 12);
            this.monthlyReportButton.Name = "monthlyReportButton";
            this.monthlyReportButton.Size = new System.Drawing.Size(136, 38);
            this.monthlyReportButton.TabIndex = 70;
            this.monthlyReportButton.Text = "Monthly Report";
            this.monthlyReportButton.UseVisualStyleBackColor = false;
            this.monthlyReportButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.monthlyReportButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.monthlyReportButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // addNewDataButton
            // 
            this.addNewDataButton.BackColor = System.Drawing.Color.White;
            this.addNewDataButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addNewDataButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.addNewDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNewDataButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewDataButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.addNewDataButton.Location = new System.Drawing.Point(135, 12);
            this.addNewDataButton.Name = "addNewDataButton";
            this.addNewDataButton.Size = new System.Drawing.Size(123, 38);
            this.addNewDataButton.TabIndex = 69;
            this.addNewDataButton.Text = "Add New";
            this.addNewDataButton.UseVisualStyleBackColor = false;
            this.addNewDataButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.addNewDataButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.addNewDataButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // homeButton
            // 
            this.homeButton.BackColor = System.Drawing.Color.White;
            this.homeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.homeButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.homeButton.Location = new System.Drawing.Point(10, 12);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(119, 38);
            this.homeButton.TabIndex = 68;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = false;
            this.homeButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.homeButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.homeButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.submitPasswordButton);
            this.panel1.Controls.Add(this.confirmPasswordTextBox);
            this.panel1.Controls.Add(this.newPasswordTextBox);
            this.panel1.Controls.Add(this.currentPasswordTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.submitUserNameButton);
            this.panel1.Controls.Add(this.passwordTextBox);
            this.panel1.Controls.Add(this.newUserNameTextBox);
            this.panel1.Controls.Add(this.currentUserNameTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.userNameLaabel);
            this.panel1.Location = new System.Drawing.Point(10, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(783, 312);
            this.panel1.TabIndex = 74;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.button1.Location = new System.Drawing.Point(477, 431);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 31);
            this.button1.TabIndex = 75;
            this.button1.Text = "View Source";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.button2.Location = new System.Drawing.Point(632, 431);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 31);
            this.button2.TabIndex = 76;
            this.button2.Text = "View Source";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 487);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.statisticsButton);
            this.Controls.Add(this.monthlyReportButton);
            this.Controls.Add(this.addNewDataButton);
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.viewSourceButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.reportIssueButton);
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
        private System.Windows.Forms.Label userNameLaabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currentUserNameTextBox;
        private System.Windows.Forms.TextBox newUserNameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button submitUserNameButton;
        private System.Windows.Forms.Button submitPasswordButton;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.TextBox currentPasswordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button reportIssueButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button viewSourceButton;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.Button monthlyReportButton;
        private System.Windows.Forms.Button addNewDataButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}