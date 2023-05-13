using System;
using System.Collections.Generic;
using System.Linq;

namespace Phinanze.Models.Repositories
{
    public class ExpenseRepository: Repository<Expense>
    {
        public static Repository<Expense> Get { get => new Repository<Expense>(); }
    }
}
