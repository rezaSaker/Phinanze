using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models.Repositories
{
    public class UserRepository: BaseRepository<User>
    {
        public UserRepository() { _model = null; }

        private User _model;

        protected User Model { set => _model = value; }

        public bool Save()
        {
            return base.Save(_model, nameof(Category));
        }

        public static bool Delete(ref Category c)
        {
            if (BaseRepository<Category>.Delete(c, nameof(Category)))
            {
                c = null;
            }
            return c == null;
        }
    }
}
