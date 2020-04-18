using System;
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

        #region UI EventHandler Methods

        private void ThisFormLoading(object sender, EventArgs e)
        {             
            MonthlyInfo.Fetch();

            for (int year = 2018; year <= _selectedYear + 3; year++)
            {
                YearComboBox.Items.Add(year.ToString());
            }

            YearComboBox.SelectedIndex = 0;
            VersionLabel.Text = "Version: " + Application.ProductVersion;
        }

        private void YearComboBoxIndexChanged(object sender, EventArgs e)
        {
            if (YearComboBox.SelectedItem.ToString() == "All years")
            {
                _selectedYear = 0;
            }
            else
            {
                _selectedYear = Convert.ToInt32(YearComboBox.SelectedItem.ToString());
            }

            PlotMonthlyInfo();
        }             

        private void DataGridViewCellDoubleClicked(object sender, DataGridViewCellEventArgs e)
        {
            int year = Convert.ToInt32(HomeDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            int month = _monthList.IndexOf(HomeDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()) + 1;

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

            if (button.Name == "AddNewDataButton")
            {
                OpenNewForm(new AddNewDataForm());
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


        private void ThisFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_quitAppOnFormClosing)
            {
                Application.Exit();
            }
        }
        #endregion

        #region General Private Methods

        private void PlotMonthlyInfo()
        {
            HomeDataGridView.Rows.Clear();

            int rowIndex = 0;

            foreach (MonthlyInfo monthly in GlobalSpace.MonthlyInfoList)
            {
                string year = monthly.Year.ToString();
                string month = _monthList[monthly.Month - 1];
                string earning = monthly.Earning.ToString();
                string expense = monthly.Expense.ToString();

                if (_selectedYear == 0)
                {
                    //show info for all years
                    HomeDataGridView.Rows.Add(year, month, earning, expense);
                    ShowOverview(monthly, rowIndex);
                }
                else if (_selectedYear == monthly.Year)
                {
                    // show info only for selected year
                    HomeDataGridView.Rows.Add(year, month, earning, expense);
                    ShowOverview(monthly, rowIndex);
                }
                rowIndex++;
            }

            if(HomeDataGridView.Rows.Count > 0)
            {
                HomeDataGridView.Rows[0].Cells[0].Selected = false;
            }            
        }

        private void ShowOverview(MonthlyInfo monthly, int row)
        {
            //add an overview for that month on the last column of dataGridView
            if (monthly.Earning < monthly.Expense)
            {
                HomeDataGridView.Rows[row].Cells[4].Style.ForeColor = Color.Red;
                HomeDataGridView.Rows[row].Cells[4].Value = "Negative";

            }
            else if (monthly.Earning > monthly.Expense)
            {
                HomeDataGridView.Rows[row].Cells[4].Style.ForeColor = Color.Green;
                HomeDataGridView.Rows[row].Cells[4].Value = "Positive";
            }
            else
            {
                HomeDataGridView.Rows[row].Cells[4].Style.ForeColor = Color.OrangeRed;
                HomeDataGridView.Rows[row].Cells[4].Value = "Neutral";
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
