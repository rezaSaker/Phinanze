using Phinanze.Models.DBInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace Phinanze.Models.Repositories
{
    public class DailyInfoRepository: Repository<DailyInfo2>
    {

        public static Repository<DailyInfo2> Get => new Repository<DailyInfo2>(); 

        public List<Earning> Earnings => Earning.Get.Where("dailyinfo_id", Id);

        public List<Expense> Expenses => Expense.Get.Where("dailyinfo_id", Id);

        public double TotalExpense => Expenses.Sum(e => e.Amount);

        public double TotalEarning => Earnings.Sum(e => e.Amount);

        public static List<DailyInfo2> GetAllFromMonth(int month, int? year = null)
        {
            if(year == null)
            {
                return GetAll().FindAll(d => d.Date.Month == month);
            }
            return GetAll().FindAll(d => d.Date.Month == month && d.Date.Year == year);
        }

        public static double GetTotalEarningsByMonth(int month, int? year = null)
        {
            double total = 0;

            if(year == null)
            {
                GetAllFromMonth(month).ForEach(d => total += d.Earnings.Sum(e => e.Amount));
            }
            else
            {
                GetAllFromMonth(month, year).ForEach(d => total += d.Earnings.Sum(e => e.Amount));
            }
            return total;
        }

        public static double GetTotalExpensesByMonth(int month, int? year = null)
        {
            double total = 0;

            if (year == null)
            {
                GetAllFromMonth(month).ForEach(d => total += d.Expenses.Sum(e => e.Amount));
            }
            else
            {
                GetAllFromMonth(month, year).ForEach(d => total += d.Expenses.Sum(e => e.Amount));
            }
            return total;
        }

        public static List<DailyInfo2> GetAll()
        {
            if (DBReflection.DailyInfoModels.Count == 0) DBReflection.DailyInfoModels = Get.All();
            return DBReflection.DailyInfoModels;
        }
    }
}
