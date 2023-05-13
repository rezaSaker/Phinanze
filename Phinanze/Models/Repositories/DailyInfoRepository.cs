using System;
using System.Collections.Generic;
using System.Linq;

namespace Phinanze.Models.Repositories
{
    public class DailyInfoRepository: Repository<DailyInfo2>
    {
        public static Repository<DailyInfo2> Get { get => new Repository<DailyInfo2>(); }
    }
}
