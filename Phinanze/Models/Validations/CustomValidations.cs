using System;
using System.ComponentModel.DataAnnotations;

namespace Phinanze.Models.Validations
{
    public class CustomValidations
    {
        public static ValidationResult ValidDate(DateTime date)
        {
            string[] dateTime = date.ToString().Split(' ');
            string[] dateArr = dateTime[0].Split('-');

            try
            {
                int year = Convert.ToInt32(dateArr[0]);
                int month = Convert.ToInt32(dateArr[1]);
                int day = Convert.ToInt32(dateArr[2]);

                if (year < 2000 || year > 2100 || month > 12 || month < 1 || day < 1 || day > DateTime.DaysInMonth(year, month))
                {
                    return new ValidationResult("Invalid date");
                }
            }
            catch
            {
                return new ValidationResult("Invalid date");
            }
            return null;
        }
    }
}
