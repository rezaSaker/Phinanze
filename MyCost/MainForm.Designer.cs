namespace MyCost
{
    partial class MainForm
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
            this.btn_registerPanel = new System.Windows.Forms.Button();
            this.btn_loginPanel = new System.Windows.Forms.Button();
            this.lbl_welcomeText = new System.Windows.Forms.Label();
            this.btn_submit = new System.Windows.Forms.Button();
            this.tb_confirmPassword = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.lbl_status = new System.Windows.Forms.Label();
            this.cb_rememberMe = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_registerPanel
            // 
            this.btn_registerPanel.AutoSize = true;
            this.btn_registerPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_registerPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_registerPanel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_registerPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_registerPanel.Location = new System.Drawing.Point(140, 82);
            this.btn_registerPanel.Name = "btn_registerPanel";
            this.btn_registerPanel.Size = new System.Drawing.Size(246, 36);
            this.btn_registerPanel.TabIndex = 0;
            this.btn_registerPanel.Text = "Register";
            this.btn_registerPanel.UseVisualStyleBackColor = false;
            this.btn_registerPanel.Click += new System.EventHandler(this.btn_registerPanel_Click);
            // 
            // btn_loginPanel
            // 
            this.btn_loginPanel.AutoSize = true;
            this.btn_loginPanel.BackColor = System.Drawing.Color.White;
            this.btn_loginPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_loginPanel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_loginPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_loginPanel.Location = new System.Drawing.Point(394, 82);
            this.btn_loginPanel.Name = "btn_loginPanel";
            this.btn_loginPanel.Size = new System.Drawing.Size(246, 36);
            this.btn_loginPanel.TabIndex = 1;
            this.btn_loginPanel.Text = "Log in";
            this.btn_loginPanel.UseVisualStyleBackColor = false;
            this.btn_loginPanel.Click += new System.EventHandler(this.btn_loginPanel_Click);
            // 
            // lbl_welcomeText
            // 
            this.lbl_welcomeText.AutoSize = true;
            this.lbl_welcomeText.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_welcomeText.Font = new System.Drawing.Font("Bauhaus 93", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcomeText.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_welcomeText.Location = new System.Drawing.Point(293, 9);
            this.lbl_welcomeText.Name = "lbl_welcomeText";
            this.lbl_welcomeText.Size = new System.Drawing.Size(191, 54);
            this.lbl_welcomeText.TabIndex = 3;
            this.lbl_welcomeText.Text = "MyCost";
            // 
            // btn_submit
            // 
            this.btn_submit.AutoSize = true;
            this.btn_submit.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_submit.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.ForeColor = System.Drawing.Color.White;
            this.btn_submit.Location = new System.Drawing.Point(270, 299);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(246, 36);
            this.btn_submit.TabIndex = 13;
            this.btn_submit.Text = "Log in";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // tb_confirmPassword
            // 
            this.tb_confirmPassword.BackColor = System.Drawing.SystemColors.Control;
            this.tb_confirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_confirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_confirmPassword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tb_confirmPassword.Location = new System.Drawing.Point(140, 226);
            this.tb_confirmPassword.Multiline = true;
            this.tb_confirmPassword.Name = "tb_confirmPassword";
            this.tb_confirmPassword.Size = new System.Drawing.Size(500, 30);
            this.tb_confirmPassword.TabIndex = 12;
            this.tb_confirmPassword.Text = "Confirm password";
            this.tb_confirmPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_confirmPassword_MouseClick);
            // 
            // tb_password
            // 
            this.tb_password.BackColor = System.Drawing.SystemColors.Control;
            this.tb_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_password.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tb_password.Location = new System.Drawing.Point(140, 180);
            this.tb_password.Multiline = true;
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(500, 30);
            this.tb_password.TabIndex = 11;
            this.tb_password.Text = "Password";
            this.tb_password.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_password_MouseClick);
            // 
            // tb_username
            // 
            this.tb_username.BackColor = System.Drawing.SystemColors.Control;
            this.tb_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_username.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tb_username.Location = new System.Drawing.Point(140, 134);
            this.tb_username.Multiline = true;
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(500, 30);
            this.tb_username.TabIndex = 10;
            this.tb_username.Text = "Username";
            this.tb_username.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_username_MouseClick);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(157, 348);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(82, 20);
            this.lbl_status.TabIndex = 14;
            this.lbl_status.Text = "Label Status";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_rememberMe
            // 
            this.cb_rememberMe.AutoSize = true;
            this.cb_rememberMe.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_rememberMe.Location = new System.Drawing.Point(140, 269);
            this.cb_rememberMe.Name = "cb_rememberMe";
            this.cb_rememberMe.Size = new System.Drawing.Size(126, 21);
            this.cb_rememberMe.TabIndex = 15;
            this.cb_rememberMe.Text = "Remember me";
            this.cb_rememberMe.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 377);
            this.Controls.Add(this.cb_rememberMe);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.tb_confirmPassword);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.lbl_welcomeText);
            this.Controls.Add(this.btn_loginPanel);
            this.Controls.Add(this.btn_registerPanel);
            this.Name = "MainForm";
            this.Text = "Login or Register";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_registerPanel;
        private System.Windows.Forms.Button btn_loginPanel;
        private System.Windows.Forms.Label lbl_welcomeText;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.TextBox tb_confirmPassword;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.CheckBox cb_rememberMe;
    }
}

