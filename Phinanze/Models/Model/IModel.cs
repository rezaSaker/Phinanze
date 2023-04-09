using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models.Model
{
    public interface IModel<T>
    {
        int Find(int id);
    }
}
