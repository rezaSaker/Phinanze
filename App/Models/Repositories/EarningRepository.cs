using System;
using System.Collections.Generic;
using System.Linq;

namespace Phinanze.Models.Repositories
{
    public class EarningRepository: Repository<Earning>
    {
        private static Repository<Earning> _repository;
        public static Repository<Earning> Get
        {
            get
            {
                if (_repository == null)
                {
                    _repository = new Repository<Earning>();
                }
                return _repository;
            }
        }
    }
}
