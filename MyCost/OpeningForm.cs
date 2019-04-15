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
    public partial class OpeningForm : Form
    {
        private int _secondsCount;

        public OpeningForm()
        {
            InitializeComponent();

            _secondsCount = 0;
        }

        private void OpeningForm_Load(object sender, EventArgs e)
        {
            //timer.Enabled = true;
            UserAuthenticationForm form = new UserAuthenticationForm();
            form.Show();

            this.Visible = false;
        }

        private void TimerTick(object sender, EventArgs e)
        {

        }
    }
}
