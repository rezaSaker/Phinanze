namespace MyCost.View
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
            ((System.ComponentModel.ISupportInitialize)(this.MonthlyReportDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MonthComboBox
            // 
            this.MonthComboBox.BackColor = System.Drawing.Color.White;
            this.MonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonthComboBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            "December"});
            this.MonthComboBox.Location = new System.Drawing.Point(588, 59);
            this.MonthComboBox.Name = "MonthComboBox";
            this.MonthComboBox.Size = new System.Drawing.Size(153, 29);
            this.MonthComboBox.TabIndex = 3;
            this.MonthComboBox.SelectedIndexChanged += new System.EventHandler(this.MonthComboBoxIndexChanged);
            // 
            // MonthlyReportDataGridView
            // 
            this.MonthlyReportDataGridView.AllowUserToAddRows = false;
            this.MonthlyReportDataGridView.AllowUserToResizeColumns = false;
            this.MonthlyReportDataGridView.AllowUserToResizeRows = false;
            this.MonthlyReportDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MonthlyReportDataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MonthlyReportDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.MonthlyReportDataGridView.GridColor = System.Drawing.Color.Black;
            this.MonthlyReportDataGridView.Location = new System.Drawing.Point(15, 96);
            this.MonthlyReportDataGridView.Name = "MonthlyReportDataGridView";
            this.MonthlyReportDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
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
            this.MonthlyReportDataGridView.Size = new System.Drawing.Size(812, 343);
            this.MonthlyReportDataGridView.TabIndex = 5;
            this.MonthlyReportDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellDoubleClicked);
            this.MonthlyReportDataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DataGridViewUserDeletingRow);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Date";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Note";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Earning";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Expense";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // YearComboBox
            // 
            this.YearComboBox.BackColor = System.Drawing.Color.White;
            this.YearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearComboBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearComboBox.ForeColor = System.Drawing.Color.Black;
            this.YearComboBox.FormattingEnabled = true;
            this.YearComboBox.Location = new System.Drawing.Point(747, 59);
            this.YearComboBox.Name = "YearComboBox";
            this.YearComboBox.Size = new System.Drawing.Size(80, 29);
            this.YearComboBox.TabIndex = 9;
            this.YearComboBox.SelectedIndexChanged += new System.EventHandler(this.YearComboBoxIndexChanged);
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.Location = new System.Drawing.Point(12, 64);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(110, 21);
            this.HeaderLabel.TabIndex = 10;
            this.HeaderLabel.Text = "Header label";
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.DeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.ForeColor = System.Drawing.Color.White;
            this.DeleteButton.Location = new System.Drawing.Point(588, 447);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(118, 33);
            this.DeleteButton.TabIndex = 46;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButtonClicked);
            // 
            // LogOutButton
            // 
            this.LogOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogOutButton.BackColor = System.Drawing.Color.LimeGreen;
            this.LogOutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogOutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.LogOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOutButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.ForeColor = System.Drawing.Color.White;
            this.LogOutButton.Location = new System.Drawing.Point(710, 8);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(117, 33);
            this.LogOutButton.TabIndex = 52;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // ProfileButton
            // 
            this.ProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfileButton.BackColor = System.Drawing.Color.LimeGreen;
            this.ProfileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.ProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfileButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileButton.ForeColor = System.Drawing.Color.White;
            this.ProfileButton.Location = new System.Drawing.Point(588, 8);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(118, 33);
            this.ProfileButton.TabIndex = 51;
            this.ProfileButton.Text = "Profile";
            this.ProfileButton.UseVisualStyleBackColor = false;
            this.ProfileButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // StatisticsButton
            // 
            this.StatisticsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatisticsButton.BackColor = System.Drawing.Color.LimeGreen;
            this.StatisticsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StatisticsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.StatisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatisticsButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatisticsButton.ForeColor = System.Drawing.Color.White;
            this.StatisticsButton.Location = new System.Drawing.Point(463, 8);
            this.StatisticsButton.Name = "StatisticsButton";
            this.StatisticsButton.Size = new System.Drawing.Size(121, 33);
            this.StatisticsButton.TabIndex = 50;
            this.StatisticsButton.Text = "Statistics";
            this.StatisticsButton.UseVisualStyleBackColor = false;
            this.StatisticsButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // MonthlyReportButton
            // 
            this.MonthlyReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MonthlyReportButton.BackColor = System.Drawing.Color.White;
            this.MonthlyReportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MonthlyReportButton.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.MonthlyReportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.MonthlyReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MonthlyReportButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthlyReportButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.MonthlyReportButton.Location = new System.Drawing.Point(307, 8);
            this.MonthlyReportButton.Name = "MonthlyReportButton";
            this.MonthlyReportButton.Size = new System.Drawing.Size(152, 33);
            this.MonthlyReportButton.TabIndex = 49;
            this.MonthlyReportButton.Text = "Monthly Report";
            this.MonthlyReportButton.UseVisualStyleBackColor = false;
            // 
            // AddNewDataButton
            // 
            this.AddNewDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddNewDataButton.BackColor = System.Drawing.Color.LimeGreen;
            this.AddNewDataButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddNewDataButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.AddNewDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNewDataButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewDataButton.ForeColor = System.Drawing.Color.White;
            this.AddNewDataButton.Location = new System.Drawing.Point(188, 8);
            this.AddNewDataButton.Name = "AddNewDataButton";
            this.AddNewDataButton.Size = new System.Drawing.Size(115, 33);
            this.AddNewDataButton.TabIndex = 48;
            this.AddNewDataButton.Text = "Add New";
            this.AddNewDataButton.UseVisualStyleBackColor = false;
            this.AddNewDataButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // HomeButton
            // 
            this.HomeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HomeButton.BackColor = System.Drawing.Color.LimeGreen;
            this.HomeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HomeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.White;
            this.HomeButton.Location = new System.Drawing.Point(67, 8);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(117, 33);
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
            this.LogoButton.Location = new System.Drawing.Point(12, 8);
            this.LogoButton.Name = "LogoButton";
            this.LogoButton.Size = new System.Drawing.Size(49, 33);
            this.LogoButton.TabIndex = 53;
            this.LogoButton.UseVisualStyleBackColor = false;
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.EditButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.ForeColor = System.Drawing.Color.White;
            this.EditButton.Location = new System.Drawing.Point(712, 447);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(115, 33);
            this.EditButton.TabIndex = 54;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButtonClicked);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TotalExpenseLabel);
            this.panel1.Controls.Add(this.TotalEarningLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_status);
            this.panel1.Location = new System.Drawing.Point(16, 447);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 33);
            this.panel1.TabIndex = 56;
            // 
            // TotalExpenseLabel
            // 
            this.TotalExpenseLabel.AutoSize = true;
            this.TotalExpenseLabel.BackColor = System.Drawing.Color.White;
            this.TotalExpenseLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TotalExpenseLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalExpenseLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.TotalExpenseLabel.Location = new System.Drawing.Point(367, 5);
            this.TotalExpenseLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalExpenseLabel.Name = "TotalExpenseLabel";
            this.TotalExpenseLabel.Size = new System.Drawing.Size(41, 21);
            this.TotalExpenseLabel.TabIndex = 36;
            this.TotalExpenseLabel.Text = "0.00";
            this.TotalExpenseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TotalEarningLabel
            // 
            this.TotalEarningLabel.AutoSize = true;
            this.TotalEarningLabel.BackColor = System.Drawing.Color.White;
            this.TotalEarningLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TotalEarningLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalEarningLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.TotalEarningLabel.Location = new System.Drawing.Point(110, 5);
            this.TotalEarningLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalEarningLabel.Name = "TotalEarningLabel";
            this.TotalEarningLabel.Size = new System.Drawing.Size(41, 21);
            this.TotalEarningLabel.TabIndex = 35;
            this.TotalEarningLabel.Text = "0.00";
            this.TotalEarningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 21);
            this.label1.TabIndex = 24;
            this.label1.Text = "Total Earning";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.BackColor = System.Drawing.Color.White;
            this.lbl_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_status.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(256, 5);
            this.lbl_status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(117, 21);
            this.lbl_status.TabIndex = 15;
            this.lbl_status.Text = "Total Expense";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MonthlyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(840, 491);
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
            this.MaximizeBox = false;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
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
    }
}