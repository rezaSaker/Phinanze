using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MyCost.Common;
using System.Linq;
using System.Drawing;

namespace MyCost.View
{
    public partial class MonthlyReportForm : Form
    {
        private int _selectedMonth;
        private int _selectedYear;

        private bool _quitAppOnFormClosing;
        private bool _isInitializationCall;

        private List<string> _monthList;

        public MonthlyReportForm()
        {
            InitializeComponent();

            _selectedMonth = DateTime.Now.Month;
            _selectedYear = DateTime.Now.Year;
            _quitAppOnFormClosing = true;

            InitializeMonthList();
        }

        public MonthlyReportForm(int month, int year)
        {
            InitializeComponent();

            _selectedMonth = month;
            _selectedYear = year;
            _quitAppOnFormClosing = true;

            InitializeMonthList();
        }

        #region UI EventHandler Methods

        private void ThisFormLoading(object sender, EventArgs e)
        {
            for (int i = 2018; i <= DateTime.Now.Year + 3; i++)
            {
                YearComboBox.Items.Add(i.ToString());
            }
            YearComboBox.Items.Add("All Years");
            
            MonthComboBox.SelectedIndex = _selectedMonth - 1;

            //_isInitializationCall = true will prevent calling PlotDailyInfo() method
            //a second time which is called when index of month or year combobox is changed
            _isInitializationCall = true;
            YearComboBox.SelectedIndex = YearComboBox.Items.IndexOf(_selectedYear.ToString());           
        }

        private void ThisFormShown(object sender, EventArgs e)
        {
            if (GlobalSpace.MonthlyInfoList.Count < 1)
            {
                //if there's no data to show
                string message = "Currently you do not have any saved information to appear on this page. " +
                        "Add your today's earning and expense and see the magic happen. Ready?";

                DialogResult userResponse = MessageBox.Show(message, "Message",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (userResponse == DialogResult.Yes)
                {
                    AddNewDataButton.PerformClick();
                }
            }
        }

        private void MonthComboBoxIndexChanged(object sender, EventArgs e)
        {
            _selectedMonth = MonthComboBox.SelectedIndex + 1;
            PlotDailyInfo();
        }

        private void YearComboBoxIndexChanged(object sender, EventArgs e)
        {
            if(int.TryParse(YearComboBox.SelectedItem.ToString(), out int year))
            {
                _selectedYear = year;
            }
            else
            {
                _selectedYear = 0;
            }

            if (!_isInitializationCall)
            {
                PlotDailyInfo();
            }
            else
            {
                _isInitializationCall = false;
            }
        }

        private void DataGridViewCellDoubleClicked(object sender, DataGridViewCellEventArgs e)
        {
            string[] date = MonthlyReportDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString().Split(' ');
            int day = Convert.ToInt32(date[0]);
            int month = _monthList.IndexOf(date[1].Replace(",", "")) + 1;
            int year = Convert.ToInt32(date[2]);

            OpenNewForm(new AddNewDataForm(day, month, year));
        }

        private void DeleteButtonClicked(object sender, EventArgs e)
        {
            //sending true as argument removes the rows from this dataGridView manually
            //since clicking on delete button doesn't automatically remove any row
            DeleteDailyInfo(true);
        }

        private void DataGridViewUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;

            DeleteDailyInfo(true);
        }

        private void MenuButtonsClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Name == "HomeButton")
            {
                OpenNewForm(new MainForm());
            }
            else if (button.Name == "AddNewDataButton")
            {
                OpenNewForm(new AddNewDataForm());
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

        private void EditButtonClicked(object sender, EventArgs e)
        {
            if(MonthlyReportDataGridView.SelectedRows.Count == 1)
            {
                int rowIndex = MonthlyReportDataGridView.CurrentCell.RowIndex;
                int day = Convert.ToInt32(MonthlyReportDataGridView.Rows[rowIndex].Cells[0].Value.ToString().Split(' ')[0]);
                int month = _selectedMonth;
                int year = _selectedYear;

                OpenNewForm(new AddNewDataForm(day, month, year));
            }
            else if (MonthlyReportDataGridView.SelectedRows.Count > 1)
            {
                string message = "You cannot select more than one row at a time for edit.";

                MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                string message = "No row is selected. Select a row to edit.";

                MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DateSearchTextBox_Click(object sender, EventArgs e)
        {
            if(DateSearchTextBox.ForeColor != Color.Black)
            {
                DateSearchTextBox.ForeColor = Color.Black;
                DateSearchTextBox.Text = "";
            }
        }

        private void DateSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            PlotDailyInfo();
        }

        private void NoteSearchTextBox_Click(object sender, EventArgs e)
        {
            if (NoteSearchTextBox.ForeColor != Color.Black)
            {
                NoteSearchTextBox.ForeColor = Color.Black;
                NoteSearchTextBox.Text = "";
            }
        }

        private void NoteSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            PlotDailyInfo();
        }

        private void EarningSearchTextBox_Click(object sender, EventArgs e)
        {
            if (EarningSearchTextBox.ForeColor != Color.Black)
            {
                EarningSearchTextBox.ForeColor = Color.Black;
                EarningSearchTextBox.Text = "";
            }
        }

        private void EarningSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            PlotDailyInfo();
        }

        private void ExpenseSearchTextBox_Click(object sender, EventArgs e)
        {
            if (ExpenseSearchTextBox.ForeColor != Color.Black)
            {
                ExpenseSearchTextBox.ForeColor = Color.Black;
                ExpenseSearchTextBox.Text = "";
            }
        }

        private void ExpenseSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            PlotDailyInfo();
        }

        private void ThisFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_quitAppOnFormClosing)
            {
                Application.Exit();
            }
        }
        #endregion

        #region General Private Methods

        private void InitializeMonthList()
        {
            //monthList is used to convert month from numeric to text, ex: 1 -> January
            _monthList = new List<string>();
            _monthList.Add("January");
            _monthList.Add("February");
            _monthList.Add("March");
            _monthList.Add("April");
            _monthList.Add("May");
            _monthList.Add("June");
            _monthList.Add("July");
            _monthList.Add("August");
            _monthList.Add("September");
            _monthList.Add("October");
            _monthList.Add("November");
            _monthList.Add("December");
        }

        private void PlotDailyInfo()
        {
            MonthlyReportDataGridView.Rows.Clear();

            HeaderLabel.Text = "Showing monthly information for ";
            HeaderLabel.Text += (_selectedMonth <= 12?_monthList[_selectedMonth - 1] : "all months of") + 
                " " + (_selectedYear != 0? _selectedYear.ToString(): " all years");
            
            List<DailyInfo> dailyInfoList;

            if(_selectedYear == 0 && _selectedMonth == 13)
            {
                //if user selected all years and all months
                dailyInfoList = GlobalSpace.DailyInfoList.ToList();
                dailyInfoList = dailyInfoList.OrderBy(d => d.Day).ToList();
                dailyInfoList = dailyInfoList.OrderBy(d => d.Month).ToList();
                dailyInfoList = dailyInfoList.OrderBy(d => d.Year).ToList();               
            }
            else if(_selectedYear == 0 && _selectedMonth != 13)
            {
                //if user selected all years and a specific month
                dailyInfoList = GlobalSpace.DailyInfoList.FindAll(d => d.Month == _selectedMonth).ToList();
                dailyInfoList = dailyInfoList.OrderBy(d => d.Day).ToList();
                dailyInfoList = dailyInfoList.OrderBy(d => d.Year).ToList();
            }
            else if (_selectedYear != 0 && _selectedMonth == 13)
            {
                //if user selected a specific year and all months
                dailyInfoList = GlobalSpace.DailyInfoList.FindAll(d => d.Year == _selectedYear).ToList();
                dailyInfoList = dailyInfoList.OrderBy(d => d.Day).ToList();
                dailyInfoList = dailyInfoList.OrderBy(d => d.Month).ToList();
            }
            else
            {
                //if user selected a specific month and a specific year
                dailyInfoList = GlobalSpace.DailyInfoList.FindAll(
                d => d.Month == _selectedMonth && d.Year == _selectedYear).ToList();
                dailyInfoList = dailyInfoList.OrderBy(d => d.Day).ToList();
            }                   

            foreach (DailyInfo daily in dailyInfoList)
            {
                string date = daily.Day + " " + _monthList[daily.Month - 1] + ", " + daily.Year.ToString();
                bool addRow = true;

                //check for filtering by date
                if (DateSearchTextBox.ForeColor == Color.Black 
                    && DateSearchTextBox.Text.Length > 0)
                {
                   if(!date.ToLower().Contains(DateSearchTextBox.Text.ToLower()))
                    {
                        addRow = false;
                    }
                }

                //check for filtering by note
                if (NoteSearchTextBox.ForeColor == Color.Black
                    && NoteSearchTextBox.Text.Length > 0)
                {
                    if (!daily.Note.ToLower().Contains(NoteSearchTextBox.Text.ToLower()))
                    {
                        addRow = false;
                    }
                }

                //check for filtering by earning
                if (EarningSearchTextBox.ForeColor == Color.Black
                    && EarningSearchTextBox.Text.Length > 0)
                {
                    if (!daily.TotalEarning.ToString().Equals(EarningSearchTextBox.Text))
                    {
                        addRow = false;
                    }
                }

                //check for filtering by expense
                if (ExpenseSearchTextBox.ForeColor == Color.Black
                    && ExpenseSearchTextBox.Text.Length > 0)
                {
                    if (!daily.TotalExpense.ToString().Equals(ExpenseSearchTextBox.Text))
                    {
                        addRow = false;
                    }
                }

                if(addRow)
                {
                    MonthlyReportDataGridView.Rows.Add(date, daily.Note, daily.TotalEarning.ToString(), daily.TotalExpense.ToString());
                }
            }

            if(MonthlyReportDataGridView.Rows.Count > 0)
            {
                MonthlyReportDataGridView.Rows[0].Cells[0].Selected = false;

                UpdateTotalEarningAndExpenseLabel();
            }          
        }

        private void DeleteDailyInfo(bool manuallyRemoveRow = false)
        {
            string message = "Selected information will be permanently deleted. " +
                "Are you sure you want to delete the selected information?";

            DialogResult userResponse = MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(userResponse == DialogResult.No)
            {
                return;
            }

            foreach (DataGridViewRow row in MonthlyReportDataGridView.SelectedRows)
            {
                string[] date = row.Cells[0].Value.ToString().Split(' ');
                int day = Convert.ToInt32(date[0]);
                int month = _monthList.IndexOf(date[1].Replace(",", "")) + 1;
                int year = Convert.ToInt32(date[2]);

                string result = WebHandler.DeleteDailyInfo(day, month, year);

                if (result == "SUCCESS")
                {
                    if (manuallyRemoveRow)
                    {
                        //when we delete a row on click of delete button
                        //that doesn't automatically remove that row from dataGridView
                        //so we need to manually remove it
                        MonthlyReportDataGridView.Rows.RemoveAt(row.Index);
                    }

                    GlobalSpace.DailyInfoList.RemoveAll(
                        d => d.Day == day && d.Month == month && d.Year == year);                    
                }
                else
                {
                    //if the deleting doesn't succeed, the error info is returned
                    MessageBox.Show("Something went wrong! Please check your internet connection and try again.", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //monthly info should change accordingly since daily info has been modified
            MonthlyInfo.Fetch();

            UpdateTotalEarningAndExpenseLabel();
        }

        private void OpenNewForm(Form form)
        {
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();
        }

        private void UpdateTotalEarningAndExpenseLabel()
        {
            double earning, totalEarning = 0.0;
            double expense, totalExpense = 0.0;

            foreach(DataGridViewRow row in MonthlyReportDataGridView.Rows)
            {
                if(double.TryParse(row.Cells[2].Value.ToString(), out earning))
                {
                    totalEarning += earning;
                }
                
                if(double.TryParse(row.Cells[3].Value.ToString(), out expense))
                {
                    totalExpense += expense;
                }
            }

            TotalEarningLabel.Text = string.Format("${0:00}", totalEarning);
            TotalExpenseLabel.Text = string.Format("${0:00}", totalExpense);
        }
        #endregion
    }
}
