using System;
using System.Windows.Forms;
using Phinanze.Views;

namespace Phinanze
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(AppLoaderView.Instance);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show("Something went wrong. Please restart the application.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
