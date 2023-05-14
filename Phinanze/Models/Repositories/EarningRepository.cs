using System;
using System.Collections.Generic;
using System.Linq;

namespace Phinanze.Models.Repositories
{
    public class EarningRepository: Repository<Earning>
    {
        public static Repository<Earning> Get => new Repository<Earning>(); 
    }
}
