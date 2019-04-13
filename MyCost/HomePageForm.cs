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
    public partial class HomePageForm : Form
    {
        private List<string> monthsList;
                                                    
        public HomePageForm()
        {
            InitializeComponent();

            //monthList is user to convert numeric month to month text
            monthsList = new List<string>();
            monthsList.Add("January");
            monthsList.Add("February");
            monthsList.Add("March");
            monthsList.Add("April");
            monthsList.Add("May");
            monthsList.Add("June");
            monthsList.Add("July");
            monthsList.Add("August");
            monthsList.Add("September");
            monthsList.Add("October");
            monthsList.Add("November");
            monthsList.Add("December");

        }

        private void HomePageLoaded(object sender, EventArgs e)
        {
            PlotMonthlyInfo();
        }

        private void PlotMonthlyInfo()
        {
            dataGridView.Rows.Clear();

            int row = 0;

            foreach(Monthly monthly in StaticStorage.MonthlyInfo)
            {
                string year = monthly.Year.ToString();
                string month = monthsList[monthly.Month - 1];
                string earning = monthly.Earning.ToString();
                string expense = monthly.Expense.ToString();

                //adds year, month, earning and expense in the first four columns of the dataGridView
                dataGridView.Rows.Add(year, month, earning, expense);
                
                //adds the overview to the last column according to the earning and expense
                if(monthly.Earning < monthly.Expense)
                {
                    dataGridView.Rows[row].Cells[4].Style.ForeColor = Color.Red;
                    dataGridView.Rows[row].Cells[4].Value           = "Negative";

                }
                else if(monthly.Earning > monthly.Expense)
                {
                    dataGridView.Rows[row].Cells[4].Style.ForeColor = Color.Green;
                    dataGridView.Rows[row].Cells[4].Value           = "Positive";
                }
                else
                {
                    dataGridView.Rows[row].Cells[4].Style.ForeColor = Color.Yellow;
                    dataGridView.Rows[row].Cells[4].Value           = "neutral";
                }
            }
        }

        private void AddNewDataButtonClicked(object sender, EventArgs e)
        {
            AddNewDataForm form = new AddNewDataForm();
            form.Show();
        }
    }
}
