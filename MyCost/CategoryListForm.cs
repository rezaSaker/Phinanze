using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCost
{
    public partial class CategoryListForm : Form
    {
        private int rowIndex;

        private List<int> expenseRowIndexList;
        private List<int> earningRowIndexList;

        private DataGridView dgv;
        private DataGridView expenseDGV;
        private DataGridView earningDGV;

        private bool multipleRowSelected;

        public CategoryListForm(DataGridView dgv, int rowIndex)
        {
            InitializeComponent();

            this.rowIndex = rowIndex;
            this.dgv = dgv;

            multipleRowSelected = false;
        }

        public CategoryListForm(
            DataGridView dgv1, 
            DataGridView dgv2, 
            List<int>rowIndexList1, 
            List<int>rowIndexList2)
        {
            InitializeComponent();

            expenseDGV = dgv1;
            earningDGV = dgv2;
            expenseRowIndexList = rowIndexList1;
            earningRowIndexList = rowIndexList2;

            multipleRowSelected = true;
        }

        private void CategoryListForm_Load(object sender, EventArgs e)
        {
            if(dgv.Name == "expenseDataGridView")
            {
                foreach(string category in StaticStorage.ExpenseCategories)
                {
                    dataGridView.Rows.Add(category);
                }
            }
            else
            {
                foreach(string category in StaticStorage.EarningCategories)
                {
                    dataGridView.Rows.Add(category);
                }
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == dataGridView.Rows.Count - 1)
            {
                //this is the last row and this row is empty
                return;
            }
            string category = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (!multipleRowSelected)
            {
                //dgv points to a DataGridView on AddNewDataForm form
                dgv.Rows[rowIndex].Cells[2].Value = category;
                this.Close();
            }
            else
            {
                foreach(int rowIndex in expenseRowIndexList)
                {
                    //expenseDGV points to a DataGridView on AddNewDataForm form
                    expenseDGV.Rows[rowIndex].Cells[2].Value = category;
                }

                foreach(int rowIndex in earningRowIndexList)
                {
                    //earningDGV points to a dataGridView on AddNewDataForm form
                    earningDGV.Rows[rowIndex].Cells[2].Value = category;
                }

                this.Close();
            }
        }
    }
}
