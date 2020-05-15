using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using MyCost.Common;

namespace MyCost.View
{
    public partial class AddNewDataForm : Form
    {
        private int _selectedDay;
        private int _selectedMonth;
        private int _selectedYear;
        private int _dayComboBoxPrevSelectedIndex;
        private int _monthComboBoxPrevSelectedIndex;
        private int _yearComboBoxPrevSelectedIndex;

        private bool _quitAppOnFormClosing;
        private bool _hasUnsavedChanges;
        private bool _isRedundantTriggerOfEventHandler;
        private bool _isUnsavedChangesWarningAlreadyShown;

        public AddNewDataForm()
        {
            InitializeComponent();          

            _selectedDay = DateTime.Now.Day;
            _selectedMonth = DateTime.Now.Month;
            _selectedYear = DateTime.Now.Year;
        }

        public AddNewDataForm(int day, int month, int year)
        {
            InitializeComponent();

            _selectedDay = day;
            _selectedMonth = month;
            _selectedYear = year;
        }

        #region UI Eventhandler Methods

        private void ThisFormLoading(object sender, EventArgs e)
        {
            _quitAppOnFormClosing = true;
            _hasUnsavedChanges = false;
            _isUnsavedChangesWarningAlreadyShown = false;
            _isRedundantTriggerOfEventHandler = false;

            for (int i = 2018; i <= DateTime.Now.Year + 1; i++)
            {
                YearComboBox.Items.Add(i.ToString());
            }

            MonthComboBox.SelectedIndex = _selectedMonth - 1;
            YearComboBox.SelectedIndex = YearComboBox.Items.IndexOf(_selectedYear.ToString());

            //Add an event handler method to each editable control on the form
            //so that we can detect if there's any unsaved changes when closing the form
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).TextChanged += ControlChanged;
                }
                else if (control is DataGridView)
                {
                    ((DataGridView)control).UserAddedRow += ControlChanged;
                    ((DataGridView)control).UserDeletedRow += ControlChanged;
                    ((DataGridView)control).CellEndEdit += ControlChanged;
                    ((DataGridView)control).CellBeginEdit += ControlChanged;
                }
            }
        }

        private void DayComboBoxIndexChanged(object sender, EventArgs e)
        {
            if (!_isRedundantTriggerOfEventHandler)
            {
                if (_hasUnsavedChanges)
                {
                    DialogResult userResponse = ShowUnsavedChangesWarning();

                    if(userResponse == DialogResult.No)
                    {
                        //Since we are changing selected index in this block, 
                        //this will trigger this method again which is unexpected.
                        //Setting _isRedundantTriggerOfEventHandler = true will prevent that
                        _isRedundantTriggerOfEventHandler = true;

                        DayComboBox.SelectedIndex = _dayComboBoxPrevSelectedIndex;
                        return;
                    }
                }

                //Keep record of the selected index so that we can 
                //switch back to this index if needed during next selection change
                _dayComboBoxPrevSelectedIndex = DayComboBox.SelectedIndex;

                _selectedDay = DayComboBox.SelectedIndex + 1;
                PlotDailyInfo();

                _hasUnsavedChanges = false;
            }
            else
            {
                _isRedundantTriggerOfEventHandler = false;
            }
        }

        private void MonthComboBoxIndexChanged(object sender, EventArgs e)
        {
            if (!_isRedundantTriggerOfEventHandler)
            {
                if (_hasUnsavedChanges)
                {
                    DialogResult userResponse = ShowUnsavedChangesWarning();

                    if (userResponse == DialogResult.No)
                    {
                        //Since we are changing selected index in this block, 
                        //this will trigger this method again which is unexpected.
                        //Setting _isRedundantTriggerOfEventHandler = true will prevent
                        _isRedundantTriggerOfEventHandler = true;

                        MonthComboBox.SelectedIndex = _monthComboBoxPrevSelectedIndex;
                        return;
                    }
                }

                //Keep the record of the selected index so that we can 
                //switch back to this index if needed during next selection change
                _monthComboBoxPrevSelectedIndex = MonthComboBox.SelectedIndex;

                _selectedMonth = MonthComboBox.SelectedIndex + 1;
                AddItemsToDayComboBox();

                _hasUnsavedChanges = false;
            }
            else
            {
                _isRedundantTriggerOfEventHandler = false;
            }
        }

        private void YearComboBoxIndexChanged(object sender, EventArgs e)
        {
            if (!_isRedundantTriggerOfEventHandler)
            {
                if (_hasUnsavedChanges)
                {
                    DialogResult userResponse = ShowUnsavedChangesWarning();

                    if (userResponse == DialogResult.No)
                    {
                        //Since we are changing selected index in this block, 
                        //this will trigger this method again which is unexpected.
                        //Setting _isRedundantTriggerOfEventHandler = true will prevent
                        _isRedundantTriggerOfEventHandler = true;

                        YearComboBox.SelectedIndex = _yearComboBoxPrevSelectedIndex;
                        return;
                    }
                }

                //Keep record of the selected index so that we can 
                //switch back to this index if needed during next selection change
                _yearComboBoxPrevSelectedIndex = YearComboBox.SelectedIndex;

                _selectedYear = Convert.ToInt32(YearComboBox.SelectedItem.ToString());
                AddItemsToDayComboBox();

                _hasUnsavedChanges = false;
            }
            else
            {
                _isRedundantTriggerOfEventHandler = false;
            }
        }

        private void NoteTextBoxClicked(object sender, EventArgs e)
        {
            //if the textBox only contains the placeholder 
            //and user hasn't yet entered any text
            if (NoteTextBox.ForeColor == Color.Gray)
            {
                NoteTextBox.Text = "";
                NoteTextBox.ForeColor = Color.Maroon;
            }
        }

        private void ExpenseDataGridViewCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if(IsLastEmptyRow(ExpenseDataGridView, e.RowIndex) || e.RowIndex == -1)
            {
                return;
            }

            //if it's category column
            if (e.ColumnIndex == 2)
            {
                List<int> rowIndexList = new List<int>();
                rowIndexList.Add(e.RowIndex);
                CategoryListForm form = new CategoryListForm(ExpenseDataGridView, rowIndexList);
                form.Location = new Point(this.Location.X + 300, this.Location.Y);
                form.Show();
            }
        }

        private void ExpenseDGVEditBegan(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if it's amount column
            if (e.ColumnIndex == 1)
            {
                ResetAmountColumnColorToDeafault(ExpenseDataGridView, e.RowIndex);
            }
        }

        private void ExpenseDGVEditEnded(object sender, DataGridViewCellEventArgs e)
        {
            //if an expense amount is entered
            if (e.ColumnIndex == 1)
            {
                UpdateTotalExpenseLabel();
            }
        }

        private void EarningDataGridViewCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (IsLastEmptyRow(EarningDataGridView, e.RowIndex) || e.RowIndex == -1)
            {
                return;
            }

            //if it's category column
            if (e.ColumnIndex == 2)
            {
                List<int> rowIndexList = new List<int>();
                rowIndexList.Add(e.RowIndex);
                CategoryListForm form = new CategoryListForm(EarningDataGridView, rowIndexList);
                form.Location = new Point(this.Location.X + 300, this.Location.Y);
                form.Show();
            }
        }

        private void EarningDGVEditBegan(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if it's amount column
            if (e.ColumnIndex == 1)
            {
                ResetAmountColumnColorToDeafault(EarningDataGridView, e.RowIndex);
            }
        }

        private void EarningDGVEditEnded(object sender, DataGridViewCellEventArgs e)
        {
            //if an earning amount is entered
            if (e.ColumnIndex == 1)
            {
                UpdateTotalEarningLabel();
            }
        }

        private void SaveButtonClicked(object sender, EventArgs e)
        {
            string result = SaveDailyInfo();

            if(result == "Server connection error")
            {
                string message = "Could not save the information to database. ";
                message += "Please check your internet connection and try again.";
                MessageBox.Show(message);
            }
        }
      
        private void ApplyCategoryButtonClicked(object sender, EventArgs e)
        {
            //clicking on this button applies a particular category to all selected rows
            if (ExpenseDataGridView.SelectedRows.Count > 0)
            {
                OpenCategoryListForm(ExpenseDataGridView);
            }
            else if (EarningDataGridView.SelectedRows.Count > 0)
            {
                OpenCategoryListForm(EarningDataGridView);
            }
        }

        private void MenuButtonsMouseHovering(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.FlatAppearance.BorderColor = Color.Orange;
        }

        private void MenuButtonsMouseLeaving(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.FlatAppearance.BorderColor = Color.LimeGreen;
        }

        private void MenuButtonsClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Name == "HomeButton")
            {
                OpenNewForm(new MainForm());
            }
            else if (button.Name == "MonthlyReportButton")
            {
                OpenNewForm(new MonthlyReportForm());
            }
            else if (button.Name == "StatisticsButton")
            {
                OpenNewForm(new StatisticsForm());
            }
            else if (button.Name == "ProfileButton")
            {
                OpenNewForm(new ProfileForm());
            }
            else if (button.Name == "LogOutButton")
            {
                GlobalSpace.LogOutUser();
                _quitAppOnFormClosing = false;
                this.Close();
            }
        }

        private void ControlChanged(object sender, EventArgs e)
        {
            //this method is triggered when any editable control on this form is edited
            SaveButton.Enabled = true;
            SaveButton.BackColor = Color.RoyalBlue;
            _hasUnsavedChanges = true;
        }    

        private void ThisFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseOpenedCategoryForm();

            if (_hasUnsavedChanges && !_isUnsavedChangesWarningAlreadyShown)
            {
                DialogResult userResponse = ShowUnsavedChangesWarning();

                if (userResponse == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            if (_quitAppOnFormClosing)
            {
                Application.Exit();
            }
        }

        private void DeleteButtonClicked(object sender, EventArgs e)
        {
            if(ExpenseDataGridView.SelectedRows.Count < 1 && EarningDataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("No row selected. Please select the row that you want to delete.");
            }
            else
            {
                string warningMsg = "Selected rows will be permanently deleted. " +
                    "Are you sure you want to delete the selected rows?";
                DialogResult userResponse = MessageBox.Show(warningMsg, "Warning", MessageBoxButtons.YesNo);

                if(userResponse == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in ExpenseDataGridView.SelectedRows)
                    {
                        ExpenseDataGridView.Rows.Remove(row);
                    }

                    foreach (DataGridViewRow row in EarningDataGridView.SelectedRows)
                    {
                        EarningDataGridView.Rows.Remove(row);
                    }

                    UpdateTotalEarningLabel();
                    UpdateTotalExpenseLabel();

                    string result = SaveDailyInfo();

                    if (result == "Server connection error")
                    {
                        string message = "Could not delete the information from database. ";
                        message += "Please check your internet connection and try again.";
                        MessageBox.Show(message);

                        //following method will refresh the page and reload data that could not be deleted
                        PlotDailyInfo();
                    }
                }
            }

        }
        #endregion

        #region General Private Methods

        private void AddItemsToDayComboBox()
        {
            DayComboBox.Items.Clear();

            int numberOfdays;

            //set the number of days according to month
            if (_selectedMonth == 2 && DateTime.IsLeapYear(_selectedYear))
            {
                numberOfdays = 29;
            }
            else if (_selectedMonth == 2 && !DateTime.IsLeapYear(_selectedYear))
            {
                numberOfdays = 28;
            }
            else if (_selectedMonth <= 7 && _selectedMonth % 2 == 1)
            {
                numberOfdays = 31;
            }
            else if (_selectedMonth <= 7 && _selectedMonth % 2 == 0)
            {
                numberOfdays = 30;
            }
            else if (_selectedMonth > 7 && _selectedMonth % 2 == 1)
            {
                numberOfdays = 30;
            }
            else
            {
                numberOfdays = 31;
            }

            //set the days as items to dayComboBox
            for (int day = 1; day <= numberOfdays; day++)
            {
                DayComboBox.Items.Add(day.ToString());
            }

            try
            {
                DayComboBox.SelectedIndex = _selectedDay - 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                //this exception occurs when the selected day is greater 
                //than the number of days in the selected month
                DayComboBox.SelectedIndex = 0;
                _selectedDay = 1;
            }
        }

        private void PlotDailyInfo()
        {
            //clear previous info
            NoteTextBox.Text = "Note";
            NoteTextBox.ForeColor = Color.Gray;
            TotalExpenseLabel.Text = "0.00";
            TotalEarningLabel.Text = "0.00";
            ExpenseDataGridView.Rows.Clear();
            EarningDataGridView.Rows.Clear();

            //plot info for new selected date
            DailyInfo daily = GlobalSpace.DailyInfoList.Find(
                                    d => d.Day == _selectedDay 
                                    && d.Month == _selectedMonth 
                                    && d.Year == _selectedYear);

            if (daily != null)
            {
                NoteTextBox.Text = daily.Note;
                NoteTextBox.ForeColor = Color.Black;

                //last column in the grid is an invisible coulmn that keep record of whether 
                //the info is is previously saved (old) info or new info so that we don't 
                //save the same info twice
                foreach (ExpenseInfo expense in daily.ExpenseList)
                {         
                    ExpenseDataGridView.Rows.Add(expense.Reason, expense.Amount, expense.Category, expense.Comment, "old");
                }               

                foreach (EarningInfo earning in daily.EarningList)
                {
                    EarningDataGridView.Rows.Add(earning.Source, earning.Amount, earning.Category, earning.Comment, "old");
                }
            }
            ExpenseDataGridView.Rows[0].Cells[0].Selected = false;

            UpdateTotalExpenseLabel();
            UpdateTotalEarningLabel();
        }

        private void UpdateTotalExpenseLabel()
        {
            double amount;
            double total = 0.0;

            //go through each row in expense datagridView and add up the amounts
            foreach (DataGridViewRow row in ExpenseDataGridView.Rows)
            {
                if (IsLastEmptyRow(ExpenseDataGridView, row.Index))
                {
                    break;
                }

                try
                {
                    if(double.TryParse(row.Cells[1].Value.ToString(), out amount))
                    {
                        total += amount;
                    }
                    else
                    {
                        string message = "The amount on row " + (row.Index + 1) +
                            " in the expense table is not correct. Please correct the amount.";
                        MessageBox.Show(message);

                        //make column color yellow so the user can easily notice the error
                        row.Cells[1].Style.BackColor = Color.Red;
                        row.Cells[1].Style.ForeColor = Color.White;
                    }
                }
                catch (NullReferenceException)
                {
                    string message = "The amount on row " + (row.Index + 1) +
                            " in the expense table is empty.";
                    MessageBox.Show(message);

                    //make column color yellow so the user can easily notice the error
                    row.Cells[1].Style.BackColor = Color.Yellow;
                }
            }

            TotalExpenseLabel.Text = string.Format("{0:0.00}", total);
        }

        private void UpdateTotalEarningLabel()
        {
            double amount;
            double total = 0.0;

            //go through each row in expense datagridView and add up the amounts
            foreach (DataGridViewRow row in EarningDataGridView.Rows)
            {
                if (IsLastEmptyRow(EarningDataGridView, row.Index))
                {
                    break;
                }

                try
                {
                    if(double.TryParse(row.Cells[1].Value.ToString(), out amount))
                    {
                        total += amount;
                    }
                    else
                    {
                        string message = "The amount on row " + (row.Index + 1) +
                            " in the earning table is not correct. Please correct the amount.";
                        MessageBox.Show(message);

                        //make column color yellow so the user can easily notice the error
                        row.Cells[1].Style.BackColor = Color.Red;
                        row.Cells[1].Style.ForeColor = Color.White;
                    }
                }
                catch (NullReferenceException)
                {
                    string message = "The amount on row " + (row.Index + 1) +
                            " in the earning table is empty.";
                    MessageBox.Show(message);

                    //make column color yellow so the user can easily point out
                    row.Cells[1].Style.BackColor = Color.Yellow;
                }
            }

            TotalEarningLabel.Text = string.Format("{0:0.00}", total);
        }  
        
        private void ResetAmountColumnColorToDeafault(DataGridView dgv, int rowIndex)
        {
            //Whenever an invalid amount is entered, we change the color of 
            //the amount column so user can easily point out the error.
            //Therefore, when the invalid amount is changed to a valid amount,
            //the amount column color should be reset to default color
            if (dgv.Rows[rowIndex].Cells[1].Style.BackColor == Color.Red)
            {
                dgv.Rows[rowIndex].Cells[1].Style.BackColor = Color.White;
                dgv.Rows[rowIndex].Cells[1].Style.ForeColor = Color.Black;
            }
            else if (dgv.Rows[rowIndex].Cells[1].Style.BackColor == Color.Yellow)
            {
                dgv.Rows[rowIndex].Cells[1].Style.BackColor = Color.White;
            }
        }

        private string SaveDailyInfo()
        {
            if(!_hasUnsavedChanges)
            {
                return "No changes to save.";
            }

            DailyInfo daily = new DailyInfo();
            daily.Note = NoteTextBox.ForeColor == Color.Black ? NoteTextBox.Text : "No note";
            daily.Day = _selectedDay;
            daily.Month = _selectedMonth;
            daily.Year = _selectedYear;
            daily.TotalEarning = Convert.ToDouble(TotalEarningLabel.Text);
            daily.TotalExpense = Convert.ToDouble(TotalExpenseLabel.Text);

            string source;
            string reason;
            string category;
            string comment;
            double amount;

            foreach (DataGridViewRow row in ExpenseDataGridView.Rows)
            {
                if (IsLastEmptyRow(ExpenseDataGridView, row.Index))
                {
                    break;
                }

                try
                {
                    reason = ExpenseDataGridView.Rows[row.Index].Cells[0].Value.ToString();
                    reason = FilterString(reason);
                }
                catch
                {
                    reason = "";
                }

                try
                {
                    if(!double.TryParse(ExpenseDataGridView.Rows[row.Index].Cells[1].Value.ToString(), out amount))
                    {
                        string message = "The value for amount is not correct on row";
                        message += (row.Index + 1) + " in the expense table. Please correct" +
                            " the amount in order to save.";

                        MessageBox.Show(message);
                        return "Invalid value entered";
                    }
                }
                catch (NullReferenceException)
                {
                    string message;
                    message = "Looks like you forgot to enter amount on row ";
                    message += (row.Index + 1) + " in the expense table. ";
                    message += "Do you want to save without changing the amount?";

                    DialogResult dlgResult = MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo);

                    if (dlgResult == DialogResult.Yes)
                    {
                        amount = 0;
                    }
                    else
                    {
                        return "Terminated by user";
                    }
                }            

                try
                {
                    category = ExpenseDataGridView.Rows[row.Index].Cells[2].Value.ToString();
                    category = FilterString(category);
                }
                catch
                {
                    category = "Other";
                }

                try
                {
                    comment = ExpenseDataGridView.Rows[row.Index].Cells[3].Value.ToString();
                    comment = FilterString(comment);
                }
                catch
                {
                    comment = "";
                }

                ExpenseInfo expense = new ExpenseInfo
                {
                    Reason = reason,
                    Amount = amount,
                    Category = category,
                    Comment = comment
                };
                daily.ExpenseList.Add(expense);
            }

            foreach (DataGridViewRow row in EarningDataGridView.Rows)
            {
                if (IsLastEmptyRow(EarningDataGridView, row.Index))
                {
                    break;
                }

                try
                {
                    source = EarningDataGridView.Rows[row.Index].Cells[0].Value.ToString();
                    source = FilterString(source);
                }
                catch
                {
                    source = "";
                }

                try
                {
                    if(!double.TryParse(EarningDataGridView.Rows[row.Index].Cells[1].Value.ToString(), out amount))
                    {
                        string message = "The value for amount is not correct on row" + (row.Index + 1) + 
                            " in the earning table. Please correct the amount in order to save.";

                        MessageBox.Show(message);
                        return "Invalid value entered";
                    }
                }
                catch (NullReferenceException)
                {
                    string message = "Looks like you forgot to enter amount on row " + (row.Index + 1) + 
                        " in the earning table. Do you want to save without changing the amount?";

                    DialogResult dlgResult = MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo);

                    if (dlgResult == DialogResult.Yes)
                    {
                        amount = 0;
                    }
                    else
                    {
                        return "Terminated by user";
                    }
                }

                try
                {
                    category = EarningDataGridView.Rows[row.Index].Cells[2].Value.ToString();
                    category = FilterString(category);
                }
                catch
                {
                    category = "Other";
                }

                try
                {
                    comment = EarningDataGridView.Rows[row.Index].Cells[3].Value.ToString();
                    comment = FilterString(comment);
                }
                catch
                {
                    comment = "";
                }

                EarningInfo earning = new EarningInfo
                {
                    Source = source,
                    Amount = amount,
                    Category = category,
                    Comment = comment,
                };
                daily.EarningList.Add(earning);
            }

            string result = WebHandler.SaveDailyInfo(daily);

            if (result == "SUCCESS")
            {
                //if any info on the same date already exists, overwrite that info 
                //otherwise, add this info as new info
                int index = GlobalSpace.DailyInfoList.FindIndex(
                    d => d.Day == daily.Day && d.Month == daily.Month && d.Year == daily.Year);

                if (index != -1)
                {
                    GlobalSpace.DailyInfoList[index] = daily;
                }
                else
                {
                    GlobalSpace.DailyInfoList.Add(daily);
                }

                //monthly info should change accordingly since daily info has been modified
                MonthlyInfo.Fetch();

                MessageBox.Show("Information has been successfully saved.");
                _hasUnsavedChanges = false;
            }

            return result;
        }

        private void OpenCategoryListForm(DataGridView dgv)
        {
            CloseOpenedCategoryForm();

            List<int> rowIndexList = new List<int>();

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                if (IsLastEmptyRow(dgv, row.Index))
                {
                    break;
                }
                rowIndexList.Add(row.Index);
            }

            CategoryListForm form = new CategoryListForm(dgv, rowIndexList);
            form.Location = new Point(this.Location.X + 300, this.Location.Y);
            form.Show();
        }           
        
        private void CloseOpenedCategoryForm()
        {
            Form openForm = Application.OpenForms["CategoryListForm"];

            if (openForm != null)
            {
                openForm.Close();
            }
        }

        private bool IsLastEmptyRow(DataGridView dgv, int rowIndex)
        {
            return rowIndex == dgv.Rows.Count - 1? true: false;
        }

        private void OpenNewForm(Form form)
        {
            if (_hasUnsavedChanges)
            {
                DialogResult userResponse = ShowUnsavedChangesWarning();

                if (userResponse == DialogResult.Yes)
                {
                    form.Location = this.Location;
                    form.Show();

                    _isUnsavedChangesWarningAlreadyShown = true;
                    _quitAppOnFormClosing = false;
                    this.Close();
                }
            }
            else
            {
                form.Location = this.Location;
                form.Show();

                _quitAppOnFormClosing = false;
                this.Close();
            }
        }    

        private string FilterString(string str)
        {
            //we use '~' character to split daily information when retrieving 
            //from database. So, if any string contains that character, that
            //might lead to an unexpected error. So this method will replace
            //all '~' characters with '-' character in a string
            string filteredString = str.Replace('~', '-');

            return filteredString;
        }

        private DialogResult ShowUnsavedChangesWarning()
        {
            string message = "You have unsaved changes. Changing this page" + 
                             "might  cause permanent loss of current changes. " +
                             "Do you still want to change this page?";

            DialogResult dlgRes = MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo);

            return dlgRes;
        }

        #endregion
    }
}
