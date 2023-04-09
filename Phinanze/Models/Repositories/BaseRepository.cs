using Phinanze.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models.Repositories
{
    public abstract class BaseRepository<T>
    {
        protected readonly string ConnectionString;

        public abstract List<T> All();
        public abstract object Find(int id);
        public abstract object Update(int id, object model);
        public abstract object Delete(int id);
    }
}
