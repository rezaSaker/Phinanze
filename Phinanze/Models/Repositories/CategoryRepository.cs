using System;
using System.Collections.Generic;
using System.Linq;

namespace Phinanze.Models.Repositories
{
    public class CategoryRepository: BaseRepository<Category>
    {
        public CategoryRepository() { _model = null; }

        private Category _model;

        protected Category Model
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
            return base.Save(_model, nameof(Category));
        }

        public static List<Category> GetAll()
        {
            return BaseRepository<Category>.GetAll(nameof(Category));
        }

        public static Category Find(int id)
        {
            return BaseRepository<Category>.GetBy("id", id.ToString(), nameof(Category)).FirstOrDefault();
        }

        public static List<Category> GetBy(string param, string value)
        {
            return BaseRepository<Category>.GetBy(param, value, nameof(Category));
        }

        public static bool Delete(Category c)
        {
            return BaseRepository<Category>.Delete(c, nameof(Category));
        }
    }
}
