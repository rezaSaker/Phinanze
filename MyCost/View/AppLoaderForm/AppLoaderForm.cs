using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCost.View
{
    public partial class AppLoaderForm : Form
    {
        private int _countSeconds = 0;

        public AppLoaderForm()
        {
            InitializeComponent();
        }

        private void AppLoaderForm_Load(object sender, EventArgs e)
        {
            //when the app is run on a user's machine for the first time,
            //we create an permanent access token that is later used to 
            //communicate with the server
            if (Properties.Settings.Default.AccessKey == "")
            {
                Properties.Settings.Default.AccessKey = RandomString(100);
                Properties.Settings.Default.Save();
            }
        }

        private void AppLoaderFormShown(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if(++_countSeconds == 2)
            {
                UserAuthenticationForm form = new UserAuthenticationForm();
                form.Show();
                this.Hide();
            }
        }

        private string RandomString(int size)
        {
            string randStr = "";
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                             "abcdefghijklmnopqrstuvwxyz1234567890";
            char[] charSet = str.ToCharArray();

            Random rand = new Random();

            for (int i = 0; i < size; ++i)
                randStr += charSet[rand.Next(0, str.Length)];

            return randStr;
        }
    }
}
