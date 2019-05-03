using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MyCost.View
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
            progressBar.MarqueeAnimationSpeed = 1;
        }

        public void StartProgressOnSeperateThread()
        {
            Thread thread = new Thread(ProgressStarter);
            thread.Start();
        }

        private void ProgressStarter()
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            progressBar.Increment(10);
        }

        public void StopProgress()
        {
            this.Close();
        }

        public void UpdateStatus(string status)
        {
            statusLabel.Text = status;
        }

        public string Status
        {
            get => _status;
            set => _status = value;
        }
    }
}
