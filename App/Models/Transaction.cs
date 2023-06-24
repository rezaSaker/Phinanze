using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Phinanze.Models.Repositories;

namespace Phinanze.Models
{
    public class Transaction: TransactionRepository, IModel, ITransaction
    {
        public Transaction() { Model = this; }

        [Required(ErrorMessage = "Earning amount is required")]
        [Range(0, 1000000, ErrorMessage = "Earning amount must be between 0 and 1000000")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Category id is required")]
        [Range(1, 1000000000, ErrorMessage = "Invalid Category id")]
        public int CategoryId { get; set; }

        [StringLength(255, ErrorMessage = "Comment cannot exceed 255 characters")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "DailyInfo id is required")]
        [Range(1, 1000000000, ErrorMessage = "Invalid DailyInfo id")]
        public int DailyInfoId { get; set; }
    }
}
