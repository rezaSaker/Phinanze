namespace MyCost.View
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.HomeDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearComboBox = new System.Windows.Forms.ComboBox();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.HomeButton = new System.Windows.Forms.Button();
            this.AddNewDataButton = new System.Windows.Forms.Button();
            this.MonthlyReportButton = new System.Windows.Forms.Button();
            this.StatisticsButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.LicenseLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HomeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // HomeDataGridView
            // 
            this.HomeDataGridView.AllowDrop = true;
            this.HomeDataGridView.AllowUserToAddRows = false;
            this.HomeDataGridView.AllowUserToDeleteRows = false;
            this.HomeDataGridView.AllowUserToResizeColumns = false;
            this.HomeDataGridView.AllowUserToResizeRows = false;
            this.HomeDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HomeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.HomeDataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HomeDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.HomeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HomeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.HomeDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.HomeDataGridView.Location = new System.Drawing.Point(12, 110);
            this.HomeDataGridView.Name = "HomeDataGridView";
            this.HomeDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HomeDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.HomeDataGridView.RowHeadersVisible = false;
            this.HomeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HomeDataGridView.Size = new System.Drawing.Size(775, 350);
            this.HomeDataGridView.TabIndex = 6;
            this.HomeDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellDoubleClicked);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Year";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Month";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Earning";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Expense";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Overview";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // YearComboBox
            // 
            this.YearComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearComboBox.FormattingEnabled = true;
            this.YearComboBox.Items.AddRange(new object[] {
            "All years"});
            this.YearComboBox.Location = new System.Drawing.Point(12, 78);
            this.YearComboBox.Name = "YearComboBox";
            this.YearComboBox.Size = new System.Drawing.Size(132, 26);
            this.YearComboBox.TabIndex = 33;
            this.YearComboBox.SelectedIndexChanged += new System.EventHandler(this.YearComboBoxIndexChanged);
            // 
            // VersionLabel
            // 
            this.VersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VersionLabel.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel.Location = new System.Drawing.Point(9, 463);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(44, 16);
            this.VersionLabel.TabIndex = 38;
            this.VersionLabel.Text = "Version";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.ForestGreen;
            this.HomeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HomeButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.White;
            this.HomeButton.Location = new System.Drawing.Point(12, 13);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(115, 38);
            this.HomeButton.TabIndex = 1;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = false;
            // 
            // AddNewDataButton
            // 
            this.AddNewDataButton.BackColor = System.Drawing.Color.White;
            this.AddNewDataButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddNewDataButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.AddNewDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNewDataButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewDataButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.AddNewDataButton.Location = new System.Drawing.Point(133, 13);
            this.AddNewDataButton.Name = "AddNewDataButton";
            this.AddNewDataButton.Size = new System.Drawing.Size(123, 38);
            this.AddNewDataButton.TabIndex = 42;
            this.AddNewDataButton.Text = "Add New";
            this.AddNewDataButton.UseVisualStyleBackColor = false;
            this.AddNewDataButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.AddNewDataButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.AddNewDataButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // MonthlyReportButton
            // 
            this.MonthlyReportButton.BackColor = System.Drawing.Color.White;
            this.MonthlyReportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MonthlyReportButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.MonthlyReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MonthlyReportButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthlyReportButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.MonthlyReportButton.Location = new System.Drawing.Point(262, 13);
            this.MonthlyReportButton.Name = "MonthlyReportButton";
            this.MonthlyReportButton.Size = new System.Drawing.Size(140, 38);
            this.MonthlyReportButton.TabIndex = 43;
            this.MonthlyReportButton.Text = "Monthly Report";
            this.MonthlyReportButton.UseVisualStyleBackColor = false;
            this.MonthlyReportButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.MonthlyReportButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.MonthlyReportButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // StatisticsButton
            // 
            this.StatisticsButton.BackColor = System.Drawing.Color.White;
            this.StatisticsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StatisticsButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.StatisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatisticsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatisticsButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.StatisticsButton.Location = new System.Drawing.Point(408, 13);
            this.StatisticsButton.Name = "StatisticsButton";
            this.StatisticsButton.Size = new System.Drawing.Size(123, 38);
            this.StatisticsButton.TabIndex = 44;
            this.StatisticsButton.Text = "Statistics";
            this.StatisticsButton.UseVisualStyleBackColor = false;
            this.StatisticsButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.StatisticsButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.StatisticsButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.White;
            this.SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SettingsButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.SettingsButton.Location = new System.Drawing.Point(537, 13);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(123, 38);
            this.SettingsButton.TabIndex = 45;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.SettingsButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.SettingsButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
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
            this.LogOutButton.Location = new System.Drawing.Point(664, 13);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(123, 38);
            this.LogOutButton.TabIndex = 46;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.LogOutButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.LogOutButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // LicenseLabel
            // 
            this.LicenseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LicenseLabel.AutoSize = true;
            this.LicenseLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LicenseLabel.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LicenseLabel.Location = new System.Drawing.Point(561, 463);
            this.LicenseLabel.Name = "LicenseLabel";
            this.LicenseLabel.Size = new System.Drawing.Size(227, 16);
            this.LicenseLabel.TabIndex = 47;
            this.LicenseLabel.Text = "This application is provided under MIT License";
            this.LicenseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 487);
            this.Controls.Add(this.LicenseLabel);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.StatisticsButton);
            this.Controls.Add(this.MonthlyReportButton);
            this.Controls.Add(this.AddNewDataButton);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.YearComboBox);
            this.Controls.Add(this.HomeDataGridView);
            this.Controls.Add(this.HomeButton);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 526);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MyCost - Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThisFormClosing);
            this.Load += new System.EventHandler(this.ThisFormLoading);
            ((System.ComponentModel.ISupportInitialize)(this.HomeDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView HomeDataGridView;
        private System.Windows.Forms.ComboBox YearComboBox;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Button AddNewDataButton;
        private System.Windows.Forms.Button MonthlyReportButton;
        private System.Windows.Forms.Button StatisticsButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Label LicenseLabel;
    }
}