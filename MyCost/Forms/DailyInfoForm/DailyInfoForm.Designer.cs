namespace MyCost.Forms
{
    partial class DailyInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyInfoForm));
            this.expenseDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.lbl_status = new System.Windows.Forms.Label();
            this.dayComboBox = new System.Windows.Forms.ComboBox();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.earningDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.totalEarningLabel = new System.Windows.Forms.Label();
            this.totalExpenseLabel = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Button();
            this.ShowMonthlyInfoButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            this.applyCategoryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.expenseDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.earningDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // expenseDataGridView
            // 
            this.expenseDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.expenseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expenseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Category,
            this.Column3});
            this.expenseDataGridView.Location = new System.Drawing.Point(9, 97);
            this.expenseDataGridView.Name = "expenseDataGridView";
            this.expenseDataGridView.Size = new System.Drawing.Size(779, 150);
            this.expenseDataGridView.TabIndex = 3;
            this.expenseDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.ExpenseDGVEditBegan);
            this.expenseDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpenseDataGridViewCellClicked);
            this.expenseDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpenseDGVEditEnded);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Reason";
            this.Column1.Name = "Column1";
            this.Column1.Width = 255;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Amount";
            this.Column2.Name = "Column2";
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Comment";
            this.Column3.Name = "Column3";
            this.Column3.Width = 255;
            // 
            // noteTextBox
            // 
            this.noteTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.noteTextBox.Location = new System.Drawing.Point(12, 8);
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(347, 26);
            this.noteTextBox.TabIndex = 6;
            this.noteTextBox.Text = "Note";
            this.noteTextBox.Click += new System.EventHandler(this.NoteTextBoxClicked);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.BackColor = System.Drawing.Color.White;
            this.lbl_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_status.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(5, 72);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(74, 22);
            this.lbl_status.TabIndex = 15;
            this.lbl_status.Text = "Expenses";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dayComboBox
            // 
            this.dayComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayComboBox.FormattingEnabled = true;
            this.dayComboBox.Location = new System.Drawing.Point(12, 41);
            this.dayComboBox.Name = "dayComboBox";
            this.dayComboBox.Size = new System.Drawing.Size(61, 26);
            this.dayComboBox.TabIndex = 18;
            this.dayComboBox.SelectedIndexChanged += new System.EventHandler(this.DayComboBoxIndexChanged);
            // 
            // monthComboBox
            // 
            this.monthComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.monthComboBox.Location = new System.Drawing.Point(79, 41);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(164, 26);
            this.monthComboBox.TabIndex = 20;
            this.monthComboBox.SelectedIndexChanged += new System.EventHandler(this.MonthComboBoxIndexChanged);
            // 
            // yearComboBox
            // 
            this.yearComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Location = new System.Drawing.Point(250, 41);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(109, 26);
            this.yearComboBox.TabIndex = 22;
            this.yearComboBox.SelectedIndexChanged += new System.EventHandler(this.YearComboBoxIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 22);
            this.label1.TabIndex = 24;
            this.label1.Text = "Earnings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // earningDataGridView
            // 
            this.earningDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.earningDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.earningDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4});
            this.earningDataGridView.Location = new System.Drawing.Point(9, 288);
            this.earningDataGridView.Name = "earningDataGridView";
            this.earningDataGridView.Size = new System.Drawing.Size(779, 149);
            this.earningDataGridView.TabIndex = 23;
            this.earningDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.EarningDGVEditBegan);
            this.earningDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EarningDataGridViewCellClicked);
            this.earningDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EarningDGVEditEnded);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Source";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 255;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Category";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 255;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(679, 443);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(111, 32);
            this.saveButton.TabIndex = 25;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClicked);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
            this.cancelButton.Location = new System.Drawing.Point(569, 445);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(104, 30);
            this.cancelButton.TabIndex = 26;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClicked);
            // 
            // totalEarningLabel
            // 
            this.totalEarningLabel.AutoSize = true;
            this.totalEarningLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.totalEarningLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalEarningLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.totalEarningLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalEarningLabel.Location = new System.Drawing.Point(79, 261);
            this.totalEarningLabel.Name = "totalEarningLabel";
            this.totalEarningLabel.Size = new System.Drawing.Size(42, 24);
            this.totalEarningLabel.TabIndex = 35;
            this.totalEarningLabel.Text = "0.00";
            this.totalEarningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalExpenseLabel
            // 
            this.totalExpenseLabel.AutoSize = true;
            this.totalExpenseLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.totalExpenseLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalExpenseLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.totalExpenseLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalExpenseLabel.Location = new System.Drawing.Point(79, 70);
            this.totalExpenseLabel.Name = "totalExpenseLabel";
            this.totalExpenseLabel.Size = new System.Drawing.Size(42, 24);
            this.totalExpenseLabel.TabIndex = 36;
            this.totalExpenseLabel.Text = "0.00";
            this.totalExpenseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.White;
            this.settingsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("settingsButton.BackgroundImage")));
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Location = new System.Drawing.Point(648, 8);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(60, 60);
            this.settingsButton.TabIndex = 45;
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButtonClicked);
            // 
            // ShowMonthlyInfoButton
            // 
            this.ShowMonthlyInfoButton.BackColor = System.Drawing.Color.White;
            this.ShowMonthlyInfoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ShowMonthlyInfoButton.BackgroundImage")));
            this.ShowMonthlyInfoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ShowMonthlyInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowMonthlyInfoButton.Location = new System.Drawing.Point(467, 9);
            this.ShowMonthlyInfoButton.Name = "ShowMonthlyInfoButton";
            this.ShowMonthlyInfoButton.Size = new System.Drawing.Size(60, 60);
            this.ShowMonthlyInfoButton.TabIndex = 44;
            this.ShowMonthlyInfoButton.UseVisualStyleBackColor = false;
            this.ShowMonthlyInfoButton.Click += new System.EventHandler(this.MonthlyReportButtonClicked);
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.Color.Red;
            this.logOutButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logOutButton.BackgroundImage")));
            this.logOutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logOutButton.Location = new System.Drawing.Point(730, 8);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(60, 60);
            this.logOutButton.TabIndex = 43;
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.LogOutButtonClicked);
            // 
            // statisticsButton
            // 
            this.statisticsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statisticsButton.BackgroundImage")));
            this.statisticsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statisticsButton.Location = new System.Drawing.Point(558, 9);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(60, 60);
            this.statisticsButton.TabIndex = 42;
            this.statisticsButton.UseVisualStyleBackColor = true;
            this.statisticsButton.Click += new System.EventHandler(this.StatisticalReportButtonClicked);
            // 
            // homeButton
            // 
            this.homeButton.BackColor = System.Drawing.Color.White;
            this.homeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("homeButton.BackgroundImage")));
            this.homeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Location = new System.Drawing.Point(377, 9);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(60, 60);
            this.homeButton.TabIndex = 41;
            this.homeButton.UseVisualStyleBackColor = false;
            this.homeButton.Click += new System.EventHandler(this.HomeButtonClicked);
            // 
            // applyCategoryButton
            // 
            this.applyCategoryButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.applyCategoryButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.applyCategoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyCategoryButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyCategoryButton.ForeColor = System.Drawing.Color.Black;
            this.applyCategoryButton.Location = new System.Drawing.Point(9, 445);
            this.applyCategoryButton.Name = "applyCategoryButton";
            this.applyCategoryButton.Size = new System.Drawing.Size(178, 30);
            this.applyCategoryButton.TabIndex = 46;
            this.applyCategoryButton.Text = "Apply category";
            this.applyCategoryButton.UseVisualStyleBackColor = false;
            this.applyCategoryButton.Click += new System.EventHandler(this.ApplyCategoryButtonClicked);
            // 
            // DailyInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 487);
            this.Controls.Add(this.applyCategoryButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.ShowMonthlyInfoButton);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.statisticsButton);
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.totalExpenseLabel);
            this.Controls.Add(this.totalEarningLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.earningDataGridView);
            this.Controls.Add(this.yearComboBox);
            this.Controls.Add(this.monthComboBox);
            this.Controls.Add(this.dayComboBox);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.noteTextBox);
            this.Controls.Add(this.expenseDataGridView);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DailyInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Daily expense and earning information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DailyInfoFormClosing);
            this.Load += new System.EventHandler(this.AddNewDataFormLoading);
            this.Shown += new System.EventHandler(this.DailyInfoFormShown);
            ((System.ComponentModel.ISupportInitialize)(this.expenseDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.earningDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView expenseDataGridView;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.ComboBox dayComboBox;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView earningDataGridView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label totalEarningLabel;
        private System.Windows.Forms.Label totalExpenseLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button ShowMonthlyInfoButton;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button applyCategoryButton;
    }
}