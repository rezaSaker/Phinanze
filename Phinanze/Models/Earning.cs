using Phinanze.Models.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Phinanze.Models
{
    public class Earning: EarningRepository, IModel
    {
        public Earning() 
        {
            _id = 0;
            Model = this; 
        }

        private int _id;
        private double _amount;
        private int _categoryId;
        private string _comment;
        private int _dailyInfoId;

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

        [Required(ErrorMessage = "Earning amount is required")]
        [Range(0, 1000000, ErrorMessage = "Earning amount must be between 0 and 1000000")]
        public double Amount 
        { 
            get => _amount; 
            set => _amount = value; 
        }

        [ForeignKey("CateogryId")]
        [Required(ErrorMessage = "Category id is required")]
        [Range(1, 1000000000, ErrorMessage = "Invalid Category id")]
        public int CategoryId
        { 
            get => _categoryId; 
            set => _categoryId = value; 
        }

        [StringLength(255, ErrorMessage = "Comment cannot exceed 255 characters")]
        public string Comment 
        { 
            get => _comment; 
            set => _comment = value; 
        }

        [ForeignKey("DailyInfoId")]
        [Required(ErrorMessage = "DailyInfo id is required")]
        [Range(1, 1000000000, ErrorMessage = "Invalid DailyInfo id")]
        public int DailyInfoId
        {
            get => _dailyInfoId;
            set => _dailyInfoId = value;
        }
    }
}
