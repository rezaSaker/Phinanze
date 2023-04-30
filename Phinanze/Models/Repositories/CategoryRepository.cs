using System;
using System.Collections.Generic;

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
            return BaseRepository<Category>.GetBy("Id", id.ToString(), nameof(Category));
        }

        public static bool Delete(ref Category c)
        {
            if(BaseRepository<Category>.Delete(c, nameof(Category)))
            {
                c = null;
            }
            return c == null;
        }
    }
}
