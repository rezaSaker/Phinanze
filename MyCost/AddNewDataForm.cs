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
        public AddNewDataForm()
        {
            InitializeComponent();
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

        private void dgv_expenses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1)
            {
                CategoryListForm form = new CategoryListForm(dgv_expense, e.RowIndex);
                form.Show();
            }
        }

        private void btn_applyCategoryToAll_Click(object sender, EventArgs e)
        {
            if(dgv_earning.SelectedRows.Count < 1 && dgv_expense.SelectedRows.Count < 1)
            {
                //no row is selected
                return;
            }

            List<int> expenseRowIndexList = new List<int>();
            List<int> earningRowIndexList = new List<int>();
            
            foreach(DataGridViewRow row in dgv_expense.SelectedRows)
            {
                expenseRowIndexList.Add(row.Index);
            }

            foreach(DataGridViewRow row in dgv_earning.SelectedRows)
            {
                earningRowIndexList.Add(row.Index);
            }

            CategoryListForm form;
            form = new CategoryListForm(
                dgv_expense, 
                dgv_earning, 
                expenseRowIndexList, 
                earningRowIndexList);

            form.Show();
        }
    }
}
