using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCost.Common;
using MyCost.ServerHandling;

namespace MyCost.Forms
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

        #region event_handler_methods

        private void ThisFormLoading(object sender, EventArgs e)
        {
            //_dgv points to a dataGridView on AddNewDataForm whose reference is passed to this form via constructor
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

        private void DataGridViewCellDoubleClicked(object sender, DataGridViewCellEventArgs e)
        {
            OpenSelectedCategory();
        }

        private void SelectButtonClicked(object sender, EventArgs e)
        {
            OpenSelectedCategory();
        }

        private void DataGridViewCellEditEnded(object sender, DataGridViewCellEventArgs e)
        {
            UpdateCategories();
        }

        private void DataGridViewUserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateCategories();
        }

        private void DeleteButtonClicked(object sender, EventArgs e)
        {
            int rowIndex = dataGridView.CurrentCell.RowIndex;

            if (IsLastAndEmptyRow(rowIndex))
                return;

            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                dataGridView.Rows.Remove(row);
            }

            UpdateCategories();
        }

        private void CancelButtonClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region non_event_handler_methods

        private void OpenSelectedCategory()
        {
            int rowIndex = dataGridView.CurrentCell.RowIndex;

            if (IsLastAndEmptyRow(rowIndex))
                return;

            string category = dataGridView.Rows[rowIndex].Cells[0].Value.ToString();

            foreach (int index in _rowIndexes)
            {
                //_dgv points to a dataGridView on AddNewDataForm whose reference is passed to this form via constructor
                _dgv.Rows[index].Cells[2].Value = category;
            }

            this.Close();
        }

        private void UpdateCategories()
        {
            string categoryNames = "";

            if (_categoryType == "Expense")
            {
                StaticStorage.ExpenseCategories.Clear();

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (IsLastAndEmptyRow(row.Index))
                        break;

                    StaticStorage.ExpenseCategories.Add(row.Cells[0].Value.ToString());
                    categoryNames += row.Cells[0].Value.ToString();

                    //adds a splitting character after each category except the last one
                    if (row.Index < dataGridView.Rows.Count - 2)
                        categoryNames += "|";
                }
            }
            else
            {
                StaticStorage.EarningCategories.Clear();

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (IsLastAndEmptyRow(row.Index))
                        break;

                    StaticStorage.EarningCategories.Add(row.Cells[0].Value.ToString());
                    categoryNames += row.Cells[0].Value.ToString();

                    //adds a splitting character after each category except the last one
                    if (row.Index < dataGridView.Rows.Count - 2)
                        categoryNames += "|";
                }
            }

            string result = ServerHandler.SaveCategory(categoryNames, _categoryType);

            if(result != "SUCCESS")
            {
                //if not succeeds, the error message is returned
                MessageBox.Show(result);
            }
        }     

        private bool IsLastAndEmptyRow(int rowIndex)
        {
            if (rowIndex == dataGridView.Rows.Count - 1)
                return true;
            else
                return false;
        }

        #endregion
    }
}
