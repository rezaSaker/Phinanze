using System;
using System.Collections.Generic;
using System.Linq;

namespace Phinanze.Models.Repositories
{
    public class CategoryRepository: Repository<Category>
    {
        public static Repository<Category> Get => new Repository<Category>(); 
    }
}
