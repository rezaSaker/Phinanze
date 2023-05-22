using System.ComponentModel;

namespace Phinanze.Models.ViewModels
{
    public class MonthlyOverview
    {
        [DisplayName("Year")]
        public int Year { get; set; }

        [DisplayName("Month")]
        public string Month { get; set; }

        [DisplayName("Total Earning")]
        public double TotalEarning { get; set; }

        [DisplayName("Total Expense")]
        public double TotalExpense { get; set; }

        [DisplayName("Overview")]
        public double Difference { get; set; }
    }
}
