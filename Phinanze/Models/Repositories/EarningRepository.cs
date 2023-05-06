using System;
using System.Collections.Generic;
using System.Linq;

namespace Phinanze.Models.Repositories
{
    public class EarningRepository: BaseRepository<Earning>
    {
        public EarningRepository() { _model = null; }

        private Earning _model;

        protected Earning Model
        {
            set
            {
                if(_model == null)
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
            return base.Save(_model, nameof(Earning));
        }

        public static List<Earning> GetAll()
        {
            return BaseRepository<Earning>.GetAll(nameof(Earning));
        }

        public static Earning Find(int id)
        {
            return BaseRepository<Earning>.GetBy("id", id.ToString(), nameof(Earning)).FirstOrDefault();
        }

        public static List<Earning> GetBy(string param, string value)
        {
            return BaseRepository<Earning>.GetBy(param, value, nameof(Earning));
        }

        public static bool Delete(ref Earning e)
        {
            if(BaseRepository<Earning>.Delete(e, nameof(Earning)))
            {
                e = null;
            }
            return e == null;
        }
    }
}
