using System;
using System.Windows.Forms;

namespace MyCost
{
    public partial class SettingsForm : Form
    {
        private Form _callerForm;

        public SettingsForm(Form form)
        {
            InitializeComponent();

            _callerForm = form;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
