namespace MyCost
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.btn_home = new System.Windows.Forms.Button();
            this.btn_addNewData = new System.Windows.Forms.Button();
            this.btn_statistics = new System.Windows.Forms.Button();
            this.btn_userProfile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_headerText = new System.Windows.Forms.TextBox();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_home
            // 
            this.btn_home.BackColor = System.Drawing.Color.White;
            this.btn_home.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_home.BackgroundImage")));
            this.btn_home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_home.Location = new System.Drawing.Point(9, 12);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(102, 82);
            this.btn_home.TabIndex = 0;
            this.btn_home.UseVisualStyleBackColor = false;
            // 
            // btn_addNewData
            // 
            this.btn_addNewData.BackColor = System.Drawing.Color.White;
            this.btn_addNewData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_addNewData.BackgroundImage")));
            this.btn_addNewData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_addNewData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addNewData.Location = new System.Drawing.Point(9, 112);
            this.btn_addNewData.Name = "btn_addNewData";
            this.btn_addNewData.Size = new System.Drawing.Size(102, 82);
            this.btn_addNewData.TabIndex = 1;
            this.btn_addNewData.UseVisualStyleBackColor = false;
            this.btn_addNewData.Click += new System.EventHandler(this.btn_addNewData_Click);
            // 
            // btn_statistics
            // 
            this.btn_statistics.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_statistics.BackgroundImage")));
            this.btn_statistics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_statistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_statistics.Location = new System.Drawing.Point(9, 211);
            this.btn_statistics.Name = "btn_statistics";
            this.btn_statistics.Size = new System.Drawing.Size(102, 82);
            this.btn_statistics.TabIndex = 2;
            this.btn_statistics.UseVisualStyleBackColor = true;
            // 
            // btn_userProfile
            // 
            this.btn_userProfile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_userProfile.BackgroundImage")));
            this.btn_userProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_userProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_userProfile.Location = new System.Drawing.Point(9, 312);
            this.btn_userProfile.Name = "btn_userProfile";
            this.btn_userProfile.Size = new System.Drawing.Size(102, 82);
            this.btn_userProfile.TabIndex = 3;
            this.btn_userProfile.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Controls.Add(this.cmb_year);
            this.panel1.Controls.Add(this.tb_headerText);
            this.panel1.Location = new System.Drawing.Point(117, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 382);
            this.panel1.TabIndex = 4;
            // 
            // tb_headerText
            // 
            this.tb_headerText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_headerText.Location = new System.Drawing.Point(3, 3);
            this.tb_headerText.Name = "tb_headerText";
            this.tb_headerText.ReadOnly = true;
            this.tb_headerText.Size = new System.Drawing.Size(411, 26);
            this.tb_headerText.TabIndex = 0;
            this.tb_headerText.Text = "Showing monthly expense and earning data for all years";
            this.tb_headerText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmb_year
            // 
            this.cmb_year.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_year.FormattingEnabled = true;
            this.cmb_year.Items.AddRange(new object[] {
            "All years"});
            this.cmb_year.Location = new System.Drawing.Point(420, 3);
            this.cmb_year.Name = "cmb_year";
            this.cmb_year.Size = new System.Drawing.Size(246, 26);
            this.cmb_year.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView.Location = new System.Drawing.Point(3, 35);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(663, 342);
            this.dataGridView.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Date";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 160;
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
            this.Column4.Width = 140;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 411);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_userProfile);
            this.Controls.Add(this.btn_statistics);
            this.Controls.Add(this.btn_addNewData);
            this.Controls.Add(this.btn_home);
            this.Name = "HomePage";
            this.Text = "Home Page";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_home;
        private System.Windows.Forms.Button btn_addNewData;
        private System.Windows.Forms.Button btn_statistics;
        private System.Windows.Forms.Button btn_userProfile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_headerText;
        private System.Windows.Forms.ComboBox cmb_year;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}