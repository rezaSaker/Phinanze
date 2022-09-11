namespace MyCost.View
{
    partial class PasswordResetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordResetForm));
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.ResetpasswordButton = new System.Windows.Forms.Button();
            this.ResetUsernameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.EmailTextBox.Location = new System.Drawing.Point(120, 34);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(517, 30);
            this.EmailTextBox.TabIndex = 0;
            this.EmailTextBox.TabStop = false;
            this.EmailTextBox.Text = "Type your email";
            this.EmailTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EmailTextBoxClicked);
            // 
            // ResetpasswordButton
            // 
            this.ResetpasswordButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.ResetpasswordButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.ResetpasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetpasswordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetpasswordButton.ForeColor = System.Drawing.Color.White;
            this.ResetpasswordButton.Location = new System.Drawing.Point(120, 91);
            this.ResetpasswordButton.Margin = new System.Windows.Forms.Padding(4);
            this.ResetpasswordButton.Name = "ResetpasswordButton";
            this.ResetpasswordButton.Size = new System.Drawing.Size(253, 43);
            this.ResetpasswordButton.TabIndex = 3;
            this.ResetpasswordButton.Text = "Reset Password";
            this.ResetpasswordButton.UseVisualStyleBackColor = false;
            this.ResetpasswordButton.Click += new System.EventHandler(this.ResetPasswordButtonClicked);
            // 
            // ResetUsernameButton
            // 
            this.ResetUsernameButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.ResetUsernameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.ResetUsernameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetUsernameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetUsernameButton.ForeColor = System.Drawing.Color.White;
            this.ResetUsernameButton.Location = new System.Drawing.Point(385, 91);
            this.ResetUsernameButton.Margin = new System.Windows.Forms.Padding(4);
            this.ResetUsernameButton.Name = "ResetUsernameButton";
            this.ResetUsernameButton.Size = new System.Drawing.Size(253, 43);
            this.ResetUsernameButton.TabIndex = 4;
            this.ResetUsernameButton.Text = "Reset Username";
            this.ResetUsernameButton.UseVisualStyleBackColor = false;
            this.ResetUsernameButton.Click += new System.EventHandler(this.ResetUsernameButtonClicked);
            // 
            // PasswordResetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 165);
            this.Controls.Add(this.ResetUsernameButton);
            this.Controls.Add(this.ResetpasswordButton);
            this.Controls.Add(this.EmailTextBox);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordResetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Phinanze - Reset Password or Username";
            this.Load += new System.EventHandler(this.ThisFormLoading);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Button ResetpasswordButton;
        private System.Windows.Forms.Button ResetUsernameButton;
    }
}