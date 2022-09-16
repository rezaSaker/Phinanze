using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Utils
{
    class MonthlyInfo
    {
        private int _month;
        private int _year;

        private double _earning;
        private double _expense;

        public MonthlyInfo() { }

        public int Month
        {
            get => _month; 
            set => _month = value; 
        }

        public int Year
        {
            get => _year; 
            set => _year = value; 
        }

        public double Earning
        {
            get => _earning; 
            set => _earning = value; 
        }

        public double Expense
        {
            get => _expense; 
            set => _expense = value; 
        }

        /// <summary>
        /// Fetch monthly info from the list of daily info 
        /// and store it in StaticStorage.MonthlyInfoList
        /// </summary>
        public static void Fetch()
        {
            GlobalSettings.MonthlyInfoList.Clear();

            if (GlobalSettings.DailyInfoList.Count < 1)
            {
                //monthly info consists of daily info
                //so, no daily info means no monthly info 
                return;
            }

            //we get the info from db in decsneding order of year
            //so the first year in the list is the most recent
            //and last year in the list is the oldest year
            int recentYear = GlobalSettings.DailyInfoList[0].Year;
            int oldestYear = GlobalSettings.DailyInfoList[GlobalSettings.DailyInfoList.Count - 1].Year;

            for (int year = oldestYear; year <= recentYear; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    List<DailyInfo> dailyInfoList = GlobalSettings.DailyInfoList.FindAll(
                        d => d.Year == year && d.Month == month);

                    if(dailyInfoList != null && dailyInfoList.Count > 0)
                    {
                        double earning = dailyInfoList.Sum(d => d.TotalEarning);
                        double expense = dailyInfoList.Sum(d => d.TotalExpense);

                        MonthlyInfo monthly = new MonthlyInfo();
                        monthly.Month = month;
                        monthly.Year = year;
                        monthly.Expense = expense;
                        monthly.Earning = earning;
                        GlobalSettings.MonthlyInfoList.Add(monthly);
                    }                  
                }
            }
        }

    }
}
