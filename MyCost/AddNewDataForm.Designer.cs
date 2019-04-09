namespace MyCost
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
            this.dgv_expense = new System.Windows.Forms.DataGridView();
            this.tb_note = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbl_status = new System.Windows.Forms.Label();
            this.btn_applyCategoryToAll = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmb_day = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_earning = new System.Windows.Forms.DataGridView();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_expense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_earning)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_expense
            // 
            this.dgv_expense.BackgroundColor = System.Drawing.Color.White;
            this.dgv_expense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_expense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Category,
            this.Column3});
            this.dgv_expense.Location = new System.Drawing.Point(25, 112);
            this.dgv_expense.Name = "dgv_expense";
            this.dgv_expense.Size = new System.Drawing.Size(753, 153);
            this.dgv_expense.TabIndex = 3;
            this.dgv_expense.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_expenses_CellDoubleClick);
            // 
            // tb_note
            // 
            this.tb_note.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_note.Location = new System.Drawing.Point(25, 18);
            this.tb_note.Name = "tb_note";
            this.tb_note.ReadOnly = true;
            this.tb_note.Size = new System.Drawing.Size(54, 26);
            this.tb_note.TabIndex = 5;
            this.tb_note.Text = "Note";
            this.tb_note.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(85, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(693, 26);
            this.textBox2.TabIndex = 6;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(21, 89);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(74, 22);
            this.lbl_status.TabIndex = 15;
            this.lbl_status.Text = "Expenses";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_applyCategoryToAll
            // 
            this.btn_applyCategoryToAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_applyCategoryToAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_applyCategoryToAll.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_applyCategoryToAll.ForeColor = System.Drawing.Color.Black;
            this.btn_applyCategoryToAll.Location = new System.Drawing.Point(25, 486);
            this.btn_applyCategoryToAll.Name = "btn_applyCategoryToAll";
            this.btn_applyCategoryToAll.Size = new System.Drawing.Size(211, 36);
            this.btn_applyCategoryToAll.TabIndex = 16;
            this.btn_applyCategoryToAll.Text = "Apply category to all ";
            this.btn_applyCategoryToAll.UseVisualStyleBackColor = false;
            this.btn_applyCategoryToAll.Click += new System.EventHandler(this.btn_applyCategoryToAll_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(25, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(54, 26);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "Day";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmb_day
            // 
            this.cmb_day.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_day.FormattingEnabled = true;
            this.cmb_day.Location = new System.Drawing.Point(85, 50);
            this.cmb_day.Name = "cmb_day";
            this.cmb_day.Size = new System.Drawing.Size(118, 26);
            this.cmb_day.TabIndex = 18;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(242, 50);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(54, 26);
            this.textBox3.TabIndex = 19;
            this.textBox3.Text = "Month";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmb_month
            // 
            this.cmb_month.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_month.FormattingEnabled = true;
            this.cmb_month.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "November",
            "December"});
            this.cmb_month.Location = new System.Drawing.Point(302, 50);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(219, 26);
            this.cmb_month.TabIndex = 20;
            this.cmb_month.SelectedIndexChanged += new System.EventHandler(this.cmb_month_SelectedIndexChanged);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(557, 50);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(54, 26);
            this.textBox4.TabIndex = 21;
            this.textBox4.Text = "Year";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmb_year
            // 
            this.cmb_year.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_year.FormattingEnabled = true;
            this.cmb_year.Location = new System.Drawing.Point(617, 50);
            this.cmb_year.Name = "cmb_year";
            this.cmb_year.Size = new System.Drawing.Size(161, 26);
            this.cmb_year.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 22);
            this.label1.TabIndex = 24;
            this.label1.Text = "Earning";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_earning
            // 
            this.dgv_earning.BackgroundColor = System.Drawing.Color.White;
            this.dgv_earning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_earning.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4});
            this.dgv_earning.Location = new System.Drawing.Point(25, 310);
            this.dgv_earning.Name = "dgv_earning";
            this.dgv_earning.Size = new System.Drawing.Size(753, 153);
            this.dgv_earning.TabIndex = 23;
            this.dgv_earning.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_earning_CellDoubleClick);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(667, 486);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(111, 36);
            this.btn_save.TabIndex = 25;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_cancel.Location = new System.Drawing.Point(557, 486);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(104, 36);
            this.btn_cancel.TabIndex = 26;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
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
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Comment";
            this.Column3.Name = "Column3";
            this.Column3.Width = 255;
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
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 255;
            // 
            // AddNewDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 558);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_earning);
            this.Controls.Add(this.cmb_year);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.cmb_month);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.cmb_day);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_applyCategoryToAll);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.tb_note);
            this.Controls.Add(this.dgv_expense);
            this.Name = "AddNewDataForm";
            this.Text = "Add New Data";
            this.Load += new System.EventHandler(this.AddNewDataForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_expense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_earning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_expense;
        private System.Windows.Forms.TextBox tb_note;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button btn_applyCategoryToAll;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmb_day;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox cmb_year;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_earning;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}