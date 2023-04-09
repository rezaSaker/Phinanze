using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phinanze.Models.Data;

namespace Phinanze.Models.Repositories
{
    public class EarningRepository: BaseRepository<Earning>
    {
        private readonly EarningData _earningData;

        public EarningRepository()
        {
            _earningData = EarningData.GetInstance();
        }
        public override List<Earning> All()
        {
            return _earningData.EarningList;
        }

        public override object Find(int id)
        {
            return new object();
        }

        public override object Update(int id, object model)
        {
            return new object();
        }

        public override object Delete(int id)
        {
            return new object();
        }
    }
}
