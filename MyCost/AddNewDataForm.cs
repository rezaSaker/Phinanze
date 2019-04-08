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

        private void dgv_earning_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                CategoryListForm form = new CategoryListForm(dgv_earning, e.RowIndex);
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

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Daily daily = new Daily();
            daily.Note = tb_note.Text;
            daily.Day = Convert.ToUInt16(cmb_day.SelectedValue.ToString());
            daily.Month = cmb_day.Items.IndexOf(cmb_day.SelectedValue.ToString()) + 1;
            daily.Year = Convert.ToUInt16(cmb_year.SelectedValue.ToString());

            string source;
            string reason;
            string category;
            string comment;
            double amount;

            foreach(DataGridViewRow row in dgv_expense.Rows)
            {
                try
                {
                    reason = dgv_expense.Rows[row.Index].Cells[0].Value.ToString();
                }
                catch (NullReferenceException)
                {
                    //since reason is option, no need to show any warning
                    reason = "";
                }

                try
                {
                    amount = Convert.ToDouble(dgv_expense.Rows[row.Index].Cells[1].Value.ToString());
                }
                catch (NullReferenceException)
                {
                    string message = "Looks like you forgot to enter amount on row ";
                    message += row.Index + " in Expense table Continuing may cause ";
                    message += "loss of data.  Do you want to continue?";

                    var result = MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes) amount = .0;
                    else return;         
                }
                catch (FormatException)
                {
                    string message = "Looks like you have typos on row ";
                    message += row.Index + " in expense table. Amount can only be numbers. ";
                    message += "Continuing may cause loss of data. Do you want to continue?";

                    var result = MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes) amount = .0;
                    else return;
                }

                try
                {
                    category = dgv_expense.Rows[row.Index].Cells[2].Value.ToString();
                }
                catch (NullReferenceException)
                {
                    string message = "Looks like you forgot to enter category on row ";
                    message += row.Index + " in Expense table. Continuing may cause ";
                    message += "loss of data. Do you want to continue?";

                    var result = MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes) category = "";
                    else return;
                }

                try
                {
                    comment = dgv_expense.Rows[row.Index].Cells[3].Value.ToString();
                }
                catch (NullReferenceException)
                {
                    //since comment is optional, no need to show any warning
                    comment = "";
                }

                Expense expense = new Expense(reason, amount, category, comment);
                daily.Expenses.Add(expense);
            }

            foreach (DataGridViewRow row in dgv_earning.Rows)
            {
                try
                {
                    source = dgv_earning.Rows[row.Index].Cells[0].Value.ToString();
                }
                catch (NullReferenceException)
                {
                    //since source is option, no need to show any warning
                    source = "";
                }

                try
                {
                    amount = Convert.ToDouble(dgv_earning.Rows[row.Index].Cells[1].Value.ToString());
                }
                catch (NullReferenceException)
                {
                    string message = "Looks like you forgot to enter amount on row ";
                    message += row.Index + " in Earning table Continuing may cause ";
                    message += "loss of data.  Do you want to continue?";

                    var result = MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes) amount = .0;
                    else return;
                }
                catch (FormatException)
                {
                    string message = "Looks like you have typos on row ";
                    message += row.Index + " in Earning table. Amount can only be numbers. ";
                    message += "Continuing may cause loss of data. Do you want to continue?";

                    var result = MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes) amount = .0;
                    else return;
                }

                try
                {
                    category = dgv_earning.Rows[row.Index].Cells[2].Value.ToString();
                }
                catch (NullReferenceException)
                {
                    string message = "Looks like you forgot to enter category on row ";
                    message += row.Index + " in earning table. Continuing may cause ";
                    message += "loss of data. Do you want to continue?";

                    var result = MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes) category = "";
                    else return;
                }

                try
                {
                    comment = dgv_earning.Rows[row.Index].Cells[3].Value.ToString();
                }
                catch (NullReferenceException)
                {
                    //since comment is optional, no need to show any warning
                    comment = "";
                }

                Earning earning = new Earning(source, amount, category, comment);
                daily.Earnings.Add(earning);
            }

            string res = ServerHandler.SaveDailyInfo(daily);
        }
    }
}
