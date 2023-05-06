using System;
using System.ComponentModel.DataAnnotations;
using Phinanze.Models.Repositories;
using Phinanze.Models.Validations;

namespace Phinanze.Models
{
    public class DailyInfo2: DailyInfoRepository, IModel
    {
        public DailyInfo2() 
        {
            _id = 0;
            Model = this; 
        } 

        private int _id;
        private DateTime _date;
        private string _note;

        [Key]
        public int Id
        {
            get => _id;
            set
            {
                if (_id == 0)
                {
                    _id = value;
                }
                else
                {
                    throw new ArgumentException("Model id property cannot be changed");
                }
            }
        }

        /// <summary>
        /// Date property - only accepts default DateTime format (yyyy-mm-dd hh:mm:ss AM) or (yyyy-mm-dd)
        /// </summary>
        [Required(ErrorMessage = "Date is required for daily info")]
        [CustomValidation(typeof(CustomValidations), "ValidDate")]
        public DateTime Date
        {
            get => _date; 
            set => _date = value.Date; 
        }

        [StringLength(255, ErrorMessage = "Note cannot exceed 255 characters")]
        public string Note
        {
            get => _note; 
            set => _note = value; 
        }
    }
}
