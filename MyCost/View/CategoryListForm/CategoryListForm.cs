using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCost.Common;

namespace MyCost.View
{
    public partial class CategoryListForm : Form
    {
        private List<int> _rowIndexList;

        private string _categoryType;
        private string _previousCellValue;

        private DataGridView _dgv;

        public CategoryListForm(DataGridView dgv, List<int> rowIndexList)
        {
            InitializeComponent();

            _dgv = dgv;
            _rowIndexList = rowIndexList;
        }

        #region UI EventHandler Methods

        private void ThisFormLoading(object sender, EventArgs e)
        {
            //_dgv points to a dataGridView on AddNewDataForm 
            if (_dgv.Name == "ExpenseDataGridView")
            {
                foreach (string category in GlobalSpace.ExpenseCategories)
                {
                    CategoryDataGridView.Rows.Add(category);
                }
                _categoryType = "Expense";
            }
            else if (_dgv.Name == "EarningDataGridView")
            {
                foreach (string category in GlobalSpace.EarningCategories)
                {
                    CategoryDataGridView.Rows.Add(category);
                }
                _categoryType = "Earning";
            }

            CategoryDataGridView.Rows[0].Selected = false;
        }

        private void DataGridViewCellDoubleClicked(object sender, DataGridViewCellEventArgs e)
        {
            OpenSelectedCategory();
        }

        private void SelectButtonClicked(object sender, EventArgs e)
        {
            OpenSelectedCategory();
        }

        private void DataGridViewCellEditBegan(object sender, DataGridViewCellCancelEventArgs e)
        {
            //If the user is attempting to edit a row with valid category value,
            //we would keep the current value of the cell before user makes any change
            //so that we can get back the previous value if user wish not to change it
            if (!IsLastEmptyRow(e.RowIndex))
            {
                _previousCellValue = CategoryDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            else
            {
                _previousCellValue = null;
            }
        }

        private void DataGridViewCellEditEnded(object sender, DataGridViewCellEventArgs e)
        {
            var cellValue = CategoryDataGridView.Rows[e.RowIndex].Cells[0].Value;

            if(_previousCellValue != null && cellValue.ToString() == _previousCellValue)
            {
                //if the user didin't actually change the previous value
                return;
            }
            else if(_previousCellValue != null && 
                cellValue.ToString().ToLower().Trim() == _previousCellValue.ToLower().Trim())
            {
                //if the user just changed the character case of the category name but 
                //didn't change the actual name of the category or added some unneccesary space
                //after the category name, then we have to just trim the unnecessary spaces and then save it
                CategoryDataGridView.Rows[e.RowIndex].Cells[0].Value = cellValue.ToString().ToLower().Trim();
                UpdateCategories();

                return;
            }

            //we have to check if another category with the same name already exists
            //we will not allow user to add two categories with identical names
            foreach (string categoryName in _categoryType == "Expense" ?
                GlobalSpace.ExpenseCategories : GlobalSpace.EarningCategories)
            {
                if (categoryName.ToLower().Trim() == cellValue.ToString().ToLower().Trim())
                {
                    string message = "A category called " + categoryName + " already exists in the category list.";
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if(_previousCellValue == null)
                    {
                        //if the user was attempting to add a new category
                        //remove the new row from the DGV
                        CategoryDataGridView.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        //if the user was attempting to edit an existing row,
                        //set the cell value to previous value
                        CategoryDataGridView.Rows[e.RowIndex].Cells[0].Value = _previousCellValue;
                    }

                    return;
                }
            }

            if (cellValue != null && cellValue.ToString().Length >= 1)
            {
                if (_previousCellValue == null)
                {
                    //if the user is adding a new category
                    UpdateCategories();
                }
                else
                {
                    //if the user is editing an exisiting row and we need to give an warning before editing
                    //the category in our system
                    string message = "Please note that '" + _previousCellValue +
                    "' category might be associated with some existing daily information and editing this category " +
                    "will not automatically update this category in the existing daily information. Moreover, all daily " +
                    "information that use this category will appear under the 'Other' category on the Statistics page. " +
                    "Do you still want to edit this category? ";

                    DialogResult userResponse = MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (userResponse == DialogResult.No)
                    {
                        CategoryDataGridView.Rows[e.RowIndex].Cells[0].Value = _previousCellValue;
                    }
                    else
                    {
                        UpdateCategories();
                    }
                }
            }
        }

        private void DataGridViewUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if(!IsLastEmptyRow(e.Row.Index))
            {
                string message = "Please note that '" + CategoryDataGridView.Rows[e.Row.Index].Cells[0].Value.ToString() +
                   "' category might be associated with some existing daily information and deleting this category " +
                   "will not automatically remove this category from the existing daily information. Moreover, all daily " +
                   "information that use this category will appear under the 'Other' category on the Statistics page. " +
                   "Do you still want to delete this category? ";

                DialogResult userResponse = MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (userResponse == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void DataGridViewUserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if(!IsLastEmptyRow(e.Row.Index))
            {
                UpdateCategories();
            }
        }

        private void DeleteButtonClicked(object sender, EventArgs e)
        {
            int rowIndex = CategoryDataGridView.CurrentCell.RowIndex;

            if (!IsLastEmptyRow(rowIndex))
            {
                string message = "Please note that the selected category " +
                   " might be associated with some existing daily information and deleting this category " +
                   "will not automatically remove this category from the existing daily information. Moreover, all daily " +
                   "information that use this category will appear under the 'Other' category on the Statistics page. " +
                   "Do you still want to delete this category? ";

                DialogResult userResponse = MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (userResponse == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in CategoryDataGridView.SelectedRows)
                    {
                        CategoryDataGridView.Rows.Remove(row);
                    }

                    UpdateCategories();
                }
            }
        }

        private void CancelButtonClicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region General Private Methods

        private void OpenSelectedCategory()
        {
            int rowIndex = CategoryDataGridView.CurrentCell.RowIndex;

            if (IsLastEmptyRow(rowIndex))
            {
                return;
            }

            string category = CategoryDataGridView.Rows[rowIndex].Cells[0].Value.ToString();

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
            string category;

            if (_categoryType == "Expense")
            {
                GlobalSpace.ExpenseCategories.Clear();

                foreach (DataGridViewRow row in CategoryDataGridView.Rows)
                {
                    if (!IsLastEmptyRow(row.Index))
                    {
                        category = FilterString(row.Cells[0].Value.ToString());
                        GlobalSpace.ExpenseCategories.Add(category);
                        categoryNames += category;

                        //add a splitting character after each category except the last one
                        if (row.Index < CategoryDataGridView.Rows.Count - 2)
                        {
                            categoryNames += "|";
                        }
                    }
                }
            }
            else
            {
                GlobalSpace.EarningCategories.Clear();

                foreach (DataGridViewRow row in CategoryDataGridView.Rows)
                {
                    if (!IsLastEmptyRow(row.Index))
                    {
                        category = FilterString(row.Cells[0].Value.ToString());
                        GlobalSpace.EarningCategories.Add(category);
                        categoryNames += category;

                        //add a splitting character after each category except the last one
                        if (row.Index < CategoryDataGridView.Rows.Count - 2)
                        {
                            categoryNames += "|";
                        }
                    }                  
                }
            }

            string result = WebHandler.SaveCategory(categoryNames, _categoryType);

            if(result != "SUCCESS")
            {
                //if not succeeds, the error message is returned
                MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }     

        private bool IsLastEmptyRow(int rowIndex)
        {
            if (rowIndex == CategoryDataGridView.Rows.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string FilterString(string str)
        {
            //we use '|' character to split categories when retrieving 
            //from database. So, if any string contains that character, that
            //might lead to an unexpected error. So this method will replace
            //all '|' characters with '/' character in a string
            string filteredString = str.Replace('|', '/');

            return filteredString;
        }
        #endregion
    }
}
