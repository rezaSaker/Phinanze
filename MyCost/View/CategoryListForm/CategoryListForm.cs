using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCost.Common;
using MyCost.Common.WebHandler;

namespace MyCost.View
{
    public partial class CategoryListForm : Form
    {
        private List<int> _rowIndexList;

        private string _categoryType;

        private DataGridView _dgv;

        public CategoryListForm(DataGridView dgv, List<int> rowIndexList)
        {
            InitializeComponent();

            _dgv = dgv;
            _rowIndexList = rowIndexList;
        }

        #region event_handler_methods

        private void ThisFormLoading(object sender, EventArgs e)
        {
            //_dgv points to a dataGridView on AddNewDataForm 
            if (_dgv.Name == "expenseDataGridView")
            {
                foreach (string category in StaticStorage.ExpenseCategories)
                {
                    dataGridView.Rows.Add(category);
                }
                _categoryType = "Expense";
            }
            else if (_dgv.Name == "earningDataGridView")
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

            if (IsLastEmptyRow(rowIndex))
            {
                return;
            }

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

            if (IsLastEmptyRow(rowIndex))
            {
                return;
            }

            string category = dataGridView.Rows[rowIndex].Cells[0].Value.ToString();

            foreach (int index in _rowIndexList)
            {
                //_dgv points to a dataGridView on AddNewDataForm
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
                    if (IsLastEmptyRow(row.Index))
                    {
                        break;
                    }

                    StaticStorage.ExpenseCategories.Add(row.Cells[0].Value.ToString());
                    categoryNames += row.Cells[0].Value.ToString();

                    //add a splitting character after each category except the last one
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
                    if (IsLastEmptyRow(row.Index))
                    {
                        break;
                    }

                    StaticStorage.EarningCategories.Add(row.Cells[0].Value.ToString());
                    categoryNames += row.Cells[0].Value.ToString();

                    //add a splitting character after each category except the last one
                    if (row.Index < dataGridView.Rows.Count - 2)
                    {
                        categoryNames += "|";
                    }
                }
            }

            string result = WebHandler.SaveCategory(categoryNames, _categoryType);

            if(result != "SUCCESS")
            {
                //if not succeeds, the error message is returned
                MessageBox.Show(result);
            }
        }     

        private bool IsLastEmptyRow(int rowIndex)
        {
            if (rowIndex == dataGridView.Rows.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
