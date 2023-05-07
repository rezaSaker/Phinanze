using System;
using System.Collections.Generic;
using System.Linq;

namespace Phinanze.Models.Repositories
{
    public class ExpenseRepository: BaseRepository<Expense>
    {
        public ExpenseRepository() { _model = null; }

        private Expense _model;
        protected Expense Model
        {
            set
            {
                if (_model == null)
                {
                    _model = value;
                }
                else
                {
                    throw new ArgumentException("Model is already assigned");
                }
            }
        }

        public bool Save()
        {
            return base.Save(_model, nameof(Expense));
        }
        public static List<Expense> GetAll()
        {
            return BaseRepository<Expense>.GetAll(nameof(Expense));
        }

        public static Expense Find(int id)
        {
            return BaseRepository<Expense>.GetBy("id", id.ToString(), nameof(Expense)).FirstOrDefault();
        }

        public static List<Expense> GetBy(string param, string value)
        {
            return BaseRepository<Expense>.GetBy(param, value, nameof(Expense));
        }

        public static bool Delete(Expense e)
        {
            return BaseRepository<Expense>.Delete(e, nameof(Expense));
        }
    }
}
