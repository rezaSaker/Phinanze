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
    public partial class HomePage : Form
    {
        private int userid;

        public HomePage(int userid)
        {
            InitializeComponent();

            this.userid = userid;
        }
    }
}
