using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models.Repositories
{
    public class UserRepository: Repository<User>
    {
        public static Repository<User> Get => new Repository<User>();
    }
}
