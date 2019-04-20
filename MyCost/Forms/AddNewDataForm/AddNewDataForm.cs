using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MyCost.Common;
using MyCost.ServerHandling;

namespace MyCost.Forms
{
    public partial class AddNewDataForm : Form
    {
        private int _selectedDay;
        private int _selectedMonth;
        private int _selectedYear;

        private bool _firstCall;
        private bool _quitAppOnFormClosing;
        private bool _hasSaved;

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
            _hasSaved = true;   //prevents save attempt when closing the form
            _quitAppOnFormClosing = true;   //prevents exiting the app on closing of this form          
            _firstCall = true;  //disable call to AddItemsToDayComboBox() in YearComboBoxSelectedIndexChanged() method

            for (int i = 2018; i < _selectedYear + 3; i++)
            {
                yearComboBox.Items.Add(i.ToString());
            }
            
            monthComboBox.SelectedIndex = _selectedMonth - 1;
            yearComboBox.SelectedIndex = yearComboBox.Items.IndexOf(_selectedYear.ToString());

            _firstCall = false; //enable call to AddItemsToDayComboBox() in YearComboBoxSelectedIndexChanged() method

            //add an event handler method to each editable control on the form
            //so that we can detect if there's any unsaved changes when closing the form
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).TextChanged += ControlChanged;
                }
                else if (control is DataGridView)
                {
                    ((DataGridView)control).CellValueChanged += ControlChanged;
                    ((DataGridView)control).UserAddedRow += ControlChanged;
                    ((DataGridView)control).UserDeletedRow += ControlChanged;
                    ((DataGridView)control).CellEndEdit += ControlChanged;
                }
            }

            saveButton.Enabled = false;
            saveButton.BackColor = Color.LightGray;
        }

        private void DayComboBoxIndexChanged(object sender, EventArgs e)
        {
            _selectedDay = dayComboBox.SelectedIndex + 1;

            //plot data for the newly selected date
            PlotDailyInfo();
        }

        private void MonthComboBoxIndexChanged(object sender, EventArgs e)
        {         
            _selectedMonth = monthComboBox.SelectedIndex + 1;
            AddItemsToDayComboBox();
        }

        private void YearComboBoxIndexChanged(object sender, EventArgs e)
        {
            _selectedYear = Convert.ToInt32(yearComboBox.SelectedItem.ToString());

            //if _firstCall is true, then the items are already set to dayComboBox and no need to reset it
            if (!_firstCall)
            {
                AddItemsToDayComboBox();
            }         
        }

        private void NoteTextBoxClicked(object sender, EventArgs e)
        {
            //if the textBox only contains the placeholder and user hasn't yet entered any text
            if (noteTextBox.ForeColor == Color.Gray)
            {
                noteTextBox.Text = "";
                noteTextBox.ForeColor = Color.Black;
            }
        }

        private void ExpenseDataGridViewCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            //if the clicked column is category column
            if (e.ColumnIndex == 2)
            {
                OpenCategoryListForm(expenseDataGridView);
            }
        }

        private void ExpenseDGVEditBegan(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                //if the column is amount column, the color should be reset to default color
                //because, we change the color when a wrong amount is entered
                if (expenseDataGridView.Rows[e.RowIndex].Cells[1].Style.BackColor == Color.Red)
                {
                    expenseDataGridView.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.White;
                    expenseDataGridView.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.Black;
                }
                else if (expenseDataGridView.Rows[e.RowIndex].Cells[1].Style.BackColor == Color.Yellow)
                {
                    expenseDataGridView.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.White;
                }
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
            //if the clicked column is category column
            if (e.ColumnIndex == 2)
            {
                OpenCategoryListForm(earningDataGridView);
            }
        }

        private void EarningDGVEditBegan(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                //if the column is amount column, the color should be reset to default color
                //because, we change the color when a wrong amount is entered
                if (earningDataGridView.Rows[e.RowIndex].Cells[1].Style.BackColor == Color.Red)
                {
                    earningDataGridView.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.White;
                    earningDataGridView.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.Black;
                }
                else if (earningDataGridView.Rows[e.RowIndex].Cells[1].Style.BackColor == Color.Yellow)
                {
                    earningDataGridView.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.White;
                }
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
            DailyInfo daily = new DailyInfo();

            daily.Note = noteTextBox.Text;
            daily.Day = Convert.ToUInt16(dayComboBox.SelectedItem.ToString());
            daily.Month = monthComboBox.Items.IndexOf(monthComboBox.SelectedItem.ToString()) + 1;
            daily.Year = Convert.ToUInt16(yearComboBox.SelectedItem.ToString());
            daily.TotalEarning = Convert.ToDouble(totalEarningLabel.Text);
            daily.TotalExpense = Convert.ToDouble(totalExpenseLabel.Text);

            string source;
            string reason;
            string category;
            string comment;
            double amount;

            foreach (DataGridViewRow row in expenseDataGridView.Rows)
            {
                if (row.Index == expenseDataGridView.Rows.Count - 1)
                {
                    //this is the last row and it's an empty row
                    break;
                }

                try
                {
                    reason = expenseDataGridView.Rows[row.Index].Cells[0].Value.ToString();
                }
                catch (NullReferenceException)
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
                    message += (row.Index + 1) + ". Do you want to continue saving?";

                    DialogResult dresult = MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo);

                    if (dresult == DialogResult.Yes)
                        amount = .0;
                    else
                        return;
                }
                catch (FormatException)
                {
                    string message;
                    message = "Looks like the amount is not correct on row ";
                    message += (row.Index + 1) + " in expense table. Amount can only be numbers. ";
                    message += "Please correct the amount before saving.";

                    MessageBox.Show(message);
                    return;
                }

                try
                {
                    category = expenseDataGridView.Rows[row.Index].Cells[2].Value.ToString();
                }
                catch (NullReferenceException)
                {
                    category = "Other";
                }

                try
                {
                    comment = expenseDataGridView.Rows[row.Index].Cells[3].Value.ToString();
                }
                catch (NullReferenceException)
                {
                    comment = "";
                }

                ExpenseInfo expense = new ExpenseInfo(reason, amount, category, comment);
                daily.Expenses.Add(expense);
            }

            foreach (DataGridViewRow row in earningDataGridView.Rows)
            {
                if (row.Index == earningDataGridView.Rows.Count - 1)
                {
                    //this is the last row and it's an empty row
                    break;
                }

                try
                {
                    source = earningDataGridView.Rows[row.Index].Cells[0].Value.ToString();
                }
                catch (NullReferenceException)
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
                        amount = .0;
                    else
                        return;
                }
                catch (FormatException)
                {
                    string message = "Looks like the amount is not correct on row ";
                    message += (row.Index + 1) + " in expense table. Amount can only be numbers. ";
                    message += "Please correct the amount before saving.";

                    MessageBox.Show(message);
                    return;
                }

                try
                {
                    category = earningDataGridView.Rows[row.Index].Cells[2].Value.ToString();
                }
                catch (NullReferenceException)
                {
                    category = "Other";
                }

                try
                {
                    comment = earningDataGridView.Rows[row.Index].Cells[3].Value.ToString();
                }
                catch (NullReferenceException)
                {
                    comment = "";
                }

                EarningInfo earning = new EarningInfo(source, amount, category, comment);
                daily.Earnings.Add(earning);
            }

            string result = ServerHandler.SaveDailyInfo(daily);

            if (result == "SUCCESS")
            {
                int index = -1;

                //checks id any info with same date already exists
                foreach(DailyInfo d in StaticStorage.DailyInfoList)
                {
                    if(d.Day == daily.Day 
                        && d.Month == daily.Month 
                        && d.Year == daily.Year)
                    {
                        index = StaticStorage.DailyInfoList.IndexOf(d);
                        break;
                    }
                }
                if(index == -1)
                {
                    //no info exists for this date, so add a new info
                    StaticStorage.DailyInfoList.Add(daily);
                }
                else
                {
                    //info on this date already exists, so update the existing info
                    StaticStorage.DailyInfoList[index] = daily;
                }

                //monthly info needs to be updated according to daily info
                StaticStorage.FetchMonthlyInfo();

                //this will prevent the OnFormClosing method to attempt to save the info
                _hasSaved = true;
                saveButton.Enabled = false;
                saveButton.BackColor = Color.LightGray;
            }
            else
            {
                //if not success, the error info is returned
                MessageBox.Show(result);
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
            Button button = (Button)sender;

            if (button.Name == "homeButton")
                OpenNewForm(new MainForm());
            else if (button.Name == "dailyReportButton")
                OpenNewForm(new DailyReportForm());
            else if (button.Name == "yearlyStatisticsButton")
                OpenNewForm(new YearlyStatisticsForm());
            else if (button.Name == "settingsButton")
                OpenNewForm(new SettingsForm());
            else if (button.Name == "logOutButton")
                LogOut();
        }

        private void ControlChanged(object sender, EventArgs e)
        {
            //this method is triggered when any editable control on this form is edited
            saveButton.Enabled = true;
            saveButton.BackColor = Color.RoyalBlue;
            _hasSaved = false;
        }    

        private void ThisFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseOpenedCategoryForm();

            if (!_hasSaved)
                saveButton.PerformClick();

            if (_quitAppOnFormClosing)
                Application.Exit();
        }
        #endregion

        #region non_event_handler_methods

        private void AddItemsToDayComboBox()
        {
            dayComboBox.Items.Clear();

            int numberOfdays;

            //set the number of days according to month
            if (_selectedMonth == 2 && DateTime.IsLeapYear(_selectedYear))
                numberOfdays = 29;
            else if (_selectedMonth == 2 && !DateTime.IsLeapYear(_selectedYear))
                numberOfdays = 28;
            else if (_selectedMonth <= 7 && _selectedMonth % 2 == 1)
                numberOfdays = 31;
            else if (_selectedMonth <= 7 && _selectedMonth % 2 == 0)
                numberOfdays = 30;
            else if (_selectedMonth > 7 && _selectedMonth % 2 == 1)
                numberOfdays = 30;
            else
                numberOfdays = 31;

            //set the days as items to dayComboBox
            for (int i = 0; i < numberOfdays; i++)
            {
                dayComboBox.Items.Add((i + 1).ToString());
            }

            try
            {
                dayComboBox.SelectedIndex = _selectedDay - 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                //this exception is thrown when _selectedDay is greater than the number of days for _selectedMonth
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
            foreach (DailyInfo daily in StaticStorage.DailyInfoList)
            {
                if (_selectedDay == daily.Day
                    && _selectedMonth == daily.Month
                    && _selectedYear == daily.Year)
                {
                    //plot common info first
                    noteTextBox.Text = daily.Note;
                    noteTextBox.ForeColor = Color.Black;

                    //plot expense info
                    foreach (ExpenseInfo expense in daily.Expenses)
                    {
                        expenseDataGridView.Rows.Add(expense.Reason, expense.Amount, expense.Category, expense.Comment);
                    }
                    expenseDataGridView.Rows[0].Cells[0].Selected = false;

                    //plot earning info
                    foreach (EarningInfo earning in daily.Earnings)
                    {
                        earningDataGridView.Rows.Add(earning.Source, earning.Amount, earning.Category, earning.Comment);
                    }
                    earningDataGridView.Rows[0].Cells[0].Selected = false;

                    break;
                }
            }

            UpdateTotalExpenseLabel();
            UpdateTotalEarningLabel();
        }

        private void UpdateTotalExpenseLabel()
        {
            double amount;
            double total = .0;

            //go through each row in expense datagridView and add up the amounts
            for (int i = 0; i < expenseDataGridView.Rows.Count - 1; ++i)
            {
                try
                {
                    amount = Convert.ToDouble(expenseDataGridView.Rows[i].Cells[1].Value.ToString());
                    total += amount;
                }
                catch (FormatException)
                {
                    //make the color of the column different so the user can easily notice the error
                    expenseDataGridView.Rows[i].Cells[1].Style.BackColor = Color.Red;
                    expenseDataGridView.Rows[i].Cells[1].Style.ForeColor = Color.White;
                }
                catch (NullReferenceException)
                {
                    //make the color of the column different so the user can easily point out
                    expenseDataGridView.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                    expenseDataGridView.Rows[i].Cells[1].Value = "0.00";
                }
            }

            totalExpenseLabel.Text = string.Format("{0:0.00}", total);
        }

        private void UpdateTotalEarningLabel()
        {
            double amount;
            double total = .0;

            //go through each row in expense datagridView and add up the amounts
            for (int i = 0; i < earningDataGridView.Rows.Count - 1; ++i)
            {
                try
                {
                    amount = Convert.ToDouble(earningDataGridView.Rows[i].Cells[1].Value.ToString());
                    total += amount;
                }
                catch (FormatException)
                {
                    //make the color of the column different so the user can easily point out
                    earningDataGridView.Rows[i].Cells[1].Style.BackColor = Color.Red;
                    earningDataGridView.Rows[i].Cells[1].Style.ForeColor = Color.White;
                }
                catch (NullReferenceException)
                {
                    //make the color of the column different so the user can easily point out
                    earningDataGridView.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                    earningDataGridView.Rows[i].Cells[1].Value = "0.00";
                }
            }

            totalEarningLabel.Text = string.Format("{0:0.00}", total);
        }       

        private void OpenCategoryListForm(DataGridView dgv)
        {
            CloseOpenedCategoryForm();  //prevents opening multiple category form at a time

            List<int> rowIndexes = new List<int>();

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                if (row.Index == dgv.Rows.Count - 1)
                {
                    //this is the last row and an empty row
                    break;
                }
                rowIndexes.Add(row.Index);
            }

            CategoryListForm form = new CategoryListForm(dgv, rowIndexes);
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

        private void OpenNewForm(Form form)
        {
            form.Location = this.Location;
            form.Size = this.Size;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();
        }

        private void LogOut()
        {
            //reset auto login properties
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();

            OpenNewForm(new UserAuthenticationForm());
        }

        #endregion            
    }
}
