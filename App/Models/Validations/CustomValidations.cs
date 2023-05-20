using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;

namespace Phinanze.Models.Validations
{
    public class CustomValidations
    {
        /// <summary>
        /// Validates the date format for DailyInfo model
        /// </summary>
        /// <param name="date">The date to be validated</param>
        /// <returns></returns>
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

        /// <summary>
        /// Validates the CategoryType property of category model
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static ValidationResult ValidCategoryType(string category)
        {
            if(category != Statics.CategoryType.EARNING && category != Statics.CategoryType.EXPENSE)
            {
                return new ValidationResult("Invalid category type");
            }
            return null;
        }
    }
}
