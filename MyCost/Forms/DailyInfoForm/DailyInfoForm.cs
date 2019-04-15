using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MyCost.Common;
using MyCost.ServerHandling;

namespace MyCost
{
    public partial class DailyInfoForm : Form
    {
        private int _selectedDay;
        private int _selectedMonth;
        private int _selectedYear;

        private bool _firstInitializationCall;
        private bool _quitAppOnFormClosing;
        private bool _hasSaved;

        private Form _callerForm;

        public DailyInfoForm(Form form)
        {
            InitializeComponent();

            _callerForm = form;
            _quitAppOnFormClosing = true;
            _hasSaved = false;

            //sets current day, month and year
            _selectedDay = DateTime.Now.Day;
            _selectedMonth = DateTime.Now.Month;
            _selectedYear = DateTime.Now.Year;
        }

        public DailyInfoForm(int day, int month, int year, Form form)
        {
            InitializeComponent();

            _selectedDay = day;
            _selectedMonth = month;
            _selectedYear = year;
            _callerForm = form;
            _quitAppOnFormClosing = true;
            _hasSaved = false;
        }

        private void AddNewDataFormLoading(object sender, EventArgs e)
        {
            for (int i = 2018; i < _selectedYear + 10; i++)
            {
                yearComboBox.Items.Add(i.ToString());
            }

            //changing selctedIndex in comboBox results in calling of PlotDailyInfo() & AddItemsToDayComboBox()
            //since we change selectedIndex in this loader method twice it will call those methods twice
            //to avoid that redundancy we will check with a boolean if it is the first initialization call
            _firstInitializationCall = true;

            //Sets the date fields to currents date
            //day is selected in MonthComboBoxIndexChanged() which is called when we set the month 
            monthComboBox.SelectedIndex = _selectedMonth - 1;
            yearComboBox.SelectedIndex = yearComboBox.Items.IndexOf(_selectedYear.ToString());

            _firstInitializationCall = false;
        }

        private void MonthComboBoxIndexChanged(object sender, EventArgs e)
        {         
            _selectedMonth = monthComboBox.SelectedIndex + 1;

            //followiing method call will change the number of days in the dayComboBox according to the selected month
            //this will also reset the selectedIndex of dayComboBox to _selectedDay
            //changing index of dayComboBox will make call to PlotDailyInfo() method
            AddItemsToDayComboBox();
        }

        private void YearComboBoxIndexChanged(object sender, EventArgs e)
        {
            _selectedYear = Convert.ToInt32(yearComboBox.SelectedItem.ToString());

            //if it is first initialization call, then the items are already set to dayComboBox
            //otherwise, if the yearComboBox index is changed later by user, then we need to ...
            //reset the items to dayComboBox according to the year
            if (!_firstInitializationCall)
            {
                AddItemsToDayComboBox();
            }         
        }

        private void DayComboBoxIndexChanged(object sender, EventArgs e)
        {
            _selectedDay = dayComboBox.SelectedIndex + 1;

            PlotDailyInfo();
        }

        private void CloseOpenedCategoryForm()
        {
            Form openForm = Application.OpenForms["CategoryListForm"];
            if(openForm != null)
            {
                openForm.Close();
            }
        }

        private void ExpenseDataGridViewCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            //if the clicked column is category column
            if (e.ColumnIndex == 2)
            {
                List<int> rowIndex = new List<int>();
                rowIndex.Add(e.RowIndex);
                
                //this will prevent opeing multiple forms at the same time
                CloseOpenedCategoryForm();

                CategoryListForm form = new CategoryListForm(expenseDataGridView, rowIndex);
                form.Location = new Point(384, 97);
                form.Show();
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
                List<int> rowIndex = new List<int>();
                rowIndex.Add(e.RowIndex);

                //this will prevent opeing multiple forms at the same time
                CloseOpenedCategoryForm();

                CategoryListForm form = new CategoryListForm(earningDataGridView, rowIndex);
                form.Location = new Point(384, 288);
                form.Show();
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

                foreach(DailyInfo d in StaticStorage.DailyInfo)
                {
                    if(d.Day == daily.Day 
                        && d.Month == daily.Month 
                        && d.Year == daily.Year)
                    {
                        index = StaticStorage.DailyInfo.IndexOf(d);
                        break;
                    }
                }
                if(index == -1)
                {
                    //if no matching daily info is found, so add a new info
                    StaticStorage.DailyInfo.Add(daily);
                }
                else
                {
                    //matching info is found, so update the current info
                    StaticStorage.DailyInfo[index] = daily;
                }

                //this will prevent the OnFormClosing method to attempt to save the info
                _hasSaved = true;
            }
            else
            {
                //if not success, the error info is returned
                MessageBox.Show(result);
            }
        }

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

            //sets the days as items to dayComboBox
            for (int i = 0; i < numberOfdays; i++)
            {
                dayComboBox.Items.Add((i + 1).ToString());
            }

            try
            {
                dayComboBox.SelectedIndex = _selectedDay - 1;
            }
            catch(ArgumentOutOfRangeException)
            {
                //this exception is thrown when _selectedDay is greater than...
                //...the number of days for _selectedMonth
                dayComboBox.SelectedIndex = 0;
                _selectedDay = 1;
            }
            
        }

        private void UpdateTotalExpenseLabel()
        {
            double amount;
            double total = .0;

            //goes through each row in expense datagridView and adds up the amounts
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

            //goes through each row in expense datagridView and adds up the amounts
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

        private void PlotDailyInfo()
        {
            //clears the previous info
            noteTextBox.Text = "Note";
            noteTextBox.ForeColor = Color.Gray;
            totalExpenseLabel.Text = "0.00";
            totalEarningLabel.Text = "0.00";
            expenseDataGridView.Rows.Clear();
            earningDataGridView.Rows.Clear();

            //plot info for new selected date
            foreach(DailyInfo daily in StaticStorage.DailyInfo)
            {
                if(_selectedDay == daily.Day
                    && _selectedMonth == daily.Month
                    && _selectedYear == daily.Year)
                {
                    //plot common info first
                    noteTextBox.Text = daily.Note;
                    noteTextBox.ForeColor = Color.Black;

                    //plot expense info
                    foreach(ExpenseInfo expense in daily.Expenses)
                    {
                        expenseDataGridView.Rows.Add(expense.Reason, expense.Amount, expense.Category, expense.Comment);
                    }

                    //plot earning info
                    foreach(EarningInfo earning in daily.Earnings)
                    {
                        earningDataGridView.Rows.Add(earning.Source, earning.Amount, earning.Category, earning.Comment);
                    }

                    break;
                }
            }

            UpdateTotalExpenseLabel();
            UpdateTotalEarningLabel();
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

        private void OpenCategoryListForm(DataGridView dgv)
        {
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

        private void CancelButtonClicked(object sender, EventArgs e)
        {
            _callerForm.Location = new Point(this.Location.X, this.Location.Y);
            _callerForm.Show();

            _hasSaved = true;//this will prevent the OnFormClosing method to attempt to save the info
            _quitAppOnFormClosing = false;
            this.Close();
        }

        private void HomeButtonClicked(object sender, EventArgs e)
        {
            _callerForm.Close();

            MainForm form = new MainForm();
            form.Location = new Point(this.Location.X, this.Location.Y);
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();

        }

        private void MonthlyReportButtonClicked(object sender, EventArgs e)
        {
            _callerForm.Close();

            MonthlyInfoForm form = new MonthlyInfoForm();
            form.Location = new Point(this.Location.X, this.Location.Y);
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();
        }

        private void StatisticalReportButtonClicked(object sender, EventArgs e)
        {
            StatisticalReportForm form = new StatisticalReportForm(this);
            form.Location = new Point(this.Location.X, this.Location.Y);
            form.Show();

            _quitAppOnFormClosing = false;
            this.Hide();
        }

        private void SettingsButtonClicked(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(this);
            form.Location = new Point(this.Location.X, this.Location.Y);
            form.Show();

            _quitAppOnFormClosing = false;
            this.Hide();
        }

        private void LogOutButtonClicked(object sender, EventArgs e)
        {
            _callerForm.Close();

            //this will opt out from direct login option that occurs when remember me checkbox is checked
            Properties.Settings.Default.Username = null;
            Properties.Settings.Default.Password = null;
            Properties.Settings.Default.Save();

            UserAuthenticationForm form = new UserAuthenticationForm();
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();
        }

        private void NoteTextBoxClicked(object sender, EventArgs e)
        {
            //if the textBox only contains the placeholder and user hasn't yet netered any text
            if(noteTextBox.ForeColor == Color.Gray)
            {
                noteTextBox.Text = "";
                noteTextBox.ForeColor = Color.Black;
            }
        }

        private void DailyInfoFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasSaved)
            {
                saveButton.PerformClick();
            }

            if (_quitAppOnFormClosing)
            {
                Application.Exit();
            }
        }

        
    }
}
