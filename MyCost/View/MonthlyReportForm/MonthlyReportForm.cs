﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using MyCost.Common;
using MyCost.Common.WebHandler;

namespace MyCost.View
{
    public partial class MonthlyReportForm : Form
    {
        private int _selectedMonth;
        private int _selectedYear;

        private bool _quitAppOnFormClosing;

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

        #region event_handler_methods

        private void ThisFormLoading(object sender, EventArgs e)
        {
            for (int i = 2018; i <= _selectedYear + 3; i++)
            {
                yearComboBox.Items.Add(i.ToString());
            }
            
            monthComboBox.SelectedIndex = _selectedMonth - 1;
            yearComboBox.SelectedIndex = yearComboBox.Items.IndexOf(_selectedYear.ToString());           
        }

        private void MonthComboBoxIndexChanged(object sender, EventArgs e)
        {
            _selectedMonth = monthComboBox.SelectedIndex + 1;
            PlotDailyInfo();
        }

        private void YearComboBoxIndexChanged(object sender, EventArgs e)
        {
            _selectedYear = Convert.ToInt32(yearComboBox.SelectedItem.ToString());
            PlotDailyInfo();
        }

        private void DataGridViewCellDoubleClicked(object sender, DataGridViewCellEventArgs e)
        {
            int day = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString().Split(' ')[0]);
            int month = _selectedMonth;
            int year = _selectedYear;

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
            DeleteDailyInfo();
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
            {
                OpenNewForm(new MainForm());
            }
            else if (button.Name == "addNewDataButton")
            {
                OpenNewForm(new AddNewDataForm());
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

        private void ThisFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_quitAppOnFormClosing)
            {
                Application.Exit();
            }
        }
        #endregion

        #region non_event_handler_methods

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
            dataGridView.Rows.Clear();

            HeaderLabel.Text = "Showing monthly information for ";
            HeaderLabel.Text += _monthList[_selectedMonth - 1] + " " + _selectedYear.ToString();

            int numberOfDays = GetNumberOfDays();
            
            List<DailyInfo> dailyInfoList = StaticStorage.DailyInfoList.FindAll(
                d => d.Month == _selectedMonth && d.Year == _selectedYear);

            //plot info sorted in ascending order
            for (int day = 1; day <= numberOfDays; day++)
            {
                DailyInfo daily = dailyInfoList.Find(d => d.Day == day);

                if(daily != null)
                {
                    string date = daily.Day + " " + _monthList[_selectedMonth - 1] + ", " + _selectedYear.ToString();
                    dataGridView.Rows.Add(date, daily.Note, daily.TotalEarning.ToString(), daily.TotalExpense.ToString());
                }
            }

            if(dataGridView.Rows.Count > 0)
            {
                dataGridView.Rows[0].Cells[0].Selected = false;
            }          
        }

        private int GetNumberOfDays()
        {
            //calculates the number of days according to month
            if (_selectedMonth == 2 && DateTime.IsLeapYear(_selectedYear))
            {
                return 29;
            }
            else if (_selectedMonth == 2 && !DateTime.IsLeapYear(_selectedYear))
            {
                return 28;
            }
            else if (_selectedMonth <= 7 && _selectedMonth % 2 == 1)
            {
                return 31;
            }
            else if (_selectedMonth <= 7 && _selectedMonth % 2 == 0)
            {
                return 30;
            }
            else if (_selectedMonth > 7 && _selectedMonth % 2 == 1)
            {
                return 30;
            }
            else
            {
                return 31;
            }
        }

        private void DeleteDailyInfo(bool manuallyRemoveRow = false)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                int day = Convert.ToInt32(dataGridView.Rows[row.Index].Cells[0].Value.ToString().Split(' ')[0]);

                string result = WebHandler.DeleteDailyInfo(day, _selectedMonth, _selectedYear);

                if (result == "SUCCESS")
                {
                    if (manuallyRemoveRow)
                    {
                        //when we delete a row on click of delete button
                        //that doesn't automatically remove that row from dataGridView
                        //so we need to manually remove it
                        dataGridView.Rows.RemoveAt(row.Index);
                    }

                    StaticStorage.DailyInfoList.RemoveAll(
                        d => d.Day == day && d.Month == _selectedMonth && d.Year == _selectedYear);

                    //monthly info should change accordingly since daily info has been modified
                    MonthlyInfo.Fetch();
                }
                else
                {
                    //if the deleting doesn't succeed, the error info is returned
                    MessageBox.Show(result);
                }
            }
        }

        private void OpenNewForm(Form form)
        {
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();
        }
        #endregion
    }
}