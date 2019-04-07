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
    public partial class AddNewDataForm : Form
    {
        private int userid;
        
        public AddNewDataForm(int userid)
        {
            InitializeComponent();

            this.userid = userid;
        }

        private void AddNewDataForm_Load(object sender, EventArgs e)
        {
            //get current day, month and year
            int day = Convert.ToInt16(DateTime.Now.Day.ToString());
            int month = Convert.ToInt16(DateTime.Now.Month.ToString());
            int year = Convert.ToInt16(DateTime.Now.Year.ToString());

            //set the number of days according to month
            int numberOfdays;
            if (month == 2 && DateTime.IsLeapYear(year)) numberOfdays = 29;
            else if (month == 2 && !DateTime.IsLeapYear(year)) numberOfdays = 28;
            else if (month <= 7 && month % 2 == 1) numberOfdays = 31;
            else if (month <= 7 && month % 2 == 0) numberOfdays = 30;
            else if (month > 7 && month % 2 == 1) numberOfdays = 30;
            else numberOfdays = 31;

            //sets the days as items to combobox cmb_days
            for(int i = 0; i < numberOfdays; i++)
            {
                cmb_day.Items.Add((i + 1).ToString());
            }

            //sets years to cmb_year as items
            for(int i = 2018; i < year + 10; i++)
            {
                cmb_year.Items.Add(i.ToString());
            }

            //Sets the date fields to currents date
            cmb_day.SelectedIndex = day - 1;
            cmb_month.SelectedIndex = month - 1;
            cmb_year.SelectedIndex = cmb_year.Items.IndexOf(year.ToString());
        }
    }
}
