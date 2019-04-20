using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using MyCost.Common;
using MyCost.ServerHandling;

namespace MyCost.Forms
{
    public partial class YearlyStatisticsForm: Form
    {
        private int _selectedYear;
        private int _selectedMonth;

        private string[] _monthNames = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN",
                                        "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };

        public YearlyStatisticsForm()
        {
            InitializeComponent();

            _selectedMonth = DateTime.Now.Month;
            _selectedYear = DateTime.Now.Year;
        }

        #region event_handler_methods

        private void ThisFormLoading(object sender, EventArgs e)
        {
            monthComboBox.Enabled = false;
            yearlyRadioButton.Checked = true;
            bothEarningAndExpenseRadioButton.Checked = true;
            generalReportRadioButton.Checked = true;
            yearlyGeneralReportChart.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            for(int year = 2018; year <= _selectedYear+3; year++)
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
            ShowReports();
        }

        private void MonthlyRadioButtonClicked(object sender, EventArgs e)
        {
            yearlyRadioButton.Checked = false;
            monthComboBox.Enabled = true;
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
            //bothEarningAndExpenseRadioButton is a single button
            //that shows both earning and expense when checked
            earningRadioButton.Checked = false;
            expenseRadioButton.Checked = false;
            ShowReports();
        }

        private void GeneralReportRadioButtonClicked(object sender, EventArgs e)
        {
            categorywiseReportRadioButton.Checked = false;
            ShowReports();
        }

        private void CategorywiseReportRadioButton(object sender, EventArgs e)
        {
            generalReportRadioButton.Checked = false;
            ShowReports();
        }

        #endregion

        #region non_event_handler_methods

        private void ShowReports()
        {
            if (generalReportRadioButton.Checked && yearlyRadioButton.Checked)
                ShowGeneralYearlyReport();
            else if (generalReportRadioButton.Checked && monthlyRadioButton.Checked)
                ShowGeneralMonthlyReport();
            else if (categorywiseReportRadioButton.Checked && yearlyRadioButton.Checked)
                ShowCategorywiseYearlyReport();
            else if (categorywiseReportRadioButton.Checked && monthlyRadioButton.Checked)
                ShowCategorywiseMonthlyReport();
        }

        private void ShowGeneralYearlyReport()
        {
            List<MonthlyInfo> monthlyInfo = StaticStorage.MonthlyInfoList.FindAll(m => m.Year == _selectedYear);

            if (bothEarningAndExpenseRadioButton.Checked)
            {
                PlotGeneralYearlyEarningDataOnGraph(monthlyInfo);
                PlotGeneralYearlyExpenseDataOnGraph(monthlyInfo);
            }
            else if (earningRadioButton.Checked)
            {
                yearlyGeneralReportChart.Series["expense"].Points.Clear();
                PlotGeneralYearlyEarningDataOnGraph(monthlyInfo);
            }
            else if (expenseRadioButton.Checked)
            {
                yearlyGeneralReportChart.Series["earning"].Points.Clear();
                PlotGeneralYearlyExpenseDataOnGraph(monthlyInfo);
            }
        }

        private void ShowGeneralMonthlyReport()
        {

        }

        private void ShowCategorywiseYearlyReport() { }

        private void ShowCategorywiseMonthlyReport() { }

        private void PlotGeneralYearlyEarningDataOnGraph(List<MonthlyInfo> monthlyInfo)
        {
            yearlyGeneralReportChart.Series["earning"].Points.Clear();

            for (int i = 0; i < 12; i++)
            {
                MonthlyInfo monthly = monthlyInfo.Find(m => m.Month == i + 1);

                if (monthly != null && monthly.Earning > 0)
                {
                    DataPoint point = new DataPoint();
                    point.SetValueXY(_monthNames[i], monthly.Earning);
                    point.ToolTip = monthly.Earning.ToString();
                    yearlyGeneralReportChart.Series["earning"].Points.Add(point);
                }
            }
        }

        private void PlotGeneralYearlyExpenseDataOnGraph(List<MonthlyInfo> monthlyInfo)
        {
            yearlyGeneralReportChart.Series["expense"].Points.Clear();
            
            for (int i = 0; i < 12; i++)
            {
                MonthlyInfo monthly = monthlyInfo.Find(m => m.Month == i + 1);

                if (monthly != null && monthly.Expense > 0)
                {
                    DataPoint point = new DataPoint();
                    point.SetValueXY(_monthNames[i], monthly.Expense);
                    point.ToolTip = monthly.Expense.ToString();
                    yearlyGeneralReportChart.Series["expense"].Points.Add(point);
                }                   
            }
        }


        #endregion

        private void homeButton_Click(object sender, EventArgs e)
        {
            MainForm fomr = new MainForm();
            fomr.Show();
            this.Close();
        }
    }
}
