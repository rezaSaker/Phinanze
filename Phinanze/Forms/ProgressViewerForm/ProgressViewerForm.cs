using System;
using System.Windows.Forms;

namespace Phinanze.Forms
{
    public partial class ProgressViewerForm : Form
    {
        private string _status;

        public ProgressViewerForm(string status)
        {
            InitializeComponent();

            _status = status;
            UpdateStatus(status);
        }

        private void ProgressViewerForm_Load(object sender, EventArgs e)
        {
            UI_ProgressBar.MarqueeAnimationSpeed = 1;
        }

        public void StopProgress()
        {
            this.Close();
        }

        public void UpdateStatus(string status)
        {
            StatusLabel.Text = status;
        }

        public string Status
        {
            get => _status;
            set => _status = value;
        }
    }
}
