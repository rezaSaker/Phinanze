using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phinanze.Utils;

namespace Phinanze.Models
{
    public class Category
    {
        public int Id { get; set; }
        public CategoryType Type { get; set; }
        public string Name { get; set; }
    }
}
