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

        public Category Category()
        {
            return Phinanze.Models.Category.Get.All().Find(c => c.Id == Model.CategoryId);
        }
    }
}
