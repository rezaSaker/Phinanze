using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MyCost.Common;
using MyCost.Common.WebHandler;

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
        private bool _isAutoSaveAlreadyAttempted;
        private bool _redundantTriggerOfEventHandler;

        private ProgressViewerForm _progressViewer;

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

        #region event_handler_methods

        private void ThisFormLoading(object sender, EventArgs e)
        {
            _quitAppOnFormClosing = true;
            _hasUnsavedChanges = false;
            _isAutoSaveAlreadyAttempted = false;
            _redundantTriggerOfEventHandler = false;

            for (int i = 2018; i < _selectedYear + 3; i++)
            {
                yearComboBox.Items.Add(i.ToString());
            }

            monthComboBox.SelectedIndex = _selectedMonth - 1;
            yearComboBox.SelectedIndex = yearComboBox.Items.IndexOf(_selectedYear.ToString());

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
            if (!_redundantTriggerOfEventHandler)
            {
                if (_hasUnsavedChanges && !_isAutoSaveAlreadyAttempted)
                {
                    if (!AutoSaveDailyInfo())
                    {
                        //since we are changing selected index, 
                        //this will itrigger this method again which is unexpected
                        //setting _redundantTriggerOfEventHandler = true will prevent tht
                        _redundantTriggerOfEventHandler = true;

                        _isAutoSaveAlreadyAttempted = false;
                        dayComboBox.SelectedIndex = _dayComboBoxPrevSelectedIndex;
                        return;
                    }
                }

                //keep record of the selected index so that we can 
                //switch back to this index if needed during next selection change
                _dayComboBoxPrevSelectedIndex = dayComboBox.SelectedIndex;

                _selectedDay = dayComboBox.SelectedIndex + 1;
                PlotDailyInfo();

                ResetProperties();
            }
            else
            {
                _redundantTriggerOfEventHandler = false;
            }
        }

        private void MonthComboBoxIndexChanged(object sender, EventArgs e)
        {
            if (!_redundantTriggerOfEventHandler)
            {
                if (_hasUnsavedChanges && !_isAutoSaveAlreadyAttempted)
                {
                    if (!AutoSaveDailyInfo())
                    {
                        //since we are changing selected index, 
                        //this will itrigger this method again which is unexpected
                        //setting _redundantTriggerOfEventHandler = true will prevent tht
                        _redundantTriggerOfEventHandler = true;

                        _isAutoSaveAlreadyAttempted = false;
                        monthComboBox.SelectedIndex = _monthComboBoxPrevSelectedIndex;
                        return;
                    }
                }

                //keep the record of the selected index so that we can 
                //switch back to this index if needed during next selection change
                _monthComboBoxPrevSelectedIndex = monthComboBox.SelectedIndex;

                _selectedMonth = monthComboBox.SelectedIndex + 1;
                AddItemsToDayComboBox();

                ResetProperties();
            }
            else
            {
                _redundantTriggerOfEventHandler = false;
            }
        }

        private void YearComboBoxIndexChanged(object sender, EventArgs e)
        {
            if (!_redundantTriggerOfEventHandler)
            {
                if (_hasUnsavedChanges && !_isAutoSaveAlreadyAttempted)
                {
                    if (!AutoSaveDailyInfo())
                    {
                        //since we are changing selected index, 
                        //this will itrigger this method again which is unexpected
                        //setting _redundantTriggerOfEventHandler = true will prevent tht
                        _redundantTriggerOfEventHandler = true;

                        _isAutoSaveAlreadyAttempted = false;
                        yearComboBox.SelectedIndex = _yearComboBoxPrevSelectedIndex;
                        return;
                    }
                }

                //keep record of the selected index so that we can 
                //switch back to this index if needed during next selection change
                _yearComboBoxPrevSelectedIndex = yearComboBox.SelectedIndex;

                _selectedYear = Convert.ToInt32(yearComboBox.SelectedItem.ToString());
                AddItemsToDayComboBox();

                ResetProperties();
            }
            else
            {
                _redundantTriggerOfEventHandler = false;
            }
        }

        private void NoteTextBoxClicked(object sender, EventArgs e)
        {
            //if the textBox only contains the placeholder 
            //and user hasn't yet entered any text
            if (noteTextBox.ForeColor == Color.Gray)
            {
                noteTextBox.Text = "";
                noteTextBox.ForeColor = Color.Black;
            }
        }

        private void ExpenseDataGridViewCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if(IslastEmptyRow(expenseDataGridView, e.RowIndex))
            {
                return;
            }

            //if it's category column
            if (e.ColumnIndex == 2)
            {
                List<int> rowIndexList = new List<int>();
                rowIndexList.Add(e.RowIndex);
                CategoryListForm form = new CategoryListForm(expenseDataGridView, rowIndexList);
                form.Location = new Point(this.Location.X + 300, this.Location.Y);
                form.Show();
            }
        }

        private void ExpenseDGVEditBegan(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if it's amount column
            if (e.ColumnIndex == 1)
            {
                ResetAmountColumnColorToDeafault(expenseDataGridView, e.RowIndex);
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
            if (IslastEmptyRow(earningDataGridView, e.RowIndex))
            {
                return;
            }

            //if it's category column
            if (e.ColumnIndex == 2)
            {
                List<int> rowIndexList = new List<int>();
                rowIndexList.Add(e.RowIndex);
                CategoryListForm form = new CategoryListForm(earningDataGridView, rowIndexList);
                form.Location = new Point(this.Location.X + 300, this.Location.Y);
                form.Show();
            }
        }

        private void EarningDGVEditBegan(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if it's amount column
            if (e.ColumnIndex == 1)
            {
                ResetAmountColumnColorToDeafault(earningDataGridView, e.RowIndex);
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
            if (expenseDataGridView.SelectedRows.Count > 0)
            {
                OpenCategoryListForm(expenseDataGridView);
            }
            else if (earningDataGridView.SelectedRows.Count > 0)
            {
                OpenCategoryListForm(earningDataGridView);
            }
        }

        private void MenuButtonsMouseHovering(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.ForestGreen;
            button.ForeColor = Color.White;
        }

        private void MenuButtonsMouseLeaving(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.White;
            button.ForeColor = Color.ForestGreen;
        }

        private void MenuButtonsClicked(object sender, EventArgs e)
        {
            if (_hasUnsavedChanges)
            {
                if(!AutoSaveDailyInfo())
                {
                    //if auto saving is not successful
                    return;
                }
            }

            Button button = (Button)sender;

            if (button.Name == "homeButton")
            {
                OpenNewForm(new MainForm());
            }
            else if (button.Name == "monthlyReportButton")
            {
                OpenNewForm(new MonthlyReportForm());
            }
            else if (button.Name == "statisticsButton")
            {
                OpenNewForm(new StatisticsForm());
            }
            else if (button.Name == "settingsButton")
            {
                OpenNewForm(new SettingsForm());
            }
            else if (button.Name == "logOutButton")
            {
                StaticStorage.LogOutUser();
                _quitAppOnFormClosing = false;
                this.Close();
            }
        }

        private void ControlChanged(object sender, EventArgs e)
        {
            //this method is triggered when any editable control on this form is edited
            saveButton.Enabled = true;
            saveButton.BackColor = Color.RoyalBlue;
            _hasUnsavedChanges = true;
        }    

        private void ThisFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseOpenedCategoryForm();            

            if (_quitAppOnFormClosing)
            {
                if (_hasUnsavedChanges && !AutoSaveDailyInfo())
                {
                     //if auto saving is not successful
                     e.Cancel = true;
                     return;
                }

                Application.Exit();
            }
        }
        #endregion

        #region non_event_handler_methods

        private void AddItemsToDayComboBox()
        {
            dayComboBox.Items.Clear();

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
                dayComboBox.Items.Add(day.ToString());
            }

            try
            {
                dayComboBox.SelectedIndex = _selectedDay - 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                //this exception occurs when the selected day is greater 
                //than the number of days in the selected month
                dayComboBox.SelectedIndex = 0;
                _selectedDay = 1;
            }
        }

        private void PlotDailyInfo()
        {
            //clear previous info
            noteTextBox.Text = "Note";
            noteTextBox.ForeColor = Color.Gray;
            totalExpenseLabel.Text = "0.00";
            totalEarningLabel.Text = "0.00";
            expenseDataGridView.Rows.Clear();
            earningDataGridView.Rows.Clear();

            //plot info for new selected date
            DailyInfo daily = StaticStorage.DailyInfoList.Find(
                                    d => d.Day == _selectedDay 
                                    && d.Month == _selectedMonth 
                                    && d.Year == _selectedYear);

            if (daily != null)
            {
                noteTextBox.Text = daily.Note;
                noteTextBox.ForeColor = Color.Black;

                foreach (ExpenseInfo expense in daily.ExpenseList)
                {
                    expenseDataGridView.Rows.Add(expense.Reason, expense.Amount, expense.Category, expense.Comment);
                }               

                foreach (EarningInfo earning in daily.EarningList)
                {
                    earningDataGridView.Rows.Add(earning.Source, earning.Amount, earning.Category, earning.Comment);
                }
            }
            expenseDataGridView.Rows[0].Cells[0].Selected = false;

            UpdateTotalExpenseLabel();
            UpdateTotalEarningLabel();
        }

        private void UpdateTotalExpenseLabel()
        {
            double amount;
            double total = .0;

            //go through each row in expense datagridView and add up the amounts
            foreach (DataGridViewRow row in expenseDataGridView.Rows)
            {
                if (IslastEmptyRow(expenseDataGridView, row.Index))
                {
                    break;
                }

                try
                {
                    amount = Convert.ToDouble(row.Cells[1].Value.ToString());
                    total += amount;
                }
                catch (FormatException)
                {
                    //make column color red so the user can easily notice the error
                    row.Cells[1].Style.BackColor = Color.Red;
                    row.Cells[1].Style.ForeColor = Color.White;
                }
                catch (NullReferenceException)
                {
                    //make column color yellow so the user can easily notice the error
                    row.Cells[1].Style.BackColor = Color.Yellow;
                    row.Cells[1].Value = "0.00";
                }
            }
            totalExpenseLabel.Text = string.Format("{0:0.00}", total);
        }

        private void UpdateTotalEarningLabel()
        {
            double amount;
            double total = .0;

            //go through each row in expense datagridView and add up the amounts
            foreach (DataGridViewRow row in earningDataGridView.Rows)
            {
                if (IslastEmptyRow(earningDataGridView, row.Index))
                {
                    break;
                }

                try
                {
                    amount = Convert.ToDouble(row.Cells[1].Value.ToString());
                    total += amount;
                }
                catch (FormatException)
                {
                    //make column color red so the user can easily point out
                    row.Cells[1].Style.BackColor = Color.Red;
                    row.Cells[1].Style.ForeColor = Color.White;
                }
                catch (NullReferenceException)
                {
                    //make column color yellow so the user can easily point out
                    row.Cells[1].Style.BackColor = Color.Yellow;
                    row.Cells[1].Value = "0.00";
                }
            }
            totalEarningLabel.Text = string.Format("{0:0.00}", total);
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
            DailyInfo daily = new DailyInfo();
            daily.Note = noteTextBox.ForeColor == Color.Black ? noteTextBox.Text : "No note";
            daily.Day = _selectedDay;
            daily.Month = _selectedMonth;
            daily.Year = _selectedYear;
            daily.TotalEarning = Convert.ToDouble(totalEarningLabel.Text);
            daily.TotalExpense = Convert.ToDouble(totalExpenseLabel.Text);

            string source;
            string reason;
            string category;
            string comment;
            double amount;

            foreach (DataGridViewRow row in expenseDataGridView.Rows)
            {
                if (IslastEmptyRow(expenseDataGridView, row.Index))
                {
                    break;
                }

                try
                {
                    reason = expenseDataGridView.Rows[row.Index].Cells[0].Value.ToString();
                }
                catch
                {
                    reason = "";
                }

                try
                {
                    amount = Convert.ToDouble(expenseDataGridView.Rows[row.Index].Cells[1].Value.ToString());
                }
                catch (NullReferenceException)
                {
                    string message;
                    message = "Looks like you forgot to enter amount on row ";
                    message += (row.Index + 1) + " In expense table. Do you want to continue saving?";

                    DialogResult dresult = MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo);

                    if (dresult == DialogResult.Yes)
                    {
                        amount = .0;
                    }
                    else
                    {
                        return "Terminated by user";
                    }
                }
                catch (FormatException)
                {
                    string message;
                    message = "Looks like the amount is not correct on row ";
                    message += (row.Index + 1) + " in expense table. Continuing may cause ";
                    message += "loss of data. Do you want to continue saving?";

                    DialogResult dresult = MessageBox.Show(message,"Alert", MessageBoxButtons.YesNo);
                    
                    if(dresult == DialogResult.Yes)
                    {
                        amount = 0.0;
                    }
                    else
                    {
                        return "Terminated by user";
                    }
                }

                try
                {
                    category = expenseDataGridView.Rows[row.Index].Cells[2].Value.ToString();
                }
                catch
                {
                    category = "Other";
                }

                try
                {
                    comment = expenseDataGridView.Rows[row.Index].Cells[3].Value.ToString();
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

            foreach (DataGridViewRow row in earningDataGridView.Rows)
            {
                if (IslastEmptyRow(earningDataGridView, row.Index))
                {
                    break;
                }

                try
                {
                    source = earningDataGridView.Rows[row.Index].Cells[0].Value.ToString();
                }
                catch
                {
                    source = "";
                }

                try
                {
                    amount = Convert.ToDouble(earningDataGridView.Rows[row.Index].Cells[1].Value.ToString());
                }
                catch (NullReferenceException)
                {
                    string message = "Looks like you forgot to enter amount on row ";
                    message += (row.Index + 1) + " in Earning table. Do you want to continue saving?";

                    DialogResult dresult = MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo);

                    if (dresult == DialogResult.Yes)
                    {
                        amount = .0;
                    }
                    else
                    {
                        return "Terminated by user";
                    }
                }
                catch (FormatException)
                {
                    string message;
                    message = "Looks like the amount is not correct on row ";
                    message += (row.Index + 1) + " in earning table. Continuing may cause ";
                    message += "loss of data. Do you want to continue saving?";

                    DialogResult dresult = MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo);

                    if (dresult == DialogResult.Yes)
                    {
                        amount = 0.0;
                    }
                    else
                    {
                        return "Terminated by user";
                    }
                }

                try
                {
                    category = earningDataGridView.Rows[row.Index].Cells[2].Value.ToString();
                }
                catch
                {
                    category = "Other";
                }

                try
                {
                    comment = earningDataGridView.Rows[row.Index].Cells[3].Value.ToString();
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
                int index = StaticStorage.DailyInfoList.FindIndex(
                    d => d.Day == daily.Day && d.Month == daily.Month && d.Year == daily.Year);

                if (index != -1)
                {
                    StaticStorage.DailyInfoList[index] = daily;
                }
                else
                {
                    StaticStorage.DailyInfoList.Add(daily);
                }

                //monthly info should change accordingly since daily info has been modified
                MonthlyInfo.Fetch();

                _hasUnsavedChanges = false;
                saveButton.Enabled = false;
                saveButton.BackColor = Color.LightGray;
            }
            return result;
        }

        private bool AutoSaveDailyInfo()
        {
            _isAutoSaveAlreadyAttempted = true;

            string result = SaveDailyInfo();

            if(result == "Terminated by user")
            {
                return false;
            }
            else if (result == "Server connection error")
            {
                //if the info is not successfully saved
                string message = "Could not perform the automatic saving operation. ";
                message += "It is recommended that you check your internet connection ";
                message += "and try to save again. Continuing this page without saving might ";
                message += "cause the unsaved changes to be permanently lost.\n\n";
                message += "Do you want to continue without saving?";

                DialogResult dlgResult = MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo);

                if (dlgResult == DialogResult.No)
                {
                    return false;
                }
            }

            return true;
        }

        private void OpenCategoryListForm(DataGridView dgv)
        {
            CloseOpenedCategoryForm();

            List<int> rowIndexList = new List<int>();

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                if (IslastEmptyRow(dgv, row.Index))
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

        private bool IslastEmptyRow(DataGridView dgv, int rowindex)
        {
            if (rowindex == dgv.Rows.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OpenNewForm(Form form)
        {
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();
        } 
        
        private void ResetProperties()
        {
            _isAutoSaveAlreadyAttempted = false;
            _hasUnsavedChanges = false;
            saveButton.Enabled = false;
            saveButton.BackColor = Color.LightBlue;
        }
        #endregion            
    }
}
