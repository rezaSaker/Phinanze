using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models.DBInfo
{
    public class DBReflection
    {
        private static List<DailyInfo2> _dailyInfoModels = new List<DailyInfo2>();
        private static List<Category> _categoryModels = null;
        private static List<Earning> _earningModels = null;
        private static List<Expense> _expenseModels = null;


        public static List<DailyInfo2> DailyInfoModels
        {
            get => _dailyInfoModels.Select(d => new DailyInfo2() { Id = d.Id, Date = d.Date, Note = d.Note }).ToList();
            set => _dailyInfoModels = value.Select(d => new DailyInfo2() { Id = d.Id, Date = d.Date, Note = d.Note }).ToList();
        }

        public static List<Category> CategoryModels { get => _categoryModels; set => _categoryModels = value; }

        public static List<Earning> EarningModels { get => _earningModels; set => _earningModels = value; }

        public static List<Expense> ExpenseModels { get => _expenseModels; set => _expenseModels = value; }

        public static bool IsSet => _dailyInfoModels != null && _categoryModels != null && _earningModels != null && _expenseModels != null;
    }
}
