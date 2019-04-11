namespace MyCost
{
    partial class HomePageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePageForm));
            this.btn_addNewData = new System.Windows.Forms.Button();
            this.btn_statistics = new System.Windows.Forms.Button();
            this.btn_userProfile = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.lbl_welcomeText = new System.Windows.Forms.Label();
            this.lbl_expenseTotal1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lbl_version = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_addNewData
            // 
            this.btn_addNewData.BackColor = System.Drawing.Color.White;
            this.btn_addNewData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_addNewData.BackgroundImage")));
            this.btn_addNewData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_addNewData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addNewData.Location = new System.Drawing.Point(598, 12);
            this.btn_addNewData.Name = "btn_addNewData";
            this.btn_addNewData.Size = new System.Drawing.Size(60, 50);
            this.btn_addNewData.TabIndex = 1;
            this.btn_addNewData.UseVisualStyleBackColor = false;
            this.btn_addNewData.Click += new System.EventHandler(this.btn_addNewData_Click);
            // 
            // btn_statistics
            // 
            this.btn_statistics.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_statistics.BackgroundImage")));
            this.btn_statistics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_statistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_statistics.Location = new System.Drawing.Point(664, 12);
            this.btn_statistics.Name = "btn_statistics";
            this.btn_statistics.Size = new System.Drawing.Size(59, 50);
            this.btn_statistics.TabIndex = 2;
            this.btn_statistics.UseVisualStyleBackColor = true;
            // 
            // btn_userProfile
            // 
            this.btn_userProfile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_userProfile.BackgroundImage")));
            this.btn_userProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_userProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_userProfile.Location = new System.Drawing.Point(729, 12);
            this.btn_userProfile.Name = "btn_userProfile";
            this.btn_userProfile.Size = new System.Drawing.Size(59, 50);
            this.btn_userProfile.TabIndex = 3;
            this.btn_userProfile.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView.Location = new System.Drawing.Point(12, 79);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(775, 365);
            this.dataGridView.TabIndex = 6;
            // 
            // cmb_year
            // 
            this.cmb_year.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_year.FormattingEnabled = true;
            this.cmb_year.Items.AddRange(new object[] {
            "All years"});
            this.cmb_year.Location = new System.Drawing.Point(159, 50);
            this.cmb_year.Name = "cmb_year";
            this.cmb_year.Size = new System.Drawing.Size(123, 26);
            this.cmb_year.TabIndex = 5;
            // 
            // lbl_welcomeText
            // 
            this.lbl_welcomeText.AutoSize = true;
            this.lbl_welcomeText.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_welcomeText.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold);
            this.lbl_welcomeText.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_welcomeText.Location = new System.Drawing.Point(6, 9);
            this.lbl_welcomeText.Name = "lbl_welcomeText";
            this.lbl_welcomeText.Size = new System.Drawing.Size(129, 36);
            this.lbl_welcomeText.TabIndex = 30;
            this.lbl_welcomeText.Text = "MyCost";
            // 
            // lbl_expenseTotal1
            // 
            this.lbl_expenseTotal1.AutoSize = true;
            this.lbl_expenseTotal1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_expenseTotal1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_expenseTotal1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_expenseTotal1.Location = new System.Drawing.Point(12, 52);
            this.lbl_expenseTotal1.Name = "lbl_expenseTotal1";
            this.lbl_expenseTotal1.Size = new System.Drawing.Size(141, 24);
            this.lbl_expenseTotal1.TabIndex = 32;
            this.lbl_expenseTotal1.Text = "Monthly overview";
            this.lbl_expenseTotal1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.Column5.Width = 160;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Earning";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 160;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Spending";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 160;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Overview";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // cmb_month
            // 
            this.cmb_month.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_month.FormattingEnabled = true;
            this.cmb_month.Items.AddRange(new object[] {
            "All months",
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
            this.cmb_month.Location = new System.Drawing.Point(288, 50);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(123, 26);
            this.cmb_month.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(758, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 28);
            this.button1.TabIndex = 34;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(724, 454);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 27);
            this.button2.TabIndex = 35;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(690, 454);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 27);
            this.button3.TabIndex = 36;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(656, 454);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 27);
            this.button4.TabIndex = 37;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_version.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_version.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_version.Location = new System.Drawing.Point(12, 454);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(63, 24);
            this.lbl_version.TabIndex = 38;
            this.lbl_version.Text = "Version";
            this.lbl_version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(532, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 50);
            this.button5.TabIndex = 39;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(466, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(60, 50);
            this.button6.TabIndex = 40;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // HomePageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 487);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmb_month);
            this.Controls.Add(this.lbl_expenseTotal1);
            this.Controls.Add(this.lbl_welcomeText);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.cmb_year);
            this.Controls.Add(this.btn_userProfile);
            this.Controls.Add(this.btn_statistics);
            this.Controls.Add(this.btn_addNewData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HomePageForm";
            this.Text = "Home Page";
            this.Load += new System.EventHandler(this.HomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_addNewData;
        private System.Windows.Forms.Button btn_statistics;
        private System.Windows.Forms.Button btn_userProfile;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox cmb_year;
        private System.Windows.Forms.Label lbl_welcomeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label lbl_expenseTotal1;
        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}