using Phinanze.Models.Statics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phinanze.Models.Repositories
{
    public class TransactionRepository: Repository<Transaction>
    {
        private static Repository<Transaction> _repository;
        public static Repository<Transaction> Get
        {
            get
            {
                if (_repository == null)
                {
                    _repository = new Repository<Transaction>();
                }
                return _repository;
            }
        }

        public static List<Transaction> AllEarnings()
        {
            return Get.All().FindAll(t => t.Category().CategoryType == CategoryType.EARNING);
        }

        public static List<Transaction> AllExpenses()
        {
            return Get.All().FindAll(t => t.Category().CategoryType == CategoryType.EXPENSE);
        }

        public static List<Transaction> GetAllFromMonth(int month, int? year = null)
        {
            if (year == null)
            {
                return Get.All().FindAll(t => t.Date.Month == month);
            }
            return Get.All().FindAll(t => t.Date.Month == month && t.Date.Year == year);
        }

        public static double GetTotalEarningsByMonth(int month, int? year = null)
        {
            if (year == null)
            {
                return GetAllFromMonth(month).FindAll(t => t.Category().CategoryType == CategoryType.EARNING).Sum(t => t.Amount);
            }
            return GetAllFromMonth(month).FindAll(t => t.Category().CategoryType == CategoryType.EARNING).Sum(t => t.Amount);
        }

        public static double GetTotalExpensesByMonth(int month, int? year = null)
        {
            if (year == null)
            {
                return GetAllFromMonth(month).FindAll(t => t.Category().CategoryType == CategoryType.EXPENSE).Sum(t => t.Amount);
            }
            return GetAllFromMonth(month).FindAll(t => t.Category().CategoryType == CategoryType.EXPENSE).Sum(t => t.Amount);
        }

        public Category Category()
        {
            return Phinanze.Models.Category.Get.All().Find(c => c.Id == Model.CategoryId);
        }
    }
}
