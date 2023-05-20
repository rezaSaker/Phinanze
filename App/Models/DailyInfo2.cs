using System;
using System.ComponentModel.DataAnnotations;
using Phinanze.Models.Repositories;
using Phinanze.Models.Validations;

namespace Phinanze.Models
{
    public class DailyInfo2: DailyInfoRepository, IModel
    {
        public DailyInfo2() { Model = this; }

        /// <summary>
        /// Date property - only accepts default DateTime format (yyyy-mm-dd hh:mm:ss AM) or (yyyy-mm-dd)
        /// </summary>
        [Required(ErrorMessage = "Date is required for daily info")]
        [CustomValidation(typeof(CustomValidations), "ValidDate")]
        public DateTime Date { get; set; }

        [StringLength(255, ErrorMessage = "Note cannot exceed 255 characters")]
        public string Note { get; set; }
    }
}
