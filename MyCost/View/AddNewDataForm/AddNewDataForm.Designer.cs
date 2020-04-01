namespace MyCost.View
{
    partial class AddNewDataForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewDataForm));
            this.ExpenseDataGridView = new System.Windows.Forms.DataGridView();
            this.NoteTextBox = new System.Windows.Forms.TextBox();
            this.lbl_status = new System.Windows.Forms.Label();
            this.DayComboBox = new System.Windows.Forms.ComboBox();
            this.MonthComboBox = new System.Windows.Forms.ComboBox();
            this.YearComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EarningDataGridView = new System.Windows.Forms.DataGridView();
            this.SaveButton = new System.Windows.Forms.Button();
            this.TotalEarningLabel = new System.Windows.Forms.Label();
            this.TotalExpenseLabel = new System.Windows.Forms.Label();
            this.ApplyCategoryButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.StatisticsButton = new System.Windows.Forms.Button();
            this.MonthlyReportButton = new System.Windows.Forms.Button();
            this.AddNewDataButton = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ExpenseDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EarningDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ExpenseDataGridView
            // 
            this.ExpenseDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExpenseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ExpenseDataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExpenseDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ExpenseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExpenseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Category,
            this.Column3,
            this.type});
            this.ExpenseDataGridView.Location = new System.Drawing.Point(9, 111);
            this.ExpenseDataGridView.Name = "ExpenseDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExpenseDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ExpenseDataGridView.RowHeadersWidth = 30;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.ExpenseDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.ExpenseDataGridView.Size = new System.Drawing.Size(779, 150);
            this.ExpenseDataGridView.TabIndex = 3;
            this.ExpenseDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.ExpenseDGVEditBegan);
            this.ExpenseDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpenseDataGridViewCellClicked);
            this.ExpenseDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpenseDGVEditEnded);
            // 
            // NoteTextBox
            // 
            this.NoteTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoteTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.NoteTextBox.Location = new System.Drawing.Point(346, 55);
            this.NoteTextBox.Multiline = true;
            this.NoteTextBox.Name = "NoteTextBox";
            this.NoteTextBox.Size = new System.Drawing.Size(442, 50);
            this.NoteTextBox.TabIndex = 6;
            this.NoteTextBox.Text = "Note";
            this.NoteTextBox.Click += new System.EventHandler(this.NoteTextBoxClicked);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.BackColor = System.Drawing.Color.White;
            this.lbl_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_status.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(5, 86);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(74, 22);
            this.lbl_status.TabIndex = 15;
            this.lbl_status.Text = "Expenses";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DayComboBox
            // 
            this.DayComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayComboBox.FormattingEnabled = true;
            this.DayComboBox.Location = new System.Drawing.Point(9, 55);
            this.DayComboBox.Name = "DayComboBox";
            this.DayComboBox.Size = new System.Drawing.Size(61, 26);
            this.DayComboBox.TabIndex = 18;
            this.DayComboBox.SelectedIndexChanged += new System.EventHandler(this.DayComboBoxIndexChanged);
            // 
            // MonthComboBox
            // 
            this.MonthComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthComboBox.FormattingEnabled = true;
            this.MonthComboBox.Items.AddRange(new object[] {
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
            this.MonthComboBox.Location = new System.Drawing.Point(76, 55);
            this.MonthComboBox.Name = "MonthComboBox";
            this.MonthComboBox.Size = new System.Drawing.Size(149, 26);
            this.MonthComboBox.TabIndex = 20;
            this.MonthComboBox.SelectedIndexChanged += new System.EventHandler(this.MonthComboBoxIndexChanged);
            // 
            // YearComboBox
            // 
            this.YearComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearComboBox.FormattingEnabled = true;
            this.YearComboBox.Location = new System.Drawing.Point(231, 55);
            this.YearComboBox.Name = "YearComboBox";
            this.YearComboBox.Size = new System.Drawing.Size(109, 26);
            this.YearComboBox.TabIndex = 22;
            this.YearComboBox.SelectedIndexChanged += new System.EventHandler(this.YearComboBoxIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 22);
            this.label1.TabIndex = 24;
            this.label1.Text = "Earnings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EarningDataGridView
            // 
            this.EarningDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EarningDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EarningDataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EarningDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.EarningDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EarningDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.EarningDataGridView.Location = new System.Drawing.Point(9, 291);
            this.EarningDataGridView.Name = "EarningDataGridView";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DarkGoldenrod;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EarningDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.EarningDataGridView.RowHeadersWidth = 30;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.EarningDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.EarningDataGridView.Size = new System.Drawing.Size(779, 149);
            this.EarningDataGridView.TabIndex = 23;
            this.EarningDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.EarningDGVEditBegan);
            this.EarningDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EarningDataGridViewCellClicked);
            this.EarningDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EarningDGVEditEnded);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(677, 446);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(111, 32);
            this.SaveButton.TabIndex = 25;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButtonClicked);
            // 
            // TotalEarningLabel
            // 
            this.TotalEarningLabel.AutoSize = true;
            this.TotalEarningLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TotalEarningLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TotalEarningLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TotalEarningLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalEarningLabel.Location = new System.Drawing.Point(79, 264);
            this.TotalEarningLabel.Name = "TotalEarningLabel";
            this.TotalEarningLabel.Size = new System.Drawing.Size(42, 24);
            this.TotalEarningLabel.TabIndex = 35;
            this.TotalEarningLabel.Text = "0.00";
            this.TotalEarningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TotalExpenseLabel
            // 
            this.TotalExpenseLabel.AutoSize = true;
            this.TotalExpenseLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TotalExpenseLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TotalExpenseLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TotalExpenseLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalExpenseLabel.Location = new System.Drawing.Point(79, 84);
            this.TotalExpenseLabel.Name = "TotalExpenseLabel";
            this.TotalExpenseLabel.Size = new System.Drawing.Size(42, 24);
            this.TotalExpenseLabel.TabIndex = 36;
            this.TotalExpenseLabel.Text = "0.00";
            this.TotalExpenseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ApplyCategoryButton
            // 
            this.ApplyCategoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyCategoryButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ApplyCategoryButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ApplyCategoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyCategoryButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyCategoryButton.ForeColor = System.Drawing.Color.Black;
            this.ApplyCategoryButton.Location = new System.Drawing.Point(533, 448);
            this.ApplyCategoryButton.Name = "ApplyCategoryButton";
            this.ApplyCategoryButton.Size = new System.Drawing.Size(138, 28);
            this.ApplyCategoryButton.TabIndex = 46;
            this.ApplyCategoryButton.Text = "Apply category";
            this.ApplyCategoryButton.UseVisualStyleBackColor = false;
            this.ApplyCategoryButton.Click += new System.EventHandler(this.ApplyCategoryButtonClicked);
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
            this.LogOutButton.Location = new System.Drawing.Point(661, 10);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(127, 38);
            this.LogOutButton.TabIndex = 52;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.LogOutButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.LogOutButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.White;
            this.SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SettingsButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.SettingsButton.Location = new System.Drawing.Point(534, 10);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(121, 38);
            this.SettingsButton.TabIndex = 51;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.SettingsButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.SettingsButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // StatisticsButton
            // 
            this.StatisticsButton.BackColor = System.Drawing.Color.White;
            this.StatisticsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StatisticsButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.StatisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatisticsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatisticsButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.StatisticsButton.Location = new System.Drawing.Point(405, 10);
            this.StatisticsButton.Name = "StatisticsButton";
            this.StatisticsButton.Size = new System.Drawing.Size(123, 38);
            this.StatisticsButton.TabIndex = 50;
            this.StatisticsButton.Text = "Statistics";
            this.StatisticsButton.UseVisualStyleBackColor = false;
            this.StatisticsButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.StatisticsButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.StatisticsButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // MonthlyReportButton
            // 
            this.MonthlyReportButton.BackColor = System.Drawing.Color.White;
            this.MonthlyReportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MonthlyReportButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.MonthlyReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MonthlyReportButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthlyReportButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.MonthlyReportButton.Location = new System.Drawing.Point(256, 10);
            this.MonthlyReportButton.Name = "MonthlyReportButton";
            this.MonthlyReportButton.Size = new System.Drawing.Size(143, 38);
            this.MonthlyReportButton.TabIndex = 49;
            this.MonthlyReportButton.Text = "Monthly Report";
            this.MonthlyReportButton.UseVisualStyleBackColor = false;
            this.MonthlyReportButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.MonthlyReportButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.MonthlyReportButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // AddNewDataButton
            // 
            this.AddNewDataButton.BackColor = System.Drawing.Color.ForestGreen;
            this.AddNewDataButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddNewDataButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.AddNewDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNewDataButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewDataButton.ForeColor = System.Drawing.Color.White;
            this.AddNewDataButton.Location = new System.Drawing.Point(127, 10);
            this.AddNewDataButton.Name = "AddNewDataButton";
            this.AddNewDataButton.Size = new System.Drawing.Size(123, 38);
            this.AddNewDataButton.TabIndex = 48;
            this.AddNewDataButton.Text = "Add New";
            this.AddNewDataButton.UseVisualStyleBackColor = false;
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.White;
            this.HomeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HomeButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.HomeButton.Location = new System.Drawing.Point(9, 10);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(112, 38);
            this.HomeButton.TabIndex = 47;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            this.HomeButton.MouseLeave += new System.EventHandler(this.MenuButtonsMouseLeaving);
            this.HomeButton.MouseHover += new System.EventHandler(this.MenuButtonsMouseHovering);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Reason";
            this.Column1.Name = "Column1";
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
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Comment";
            this.Column3.Name = "Column3";
            // 
            // type
            // 
            this.type.HeaderText = "type";
            this.type.Name = "type";
            this.type.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Source";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
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
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "type";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // AddNewDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 487);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.StatisticsButton);
            this.Controls.Add(this.MonthlyReportButton);
            this.Controls.Add(this.AddNewDataButton);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.ApplyCategoryButton);
            this.Controls.Add(this.TotalExpenseLabel);
            this.Controls.Add(this.TotalEarningLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EarningDataGridView);
            this.Controls.Add(this.YearComboBox);
            this.Controls.Add(this.MonthComboBox);
            this.Controls.Add(this.DayComboBox);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.NoteTextBox);
            this.Controls.Add(this.ExpenseDataGridView);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 526);
            this.Name = "AddNewDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MyCost - Daily Expense and Earning";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThisFormClosing);
            this.Load += new System.EventHandler(this.ThisFormLoading);
            ((System.ComponentModel.ISupportInitialize)(this.ExpenseDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EarningDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView ExpenseDataGridView;
        private System.Windows.Forms.TextBox NoteTextBox;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.ComboBox DayComboBox;
        private System.Windows.Forms.ComboBox MonthComboBox;
        private System.Windows.Forms.ComboBox YearComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView EarningDataGridView;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label TotalEarningLabel;
        private System.Windows.Forms.Label TotalExpenseLabel;
        private System.Windows.Forms.Button ApplyCategoryButton;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button StatisticsButton;
        private System.Windows.Forms.Button MonthlyReportButton;
        private System.Windows.Forms.Button AddNewDataButton;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}