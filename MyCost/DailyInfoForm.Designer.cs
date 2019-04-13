namespace MyCost
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
            this.expenseDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.lbl_status = new System.Windows.Forms.Label();
            this.applyCategoryButton = new System.Windows.Forms.Button();
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
            this.cancelbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_expenseTotal2 = new System.Windows.Forms.Label();
            this.lbl_totalEarning2 = new System.Windows.Forms.Label();
            this.totalEarningLabel = new System.Windows.Forms.Label();
            this.totalExpenseLabel = new System.Windows.Forms.Label();
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
            this.expenseDataGridView.Location = new System.Drawing.Point(9, 110);
            this.expenseDataGridView.Name = "expenseDataGridView";
            this.expenseDataGridView.Size = new System.Drawing.Size(806, 165);
            this.expenseDataGridView.TabIndex = 3;
            this.expenseDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.ExpenseDGVEditBegan);
            this.expenseDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpenseDGVCellDoubleClicked);
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
            this.Column2.Width = 125;
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
            this.noteTextBox.Location = new System.Drawing.Point(58, 5);
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(757, 26);
            this.noteTextBox.TabIndex = 6;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_status.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(9, 83);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(76, 24);
            this.lbl_status.TabIndex = 15;
            this.lbl_status.Text = "Expenses";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // applyCategoryButton
            // 
            this.applyCategoryButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.applyCategoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyCategoryButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyCategoryButton.ForeColor = System.Drawing.Color.Black;
            this.applyCategoryButton.Location = new System.Drawing.Point(9, 493);
            this.applyCategoryButton.Name = "applyCategoryButton";
            this.applyCategoryButton.Size = new System.Drawing.Size(253, 31);
            this.applyCategoryButton.TabIndex = 16;
            this.applyCategoryButton.Text = "Apply category to selected rows";
            this.applyCategoryButton.UseVisualStyleBackColor = false;
            this.applyCategoryButton.Click += new System.EventHandler(this.ApplyCategoryButtonClicked);
            // 
            // dayComboBox
            // 
            this.dayComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayComboBox.FormattingEnabled = true;
            this.dayComboBox.Location = new System.Drawing.Point(58, 40);
            this.dayComboBox.Name = "dayComboBox";
            this.dayComboBox.Size = new System.Drawing.Size(97, 26);
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
            this.monthComboBox.Location = new System.Drawing.Point(241, 40);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(164, 26);
            this.monthComboBox.TabIndex = 20;
            this.monthComboBox.SelectedIndexChanged += new System.EventHandler(this.MonthComboBoxIndexChanged);
            // 
            // yearComboBox
            // 
            this.yearComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Location = new System.Drawing.Point(484, 38);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(109, 26);
            this.yearComboBox.TabIndex = 22;
            this.yearComboBox.SelectedIndexChanged += new System.EventHandler(this.YearComboBoxIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "Earning";
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
            this.earningDataGridView.Location = new System.Drawing.Point(9, 322);
            this.earningDataGridView.Name = "earningDataGridView";
            this.earningDataGridView.Size = new System.Drawing.Size(806, 165);
            this.earningDataGridView.TabIndex = 23;
            this.earningDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.EarningDGVEditBegan);
            this.earningDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EarningDGVCellDoubleClicked);
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
            this.dataGridViewTextBoxColumn3.Width = 125;
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
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(706, 493);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(111, 32);
            this.saveButton.TabIndex = 25;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClicked);
            // 
            // cancelbutton
            // 
            this.cancelbutton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cancelbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbutton.ForeColor = System.Drawing.Color.Black;
            this.cancelbutton.Location = new System.Drawing.Point(594, 494);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(104, 30);
            this.cancelbutton.TabIndex = 26;
            this.cancelbutton.Text = "Cancel";
            this.cancelbutton.UseVisualStyleBackColor = false;
            this.cancelbutton.Click += new System.EventHandler(this.CancelButtonClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "Note";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 18);
            this.label3.TabIndex = 28;
            this.label3.Text = "Day";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(183, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "Month";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(437, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 18);
            this.label5.TabIndex = 30;
            this.label5.Text = "Year";
            // 
            // lbl_expenseTotal2
            // 
            this.lbl_expenseTotal2.AutoSize = true;
            this.lbl_expenseTotal2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_expenseTotal2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_expenseTotal2.Location = new System.Drawing.Point(617, 71);
            this.lbl_expenseTotal2.Name = "lbl_expenseTotal2";
            this.lbl_expenseTotal2.Size = new System.Drawing.Size(107, 22);
            this.lbl_expenseTotal2.TabIndex = 33;
            this.lbl_expenseTotal2.Text = "Total expense";
            this.lbl_expenseTotal2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_totalEarning2
            // 
            this.lbl_totalEarning2.AutoSize = true;
            this.lbl_totalEarning2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_totalEarning2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalEarning2.Location = new System.Drawing.Point(623, 38);
            this.lbl_totalEarning2.Name = "lbl_totalEarning2";
            this.lbl_totalEarning2.Size = new System.Drawing.Size(101, 22);
            this.lbl_totalEarning2.TabIndex = 34;
            this.lbl_totalEarning2.Text = "Total earning";
            this.lbl_totalEarning2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalEarningLabel
            // 
            this.totalEarningLabel.AutoSize = true;
            this.totalEarningLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalEarningLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.totalEarningLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalEarningLabel.Location = new System.Drawing.Point(732, 38);
            this.totalEarningLabel.Name = "totalEarningLabel";
            this.totalEarningLabel.Size = new System.Drawing.Size(42, 24);
            this.totalEarningLabel.TabIndex = 35;
            this.totalEarningLabel.Text = "0.00";
            this.totalEarningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalExpenseLabel
            // 
            this.totalExpenseLabel.AutoSize = true;
            this.totalExpenseLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalExpenseLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.totalExpenseLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalExpenseLabel.Location = new System.Drawing.Point(732, 71);
            this.totalExpenseLabel.Name = "totalExpenseLabel";
            this.totalExpenseLabel.Size = new System.Drawing.Size(42, 24);
            this.totalExpenseLabel.TabIndex = 36;
            this.totalExpenseLabel.Text = "0.00";
            this.totalExpenseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DailyInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(829, 536);
            this.Controls.Add(this.totalExpenseLabel);
            this.Controls.Add(this.totalEarningLabel);
            this.Controls.Add(this.lbl_totalEarning2);
            this.Controls.Add(this.lbl_expenseTotal2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.earningDataGridView);
            this.Controls.Add(this.yearComboBox);
            this.Controls.Add(this.monthComboBox);
            this.Controls.Add(this.dayComboBox);
            this.Controls.Add(this.applyCategoryButton);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.noteTextBox);
            this.Controls.Add(this.expenseDataGridView);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "DailyInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DailyInfoFormClosing);
            this.Load += new System.EventHandler(this.AddNewDataFormLoaded);
            ((System.ComponentModel.ISupportInitialize)(this.expenseDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.earningDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView expenseDataGridView;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button applyCategoryButton;
        private System.Windows.Forms.ComboBox dayComboBox;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView earningDataGridView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_expenseTotal2;
        private System.Windows.Forms.Label lbl_totalEarning2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label totalEarningLabel;
        private System.Windows.Forms.Label totalExpenseLabel;
    }
}