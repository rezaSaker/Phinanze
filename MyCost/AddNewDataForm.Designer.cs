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
            this.lbl_status = new System.Windows.Forms.Label();
            this.btn_applyCategoryToAll = new System.Windows.Forms.Button();
            this.cmb_day = new System.Windows.Forms.ComboBox();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_earning = new System.Windows.Forms.DataGridView();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_expenseTotal1 = new System.Windows.Forms.Label();
            this.lbl_earningTotal1 = new System.Windows.Forms.Label();
            this.lbl_expenseTotal2 = new System.Windows.Forms.Label();
            this.lbl_totalEarning2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dgv_expense.Location = new System.Drawing.Point(9, 110);
            this.dgv_expense.Name = "dgv_expense";
            this.dgv_expense.Size = new System.Drawing.Size(806, 165);
            this.dgv_expense.TabIndex = 3;
            this.dgv_expense.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_expenses_CellDoubleClick);
            // 
            // tb_note
            // 
            this.tb_note.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_note.Location = new System.Drawing.Point(58, 5);
            this.tb_note.Name = "tb_note";
            this.tb_note.Size = new System.Drawing.Size(757, 26);
            this.tb_note.TabIndex = 6;
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
            // btn_applyCategoryToAll
            // 
            this.btn_applyCategoryToAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_applyCategoryToAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_applyCategoryToAll.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_applyCategoryToAll.ForeColor = System.Drawing.Color.Black;
            this.btn_applyCategoryToAll.Location = new System.Drawing.Point(9, 493);
            this.btn_applyCategoryToAll.Name = "btn_applyCategoryToAll";
            this.btn_applyCategoryToAll.Size = new System.Drawing.Size(160, 31);
            this.btn_applyCategoryToAll.TabIndex = 16;
            this.btn_applyCategoryToAll.Text = "Apply category to all ";
            this.btn_applyCategoryToAll.UseVisualStyleBackColor = false;
            this.btn_applyCategoryToAll.Click += new System.EventHandler(this.btn_applyCategoryToAll_Click);
            // 
            // cmb_day
            // 
            this.cmb_day.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_day.FormattingEnabled = true;
            this.cmb_day.Location = new System.Drawing.Point(58, 40);
            this.cmb_day.Name = "cmb_day";
            this.cmb_day.Size = new System.Drawing.Size(97, 26);
            this.cmb_day.TabIndex = 18;
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
            "October",
            "November",
            "December"});
            this.cmb_month.Location = new System.Drawing.Point(241, 40);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(164, 26);
            this.cmb_month.TabIndex = 20;
            this.cmb_month.SelectedIndexChanged += new System.EventHandler(this.cmb_month_SelectedIndexChanged);
            // 
            // cmb_year
            // 
            this.cmb_year.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_year.FormattingEnabled = true;
            this.cmb_year.Location = new System.Drawing.Point(484, 38);
            this.cmb_year.Name = "cmb_year";
            this.cmb_year.Size = new System.Drawing.Size(109, 26);
            this.cmb_year.TabIndex = 22;
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
            // dgv_earning
            // 
            this.dgv_earning.BackgroundColor = System.Drawing.Color.White;
            this.dgv_earning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_earning.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4});
            this.dgv_earning.Location = new System.Drawing.Point(9, 322);
            this.dgv_earning.Name = "dgv_earning";
            this.dgv_earning.Size = new System.Drawing.Size(806, 165);
            this.dgv_earning.TabIndex = 23;
            this.dgv_earning.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_earning_CellDoubleClick);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(706, 493);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(111, 32);
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
            this.btn_cancel.Location = new System.Drawing.Point(594, 494);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(104, 30);
            this.btn_cancel.TabIndex = 26;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Note";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Day";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(183, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Month";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(437, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Year";
            // 
            // lbl_expenseTotal1
            // 
            this.lbl_expenseTotal1.AutoSize = true;
            this.lbl_expenseTotal1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_expenseTotal1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_expenseTotal1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_expenseTotal1.Location = new System.Drawing.Point(91, 83);
            this.lbl_expenseTotal1.Name = "lbl_expenseTotal1";
            this.lbl_expenseTotal1.Size = new System.Drawing.Size(95, 24);
            this.lbl_expenseTotal1.TabIndex = 31;
            this.lbl_expenseTotal1.Text = "Total: $0.00";
            this.lbl_expenseTotal1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_earningTotal1
            // 
            this.lbl_earningTotal1.AutoSize = true;
            this.lbl_earningTotal1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_earningTotal1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_earningTotal1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_earningTotal1.Location = new System.Drawing.Point(79, 295);
            this.lbl_earningTotal1.Name = "lbl_earningTotal1";
            this.lbl_earningTotal1.Size = new System.Drawing.Size(95, 24);
            this.lbl_earningTotal1.TabIndex = 32;
            this.lbl_earningTotal1.Text = "Total: $0.00";
            this.lbl_earningTotal1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_expenseTotal2
            // 
            this.lbl_expenseTotal2.AutoSize = true;
            this.lbl_expenseTotal2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_expenseTotal2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_expenseTotal2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_expenseTotal2.Location = new System.Drawing.Point(657, 73);
            this.lbl_expenseTotal2.Name = "lbl_expenseTotal2";
            this.lbl_expenseTotal2.Size = new System.Drawing.Size(158, 24);
            this.lbl_expenseTotal2.TabIndex = 33;
            this.lbl_expenseTotal2.Text = "Total expense: $0.00";
            this.lbl_expenseTotal2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_totalEarning2
            // 
            this.lbl_totalEarning2.AutoSize = true;
            this.lbl_totalEarning2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_totalEarning2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_totalEarning2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalEarning2.Location = new System.Drawing.Point(663, 40);
            this.lbl_totalEarning2.Name = "lbl_totalEarning2";
            this.lbl_totalEarning2.Size = new System.Drawing.Size(152, 24);
            this.lbl_totalEarning2.TabIndex = 34;
            this.lbl_totalEarning2.Text = "Total earning: $0.00";
            this.lbl_totalEarning2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // AddNewDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(829, 536);
            this.Controls.Add(this.lbl_totalEarning2);
            this.Controls.Add(this.lbl_expenseTotal2);
            this.Controls.Add(this.lbl_earningTotal1);
            this.Controls.Add(this.lbl_expenseTotal1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_earning);
            this.Controls.Add(this.cmb_year);
            this.Controls.Add(this.cmb_month);
            this.Controls.Add(this.cmb_day);
            this.Controls.Add(this.btn_applyCategoryToAll);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.tb_note);
            this.Controls.Add(this.dgv_expense);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Name = "AddNewDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button btn_applyCategoryToAll;
        private System.Windows.Forms.ComboBox cmb_day;
        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.ComboBox cmb_year;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_earning;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_expenseTotal1;
        private System.Windows.Forms.Label lbl_earningTotal1;
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
    }
}