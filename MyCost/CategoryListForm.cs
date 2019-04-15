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
        private List<int> _rowIndexes;

        private string _categoryType;

        private DataGridView _dgv;

        public CategoryListForm(DataGridView dgv, List<int> rowIndexes)
        {
            InitializeComponent();

            _dgv = dgv;
            _rowIndexes = rowIndexes;
        }

        private void CategoryListFormLoading(object sender, EventArgs e)
        {
            //_dgv points to a dataGridView on DailyInfoForm whose reference is passed to this form via constructor
            if (_dgv != null && _dgv.Name == "expenseDataGridView")
            {
                foreach (string category in StaticStorage.ExpenseCategories)
                {
                    dataGridView.Rows.Add(category);
                }

                _categoryType = "Expense";
            }
            else if (_dgv != null && _dgv.Name == "earningDataGridView")
            {
                foreach (string category in StaticStorage.EarningCategories)
                {
                    dataGridView.Rows.Add(category);
                }

                _categoryType = "Earning";
            }
        }

        private void dataGridViewCellDoubleClicked(object sender, DataGridViewCellEventArgs e)
        {
            OpenSelectedCategory();
        }

        private void SelectButtonClicked(object sender, EventArgs e)
        {
            OpenSelectedCategory();
        }

        private void OpenSelectedCategory()
        {
            int rowIndex = dataGridView.CurrentCell.RowIndex;

            if (rowIndex == dataGridView.Rows.Count - 1 || dataGridView.SelectedRows.Count > 1)
            {
                //either, selected row is the last row and an empty row
                //or, more than one row is selected in the category dataGridView
                return;
            }

            string category = dataGridView.Rows[rowIndex].Cells[0].Value.ToString();

            foreach (int index in _rowIndexes)
            {
                //_dgv points to a dataGridView on DailyInfoForm whose reference is passed to this form via constructor
                _dgv.Rows[index].Cells[2].Value = category;
            }

            this.Close();
        }

        private void DataGridViewCellEditEnded(object sender, DataGridViewCellEventArgs e)
        {
            UpdateCategories();
        }

        private void UpdateCategories()
        {
            string categoryNames = "";

            if (_categoryType == "Expense")
            {
                StaticStorage.ExpenseCategories.Clear();

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.Index == dataGridView.Rows.Count - 1)
                    {
                        //this is the last row and it's an empty row
                        break;
                    }

                    StaticStorage.ExpenseCategories.Add(row.Cells[0].Value.ToString());
                    categoryNames += row.Cells[0].Value.ToString();

                    //adds a splitting character after each category
                    if (row.Index < dataGridView.Rows.Count - 2)
                    {
                        categoryNames += "|";
                    }
                }
            }
            else
            {
                StaticStorage.EarningCategories.Clear();

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.Index == dataGridView.Rows.Count - 1)
                    {
                        //this is the last row and it's an empty row
                        break;
                    }

                    StaticStorage.EarningCategories.Add(row.Cells[0].Value.ToString());
                    categoryNames += row.Cells[0].Value.ToString();

                    //adds a splitting character after each category
                    if (row.Index < dataGridView.Rows.Count - 2)
                    {
                        categoryNames += "|";
                    }
                }
            }

            string result = ServerHandler.SaveCategory(categoryNames, _categoryType);
        }

        private void DeleteButtonClicked(object sender, EventArgs e)
        {
            int rowIndex = dataGridView.CurrentCell.RowIndex;

            if (rowIndex == dataGridView.Rows.Count - 1)
            {
                //this is the last row and it's an empty row
                return;
            }

            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                dataGridView.Rows.Remove(row);
            }

            UpdateCategories();
        }

        private void DataGridViewUserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.Index == dataGridView.Rows.Count - 1)
            {
                //this is the last row and it's an empty row
                return;
            }

            UpdateCategories();
        }

        private void CancelButtonClicked(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
