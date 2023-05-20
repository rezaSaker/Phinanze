using System;
using System.Collections.Generic;
using System.Linq;

namespace Phinanze.Models.Repositories
{
    public class CategoryRepository: Repository<Category>
    {
        private static Repository<Category> _repository;
        public static Repository<Category> Get
        {
            get
            {
                if (_repository == null)
                {
                    _repository = new Repository<Category>();
                }
                return _repository;
            }
        }
    }
}
