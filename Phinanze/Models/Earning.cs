using Phinanze.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models
{
    public class Earning: EarningRepository
    {
        public Earning() { }
        public Earning(Earning e)
        {
            this.Id = e.Id;
            this.Amount = e.Amount;
            this.Category = e.Category;
            this.Comment = e.Comment;
        }
        public int Id { get; set; }
        public double Amount { get; set; }
        public Category Category { get; set; }
        public string Comment { get; set; }
    }
}
