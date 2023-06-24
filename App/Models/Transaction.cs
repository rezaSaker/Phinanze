using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Phinanze.Models.Repositories;
using Phinanze.Models.Validations;

namespace Phinanze.Models
{
    public class Transaction: TransactionRepository, IModel
    {
        public Transaction() { Model = this; }

        /// <summary>
        /// Date property - only accepts default DateTime format (yyyy-mm-dd hh:mm:ss AM) or (yyyy-mm-dd)
        /// </summary>
        [Required(ErrorMessage = "Date is required")]
        [CustomValidation(typeof(CustomValidations), "ValidDate")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0, 1000000, ErrorMessage = "Amount must be between 0 and 1000000")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Category id is required")]
        [Range(1, 1000000000, ErrorMessage = "Invalid Category id")]
        public int CategoryId { get; set; }

        [StringLength(255, ErrorMessage = "Note cannot exceed 255 characters")]
        public string Note { get; set; }
    }
}
