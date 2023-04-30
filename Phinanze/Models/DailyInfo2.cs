using Phinanze.Models.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

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

        [Required(ErrorMessage = "Date is required for daily info")]
        public DateTime Date
        {
            get => _date; 
            set => _date = value; 
        }

        [StringLength(255, ErrorMessage = "Note cannot exceed 255 characters")]
        public string Note
        {
            get => _note; 
            set => _note = value; 
        }
    }
}
