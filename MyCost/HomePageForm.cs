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
        private int userid;

        public HomePageForm(int userid)
        {
            InitializeComponent();

            this.userid = userid;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            //get all data from database
            FetchDailyInfo();
            FetchMonthlyInfo();
        }

        private void FetchDailyInfo()
        {
            //get daily expenses and earnings from database
            string result = ServerHandler.RetrieveDailyInfo(userid);
        }

        private void FetchMonthlyInfo()
        {
            //get monthly expenses and earnings from database
            string result = ServerHandler.RetriveMonthlyInfo(userid);
        }

        private void btn_addNewData_Click(object sender, EventArgs e)
        {
            AddNewDataForm form = new AddNewDataForm(userid);
            form.Show();
        }
    }
}
