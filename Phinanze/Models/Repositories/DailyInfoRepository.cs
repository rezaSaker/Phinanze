using System;
using System.Collections.Generic;
using System.Linq;

namespace Phinanze.Models.Repositories
{
    public class DailyInfoRepository: BaseRepository<DailyInfo2>
    {
        public DailyInfoRepository() { _model = null; }

        private DailyInfo2 _model;
        protected DailyInfo2 Model
        {
            set
            {
                if (_model == null)
                {
                    _model = value;
                }
                else
                {
                    throw new ArgumentException("Model is already assigned");
                }
            }
        }

        public bool Save()
        {
            return base.Save(_model, nameof(DailyInfo2));
        }

        public static List<DailyInfo2> GetAll()
        {
            return BaseRepository<DailyInfo2>.GetAll(nameof(DailyInfo2));
        }

        public static DailyInfo2 Find(int id)
        {
            return BaseRepository<DailyInfo2>.GetBy("id", id.ToString(), nameof(DailyInfo2)).FirstOrDefault();
        }

        public static List<DailyInfo2> GetBy(string param, string value)
        {
            return BaseRepository<DailyInfo2>.GetBy(param, value, nameof(DailyInfo2));
        }

        public static bool Delete(DailyInfo2 d)
        {
            return BaseRepository<DailyInfo2>.Delete(d, nameof(DailyInfo2));
        }
    }
}
