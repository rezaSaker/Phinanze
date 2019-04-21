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

        #region event_handler_methods

        private void ThisFormLoading(object sender, EventArgs e)
        {
            monthComboBox.Enabled = false;
            yearlyRadioButton.Checked = true;
            bothEarningAndExpenseRadioButton.Checked = true;
            generalReportRadioButton.Checked = true;
            yearlyReportChart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            yearlyReportChart.Series["earning"].Color = Color.YellowGreen;
            yearlyReportChart.Series["expense"].Color = Color.OrangeRed;
            monthlyReportChart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            monthlyReportChart.Series["earning"].Color = Color.YellowGreen;
            monthlyReportChart.Series["expense"].Color = Color.OrangeRed;

            for (int year = 2018; year <= _selectedYear + 3; year++)
            {
                yearComboBox.Items.Add(year.ToString());
            }
            yearComboBox.SelectedIndex = yearComboBox.Items.IndexOf(_selectedYear.ToString());
        }

        private void YearComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedYear = Convert.ToInt32(yearComboBox.SelectedItem.ToString());
            ShowReports();
        }

        private void MonthComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedMonth = monthComboBox.SelectedIndex + 1;
            ShowReports();
        }

        private void YearlyRadioButtonClicked(object sender, EventArgs e)
        {
            monthlyRadioButton.Checked = false;
            monthComboBox.Enabled = false;
            yearlyReportChart.Visible = true;
            monthlyReportChart.Visible = false;

            ShowReports();
        }

        private void MonthlyRadioButtonClicked(object sender, EventArgs e)
        {
            yearlyRadioButton.Checked = false;
            monthComboBox.Enabled = true;

            if (!categorywiseReportRadioButton.Checked)
            {
                yearlyReportChart.Visible = false;
                monthlyReportChart.Visible = true;
            }
            monthComboBox.SelectedIndex = _selectedMonth - 1;
        }

        private void EarningRadioButtonClicked(object sender, EventArgs e)
        {
            expenseRadioButton.Checked = false;
            bothEarningAndExpenseRadioButton.Checked = false;

            ShowReports();
        }

        private void ExpenseRadioButtonClicked(object sender, EventArgs e)
        {
            earningRadioButton.Checked = false;
            bothEarningAndExpenseRadioButton.Checked = false;

            ShowReports();
        }

        private void BothEarningAndExpenseRadionButtonClicked(object sender, EventArgs e)
        {
            //bothEarningAndExpenseRadioButton is a single radioButton
            //that shows both earning and expense when checked
            earningRadioButton.Checked = false;
            expenseRadioButton.Checked = false;

            ShowReports();
        }

        private void GeneralReportRadioButtonClicked(object sender, EventArgs e)
        {
            categorywiseReportRadioButton.Checked = false;
            bothEarningAndExpenseRadioButton.Enabled = true;
            bothEarningAndExpenseRadioButton.Visible = true;

            if(monthlyRadioButton.Checked)
            {
                yearlyReportChart.Visible = false;
                monthlyReportChart.Visible = true;
            }

            ShowReports();
        }

        private void CategorywiseReportRadioButton(object sender, EventArgs e)
        {
            generalReportRadioButton.Checked = false;
            monthlyReportChart.Visible = false;
            yearlyReportChart.Visible = true;
            earningRadioButton.Checked = expenseRadioButton.Checked ? false : true;
            bothEarningAndExpenseRadioButton.Enabled = false;
            bothEarningAndExpenseRadioButton.Visible = false;

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

            if (button.Name == "homeButton")
            {
                OpenNewForm(new MainForm());
            }
            else if (button.Name == "addNewDataButton")
            {
                OpenNewForm(new AddNewDataForm());
            }
            else if (button.Name == "monthlyReportButton")
            {
                OpenNewForm(new MonthlyReportForm());
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

        private void ShowReports()
        {
            if (generalReportRadioButton.Checked && yearlyRadioButton.Checked)
            {
                ShowGeneralYearlyReport();
            }
            else if (generalReportRadioButton.Checked && monthlyRadioButton.Checked)
            {
                ShowGeneralMonthlyReport();
            }
            else if (categorywiseReportRadioButton.Checked && yearlyRadioButton.Checked)
            {
                ShowCategorywiseYearlyReport();
            }
            else if (categorywiseReportRadioButton.Checked && monthlyRadioButton.Checked)
            {
                ShowCategorywiseMonthlyReport();
            }
        }

        private void ShowGeneralYearlyReport()
        {
            List<MonthlyInfo> monthlyInfo = StaticStorage.MonthlyInfoList.FindAll(m => m.Year == _selectedYear);

            if (bothEarningAndExpenseRadioButton.Checked)
            {
                PlotGeneralYearlyEarningDataOnChart(monthlyInfo);
                PlotGeneralYearlyExpenseDataOnChart(monthlyInfo);
            }
            else if (earningRadioButton.Checked)
            {
                yearlyReportChart.Series["expense"].Points.Clear();
                PlotGeneralYearlyEarningDataOnChart(monthlyInfo);
            }
            else if (expenseRadioButton.Checked)
            {
                yearlyReportChart.Series["earning"].Points.Clear();
                PlotGeneralYearlyExpenseDataOnChart(monthlyInfo);
            }
        }

        private void ShowGeneralMonthlyReport()
        {
            List<DailyInfo> dailyInfo = StaticStorage.DailyInfoList.FindAll(
                d => d.Month == _selectedMonth && d.Year == _selectedYear);

            if(bothEarningAndExpenseRadioButton.Checked)
            {
                PlotGeneralMonthlyEarningDataOnChart(dailyInfo);
                PlotGeneralMonthlyExpenseDataOnChart(dailyInfo);
            }
            else if (earningRadioButton.Checked)
            {
                monthlyReportChart.Series["expense"].Points.Clear();
                PlotGeneralMonthlyEarningDataOnChart(dailyInfo);
            }
            else if (expenseRadioButton.Checked)
            {
                monthlyReportChart.Series["earning"].Points.Clear();
                PlotGeneralMonthlyExpenseDataOnChart(dailyInfo);
            }
        }

        private void ShowCategorywiseYearlyReport()
        {                       
            List<DailyInfo> dailyInfoList = StaticStorage.DailyInfoList.FindAll(d => d.Year == _selectedYear);
                  
            if (earningRadioButton.Checked)
            {
                IDictionary<string, double> dictCategorywiseEarning = new Dictionary<string, double>();
                dictCategorywiseEarning = StaticStorage.EarningCategories.ToDictionary(x => x, x => 0.0);

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
                dictCategorywiseExpense = StaticStorage.ExpenseCategories.ToDictionary(x => x, x => 0.0);

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
            List<DailyInfo> dailyInfoList = StaticStorage.DailyInfoList.FindAll(
                d => d.Year == _selectedYear && d.Month == _selectedMonth);

            if (earningRadioButton.Checked)
            {
                IDictionary<string, double> dictCategorywiseEarning = new Dictionary<string, double>();
                dictCategorywiseEarning = StaticStorage.EarningCategories.ToDictionary(x => x, x => 0.0);

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
                dictCategorywiseExpense = StaticStorage.ExpenseCategories.ToDictionary(x => x, x => 0.0);

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
            yearlyReportChart.Series["earning"].Points.Clear();

            for (int mon = 1; mon <= 12; mon++)
            {
                MonthlyInfo monthly = monthlyInfo.Find(m => m.Month == mon);
                DataPoint point = new DataPoint();

                if (monthly != null)
                {                    
                    point.SetValueXY(_monthNames[mon - 1], monthly.Earning); 
                    point.ToolTip = monthly.Earning.ToString();
                    yearlyReportChart.Series["earning"].Points.Add(point);
                }
                else
                {
                    point.SetValueXY(_monthNames[mon - 1], 0);
                    point.ToolTip = "0.00";
                    yearlyReportChart.Series["earning"].Points.Add(point);
                }
            }
        }

        private void PlotGeneralYearlyExpenseDataOnChart(List<MonthlyInfo> monthlyInfo)
        {
            yearlyReportChart.Series["expense"].Points.Clear();
            
            for (int mon = 1; mon <= 12; mon++)
            {
                MonthlyInfo monthly = monthlyInfo.Find(m => m.Month == mon);
                DataPoint point = new DataPoint();

                if (monthly != null)
                {
                    point.SetValueXY(_monthNames[mon - 1], monthly.Expense);
                    point.ToolTip = monthly.Expense.ToString();
                    yearlyReportChart.Series["expense"].Points.Add(point);
                }
                else
                {
                    point.SetValueXY(_monthNames[mon - 1], 0);
                    point.ToolTip = "0.00";
                    yearlyReportChart.Series["expense"].Points.Add(point);
                }
            }
        }

        private void PlotGeneralMonthlyEarningDataOnChart(List<DailyInfo> dailyInfo)
        {
            monthlyReportChart.Series["earning"].Points.Clear();

            int numOfDays = GetNumberOfDays();

            for(int day = 1; day <= numOfDays; day++)
            {
                DailyInfo daily = dailyInfo.Find(d => d.Day == day);
                DataPoint point = new DataPoint();

                if (daily != null)
                {
                    point.SetValueXY(day, daily.TotalEarning);
                    point.ToolTip = daily.TotalEarning.ToString();
                    monthlyReportChart.Series["earning"].Points.Add(point);
                }
                else
                {
                    point.SetValueXY(day, 0);
                    point.ToolTip = "0.00";
                    monthlyReportChart.Series["earning"].Points.Add(point);
                }
            }
        }

        private void PlotGeneralMonthlyExpenseDataOnChart(List<DailyInfo> dailyInfo)
        {
            monthlyReportChart.Series["expense"].Points.Clear();

            int numOfDays = GetNumberOfDays();

            for (int day = 1; day <= numOfDays; day++)
            {
                DailyInfo daily = dailyInfo.Find(d => d.Day == day);
                DataPoint point = new DataPoint();

                if (daily != null)
                {
                    point.SetValueXY(day, daily.TotalExpense);
                    point.ToolTip = daily.TotalExpense.ToString();
                    monthlyReportChart.Series["expense"].Points.Add(point);
                }
                else
                {
                    point.SetValueXY(day, 0);
                    point.ToolTip = "0.00";
                    monthlyReportChart.Series["expense"].Points.Add(point);
                }
            }
        }

        private void PlotCategorywiseYearlyEarningDataOnChart(
            IDictionary<string, double> dictCategorywiseEarning)
        {
            yearlyReportChart.Series["earning"].Points.Clear();
            yearlyReportChart.Series["expense"].Points.Clear();

            double total = dictCategorywiseEarning.Sum(x => x.Value);

            foreach (string category in dictCategorywiseEarning.Keys)
            {
                double amount = dictCategorywiseEarning[category];
                double percentage = (total > 0 && amount > 0) ? (amount / total) * 100 : 0.0;

                DataPoint point = new DataPoint();
                point.SetValueXY(category, amount);
                point.ToolTip = amount.ToString() + string.Format(" ({0:0.00}%)", percentage);
                yearlyReportChart.Series["earning"].Points.Add(point);
            }
        }

        private void PlotCategorywiseYearlyExpenseDataOnChart(
            IDictionary<string, double> dictCategorywiseExpense)
        {
            yearlyReportChart.Series["earning"].Points.Clear();
            yearlyReportChart.Series["expense"].Points.Clear();

            double total = dictCategorywiseExpense.Sum(x => x.Value);

            foreach (string category in dictCategorywiseExpense.Keys)
            {
                double amount = dictCategorywiseExpense[category];
                double percentage = (total > 0 && amount > 0) ? (amount / total) * 100 : 0.0;

                DataPoint point = new DataPoint();
                point.SetValueXY(category, amount);
                point.ToolTip = amount.ToString() + string.Format(" ({0:0.00}%)", percentage);
                yearlyReportChart.Series["expense"].Points.Add(point);
            }
        }

        private void PlotCategorywiseMonthlyEarningDataOnChart(
            IDictionary<string, double> dictCategorywiseEarning)
        {
            yearlyReportChart.Series["earning"].Points.Clear();
            yearlyReportChart.Series["expense"].Points.Clear();

            double total = dictCategorywiseEarning.Sum(x => x.Value);

            foreach (string category in dictCategorywiseEarning.Keys)
            {
                double amount = dictCategorywiseEarning[category];
                double percentage = (total > 0 && amount > 0) ? (amount / total) * 100 : 0.0;

                DataPoint point = new DataPoint();
                point.SetValueXY(category, amount);
                point.ToolTip = amount.ToString() + string.Format(" ({0:0.00}%)", percentage);
                yearlyReportChart.Series["earning"].Points.Add(point);
            }
        }

        private void PlotCategorywiseMonthlyExpenseDataOnChart(
            IDictionary<string, double> dictCategorywiseExpense)
        {
            yearlyReportChart.Series["earning"].Points.Clear();
            yearlyReportChart.Series["expense"].Points.Clear();

            double total = dictCategorywiseExpense.Sum(x => x.Value);

            foreach (string category in dictCategorywiseExpense.Keys)
            {
                double amount = dictCategorywiseExpense[category];
                double percentage = (total > 0 && amount > 0) ? (amount / total) * 100 : 0.0;

                DataPoint point = new DataPoint();
                point.SetValueXY(category, amount);
                point.ToolTip = amount.ToString() + string.Format(" ({0:0.00}%)", percentage);
                yearlyReportChart.Series["expense"].Points.Add(point);
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
