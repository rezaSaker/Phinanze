using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MyCost.Common;

namespace MyCost.View
{
    public partial class MainForm : Form
    {
        private int _selectedYear;

        private bool _quitAppOnFormClosing;
        private bool _isNewSession;
        private bool _isFirstCall;

        private List<string> _monthList;
                                                    
        public MainForm(bool isNewSession = false)
        {
            InitializeComponent();

            _quitAppOnFormClosing = true;
            _isNewSession = isNewSession;
            _isFirstCall = true;
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

            BarChart.Series["Earning"].Color = Color.YellowGreen;
            BarChart.Series["Expense"].Color = Color.DarkOrange;

            for (int year = 2018; year <= _selectedYear + 3; year++)
            {
                YearComboBox.Items.Add(year.ToString());
            }

            YearComboBox.SelectedIndex = 0;
            VersionLabel.Text = "Version: " + Application.ProductVersion;

            _isFirstCall = false;
        }

        private void ThisFormShown(object sender, EventArgs e)
        {
            //prompt user to verify email
            if(!GlobalSpace.IsEmailVarified && _isNewSession)
            {
                EmailVerificationForm form = new EmailVerificationForm();
                form.FormClosingEventHandler += EmailVerificationFormClosed;
                form.Location = new Point(this.Location.X + 153, this.Location.Y + 120);
                form.Show();
            }
            else if (GlobalSpace.MonthlyInfoList.Count < 1)
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

        private void EmailVerificationFormClosed(object sender, EventArgs e)
        {
            if (GlobalSpace.MonthlyInfoList.Count < 1)
            {
                //if there's no data to show
                string message = "Currently you do not have any saved information to appear on this page. " +
                        "Add your today's earning and expense and see the magic happen. Are you ready?";

                DialogResult userResponse = MessageBox.Show(message, "Message",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (userResponse == DialogResult.Yes)
                {
                    AddNewDataButton.PerformClick();
                }
            }
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

            if (!_isFirstCall && GlobalSpace.MonthlyInfoList.Count < 1)
            {
                //if there's no data to show
                string message = "Currently you do not have any saved information to appear on this page. " +
                        "Add your today's earning and expense and see the magic happen. Are you ready?";

                DialogResult userResponse = MessageBox.Show(message, "Message",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (userResponse == DialogResult.Yes)
                {
                    AddNewDataButton.PerformClick();
                }
            }
            else if (!_isFirstCall && HomeDataGridView.Rows.Count < 1)
            {
                string message = "Currently you do not have any saved information for " + _selectedYear + ".";

                DialogResult userResponse = MessageBox.Show(message, "Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }             

        private void DataGridViewCellDoubleClicked(object sender, DataGridViewCellEventArgs e)
        {
            int year = Convert.ToInt32(HomeDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            int month = _monthList.IndexOf(HomeDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()) + 1;

            OpenNewForm(new MonthlyReportForm(month, year));           
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
            ResetAllDataFields();          

            int rowIndex = 0;

            double totalEarning = 0.0;
            double totalExpense = 0.0;

            //initializing each month.s earning and expense with 0.0
            Dictionary<string, double> totalEarningDictionary = new Dictionary<string, double>()
            {
                {"January", 0.0 }, {"February", 0.0 }, {"March", 0.0 }, {"April", 0.0 },
                {"May", 0.0 }, {"June", 0.0 }, {"July", 0.0 }, {"August", 0.0 },
                {"September", 0.0 }, {"October", 0.0 }, {"November", 0.0 }, {"December", 0.0 }
            };

            Dictionary<string, double> totalExpenseDictionary = new Dictionary<string, double>()
            {
                {"January", 0.0 }, {"February", 0.0 }, {"March", 0.0 }, {"April", 0.0 },
                {"May", 0.0 }, {"June", 0.0 }, {"July", 0.0 }, {"August", 0.0 },
                {"September", 0.0 }, {"October", 0.0 }, {"November", 0.0 }, {"December", 0.0 }
            };

            Dictionary<string, string> condensedMonthListDictionary = new Dictionary<string, string>()
            {
                {"January", "JAN" }, {"February", "FEB" }, {"March", "MAR" }, {"April", "APR" },
                {"May", "MAY" }, {"June", "JUN" }, {"July", "JUL" }, {"August", "AUG" },
                {"September", "SEP" }, {"October", "OCT" }, {"November", "NOV" }, {"December", "DEC" }
            };

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

                    //Add up earning and expense for same months of all years
                    //and plot them on the bar chart at the end of this method
                    totalEarningDictionary[month] += monthly.Earning;
                    totalExpenseDictionary[month] += monthly.Expense;

                    //add up all earning and expense for the pie chart
                    totalEarning += monthly.Earning;
                    totalExpense += monthly.Expense;

                    rowIndex++;
                }
                else if (_selectedYear == monthly.Year)
                {
                    // show info only for selected year
                    HomeDataGridView.Rows.Add(year, month, earning, expense);
                    ShowOverview(monthly, rowIndex);

                    //Add up earning and expense for same months of all years
                    //and plot them on the bar chart at the end of this method
                    totalEarningDictionary[month] += monthly.Earning;
                    totalExpenseDictionary[month] += monthly.Expense;

                    //add up all earning and expense for the pie chart
                    totalEarning += monthly.Earning;
                    totalExpense += monthly.Expense;

                    rowIndex++;
                }             
            }

            if(HomeDataGridView.Rows.Count > 0)
            {
                HomeDataGridView.Rows[0].Cells[0].Selected = false;
            }

            //plot the data in the bar chart
            foreach (KeyValuePair<string, double> earning in totalEarningDictionary)
            {
                AddDataToBarChart("Earning", condensedMonthListDictionary[earning.Key], earning.Value);
            }

            foreach (KeyValuePair<string, double> expense in totalExpenseDictionary)
            {
                AddDataToBarChart("Expense", condensedMonthListDictionary[expense.Key], expense.Value);
            }

            //plot the pie chart
            if(totalEarning > 0)
            {
                DataPoint point1 = new DataPoint();
                point1.Color = Color.YellowGreen;
                point1.LabelForeColor = Color.White;
                point1.ToolTip = String.Format("Total Earning: ${0:00}", totalEarning);
                point1.SetValueXY("Earning", totalEarning);
                PieChart.Series["Series1"].Points.Add(point1);
            }

            if(totalExpense > 0)
            {
                DataPoint point2 = new DataPoint();
                point2.Color = Color.DarkOrange;
                point2.LabelForeColor = Color.White;
                point2.ToolTip = String.Format("Total Expense: ${0:00}", totalExpense);
                point2.SetValueXY("Expense", totalExpense);
                PieChart.Series["Series1"].Points.Add(point2);
            }

            if(totalEarning > totalExpense)
            {
                double savings = totalEarning - totalExpense;
                savings = savings > 0 ? savings : 0.00;
                DataPoint point3 = new DataPoint();
                point3.Color = Color.CornflowerBlue;
                point3.LabelForeColor = Color.White;
                point3.ToolTip = String.Format("Total Savings: ${0:00}", savings);
                point3.SetValueXY("Savings", savings);
                PieChart.Series["Series1"].Points.Add(point3);
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

        private void AddDataToBarChart(string seriesName, string month, double value)
        {
            DataPoint point = new DataPoint();
            point.SetValueXY(month, value);
            point.ToolTip = String.Format("${0:00}", value);
            BarChart.Series[seriesName].Points.Add(point);
        }

        private void ResetAllDataFields()
        {
            //clear dataGridView
            HomeDataGridView.Rows.Clear();

            //clear bar chart
            BarChart.Series["Earning"].Points.Clear();
            BarChart.Series["Expense"].Points.Clear();

            //clear pie chart
            PieChart.Series["Series1"].Points.Clear();
        }
        #endregion
    }
}
