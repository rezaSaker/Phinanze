﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using MyCost.Common;

namespace MyCost.View
{
    public partial class MainForm : Form
    {
        private int _selectedYear;

        private bool _quitAppOnFormClosing;

        private List<string> _monthList;
                                                    
        public MainForm()
        {
            InitializeComponent();

            _quitAppOnFormClosing = true;
            _selectedYear = DateTime.Now.Year;

            //monthList is used to convert months from numeric to text, Ex: 1 -> january
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

        #region event_handler_methods

        private void ThisFormLoading(object sender, EventArgs e)
        {             
            MonthlyInfo.Fetch();

            for (int year = 2018; year <= _selectedYear + 3; year++)
            {
                yearComboBox.Items.Add(year.ToString());
            }

            yearComboBox.SelectedIndex = 0;
            versionLabel.Text = "Version: " + Application.ProductVersion;
        }

        private void YearComboBoxIndexChanged(object sender, EventArgs e)
        {
            if (yearComboBox.SelectedItem.ToString() == "All years")
            {
                _selectedYear = 0;
            }
            else
            {
                _selectedYear = Convert.ToInt32(yearComboBox.SelectedItem.ToString());
            }

            PlotMonthlyInfo();
        }             

        private void DataGridViewCellDoubleClicked(object sender, DataGridViewCellEventArgs e)
        {
            int year = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            int month = _monthList.IndexOf(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()) + 1;

            OpenNewForm(new MonthlyReportForm(month, year));           
        }
                          
        private void MenuButtonsMouseHovering(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.White;
            button.BackColor = Color.ForestGreen;
        }

        private void MenuButtonsMouseLeaving(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.ForestGreen;
            button.BackColor = Color.White;
        }

        private void MenuButtonsClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Name == "addNewDataButton")
            {
                OpenNewForm(new AddNewDataForm());
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


        private void ThisFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_quitAppOnFormClosing)
            {
                Application.Exit();
            }
        }
        #endregion

        #region non_event_handler_methods

        private void PlotMonthlyInfo()
        {
            dataGridView.Rows.Clear();

            int rowIndex = 0;

            foreach (MonthlyInfo monthly in StaticStorage.MonthlyInfoList)
            {
                string year = monthly.Year.ToString();
                string month = _monthList[monthly.Month - 1];
                string earning = monthly.Earning.ToString();
                string expense = monthly.Expense.ToString();

                if (_selectedYear == 0)
                {
                    //show info for all years
                    dataGridView.Rows.Add(year, month, earning, expense);
                    ShowOverview(monthly, rowIndex);
                }
                else if (_selectedYear == monthly.Year)
                {
                    // show info only for selected year
                    dataGridView.Rows.Add(year, month, earning, expense);
                    ShowOverview(monthly, rowIndex);
                }
                rowIndex++;
            }

            if(dataGridView.Rows.Count > 0)
            {
                dataGridView.Rows[0].Cells[0].Selected = false;
            }            
        }

        private void ShowOverview(MonthlyInfo monthly, int row)
        {
            //add an overview for that month on the last column of dataGridView
            if (monthly.Earning < monthly.Expense)
            {
                dataGridView.Rows[row].Cells[4].Style.ForeColor = Color.Red;
                dataGridView.Rows[row].Cells[4].Value = "Negative";

            }
            else if (monthly.Earning > monthly.Expense)
            {
                dataGridView.Rows[row].Cells[4].Style.ForeColor = Color.Green;
                dataGridView.Rows[row].Cells[4].Value = "Positive";
            }
            else
            {
                dataGridView.Rows[row].Cells[4].Style.ForeColor = Color.OrangeRed;
                dataGridView.Rows[row].Cells[4].Value = "Neutral";
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