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
    public partial class MonthlyInfoForm : Form
    {
        private int _selectedMonth;
        private int _selectedYear;

        private bool _firstInitializationCall;

        private MainForm _mainFormObj;

        private List<string> _monthList;

        public MonthlyInfoForm(MainForm obj)
        {
            InitializeComponent();

            _selectedMonth = DateTime.Now.Month;
            _selectedYear = DateTime.Now.Year;
            _mainFormObj = obj;

            InitializeMonthList();
        }

        public MonthlyInfoForm(int month, int year, MainForm obj)
        {
            InitializeComponent();

            _selectedMonth = month;
            _selectedYear = year;
            _mainFormObj = obj;

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

        private void MonthlyInfoFormLoaded(object sender, EventArgs e)
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
            foreach(Daily daily in StaticStorage.DailyInfo)
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
            form.Show();

            this.Visible = false;
        }

        public override void Refresh()
        {
            PlotData();
        }

        private void CancelButtonClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MonthlyInfoFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_mainFormObj != null)
            {
                _mainFormObj.Visible = true;
                _mainFormObj.Refresh();
            }
        }
    }
}
