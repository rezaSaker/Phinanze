using System;
using System.Collections.Generic;
using System.Linq;

namespace Phinanze.Models.Repositories
{
    public class ExpenseRepository: Repository<Expense>
    {
        private static Repository<Expense> _repository;
        public static Repository<Expense> Get
        {
            get
            {
                if (_repository == null)
                {
                    _repository = new Repository<Expense>();
                }
                return _repository;
            }
        }
    }
}
