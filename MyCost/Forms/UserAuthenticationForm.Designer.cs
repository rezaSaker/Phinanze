namespace MyCost
{
    partial class UserAuthenticationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAuthenticationForm));
            this.showRegisterPanelButton = new System.Windows.Forms.Button();
            this.showLoginPanelButton = new System.Windows.Forms.Button();
            this.lbl_welcomeText = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.rememberMeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // showRegisterPanelButton
            // 
            this.showRegisterPanelButton.AutoSize = true;
            this.showRegisterPanelButton.BackColor = System.Drawing.Color.White;
            this.showRegisterPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showRegisterPanelButton.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showRegisterPanelButton.ForeColor = System.Drawing.Color.Black;
            this.showRegisterPanelButton.Location = new System.Drawing.Point(140, 82);
            this.showRegisterPanelButton.Name = "showRegisterPanelButton";
            this.showRegisterPanelButton.Size = new System.Drawing.Size(246, 36);
            this.showRegisterPanelButton.TabIndex = 0;
            this.showRegisterPanelButton.Text = "Register";
            this.showRegisterPanelButton.UseVisualStyleBackColor = false;
            this.showRegisterPanelButton.Click += new System.EventHandler(this.ShowRegisterPanelButtonClicked);
            // 
            // showLoginPanelButton
            // 
            this.showLoginPanelButton.AutoSize = true;
            this.showLoginPanelButton.BackColor = System.Drawing.Color.White;
            this.showLoginPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showLoginPanelButton.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLoginPanelButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.showLoginPanelButton.Location = new System.Drawing.Point(394, 82);
            this.showLoginPanelButton.Name = "showLoginPanelButton";
            this.showLoginPanelButton.Size = new System.Drawing.Size(246, 36);
            this.showLoginPanelButton.TabIndex = 1;
            this.showLoginPanelButton.Text = "Log in";
            this.showLoginPanelButton.UseVisualStyleBackColor = false;
            this.showLoginPanelButton.Click += new System.EventHandler(this.ShowLoginPanelButoonClicked);
            // 
            // lbl_welcomeText
            // 
            this.lbl_welcomeText.AutoSize = true;
            this.lbl_welcomeText.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_welcomeText.Font = new System.Drawing.Font("Bauhaus 93", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcomeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbl_welcomeText.Location = new System.Drawing.Point(286, 9);
            this.lbl_welcomeText.Name = "lbl_welcomeText";
            this.lbl_welcomeText.Size = new System.Drawing.Size(209, 54);
            this.lbl_welcomeText.TabIndex = 3;
            this.lbl_welcomeText.Text = "MYCOST";
            // 
            // submitButton
            // 
            this.submitButton.AutoSize = true;
            this.submitButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.submitButton.FlatAppearance.BorderSize = 0;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.ForeColor = System.Drawing.Color.White;
            this.submitButton.Location = new System.Drawing.Point(270, 299);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(246, 36);
            this.submitButton.TabIndex = 13;
            this.submitButton.Text = "Log in";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.SubmitButtonClicked);
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.BackColor = System.Drawing.Color.White;
            this.confirmPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.confirmPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordTextBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(140, 226);
            this.confirmPasswordTextBox.Multiline = true;
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(500, 30);
            this.confirmPasswordTextBox.TabIndex = 12;
            this.confirmPasswordTextBox.Text = "Confirm password";
            this.confirmPasswordTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ConfirmPasswordTextBoxClicked);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.White;
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.passwordTextBox.Location = new System.Drawing.Point(140, 180);
            this.passwordTextBox.Multiline = true;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(500, 30);
            this.passwordTextBox.TabIndex = 11;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PasswordTextboxClicked);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BackColor = System.Drawing.Color.White;
            this.usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.usernameTextBox.Location = new System.Drawing.Point(140, 134);
            this.usernameTextBox.Multiline = true;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(500, 30);
            this.usernameTextBox.TabIndex = 10;
            this.usernameTextBox.Text = "Username";
            this.usernameTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UsernameTextBoxClicked);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(157, 348);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(82, 20);
            this.statusLabel.TabIndex = 14;
            this.statusLabel.Text = "Label Status";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rememberMeCheckBox
            // 
            this.rememberMeCheckBox.AutoSize = true;
            this.rememberMeCheckBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rememberMeCheckBox.Location = new System.Drawing.Point(140, 269);
            this.rememberMeCheckBox.Name = "rememberMeCheckBox";
            this.rememberMeCheckBox.Size = new System.Drawing.Size(126, 21);
            this.rememberMeCheckBox.TabIndex = 15;
            this.rememberMeCheckBox.Text = "Remember me";
            this.rememberMeCheckBox.UseVisualStyleBackColor = true;
            // 
            // UserAuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 377);
            this.Controls.Add(this.rememberMeCheckBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.confirmPasswordTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.lbl_welcomeText);
            this.Controls.Add(this.showLoginPanelButton);
            this.Controls.Add(this.showRegisterPanelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UserAuthenticationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login or Register";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserAuthenticationFormClosing);
            this.Load += new System.EventHandler(this.UserAuthenticationFormLoading);
            this.Shown += new System.EventHandler(this.UserAuthenticationFormShown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showRegisterPanelButton;
        private System.Windows.Forms.Button showLoginPanelButton;
        private System.Windows.Forms.Label lbl_welcomeText;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.CheckBox rememberMeCheckBox;
    }
}

