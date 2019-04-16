using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyCost.Common;
using MyCost.ServerHandling;

namespace MyCost.Forms
{
    public partial class MonthlyInfoForm : Form
    {
        private int _selectedMonth;
        private int _selectedYear;

        private bool _firstInitializationCall;
        private bool _quitAppOnFormClosing;

        private List<string> _monthList;

        public MonthlyInfoForm()
        {
            InitializeComponent();

            _selectedMonth = DateTime.Now.Month;
            _selectedYear = DateTime.Now.Year;

            InitializeMonthList();
        }

        public MonthlyInfoForm(int month, int year)
        {
            InitializeComponent();

            _selectedMonth = month;
            _selectedYear = year;

            InitializeMonthList();
        }

        private void InitializeMonthList()
        {
            //monthList is used to convert numeric month to month text
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

        private void MonthlyInfoFormLoading(object sender, EventArgs e)
        {
            //adds years to yearComboBox
            for (int i = 2018; i <= _selectedYear + 10; i++)
            {
                yearComboBox.Items.Add(i.ToString());
            }

            //changing selctedIndex in comboBox results in calling of PlotData()
            //since we change selectedIndex in this loader method twice it will call that method twice
            //to avoid that redundancy we will check with a boolean if it is the first initialization call
            _firstInitializationCall = true;

            monthComboBox.SelectedIndex = _selectedMonth - 1;
            yearComboBox.SelectedIndex = yearComboBox.Items.IndexOf(_selectedYear.ToString());

            _firstInitializationCall = false;
        }

        private void MonthlyInfoFormShow(object sender, EventArgs e)
        {
            _quitAppOnFormClosing = true;
        }

        private void MonthComboBoxIndexChanged(object sender, EventArgs e)
        {
            _selectedMonth = monthComboBox.SelectedIndex + 1;

            //plot data for the newly selected month
            PlotData();
        }

        private void YearComboBoxIndexChanged(object sender, EventArgs e)
        {
            _selectedYear = Convert.ToInt32(yearComboBox.SelectedItem.ToString());

            //if it is first initialization call, then the appropriate data is already plotted
            //otherwise, if the yearComboBox index is changed later by user,
            //then we need to plot data again for the selected year
            if (!_firstInitializationCall)
            {
                //plot data for newly selected year
                PlotData();
            }
        }

        private void PlotData()
        {
            HeaderLabel.Text = "Showing daily information for ";
            HeaderLabel.Text += _monthList[_selectedMonth - 1] + " " + _selectedYear.ToString();

            //remove previous data
            dataGridView.Rows.Clear();

            string date;

            //plot new for newly selected month and year
            foreach(DailyInfo daily in StaticStorage.DailyInfo)
            {
                if(_selectedMonth == daily.Month && _selectedYear == daily.Year)
                {
                    date = daily.Day + " " + _monthList[_selectedMonth - 1] + ", " + _selectedYear.ToString();

                    dataGridView.Rows.Add(date, daily.Note, daily.TotalEarning.ToString(), daily.TotalExpense.ToString());
                }
            }
        }

        private void DataGridViewCellDoubleClicked(object sender, DataGridViewCellEventArgs e)
        {
            int day = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString().Split(' ')[0]);
            int month = _selectedMonth;
            int year = _selectedYear;

            DailyInfoForm form = new DailyInfoForm(day, month, year, this);
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Hide();
        }

        private void CancelButtonClicked(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();
        }

        private void AddnewDataButtonClicked(object sender, EventArgs e)
        {
            addNewButton.PerformClick();
        }

        private void AddnewButtonClicked(object sender, EventArgs e)
        {
            DailyInfoForm form = new DailyInfoForm(this);
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Hide();
        }

        private void HomeButtonClicked(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();
        }

        private void StatisticalReportButtonClicked(object sender, EventArgs e)
        {
            StatisticalReportForm form = new StatisticalReportForm(this);
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Hide();
        }

        private void SettingsButtonClicked(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(this);
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Hide();
        }

        private void LogOutButtonClicked(object sender, EventArgs e)
        {
            //this will opt out from direct login option that occurs when remember me checkbox is checked
            Properties.Settings.Default.Username = null;
            Properties.Settings.Default.Password = null;
            Properties.Settings.Default.Save();

            UserAuthenticationForm form = new UserAuthenticationForm();
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();
        }

        private void MonthlyInfoFormClosing(object sender, FormClosingEventArgs e)
        {
            if(_quitAppOnFormClosing)
            {
                Application.Exit();
            }
        }

        private void DeleteButtonClicked(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView.SelectedRows)
            {
                int day = Convert.ToInt32(dataGridView.Rows[row.Index].Cells[0].Value.ToString().Split(' ')[0]);

                string result = ServerHandler.DeleteDailyInfo(day, _selectedMonth, _selectedYear);

                if(result != "SUCCESS")
                {
                    MessageBox.Show(result);
                }
                else
                {
                    dataGridView.Rows.Remove(row);

                    foreach (DailyInfo daily in StaticStorage.DailyInfo)
                    {
                        if (daily.Day == day && daily.Month == _selectedMonth && daily.Year == _selectedYear)
                        {
                            StaticStorage.DailyInfo.Remove(daily);
                        }
                    }
                }
            }
        }

        private void DataGridViewUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int day = Convert.ToInt32(dataGridView.Rows[e.Row.Index].Cells[0].Value.ToString().Split(' ')[0]);

            ServerHandler.DeleteDailyInfo(day, _selectedMonth, _selectedYear);
        }
    }
}
