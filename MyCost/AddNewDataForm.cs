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
        private int selectedDay;

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

            //sets years to cmb_year as items
            for(int i = 2018; i < year + 10; i++)
            {
                cmb_year.Items.Add(i.ToString());
            }

            selectedDay = day; //is used to select the day in AddItemsToDayComboBox() method

            //Sets the date fields to currents date
            cmb_year.SelectedIndex = cmb_year.Items.IndexOf(year.ToString());
            cmb_month.SelectedIndex = month - 1;
        }

        private void AddItemsToDayComboBox(int month, int year)
        {
            cmb_day.Items.Clear();

            //set the number of days according to month
            int numberOfdays;
            if (month == 2 && DateTime.IsLeapYear(year)) numberOfdays = 29;
            else if (month == 2 && !DateTime.IsLeapYear(year)) numberOfdays = 28;
            else if (month <= 7 && month % 2 == 1) numberOfdays = 31;
            else if (month <= 7 && month % 2 == 0) numberOfdays = 30;
            else if (month > 7 && month % 2 == 1) numberOfdays = 30;
            else numberOfdays = 31;

            //sets the days as items to combobox cmb_days
            for (int i = 0; i < numberOfdays; i++)
            {
                cmb_day.Items.Add((i + 1).ToString());
            }

            cmb_day.SelectedIndex = selectedDay - 1;
        }

        private void dgv_expenses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                CategoryListForm form = new CategoryListForm(dgv_expense, e.RowIndex);
                form.Show();
            }
        }

        private void dgv_earning_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
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

            daily.Note          = tb_note.Text;
            daily.Day           = Convert.ToUInt16(cmb_day.SelectedItem.ToString());
            daily.Month         = cmb_month.Items.IndexOf(cmb_month.SelectedItem.ToString()) + 1;
            daily.Year          = Convert.ToUInt16(cmb_year.SelectedItem.ToString());
            daily.TotalEarning  = Convert.ToDouble(lbl_earningTotal.Text);
            daily.TotalExpense  = Convert.ToDouble(lbl_expenseTotal.Text);

            string source;
            string reason;
            string category;
            string comment;
            double amount;

            foreach(DataGridViewRow row in dgv_expense.Rows)
            {
                if(row.Index == dgv_expense.Rows.Count - 1)
                {
                    //this is the last row and it's an empty row
                    break;
                }

                try
                {
                    reason = dgv_expense.Rows[row.Index].Cells[0].Value.ToString();
                }
                catch (NullReferenceException) { reason = ""; }

                try
                {
                    amount = Convert.ToDouble(dgv_expense.Rows[row.Index].Cells[1].Value.ToString());
                }
                catch (NullReferenceException)
                {
                    string message;
                    message = "Looks like you forgot to enter amount on row ";
                    message += (row.Index + 1) + ". Do you want to continue saving?";

                    DialogResult result = MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                        amount = .0;
                    else
                        return;         
                }
                catch (FormatException)
                {
                    string message;
                    message = "Looks like the amount is not correct on row ";
                    message += (row.Index + 1) + " in expense table. Amount can only be numbers. ";
                    message += "Please correct the amount before saving.";

                    MessageBox.Show(message);
                    return;
                }

                try
                {
                    category = dgv_expense.Rows[row.Index].Cells[2].Value.ToString();
                }
                catch (NullReferenceException) { category = "None"; }

                try
                {
                    comment = dgv_expense.Rows[row.Index].Cells[3].Value.ToString();
                }
                catch (NullReferenceException) { comment = ""; }

                Expense expense = new Expense(reason, amount, category, comment);
                daily.Expenses.Add(expense);
            }

            foreach (DataGridViewRow row in dgv_earning.Rows)
            {
                if (row.Index == dgv_earning.Rows.Count - 1)
                {
                    //this is the last row and it's an empty row
                    break;
                }

                try
                {
                    source = dgv_earning.Rows[row.Index].Cells[0].Value.ToString();
                }
                catch (NullReferenceException) { source = ""; }

                try
                {
                    amount = Convert.ToDouble(dgv_earning.Rows[row.Index].Cells[1].Value.ToString());
                }
                catch (NullReferenceException)
                {
                    string message = "Looks like you forgot to enter amount on row ";
                    message += (row.Index + 1) + " in Earning table. Do you want to continue saving?";

                    DialogResult result = MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                        amount = .0;
                    else
                        return;
                }
                catch (FormatException)
                {
                    string message = "Looks like the amount is not correct on row ";
                    message += (row.Index + 1) + " in expense table. Amount can only be numbers. ";
                    message += "Please correct the amount before saving.";

                    MessageBox.Show(message);
                    return;
                }

                try
                {
                    category = dgv_earning.Rows[row.Index].Cells[2].Value.ToString();
                }
                catch (NullReferenceException) { category = "None"; }

                try
                {
                    comment = dgv_earning.Rows[row.Index].Cells[3].Value.ToString();
                }
                catch (NullReferenceException) { comment = ""; }

                Earning earning = new Earning(source, amount, category, comment);
                daily.Earnings.Add(earning);
            }

            string savingResult = ServerHandler.SaveDailyInfo(daily);

            if (savingResult == "SUCCESS")
            {
                StaticStorage.DailyInfo.Add(daily);
            }
            else
            {
                //if not success, the error info is returned
                MessageBox.Show(savingResult);
            }

        }

        private void cmb_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if the month chnages, the number of days should be chnaged
            int month = cmb_month.SelectedIndex + 1;
            int year  = Convert.ToInt16(cmb_year.SelectedItem.ToString());

            AddItemsToDayComboBox(month, year);
        }

        private void UpdateTotalExpenseLabel()
        {
            double amount;
            double total = .0;

            for(int i = 0; i < dgv_expense.Rows.Count - 1; ++i)
            {
                try
                {
                    amount = Convert.ToDouble(dgv_expense.Rows[i].Cells[1].Value.ToString());
                    total  += amount;                
                }
                catch (FormatException)
                {
                    string message;
                    message = "Looks like you have a typo in your amount. Amount can only be numbers. ";
                    message += "Please re-enter the amount.";
                    MessageBox.Show(message);

                    //make the color of the column different so the user can easily point out
                    dgv_expense.Rows[i].Cells[1].Style.BackColor = Color.Red;
                    dgv_expense.Rows[i].Cells[1].Style.ForeColor = Color.White;
                }
                catch (NullReferenceException)
                {
                    //make the color of the column different so the user can easily point out
                    dgv_expense.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                    dgv_expense.Rows[i].Cells[1].Value           = "0.00";
                }
            }

            lbl_expenseTotal.Text = string.Format("{0:0.00}", total);
        }

        private void UpdateTotalEarningLabel()
        {
            double amount;
            double total = .0;

            for (int i = 0; i < dgv_earning.Rows.Count - 1; ++i)
            {
                try
                {
                    amount = Convert.ToDouble(dgv_earning.Rows[i].Cells[1].Value.ToString());
                    total  += amount;                
                }
                catch (FormatException)
                {
                    string message;
                    message = "Looks like you have a typo in your amount. Amount can only be numbers. ";
                    message += "Please re-enter the amount.";
                    MessageBox.Show(message);

                    //make the color of the column different so the user can easily point out
                    dgv_earning.Rows[i].Cells[1].Style.BackColor = Color.Red;
                    dgv_earning.Rows[i].Cells[1].Style.ForeColor = Color.White;
                }
                catch (NullReferenceException)
                {
                    //make the color of the column different so the user can easily point out
                    dgv_earning.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                    dgv_earning.Rows[i].Cells[1].Value           = "0.00";
                }
            }

            lbl_earningTotal.Text = string.Format("{0:0.00}", total);
        }

        private void dgv_expense_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(e.ColumnIndex == 1)
            {
                //change the color to default if it was changed before due to any error
                if (dgv_expense.Rows[e.RowIndex].Cells[1].Style.BackColor == Color.Red)
                {
                    dgv_expense.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.White;
                    dgv_expense.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.Black;
                }
                else if (dgv_expense.Rows[e.RowIndex].Cells[1].Style.BackColor == Color.Yellow)
                {
                    dgv_expense.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.White;
                }
            }
        }

        private void dgv_earning_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(e.ColumnIndex == 1)
            {
                //change the color to default if it was changed before due to any error
                if (dgv_earning.Rows[e.RowIndex].Cells[1].Style.BackColor == Color.Red)
                {
                    dgv_earning.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.White;
                    dgv_earning.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.Black;
                }
                else if (dgv_earning.Rows[e.RowIndex].Cells[1].Style.BackColor == Color.Yellow)
                {
                    dgv_earning.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.White;
                }
            }
        }

        private void dgv_expense_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if an expense amount is entered
            if (e.ColumnIndex == 1)
            {
                UpdateTotalExpenseLabel();
            }
        }

        private void dgv_earning_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if an earning amount is entered
            if (e.ColumnIndex == 1)
            {
                UpdateTotalEarningLabel();
            }
        }
    }
}
