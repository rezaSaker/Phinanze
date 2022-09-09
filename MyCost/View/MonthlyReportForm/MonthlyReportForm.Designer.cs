﻿namespace MyCost.View
{
    partial class MonthlyReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthlyReportForm));
            this.MonthComboBox = new System.Windows.Forms.ComboBox();
            this.MonthlyReportDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearComboBox = new System.Windows.Forms.ComboBox();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.ProfileButton = new System.Windows.Forms.Button();
            this.StatisticsButton = new System.Windows.Forms.Button();
            this.MonthlyReportButton = new System.Windows.Forms.Button();
            this.AddNewDataButton = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.Button();
            this.LogoButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TotalExpenseLabel = new System.Windows.Forms.Label();
            this.TotalEarningLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.ExpenseSearchTextBox = new System.Windows.Forms.TextBox();
            this.EarningSearchTextBox = new System.Windows.Forms.TextBox();
            this.NoteSearchTextBox = new System.Windows.Forms.TextBox();
            this.DateSearchTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MonthlyReportDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MonthComboBox
            // 
            this.MonthComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MonthComboBox.BackColor = System.Drawing.Color.White;
            this.MonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonthComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthComboBox.ForeColor = System.Drawing.Color.Black;
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
            "December",
            "All Months"});
            this.MonthComboBox.Location = new System.Drawing.Point(919, 58);
            this.MonthComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MonthComboBox.Name = "MonthComboBox";
            this.MonthComboBox.Size = new System.Drawing.Size(236, 33);
            this.MonthComboBox.TabIndex = 3;
            this.MonthComboBox.SelectedIndexChanged += new System.EventHandler(this.MonthComboBoxIndexChanged);
            // 
            // MonthlyReportDataGridView
            // 
            this.MonthlyReportDataGridView.AllowUserToAddRows = false;
            this.MonthlyReportDataGridView.AllowUserToResizeColumns = false;
            this.MonthlyReportDataGridView.AllowUserToResizeRows = false;
            this.MonthlyReportDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MonthlyReportDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MonthlyReportDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.MonthlyReportDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MonthlyReportDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MonthlyReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MonthlyReportDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MonthlyReportDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.MonthlyReportDataGridView.GridColor = System.Drawing.Color.Black;
            this.MonthlyReportDataGridView.Location = new System.Drawing.Point(20, 144);
            this.MonthlyReportDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MonthlyReportDataGridView.Name = "MonthlyReportDataGridView";
            this.MonthlyReportDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MonthlyReportDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.MonthlyReportDataGridView.RowHeadersVisible = false;
            this.MonthlyReportDataGridView.RowHeadersWidth = 30;
            this.MonthlyReportDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MonthlyReportDataGridView.Size = new System.Drawing.Size(1302, 396);
            this.MonthlyReportDataGridView.TabIndex = 5;
            this.MonthlyReportDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellDoubleClicked);
            this.MonthlyReportDataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DataGridViewUserDeletingRow);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 101.5228F;
            this.Column1.HeaderText = "Date";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 157.3161F;
            this.Column4.HeaderText = "Note";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 69.41014F;
            this.Column2.HeaderText = "Earning";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 71.7509F;
            this.Column3.HeaderText = "Expense";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // YearComboBox
            // 
            this.YearComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.YearComboBox.BackColor = System.Drawing.Color.White;
            this.YearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearComboBox.ForeColor = System.Drawing.Color.Black;
            this.YearComboBox.FormattingEnabled = true;
            this.YearComboBox.Location = new System.Drawing.Point(1163, 58);
            this.YearComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.YearComboBox.Name = "YearComboBox";
            this.YearComboBox.Size = new System.Drawing.Size(161, 33);
            this.YearComboBox.TabIndex = 9;
            this.YearComboBox.SelectedIndexChanged += new System.EventHandler(this.YearComboBoxIndexChanged);
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.Location = new System.Drawing.Point(16, 60);
            this.HeaderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(122, 25);
            this.HeaderLabel.TabIndex = 10;
            this.HeaderLabel.Text = "Header label";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.DeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.ForeColor = System.Drawing.Color.White;
            this.DeleteButton.Location = new System.Drawing.Point(1019, 550);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(157, 43);
            this.DeleteButton.TabIndex = 46;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButtonClicked);
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.LogOutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogOutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.LogOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.ForeColor = System.Drawing.Color.White;
            this.LogOutButton.Location = new System.Drawing.Point(1124, 10);
            this.LogOutButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(200, 40);
            this.LogOutButton.TabIndex = 52;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // ProfileButton
            // 
            this.ProfileButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.ProfileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.ProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileButton.ForeColor = System.Drawing.Color.White;
            this.ProfileButton.Location = new System.Drawing.Point(919, 10);
            this.ProfileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(200, 40);
            this.ProfileButton.TabIndex = 51;
            this.ProfileButton.Text = "Profile";
            this.ProfileButton.UseVisualStyleBackColor = false;
            this.ProfileButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // StatisticsButton
            // 
            this.StatisticsButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.StatisticsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StatisticsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.StatisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatisticsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatisticsButton.ForeColor = System.Drawing.Color.White;
            this.StatisticsButton.Location = new System.Drawing.Point(712, 10);
            this.StatisticsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StatisticsButton.Name = "StatisticsButton";
            this.StatisticsButton.Size = new System.Drawing.Size(200, 40);
            this.StatisticsButton.TabIndex = 50;
            this.StatisticsButton.Text = "Statistics";
            this.StatisticsButton.UseVisualStyleBackColor = false;
            this.StatisticsButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // MonthlyReportButton
            // 
            this.MonthlyReportButton.BackColor = System.Drawing.Color.White;
            this.MonthlyReportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MonthlyReportButton.Cursor = System.Windows.Forms.Cursors.No;
            this.MonthlyReportButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.MonthlyReportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.MonthlyReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MonthlyReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthlyReportButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.MonthlyReportButton.Location = new System.Drawing.Point(503, 10);
            this.MonthlyReportButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MonthlyReportButton.Name = "MonthlyReportButton";
            this.MonthlyReportButton.Size = new System.Drawing.Size(200, 40);
            this.MonthlyReportButton.TabIndex = 49;
            this.MonthlyReportButton.Text = "Monthly Report";
            this.MonthlyReportButton.UseVisualStyleBackColor = false;
            // 
            // AddNewDataButton
            // 
            this.AddNewDataButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.AddNewDataButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddNewDataButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.AddNewDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNewDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewDataButton.ForeColor = System.Drawing.Color.White;
            this.AddNewDataButton.Location = new System.Drawing.Point(297, 10);
            this.AddNewDataButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddNewDataButton.Name = "AddNewDataButton";
            this.AddNewDataButton.Size = new System.Drawing.Size(200, 40);
            this.AddNewDataButton.TabIndex = 48;
            this.AddNewDataButton.Text = "Add Daily Info";
            this.AddNewDataButton.UseVisualStyleBackColor = false;
            this.AddNewDataButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.HomeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HomeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.White;
            this.HomeButton.Location = new System.Drawing.Point(89, 10);
            this.HomeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(200, 40);
            this.HomeButton.TabIndex = 47;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // LogoButton
            // 
            this.LogoButton.BackColor = System.Drawing.Color.Transparent;
            this.LogoButton.BackgroundImage = global::MyCost.Properties.Resources.AppIcon;
            this.LogoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoButton.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.LogoButton.FlatAppearance.BorderSize = 0;
            this.LogoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoButton.ForeColor = System.Drawing.Color.White;
            this.LogoButton.Location = new System.Drawing.Point(13, 10);
            this.LogoButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LogoButton.Name = "LogoButton";
            this.LogoButton.Size = new System.Drawing.Size(65, 40);
            this.LogoButton.TabIndex = 53;
            this.LogoButton.UseVisualStyleBackColor = false;
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.EditButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.ForeColor = System.Drawing.Color.White;
            this.EditButton.Location = new System.Drawing.Point(1184, 549);
            this.EditButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(138, 43);
            this.EditButton.TabIndex = 54;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButtonClicked);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TotalExpenseLabel);
            this.panel1.Controls.Add(this.TotalEarningLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_status);
            this.panel1.Location = new System.Drawing.Point(21, 550);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 40);
            this.panel1.TabIndex = 56;
            // 
            // TotalExpenseLabel
            // 
            this.TotalExpenseLabel.AutoSize = true;
            this.TotalExpenseLabel.BackColor = System.Drawing.Color.White;
            this.TotalExpenseLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TotalExpenseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalExpenseLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.TotalExpenseLabel.Location = new System.Drawing.Point(489, 6);
            this.TotalExpenseLabel.Name = "TotalExpenseLabel";
            this.TotalExpenseLabel.Size = new System.Drawing.Size(50, 25);
            this.TotalExpenseLabel.TabIndex = 36;
            this.TotalExpenseLabel.Text = "0.00";
            this.TotalExpenseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TotalEarningLabel
            // 
            this.TotalEarningLabel.AutoSize = true;
            this.TotalEarningLabel.BackColor = System.Drawing.Color.White;
            this.TotalEarningLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TotalEarningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalEarningLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.TotalEarningLabel.Location = new System.Drawing.Point(147, 6);
            this.TotalEarningLabel.Name = "TotalEarningLabel";
            this.TotalEarningLabel.Size = new System.Drawing.Size(50, 25);
            this.TotalEarningLabel.TabIndex = 35;
            this.TotalEarningLabel.Text = "0.00";
            this.TotalEarningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "Total Earning";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.BackColor = System.Drawing.Color.White;
            this.lbl_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(341, 6);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(138, 25);
            this.lbl_status.TabIndex = 15;
            this.lbl_status.Text = "Total Expense";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExpenseSearchTextBox
            // 
            this.ExpenseSearchTextBox.BackColor = System.Drawing.Color.White;
            this.ExpenseSearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExpenseSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpenseSearchTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ExpenseSearchTextBox.Location = new System.Drawing.Point(989, 106);
            this.ExpenseSearchTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExpenseSearchTextBox.Name = "ExpenseSearchTextBox";
            this.ExpenseSearchTextBox.Size = new System.Drawing.Size(333, 30);
            this.ExpenseSearchTextBox.TabIndex = 57;
            this.ExpenseSearchTextBox.Text = "Search by Expense";
            this.ExpenseSearchTextBox.Click += new System.EventHandler(this.ExpenseSearchTextBox_Click);
            this.ExpenseSearchTextBox.TextChanged += new System.EventHandler(this.ExpenseSearchTextBox_TextChanged);
            // 
            // EarningSearchTextBox
            // 
            this.EarningSearchTextBox.BackColor = System.Drawing.Color.White;
            this.EarningSearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EarningSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EarningSearchTextBox.ForeColor = System.Drawing.Color.Gray;
            this.EarningSearchTextBox.Location = new System.Drawing.Point(654, 106);
            this.EarningSearchTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EarningSearchTextBox.Name = "EarningSearchTextBox";
            this.EarningSearchTextBox.Size = new System.Drawing.Size(327, 30);
            this.EarningSearchTextBox.TabIndex = 58;
            this.EarningSearchTextBox.Text = "Search by Earning";
            this.EarningSearchTextBox.Click += new System.EventHandler(this.EarningSearchTextBox_Click);
            this.EarningSearchTextBox.TextChanged += new System.EventHandler(this.EarningSearchTextBox_TextChanged);
            // 
            // NoteSearchTextBox
            // 
            this.NoteSearchTextBox.BackColor = System.Drawing.Color.White;
            this.NoteSearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NoteSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteSearchTextBox.ForeColor = System.Drawing.Color.Gray;
            this.NoteSearchTextBox.Location = new System.Drawing.Point(336, 106);
            this.NoteSearchTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NoteSearchTextBox.Name = "NoteSearchTextBox";
            this.NoteSearchTextBox.Size = new System.Drawing.Size(310, 30);
            this.NoteSearchTextBox.TabIndex = 59;
            this.NoteSearchTextBox.Text = "Search by Note";
            this.NoteSearchTextBox.Click += new System.EventHandler(this.NoteSearchTextBox_Click);
            this.NoteSearchTextBox.TextChanged += new System.EventHandler(this.NoteSearchTextBox_TextChanged);
            // 
            // DateSearchTextBox
            // 
            this.DateSearchTextBox.BackColor = System.Drawing.Color.White;
            this.DateSearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DateSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateSearchTextBox.ForeColor = System.Drawing.Color.Gray;
            this.DateSearchTextBox.Location = new System.Drawing.Point(21, 106);
            this.DateSearchTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DateSearchTextBox.Name = "DateSearchTextBox";
            this.DateSearchTextBox.Size = new System.Drawing.Size(307, 30);
            this.DateSearchTextBox.TabIndex = 60;
            this.DateSearchTextBox.Text = "Search by Date";
            this.DateSearchTextBox.Click += new System.EventHandler(this.DateSearchTextBox_Click);
            this.DateSearchTextBox.TextChanged += new System.EventHandler(this.DateSearchTextBox_TextChanged);
            // 
            // MonthlyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1340, 604);
            this.Controls.Add(this.DateSearchTextBox);
            this.Controls.Add(this.NoteSearchTextBox);
            this.Controls.Add(this.EarningSearchTextBox);
            this.Controls.Add(this.ExpenseSearchTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.LogoButton);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.ProfileButton);
            this.Controls.Add(this.StatisticsButton);
            this.Controls.Add(this.MonthlyReportButton);
            this.Controls.Add(this.AddNewDataButton);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.HeaderLabel);
            this.Controls.Add(this.YearComboBox);
            this.Controls.Add(this.MonthlyReportDataGridView);
            this.Controls.Add(this.MonthComboBox);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MonthlyReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MyCost - Monthly Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThisFormClosing);
            this.Load += new System.EventHandler(this.ThisFormLoading);
            this.Shown += new System.EventHandler(this.ThisFormShown);
            ((System.ComponentModel.ISupportInitialize)(this.MonthlyReportDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox MonthComboBox;
        private System.Windows.Forms.DataGridView MonthlyReportDataGridView;
        private System.Windows.Forms.ComboBox YearComboBox;
        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.Button StatisticsButton;
        private System.Windows.Forms.Button MonthlyReportButton;
        private System.Windows.Forms.Button AddNewDataButton;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Button LogoButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TotalExpenseLabel;
        private System.Windows.Forms.Label TotalEarningLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.TextBox ExpenseSearchTextBox;
        private System.Windows.Forms.TextBox EarningSearchTextBox;
        private System.Windows.Forms.TextBox NoteSearchTextBox;
        private System.Windows.Forms.TextBox DateSearchTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}