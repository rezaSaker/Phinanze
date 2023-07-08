using Phinanze.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phinanze.Views
{
    public partial class AddTransactionView : Form, IView, IAddTransactionView
    {
        public AddTransactionView()
        {
            InitializeComponent();

            this.Load += delegate { ViewLoading?.Invoke(this, EventArgs.Empty); };
            this.Shown += delegate { ViewShown?.Invoke(this, EventArgs.Empty); };
            this.savebutton.Click += delegate { SaveButtonClicked?.Invoke(this, EventArgs.Empty); };
            this.deleteButton.Click += delegate { DeleteButtonClicked?.Invoke(this, EventArgs.Empty); };
            this.FormClosing += OnFormClosing;
        }

        public bool IsOpen { get; private set; }

        public bool IsHidden { get; private set; }

        public DateTime Date 
        { 
            get => this.dateDTP.Value; 
            set => this.dateDTP.Value = value;
        }

        public double Amount 
        { 
            get => double.TryParse(this.amountTextBox.Text, out double amt) ? amt : 0; 
            set => this.amountTextBox.Text = value.ToString(); 
        }

        public Category Category 
        { 
            get
            {
                if(this.categoryComboBox.SelectedIndex >= 0)
                {
                    string categoryName = this.categoryComboBox.Items[this.categoryComboBox.SelectedIndex].ToString();
                    return Phinanze.Models.Category.Get.All().FirstOrDefault(c => c.Name == categoryName) ?? null;
                }
                return null;
            }
            set
            {    
                if(value != null)
                {
                    this.categoryComboBox.SelectedIndex = this.categoryComboBox.Items.IndexOf(value.Name);
                }
                else
                {
                    this.categoryComboBox.SelectedItem = null;
                }
            }
        }

        public string Note 
        { 
            get => this.noteTextBox.Text;
            set => this.noteTextBox.Text = value; 
        }

        public void InitializeComponents(params object[] dataSource)
        {
            if (dataSource.Length == 0 || dataSource[0].GetType() != typeof(List<Category>))
            {
                return;
            }
            List<Category> categoryList = (List<Category>)dataSource[0];
            categoryList.ForEach(c => this.categoryComboBox.Items.Add(c.Name));
        }

        public void PlotData(params object[] dataSource)
        {
            if (dataSource.Length == 0 || dataSource[0].GetType() != typeof(Transaction))
            {
                return;
            }
            Transaction transaction = (Transaction)dataSource[0];

            Date = transaction.Date.Date;
            Amount = transaction.Amount;
            Category = transaction.Category();
            Note = transaction.Note;
        }

        public void ClearData()
        {
            Date = DateTime.Today;
            Amount = 0;
            Note = string.Empty;
            Category = null;
        }

        public new void Show()
        {
            ClearData();
            this.IsOpen = true;
            this.IsHidden = false;
            base.Show();
        }

        public new void Hide()
        {
            this.IsOpen = false;
            this.IsHidden = true;
            base.Hide();
        }

        public void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public event EventHandler ViewLoading;
        public event EventHandler ViewShown;
        public event EventHandler SaveButtonClicked;
        public event EventHandler DeleteButtonClicked;
        public event EventHandler ViewVisibilityChanged;
    }
}
