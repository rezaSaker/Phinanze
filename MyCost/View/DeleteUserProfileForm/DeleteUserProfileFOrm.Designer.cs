namespace MyCost.View
{
    partial class DeleteUserProfileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteUserProfileForm));
            this.DeleteAccountButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DeleteAccountButton
            // 
            this.DeleteAccountButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.DeleteAccountButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.DeleteAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteAccountButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteAccountButton.Location = new System.Drawing.Point(148, 103);
            this.DeleteAccountButton.Name = "DeleteAccountButton";
            this.DeleteAccountButton.Size = new System.Drawing.Size(275, 35);
            this.DeleteAccountButton.TabIndex = 6;
            this.DeleteAccountButton.Text = "Delete Account Permanently";
            this.DeleteAccountButton.UseVisualStyleBackColor = true;
            this.DeleteAccountButton.Click += new System.EventHandler(this.DeleteAccountButtonClicked);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PasswordTextBox.Location = new System.Drawing.Point(91, 56);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(389, 27);
            this.PasswordTextBox.TabIndex = 5;
            this.PasswordTextBox.TabStop = false;
            this.PasswordTextBox.Text = "Type your password";
            this.PasswordTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PasswordTextBoxClicked);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.Black;
            this.statusLabel.Location = new System.Drawing.Point(88, 23);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(257, 21);
            this.statusLabel.TabIndex = 7;
            this.statusLabel.Text = "Type your password to continue";
            // 
            // DeleteUserProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 186);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.DeleteAccountButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteUserProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MyCost - Permanently Delete Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DeleteAccountButton;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label statusLabel;
    }
}