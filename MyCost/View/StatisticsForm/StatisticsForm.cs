using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using MyCost.Common;

namespace MyCost.View
{
    public partial class StatisticsForm: Form
    {
        private int _selectedYear;
        private int _selectedMonth;

        private bool _quitAppOnFormClosing;

        private string[] _monthNames = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN",
                                        "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };

        public StatisticsForm()
        {
            InitializeComponent();

            _selectedMonth = DateTime.Now.Month;
            _selectedYear = DateTime.Now.Year;
            _quitAppOnFormClosing = true;
        }

        #region UI EventHandler Methods

        private void ThisFormLoading(object sender, EventArgs e)
        {
            MonthComboBox.Enabled = false;
            ShowYearlyReportRadioButton.Checked = true;
            ShowBothEarningAndExpenseReportRadioButton.Checked = true;
            ShowGeneralReportRadioButton.Checked = true;
            YearlyReportChart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            YearlyReportChart.Series["earning"].Color = Color.YellowGreen;
            YearlyReportChart.Series["expense"].Color = Color.OrangeRed;
            MonthlyReportChart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            MonthlyReportChart.Series["earning"].Color = Color.YellowGreen;
            MonthlyReportChart.Series["expense"].Color = Color.OrangeRed;

            for (int year = 2018; year <= _selectedYear + 3; year++)
            {
                YearComboBox.Items.Add(year.ToString());
            }
            YearComboBox.SelectedIndex = YearComboBox.Items.IndexOf(_selectedYear.ToString());
        }

        private void YearComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedYear = Convert.ToInt32(YearComboBox.SelectedItem.ToString());
            ShowReports();
        }

        private void MonthComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedMonth = MonthComboBox.SelectedIndex + 1;
            ShowReports();
        }

        private void YearlyReportRadioButtonClicked(object sender, EventArgs e)
        {
            ShowMonthlyReportRadioButton.Checked = false;
            MonthComboBox.Enabled = false;
            YearlyReportChart.Visible = true;
            MonthlyReportChart.Visible = false;

            ShowReports();
        }

        private void MonthlyReportRadioButtonClicked(object sender, EventArgs e)
        {
            ShowYearlyReportRadioButton.Checked = false;
            MonthComboBox.Enabled = true;

            if (!ShowCategorywiseReportRadioButton.Checked)
            {
                YearlyReportChart.Visible = false;
                MonthlyReportChart.Visible = true;
            }
            MonthComboBox.SelectedIndex = _selectedMonth - 1;
        }

        private void ShowEarningReportRadioButtonClicked(object sender, EventArgs e)
        {
            ShowExpenseReportRadioButton.Checked = false;
            ShowBothEarningAndExpenseReportRadioButton.Checked = false;

            ShowReports();
        }

        private void ShowExpenseReportRadioButtonClicked(object sender, EventArgs e)
        {
            ShowEarningReportRadioButton.Checked = false;
            ShowBothEarningAndExpenseReportRadioButton.Checked = false;

            ShowReports();
        }

        private void BothEarningAndExpenseRadionButtonClicked(object sender, EventArgs e)
        {
            //this method is called when ShowBothEarningAndExpenseReportRadioButton is Clicked
            ShowEarningReportRadioButton.Checked = false;
            ShowExpenseReportRadioButton.Checked = false;

            ShowReports();
        }

        private void GeneralReportRadioButtonClicked(object sender, EventArgs e)
        {
            ShowCategorywiseReportRadioButton.Checked = false;
            ShowBothEarningAndExpenseReportRadioButton.Enabled = true;
            ShowBothEarningAndExpenseReportRadioButton.Visible = true;

            if(ShowMonthlyReportRadioButton.Checked)
            {
                YearlyReportChart.Visible = false;
                MonthlyReportChart.Visible = true;
            }

            ShowReports();
        }

        private void CategorywiseReportRadioButton(object sender, EventArgs e)
        {
            ShowGeneralReportRadioButton.Checked = false;
            MonthlyReportChart.Visible = false;
            YearlyReportChart.Visible = true;
            ShowEarningReportRadioButton.Checked = ShowExpenseReportRadioButton.Checked ? false : true;
            ShowBothEarningAndExpenseReportRadioButton.Enabled = false;
            ShowBothEarningAndExpenseReportRadioButton.Visible = false;

            ShowReports();
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

            if (button.Name == "HomeButton")
            {
                OpenNewForm(new MainForm());
            }
            else if (button.Name == "AddNewDataButton")
            {
                OpenNewForm(new AddNewDataForm());
            }
            else if (button.Name == "MonthlyReportButton")
            {
                OpenNewForm(new MonthlyReportForm());
            }
            else if (button.Name == "SettingsButton")
            {
                OpenNewForm(new SettingsForm());
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

        private void ShowReports()
        {
            if (ShowGeneralReportRadioButton.Checked && ShowYearlyReportRadioButton.Checked)
            {
                ShowGeneralYearlyReport();
            }
            else if (ShowGeneralReportRadioButton.Checked && ShowMonthlyReportRadioButton.Checked)
            {
                ShowGeneralMonthlyReport();
            }
            else if (ShowCategorywiseReportRadioButton.Checked && ShowYearlyReportRadioButton.Checked)
            {
                ShowCategorywiseYearlyReport();
            }
            else if (ShowCategorywiseReportRadioButton.Checked && ShowMonthlyReportRadioButton.Checked)
            {
                ShowCategorywiseMonthlyReport();
            }
        }

        private void ShowGeneralYearlyReport()
        {
            List<MonthlyInfo> monthlyInfo = GlobalSpace.MonthlyInfoList.FindAll(m => m.Year == _selectedYear);

            if (ShowBothEarningAndExpenseReportRadioButton.Checked)
            {
                PlotGeneralYearlyEarningDataOnChart(monthlyInfo);
                PlotGeneralYearlyExpenseDataOnChart(monthlyInfo);
            }
            else if (ShowEarningReportRadioButton.Checked)
            {
                YearlyReportChart.Series["expense"].Points.Clear();
                PlotGeneralYearlyEarningDataOnChart(monthlyInfo);
            }
            else if (ShowExpenseReportRadioButton.Checked)
            {
                YearlyReportChart.Series["earning"].Points.Clear();
                PlotGeneralYearlyExpenseDataOnChart(monthlyInfo);
            }
        }

        private void ShowGeneralMonthlyReport()
        {
            List<DailyInfo> dailyInfo = GlobalSpace.DailyInfoList.FindAll(
                d => d.Month == _selectedMonth && d.Year == _selectedYear);

            if(ShowBothEarningAndExpenseReportRadioButton.Checked)
            {
                PlotGeneralMonthlyEarningDataOnChart(dailyInfo);
                PlotGeneralMonthlyExpenseDataOnChart(dailyInfo);
            }
            else if (ShowEarningReportRadioButton.Checked)
            {
                MonthlyReportChart.Series["expense"].Points.Clear();
                PlotGeneralMonthlyEarningDataOnChart(dailyInfo);
            }
            else if (ShowExpenseReportRadioButton.Checked)
            {
                MonthlyReportChart.Series["earning"].Points.Clear();
                PlotGeneralMonthlyExpenseDataOnChart(dailyInfo);
            }
        }

        private void ShowCategorywiseYearlyReport()
        {                       
            List<DailyInfo> dailyInfoList = GlobalSpace.DailyInfoList.FindAll(d => d.Year == _selectedYear);
                  
            if (ShowEarningReportRadioButton.Checked)
            {
                IDictionary<string, double> dictCategorywiseEarning = new Dictionary<string, double>();
                dictCategorywiseEarning = GlobalSpace.EarningCategories.ToDictionary(x => x, x => 0.0);

                foreach (DailyInfo daily in dailyInfoList)
                {
                    foreach (EarningInfo earning in daily.EarningList)
                    {
                        dictCategorywiseEarning[earning.Category] += earning.Amount;
                    }
                }
               
                PlotCategorywiseYearlyEarningDataOnChart(dictCategorywiseEarning);
            }
            else
            {
                IDictionary<string, double> dictCategorywiseExpense = new Dictionary<string, double>();
                dictCategorywiseExpense = GlobalSpace.ExpenseCategories.ToDictionary(x => x, x => 0.0);

                foreach (DailyInfo daily in dailyInfoList)
                {
                    foreach (ExpenseInfo expense in daily.ExpenseList)
                    {
                        dictCategorywiseExpense[expense.Category] += expense.Amount;
                    }
                }

                PlotCategorywiseYearlyExpenseDataOnChart(dictCategorywiseExpense);
            }
        }

        private void ShowCategorywiseMonthlyReport()
        {
            List<DailyInfo> dailyInfoList = GlobalSpace.DailyInfoList.FindAll(
                d => d.Year == _selectedYear && d.Month == _selectedMonth);

            if (ShowEarningReportRadioButton.Checked)
            {
                IDictionary<string, double> dictCategorywiseEarning = new Dictionary<string, double>();
                dictCategorywiseEarning = GlobalSpace.EarningCategories.ToDictionary(x => x, x => 0.0);

                foreach (DailyInfo daily in dailyInfoList)
                {
                    foreach (EarningInfo earning in daily.EarningList)
                    {
                        dictCategorywiseEarning[earning.Category] += earning.Amount;
                    }
                }

                PlotCategorywiseMonthlyEarningDataOnChart(dictCategorywiseEarning);
            }
            else
            {
                IDictionary<string, double> dictCategorywiseExpense = new Dictionary<string, double>();
                dictCategorywiseExpense = GlobalSpace.ExpenseCategories.ToDictionary(x => x, x => 0.0);

                foreach (DailyInfo daily in dailyInfoList)
                {
                    foreach (ExpenseInfo expense in daily.ExpenseList)
                    {
                        dictCategorywiseExpense[expense.Category] += expense.Amount;
                    }
                }

                PlotCategorywiseMonthlyExpenseDataOnChart(dictCategorywiseExpense);
            }
        }

        private void PlotGeneralYearlyEarningDataOnChart(List<MonthlyInfo> monthlyInfo)
        {
            YearlyReportChart.Series["earning"].Points.Clear();

            for (int mon = 1; mon <= 12; mon++)
            {
                MonthlyInfo monthly = monthlyInfo.Find(m => m.Month == mon);
                DataPoint point = new DataPoint();

                if (monthly != null)
                {                    
                    point.SetValueXY(_monthNames[mon - 1], monthly.Earning); 
                    point.ToolTip = monthly.Earning.ToString();
                    YearlyReportChart.Series["earning"].Points.Add(point);
                }
                else
                {
                    point.SetValueXY(_monthNames[mon - 1], 0);
                    point.ToolTip = "0.00";
                    YearlyReportChart.Series["earning"].Points.Add(point);
                }
            }
        }

        private void PlotGeneralYearlyExpenseDataOnChart(List<MonthlyInfo> monthlyInfo)
        {
            YearlyReportChart.Series["expense"].Points.Clear();
            
            for (int mon = 1; mon <= 12; mon++)
            {
                MonthlyInfo monthly = monthlyInfo.Find(m => m.Month == mon);
                DataPoint point = new DataPoint();

                if (monthly != null)
                {
                    point.SetValueXY(_monthNames[mon - 1], monthly.Expense);
                    point.ToolTip = monthly.Expense.ToString();
                    YearlyReportChart.Series["expense"].Points.Add(point);
                }
                else
                {
                    point.SetValueXY(_monthNames[mon - 1], 0);
                    point.ToolTip = "0.00";
                    YearlyReportChart.Series["expense"].Points.Add(point);
                }
            }
        }

        private void PlotGeneralMonthlyEarningDataOnChart(List<DailyInfo> dailyInfo)
        {
            MonthlyReportChart.Series["earning"].Points.Clear();

            int numOfDays = GetNumberOfDays();

            for(int day = 1; day <= numOfDays; day++)
            {
                DailyInfo daily = dailyInfo.Find(d => d.Day == day);
                DataPoint point = new DataPoint();

                if (daily != null)
                {
                    point.SetValueXY(day, daily.TotalEarning);
                    point.ToolTip = daily.TotalEarning.ToString();
                    MonthlyReportChart.Series["earning"].Points.Add(point);
                }
                else
                {
                    point.SetValueXY(day, 0);
                    point.ToolTip = "0.00";
                    MonthlyReportChart.Series["earning"].Points.Add(point);
                }
            }
        }

        private void PlotGeneralMonthlyExpenseDataOnChart(List<DailyInfo> dailyInfo)
        {
            MonthlyReportChart.Series["expense"].Points.Clear();

            int numOfDays = GetNumberOfDays();

            for (int day = 1; day <= numOfDays; day++)
            {
                DailyInfo daily = dailyInfo.Find(d => d.Day == day);
                DataPoint point = new DataPoint();

                if (daily != null)
                {
                    point.SetValueXY(day, daily.TotalExpense);
                    point.ToolTip = daily.TotalExpense.ToString();
                    MonthlyReportChart.Series["expense"].Points.Add(point);
                }
                else
                {
                    point.SetValueXY(day, 0);
                    point.ToolTip = "0.00";
                    MonthlyReportChart.Series["expense"].Points.Add(point);
                }
            }
        }

        private void PlotCategorywiseYearlyEarningDataOnChart(
            IDictionary<string, double> dictCategorywiseEarning)
        {
            YearlyReportChart.Series["earning"].Points.Clear();
            YearlyReportChart.Series["expense"].Points.Clear();

            double total = dictCategorywiseEarning.Sum(x => x.Value);

            foreach (string category in dictCategorywiseEarning.Keys)
            {
                double amount = dictCategorywiseEarning[category];
                double percentage = (total > 0 && amount > 0) ? (amount / total) * 100 : 0.0;

                DataPoint point = new DataPoint();
                point.SetValueXY(category, amount);
                point.ToolTip = amount.ToString() + string.Format(" ({0:0.00}%)", percentage);
                YearlyReportChart.Series["earning"].Points.Add(point);
            }
        }

        private void PlotCategorywiseYearlyExpenseDataOnChart(
            IDictionary<string, double> dictCategorywiseExpense)
        {
            YearlyReportChart.Series["earning"].Points.Clear();
            YearlyReportChart.Series["expense"].Points.Clear();

            double total = dictCategorywiseExpense.Sum(x => x.Value);

            foreach (string category in dictCategorywiseExpense.Keys)
            {
                double amount = dictCategorywiseExpense[category];
                double percentage = (total > 0 && amount > 0) ? (amount / total) * 100 : 0.0;

                DataPoint point = new DataPoint();
                point.SetValueXY(category, amount);
                point.ToolTip = amount.ToString() + string.Format(" ({0:0.00}%)", percentage);
                YearlyReportChart.Series["expense"].Points.Add(point);
            }
        }

        private void PlotCategorywiseMonthlyEarningDataOnChart(
            IDictionary<string, double> dictCategorywiseEarning)
        {
            YearlyReportChart.Series["earning"].Points.Clear();
            YearlyReportChart.Series["expense"].Points.Clear();

            double total = dictCategorywiseEarning.Sum(x => x.Value);

            foreach (string category in dictCategorywiseEarning.Keys)
            {
                double amount = dictCategorywiseEarning[category];
                double percentage = (total > 0 && amount > 0) ? (amount / total) * 100 : 0.0;

                DataPoint point = new DataPoint();
                point.SetValueXY(category, amount);
                point.ToolTip = amount.ToString() + string.Format(" ({0:0.00}%)", percentage);
                YearlyReportChart.Series["earning"].Points.Add(point);
            }
        }

        private void PlotCategorywiseMonthlyExpenseDataOnChart(
            IDictionary<string, double> dictCategorywiseExpense)
        {
            YearlyReportChart.Series["earning"].Points.Clear();
            YearlyReportChart.Series["expense"].Points.Clear();

            double total = dictCategorywiseExpense.Sum(x => x.Value);

            foreach (string category in dictCategorywiseExpense.Keys)
            {
                double amount = dictCategorywiseExpense[category];
                double percentage = (total > 0 && amount > 0) ? (amount / total) * 100 : 0.0;

                DataPoint point = new DataPoint();
                point.SetValueXY(category, amount);
                point.ToolTip = amount.ToString() + string.Format(" ({0:0.00}%)", percentage);
                YearlyReportChart.Series["expense"].Points.Add(point);
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
