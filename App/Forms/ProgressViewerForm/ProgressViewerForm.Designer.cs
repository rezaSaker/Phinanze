namespace Phinanze.Forms
{
    partial class ProgressViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressViewerForm));
            this.StatusLabel = new System.Windows.Forms.Label();
            this.UI_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(16, 11);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(90, 25);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Progress";
            // 
            // UI_ProgressBar
            // 
            this.UI_ProgressBar.ForeColor = System.Drawing.Color.LimeGreen;
            this.UI_ProgressBar.Location = new System.Drawing.Point(21, 64);
            this.UI_ProgressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UI_ProgressBar.Name = "UI_ProgressBar";
            this.UI_ProgressBar.Size = new System.Drawing.Size(821, 28);
            this.UI_ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.UI_ProgressBar.TabIndex = 1;
            // 
            // ProgressViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(859, 153);
            this.Controls.Add(this.UI_ProgressBar);
            this.Controls.Add(this.StatusLabel);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Phinanze - Progress";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ProgressViewerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.ProgressBar UI_ProgressBar;
    }
}