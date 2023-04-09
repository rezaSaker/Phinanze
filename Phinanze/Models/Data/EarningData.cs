using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phinanze.Models;

namespace Phinanze.Models.Data
{
    public class EarningData
    {
        private static EarningData _instance;
        private List<Earning> _earningList;

        private EarningData()
        {
            _earningList = new List<Earning>();
        }

        public static EarningData GetInstance()
        {
            if (_instance == null)
            {
                _instance = new EarningData();
            }
            return _instance;
        }

        public List<Earning> EarningList 
        { 
            get 
            { 
                List<Earning> earningListCopy = _earningList.Select(e => new Earning(e)).ToList();
                return earningListCopy; 
            } 
        }
    }
}
