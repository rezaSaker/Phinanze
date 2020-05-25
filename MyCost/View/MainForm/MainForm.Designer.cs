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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.HomeDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearComboBox = new System.Windows.Forms.ComboBox();
            this.HomeButton = new System.Windows.Forms.Button();
            this.AddNewDataButton = new System.Windows.Forms.Button();
            this.MonthlyReportButton = new System.Windows.Forms.Button();
            this.StatisticsButton = new System.Windows.Forms.Button();
            this.ProfileButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.LogoButton = new System.Windows.Forms.Button();
            this.BarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.StatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HomeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PieChart)).BeginInit();
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
            this.HomeDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.HomeDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.HomeDataGridView.Location = new System.Drawing.Point(329, 47);
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
            this.HomeDataGridView.RowHeadersWidth = 51;
            this.HomeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HomeDataGridView.Size = new System.Drawing.Size(498, 222);
            this.HomeDataGridView.TabIndex = 6;
            this.HomeDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellDoubleClicked);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 59.89317F;
            this.Column1.HeaderText = "Year";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 101.5228F;
            this.Column5.HeaderText = "Month";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 115.8797F;
            this.Column2.HeaderText = "Earning";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 119.688F;
            this.Column3.HeaderText = "Expense";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 103.0162F;
            this.Column4.HeaderText = "Overview";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // YearComboBox
            // 
            this.YearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearComboBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearComboBox.ForeColor = System.Drawing.Color.Black;
            this.YearComboBox.FormattingEnabled = true;
            this.YearComboBox.Items.AddRange(new object[] {
            "All years"});
            this.YearComboBox.Location = new System.Drawing.Point(207, 47);
            this.YearComboBox.Name = "YearComboBox";
            this.YearComboBox.Size = new System.Drawing.Size(117, 29);
            this.YearComboBox.TabIndex = 33;
            this.YearComboBox.SelectedIndexChanged += new System.EventHandler(this.YearComboBoxIndexChanged);
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.White;
            this.HomeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HomeButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.HomeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.HomeButton.Location = new System.Drawing.Point(67, 8);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(117, 33);
            this.HomeButton.TabIndex = 1;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = false;
            // 
            // AddNewDataButton
            // 
            this.AddNewDataButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.AddNewDataButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddNewDataButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.AddNewDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNewDataButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewDataButton.ForeColor = System.Drawing.Color.White;
            this.AddNewDataButton.Location = new System.Drawing.Point(188, 8);
            this.AddNewDataButton.Name = "AddNewDataButton";
            this.AddNewDataButton.Size = new System.Drawing.Size(115, 33);
            this.AddNewDataButton.TabIndex = 42;
            this.AddNewDataButton.Text = "Add New";
            this.AddNewDataButton.UseVisualStyleBackColor = false;
            this.AddNewDataButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // MonthlyReportButton
            // 
            this.MonthlyReportButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.MonthlyReportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MonthlyReportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.MonthlyReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MonthlyReportButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthlyReportButton.ForeColor = System.Drawing.Color.White;
            this.MonthlyReportButton.Location = new System.Drawing.Point(307, 8);
            this.MonthlyReportButton.Name = "MonthlyReportButton";
            this.MonthlyReportButton.Size = new System.Drawing.Size(152, 33);
            this.MonthlyReportButton.TabIndex = 43;
            this.MonthlyReportButton.Text = "Monthly Report";
            this.MonthlyReportButton.UseVisualStyleBackColor = false;
            this.MonthlyReportButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // StatisticsButton
            // 
            this.StatisticsButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.StatisticsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StatisticsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.StatisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatisticsButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatisticsButton.ForeColor = System.Drawing.Color.White;
            this.StatisticsButton.Location = new System.Drawing.Point(463, 8);
            this.StatisticsButton.Name = "StatisticsButton";
            this.StatisticsButton.Size = new System.Drawing.Size(121, 33);
            this.StatisticsButton.TabIndex = 44;
            this.StatisticsButton.Text = "Statistics";
            this.StatisticsButton.UseVisualStyleBackColor = false;
            this.StatisticsButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // ProfileButton
            // 
            this.ProfileButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ProfileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.ProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfileButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileButton.ForeColor = System.Drawing.Color.White;
            this.ProfileButton.Location = new System.Drawing.Point(588, 8);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(118, 33);
            this.ProfileButton.TabIndex = 45;
            this.ProfileButton.Text = "Profile";
            this.ProfileButton.UseVisualStyleBackColor = false;
            this.ProfileButton.Click += new System.EventHandler(this.MenuButtonsClicked);
            // 
            // LogOutButton
            // 
            this.LogOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogOutButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LogOutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogOutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.LogOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOutButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.ForeColor = System.Drawing.Color.White;
            this.LogOutButton.Location = new System.Drawing.Point(710, 8);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(117, 33);
            this.LogOutButton.TabIndex = 46;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.MenuButtonsClicked);
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
            this.LogoButton.TabIndex = 48;
            this.LogoButton.UseVisualStyleBackColor = false;
            // 
            // BarChart
            // 
            this.BarChart.BorderlineColor = System.Drawing.Color.Black;
            this.BarChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.Name = "ChartArea1";
            this.BarChart.ChartAreas.Add(chartArea1);
            this.BarChart.Location = new System.Drawing.Point(12, 273);
            this.BarChart.Name = "BarChart";
            this.BarChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Name = "Earning";
            series2.ChartArea = "ChartArea1";
            series2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Name = "Expense";
            this.BarChart.Series.Add(series1);
            this.BarChart.Series.Add(series2);
            this.BarChart.Size = new System.Drawing.Size(815, 220);
            this.BarChart.TabIndex = 49;
            this.BarChart.Text = "Bar Chart";
            // 
            // PieChart
            // 
            this.PieChart.BorderlineColor = System.Drawing.Color.Black;
            this.PieChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.PieChart.ChartAreas.Add(chartArea2);
            legend1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.PieChart.Legends.Add(legend1);
            this.PieChart.Location = new System.Drawing.Point(12, 85);
            this.PieChart.Name = "PieChart";
            this.PieChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.PieChart.Series.Add(series3);
            this.PieChart.Size = new System.Drawing.Size(312, 182);
            this.PieChart.TabIndex = 50;
            this.PieChart.Text = "Pie Chart";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(8, 50);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(193, 21);
            this.StatusLabel.TabIndex = 51;
            this.StatusLabel.Text = "Showing information for";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(840, 491);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.PieChart);
            this.Controls.Add(this.BarChart);
            this.Controls.Add(this.LogoButton);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.ProfileButton);
            this.Controls.Add(this.StatisticsButton);
            this.Controls.Add(this.MonthlyReportButton);
            this.Controls.Add(this.AddNewDataButton);
            this.Controls.Add(this.YearComboBox);
            this.Controls.Add(this.HomeDataGridView);
            this.Controls.Add(this.HomeButton);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 525);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MyCost - Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThisFormClosing);
            this.Load += new System.EventHandler(this.ThisFormLoading);
            this.Shown += new System.EventHandler(this.ThisFormShown);
            ((System.ComponentModel.ISupportInitialize)(this.HomeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PieChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView HomeDataGridView;
        private System.Windows.Forms.ComboBox YearComboBox;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Button AddNewDataButton;
        private System.Windows.Forms.Button MonthlyReportButton;
        private System.Windows.Forms.Button StatisticsButton;
        private System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Button LogoButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart BarChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart PieChart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label StatusLabel;
    }
}