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
    public partial class StatisticalReportForm : Form
    {
        private int _selectedYear;

        private IDictionary<string, double> _barValueDictionary;

        public StatisticalReportForm()
        {
            InitializeComponent();

            _selectedYear = DateTime.Now.Year;
            _barValueDictionary = new Dictionary<string, double>();
        }

        private void StatisticalReportFormLoaded(object sender, EventArgs e)
        {
            //add items to yearCOmboBox
            for(int year = 2018; year <= _selectedYear; year++)
            {
                yearComboBox.Items.Add(year.ToString());
            }
            yearComboBox.SelectedIndex = yearComboBox.Items.IndexOf(_selectedYear.ToString());
      
            PlotYearlyFinancialReportGraph();
        }

        private void ResetGraphBarProperties()
        {
            monthlyEarningBar1.Visible = false;
            monthlyEarningBar2.Visible = false;
            monthlyEarningBar3.Visible = false;
            monthlyEarningBar4.Visible = false;
            monthlyEarningBar5.Visible = false;
            monthlyEarningBar6.Visible = false;
            monthlyEarningBar7.Visible = false;
            monthlyEarningBar8.Visible = false;
            monthlyEarningBar9.Visible = false;
            monthlyEarningBar10.Visible = false;
            monthlyEarningBar11.Visible = false;
            monthlyEarningBar12.Visible = false;

            monthlyExpenseBar1.Visible = false;
            monthlyExpenseBar2.Visible = false;
            monthlyExpenseBar3.Visible = false;
            monthlyExpenseBar4.Visible = false;
            monthlyExpenseBar5.Visible = false;
            monthlyExpenseBar6.Visible = false;
            monthlyExpenseBar7.Visible = false;
            monthlyExpenseBar8.Visible = false;
            monthlyExpenseBar9.Visible = false;
            monthlyExpenseBar10.Visible = false;
            monthlyExpenseBar11.Visible = false;
            monthlyExpenseBar12.Visible = false;
        }

        private void PlotYearlyFinancialReportGraph()
        {
            ResetGraphBarProperties();

            double highestExpense = HighestExpense();
            double highestEarning = HighestEarning();
            //double lowestExpense = LowestExpense();
           // double lowestEarning = LowestEarning();

            double highestOfAll = highestExpense > highestEarning ? highestExpense: highestEarning;
            double highestValueOfChart = RoundToNextAllZeroNumber(highestOfAll);

            //first set the label indicating different amount stages
            highestLimitLabel.Text = highestValueOfChart.ToString();
            semiHighestLimitLabel.Text = ((highestValueOfChart / 4.0) * 3.0).ToString();
            middleLimitLabel.Text = ((highestValueOfChart / 4.0) * 2.0).ToString();
            lowestLimitLabel.Text = (highestValueOfChart / 4.0).ToString();

            PlotMonthlyEarningData(highestValueOfChart);
            PlotMonthlyExpenseData(highestValueOfChart);
        }


        private void PlotMonthlyExpenseData(double highestGraphValue)
        {
            foreach (Monthly monthly in StaticStorage.MonthlyInfo)
            {
                if (_selectedYear == monthly.Year)
                {
                    if(monthly.Month == 1)
                        DrawGraphBar(highestGraphValue, monthly.Expense, monthlyExpenseBar1);
                    else if (monthly.Month == 2)
                        DrawGraphBar(highestGraphValue, monthly.Expense, monthlyExpenseBar2);
                    else if (monthly.Month == 3)
                        DrawGraphBar(highestGraphValue, monthly.Expense, monthlyExpenseBar3);
                    else if (monthly.Month == 4)
                        DrawGraphBar(highestGraphValue, monthly.Expense, monthlyExpenseBar4);
                    else if (monthly.Month == 5)
                        DrawGraphBar(highestGraphValue, monthly.Expense, monthlyExpenseBar5);
                    else if (monthly.Month == 6)
                        DrawGraphBar(highestGraphValue, monthly.Expense, monthlyExpenseBar6);
                    else if (monthly.Month == 7)
                        DrawGraphBar(highestGraphValue, monthly.Expense, monthlyExpenseBar7);
                    else if (monthly.Month == 8)
                        DrawGraphBar(highestGraphValue, monthly.Expense, monthlyExpenseBar8);
                    else if (monthly.Month == 9)
                        DrawGraphBar(highestGraphValue, monthly.Expense, monthlyExpenseBar9);
                    else if (monthly.Month == 10)
                        DrawGraphBar(highestGraphValue, monthly.Expense, monthlyExpenseBar10);
                    else if (monthly.Month == 11)
                        DrawGraphBar(highestGraphValue, monthly.Expense, monthlyExpenseBar11);
                    else if (monthly.Month == 12)
                        DrawGraphBar(highestGraphValue, monthly.Expense, monthlyExpenseBar12);
                }
            }
        }

        private void PlotMonthlyEarningData(double highestGraphValue)
        {
            foreach (Monthly monthly in StaticStorage.MonthlyInfo)
            {
                if (_selectedYear == monthly.Year)
                {
                    if (monthly.Month == 1)
                        DrawGraphBar(highestGraphValue, monthly.Earning, monthlyEarningBar1);
                    else if (monthly.Month == 2)
                        DrawGraphBar(highestGraphValue, monthly.Earning, monthlyEarningBar2);
                    else if (monthly.Month == 3)
                        DrawGraphBar(highestGraphValue, monthly.Earning, monthlyEarningBar3);
                    else if (monthly.Month == 4)
                        DrawGraphBar(highestGraphValue, monthly.Earning, monthlyEarningBar4);
                    else if (monthly.Month == 5)
                        DrawGraphBar(highestGraphValue, monthly.Earning, monthlyEarningBar5);
                    else if (monthly.Month == 6)
                        DrawGraphBar(highestGraphValue, monthly.Earning, monthlyEarningBar6);
                    else if (monthly.Month == 7)
                        DrawGraphBar(highestGraphValue, monthly.Earning, monthlyEarningBar7);
                    else if (monthly.Month == 8)
                        DrawGraphBar(highestGraphValue, monthly.Earning, monthlyEarningBar8);
                    else if (monthly.Month == 9)
                        DrawGraphBar(highestGraphValue, monthly.Earning, monthlyEarningBar9);
                    else if (monthly.Month == 10)
                        DrawGraphBar(highestGraphValue, monthly.Earning, monthlyEarningBar10);
                    else if (monthly.Month == 11)
                        DrawGraphBar(highestGraphValue, monthly.Earning, monthlyEarningBar11);
                    else if (monthly.Month == 12)
                        DrawGraphBar(highestGraphValue, monthly.Earning, monthlyEarningBar12);
                }
            }
        }

        /// <summary>
        /// draws a bar accordin got values passed as argument
        /// </summary>
        /// <param name="chartsTopValue">the highest value of the entire chart</param>
        /// <param name="barValue">value of the bar that needs to be drawn</param>
        /// <param name="bar">object reference of the bar that needs to be drawn</param>
        private void DrawGraphBar(double chartsTopValue, double barValue, Button bar)
        {
            double percentage = barValue / chartsTopValue;

            //the rule is, the height of the bar is 160 for the highest value of the chart
            //so, the height of the bar would be 160 * percentage
            int size = (int)(160.0 * percentage);

            bar.Visible = true;
            bar.Size = new Size(13, size);
            bar.Location = new Point(bar.Location.X, bar.Location.Y + (160 - size));

            _barValueDictionary.Add(new KeyValuePair<string, double>(bar.Name, barValue));
        }

        private double HighestExpense()
        {
            double max = .0;

            foreach(Monthly monthly in StaticStorage.MonthlyInfo)
            {
                if(monthly.Expense > max)
                {
                    max = monthly.Expense;
                }
            }

            return max;
        }

        private double HighestEarning()
        {
            double max = .0;

            foreach(Monthly monthly in StaticStorage.MonthlyInfo)
            {
                if(monthly.Earning > max)
                {
                    max = monthly.Earning;
                }
            }

            return max;
        }

        private double LowestExpense()
        {
            double min = double.MaxValue;

            foreach (Monthly monthly in StaticStorage.MonthlyInfo)
            {
                if (monthly.Expense < min)
                {
                    min = monthly.Expense;
                }
            }

            return min;
        }

        private double LowestEarning()
        {
            double min = double.MaxValue;

            foreach (Monthly monthly in StaticStorage.MonthlyInfo)
            {
                if (monthly.Earning < min)
                {
                    min = monthly.Earning;
                }
            }

            return min;
        }

        /// <summary>
        /// rounds a number to its next all zero number.For example, 750 to 800
        /// </summary>
        private double RoundToNextAllZeroNumber(double amount)
        {
            bool isArgAllZero = true;

            char[] digitArray = amount.ToString().Split('.')[0].ToCharArray();

            //checks if the passes argument (amount) is already a all Zero Number
            for(int i = 1; i < digitArray.Length; i++)
            {
                if(digitArray[i] != '0')
                {
                    isArgAllZero = false;
                    break;
                }
            }

            if (isArgAllZero)
            {
                //the passed argument is already an all zero number
                return amount;
            }
            else
            {
                //convert the passed argument to next all zero number
                int firstDigit = Convert.ToInt32(digitArray[0].ToString());
                int multiplyer = 1;

                //see
                for(int i = 0; i < digitArray.Length - 1; i++)
                {
                    multiplyer *= 10;
                }

                return (double)((firstDigit + 1) * multiplyer);
            }
        }

        private void GrpahBarsHover(object sender, EventArgs e)
        {
            //this method is called when any bar in the graph is hovered
            //whenver a bar is hovered, the amount for that bar should pop up on top of it
            Button bar = (Button)sender;

            monthlyAmountLabel.Visible = true;
            monthlyAmountLabel.Location = new Point(bar.Location.X, monthlyAmountLabel.Location.Y);
            monthlyAmountLabel.Text = _barValueDictionary[bar.Name].ToString();
        }

        private void GraphBrasMouseLeft(object sender, EventArgs e)
        {
            monthlyAmountLabel.Visible = false;
        }
    }
}
