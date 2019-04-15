using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCost
{
    public partial class MainForm : Form
    {
        private int _selectedYear;

        private bool _quitAppOnFormClosing;

        private List<string> _monthList;

        private Form _callerForm;
                                                    
        public MainForm()
        {
            InitializeComponent();

            _quitAppOnFormClosing = true;

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

        private void HomePageLoaded(object sender, EventArgs e)
        {          
            versionLabel.Text = "Version: " + Application.ProductVersion;

            for(int year = 2018; year <= DateTime.Now.Year; year++)
            {
                YearComboBox.Items.Add(year.ToString());
            }

            YearComboBox.SelectedIndex = 0;
        }

        private void YearComboBoxIndexChanged(object sender, EventArgs e)
        {
            if(YearComboBox.SelectedItem.ToString() == "All years")
            {
                _selectedYear = 0;
            }
            else
            {
                _selectedYear = Convert.ToInt32(YearComboBox.SelectedItem.ToString());
            }

            PlotMonthlyInfo();
        }

        private void PlotMonthlyInfo()
        {
            dataGridView.Rows.Clear();

            StaticStorage.FetchMonthlyInfo();

            int row = 0;

            foreach (Monthly monthly in StaticStorage.MonthlyInfo)
            {
                string year = monthly.Year.ToString();
                string month = _monthList[monthly.Month - 1];
                string earning = monthly.Earning.ToString();
                string expense = monthly.Expense.ToString();

                if(_selectedYear == 0)//show info for all years
                {
                    //adds year, month, earning and expense in the first four columns of the dataGridView
                    dataGridView.Rows.Add(year, month, earning, expense);

                    //add an overview for the month on last column
                    ShowFinancialOverviewPerRow(monthly, row);

                    row++;
                }
                else if(_selectedYear == monthly.Year)// show info only for selected year
                {
                    //adds year, month, earning and expense in the first four columns of the dataGridView
                    dataGridView.Rows.Add(year, month, earning, expense);

                    //add an overview for the month on last column
                    ShowFinancialOverviewPerRow(monthly, row);

                    row++;
                }
            }
        }

        private void ShowFinancialOverviewPerRow(Monthly monthly, int row)
        {
            //adds the overview to the last column according to the earning and expense
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
                dataGridView.Rows[row].Cells[4].Style.ForeColor = Color.Yellow;
                dataGridView.Rows[row].Cells[4].Value = "neutral";
            }
        }

        private void AddNewDataButtonClicked(object sender, EventArgs e)
        {
            DailyInfoForm form = new DailyInfoForm(this);
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Hide();
        }

        private void DataGridViewCellDoubleClicked(object sender, DataGridViewCellEventArgs e)
        {
            int year = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            int month = _monthList.IndexOf(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()) + 1;

            MonthlyInfoForm form = new MonthlyInfoForm(month, year);
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();
        }

        private void ShowMonthlyInfoButtonClicked(object sender, EventArgs e)
        {
            MonthlyInfoForm form = new MonthlyInfoForm();
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();
        }

        private void StatisticsButtonClicked(object sender, EventArgs e)
        {
            StatisticalReportForm form = new StatisticalReportForm(this);
            form.Location = this.Location;
            form.Show();

            _quitAppOnFormClosing = false;
            this.Hide();
        }

        private void LogOutButtonClicked(object sender, EventArgs e)
        {
            UserAuthenticationForm form = new UserAuthenticationForm();
            form.Show();

            _quitAppOnFormClosing = false;
            this.Close();
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_quitAppOnFormClosing)
            {
                Application.Exit();
            }
        }
    }
}
