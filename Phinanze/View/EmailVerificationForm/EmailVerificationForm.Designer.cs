namespace Phinanze.View
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
            this.NotNowButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.NotNowButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.NotNowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NotNowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotNowButton.ForeColor = System.Drawing.Color.White;
            this.NotNowButton.Location = new System.Drawing.Point(377, 110);
            this.NotNowButton.Margin = new System.Windows.Forms.Padding(4);
            this.NotNowButton.Name = "NotNowButton";
            this.NotNowButton.Size = new System.Drawing.Size(172, 41);
            this.NotNowButton.TabIndex = 11;
            this.NotNowButton.Text = "Skip";
            this.NotNowButton.UseVisualStyleBackColor = false;
            this.NotNowButton.Click += new System.EventHandler(this.NotNowButtonClicked);
            // 
            // GuidelineTextBox
            // 
            this.GuidelineTextBox.BackColor = System.Drawing.Color.White;
            this.GuidelineTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GuidelineTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuidelineTextBox.ForeColor = System.Drawing.Color.Black;
            this.GuidelineTextBox.Location = new System.Drawing.Point(16, 233);
            this.GuidelineTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.GuidelineTextBox.Name = "GuidelineTextBox";
            this.GuidelineTextBox.ReadOnly = true;
            this.GuidelineTextBox.Size = new System.Drawing.Size(679, 181);
            this.GuidelineTextBox.TabIndex = 10;
            this.GuidelineTextBox.Text = resources.GetString("GuidelineTextBox.Text");
            this.GuidelineTextBox.Visible = false;
            // 
            // CodeResendButton
            // 
            this.CodeResendButton.BackColor = System.Drawing.Color.Transparent;
            this.CodeResendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CodeResendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CodeResendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeResendButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.CodeResendButton.Location = new System.Drawing.Point(183, 185);
            this.CodeResendButton.Margin = new System.Windows.Forms.Padding(4);
            this.CodeResendButton.Name = "CodeResendButton";
            this.CodeResendButton.Size = new System.Drawing.Size(367, 41);
            this.CodeResendButton.TabIndex = 9;
            this.CodeResendButton.Text = "I did not recieve any code";
            this.CodeResendButton.UseVisualStyleBackColor = false;
            this.CodeResendButton.Click += new System.EventHandler(this.CodeResendButtonClicked);
            // 
            // VerifyEmailButton
            // 
            this.VerifyEmailButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.VerifyEmailButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.VerifyEmailButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VerifyEmailButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifyEmailButton.ForeColor = System.Drawing.Color.White;
            this.VerifyEmailButton.Location = new System.Drawing.Point(183, 110);
            this.VerifyEmailButton.Margin = new System.Windows.Forms.Padding(4);
            this.VerifyEmailButton.Name = "VerifyEmailButton";
            this.VerifyEmailButton.Size = new System.Drawing.Size(187, 41);
            this.VerifyEmailButton.TabIndex = 8;
            this.VerifyEmailButton.Text = "Verify  ";
            this.VerifyEmailButton.UseVisualStyleBackColor = false;
            this.VerifyEmailButton.Click += new System.EventHandler(this.VerifyEmailButtonClicked);
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.Location = new System.Drawing.Point(35, 22);
            this.HeaderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(543, 25);
            this.HeaderLabel.TabIndex = 7;
            this.HeaderLabel.Text = "Please enter the verification code that was sent to your email: ";
            // 
            // VerificationCodeTextBox
            // 
            this.VerificationCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerificationCodeTextBox.Location = new System.Drawing.Point(183, 69);
            this.VerificationCodeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.VerificationCodeTextBox.Name = "VerificationCodeTextBox";
            this.VerificationCodeTextBox.Size = new System.Drawing.Size(365, 30);
            this.VerificationCodeTextBox.TabIndex = 6;
            // 
            // EmailVerificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(712, 261);
            this.Controls.Add(this.NotNowButton);
            this.Controls.Add(this.GuidelineTextBox);
            this.Controls.Add(this.CodeResendButton);
            this.Controls.Add(this.VerifyEmailButton);
            this.Controls.Add(this.HeaderLabel);
            this.Controls.Add(this.VerificationCodeTextBox);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmailVerificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Phinanze - Email Verification";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EmailVerificationFormClosed);
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