namespace MyCost.View
{
    partial class EmailVerificationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailVerificationForm));
            this.NotNowButton = new System.Windows.Forms.Button();
            this.GuidelineTextBox = new System.Windows.Forms.RichTextBox();
            this.CodeResendButton = new System.Windows.Forms.Button();
            this.VerifyEmailButton = new System.Windows.Forms.Button();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.VerificationCodeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NotNowButton
            // 
            this.NotNowButton.BackColor = System.Drawing.Color.Transparent;
            this.NotNowButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.NotNowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NotNowButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotNowButton.ForeColor = System.Drawing.Color.Black;
            this.NotNowButton.Location = new System.Drawing.Point(283, 89);
            this.NotNowButton.Name = "NotNowButton";
            this.NotNowButton.Size = new System.Drawing.Size(129, 33);
            this.NotNowButton.TabIndex = 11;
            this.NotNowButton.Text = "Not Now";
            this.NotNowButton.UseVisualStyleBackColor = false;
            this.NotNowButton.Click += new System.EventHandler(this.NotNowButtonClicked);
            // 
            // GuidelineTextBox
            // 
            this.GuidelineTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GuidelineTextBox.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuidelineTextBox.Location = new System.Drawing.Point(12, 189);
            this.GuidelineTextBox.Name = "GuidelineTextBox";
            this.GuidelineTextBox.ReadOnly = true;
            this.GuidelineTextBox.Size = new System.Drawing.Size(509, 147);
            this.GuidelineTextBox.TabIndex = 10;
            this.GuidelineTextBox.Text = resources.GetString("GuidelineTextBox.Text");
            this.GuidelineTextBox.Visible = false;
            // 
            // CodeResendButton
            // 
            this.CodeResendButton.BackColor = System.Drawing.Color.Transparent;
            this.CodeResendButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.CodeResendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CodeResendButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeResendButton.ForeColor = System.Drawing.Color.Black;
            this.CodeResendButton.Location = new System.Drawing.Point(137, 150);
            this.CodeResendButton.Name = "CodeResendButton";
            this.CodeResendButton.Size = new System.Drawing.Size(275, 33);
            this.CodeResendButton.TabIndex = 9;
            this.CodeResendButton.Text = "I did not recieve any code";
            this.CodeResendButton.UseVisualStyleBackColor = false;
            this.CodeResendButton.Click += new System.EventHandler(this.CodeResendButtonClicked);
            // 
            // VerifyEmailButton
            // 
            this.VerifyEmailButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.VerifyEmailButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.VerifyEmailButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VerifyEmailButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifyEmailButton.ForeColor = System.Drawing.Color.White;
            this.VerifyEmailButton.Location = new System.Drawing.Point(137, 89);
            this.VerifyEmailButton.Name = "VerifyEmailButton";
            this.VerifyEmailButton.Size = new System.Drawing.Size(140, 33);
            this.VerifyEmailButton.TabIndex = 8;
            this.VerifyEmailButton.Text = "Verify My Email";
            this.VerifyEmailButton.UseVisualStyleBackColor = false;
            this.VerifyEmailButton.Click += new System.EventHandler(this.VerifyEmailButtonClicked);
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.Location = new System.Drawing.Point(26, 18);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(495, 21);
            this.HeaderLabel.TabIndex = 7;
            this.HeaderLabel.Text = "Please enter the verification code that was sent to your email: ";
            // 
            // VerificationCodeTextBox
            // 
            this.VerificationCodeTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerificationCodeTextBox.Location = new System.Drawing.Point(137, 56);
            this.VerificationCodeTextBox.Name = "VerificationCodeTextBox";
            this.VerificationCodeTextBox.Size = new System.Drawing.Size(275, 27);
            this.VerificationCodeTextBox.TabIndex = 6;
            // 
            // EmailVerificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 208);
            this.Controls.Add(this.NotNowButton);
            this.Controls.Add(this.GuidelineTextBox);
            this.Controls.Add(this.CodeResendButton);
            this.Controls.Add(this.VerifyEmailButton);
            this.Controls.Add(this.HeaderLabel);
            this.Controls.Add(this.VerificationCodeTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EmailVerificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MyCost - Email Verification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NotNowButton;
        private System.Windows.Forms.RichTextBox GuidelineTextBox;
        private System.Windows.Forms.Button CodeResendButton;
        private System.Windows.Forms.Button VerifyEmailButton;
        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.TextBox VerificationCodeTextBox;
    }
}