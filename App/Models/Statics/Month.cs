using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models.Statics
{
    public class Month
    {
        public static List<string> MonthNames = new List<string>() { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public static string MonthName(int month)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException("Invalid month number");
            }
            return MonthNames[month - 1];
        }

        public static int? MonthNumber(string monthName)
        {
            if(monthName.IsNullOrEmpty() || !MonthNames.Contains(monthName))
            {
                return null;
            }
            return (int?)MonthNames.IndexOf(monthName) + 1;
        }
    }
}
