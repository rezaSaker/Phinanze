using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Models.ViewModels
{
    public class PieChartPoint
    {
        public string X { get; set; }

        public double Y { get; set; }

        [Required]
        public Color BackColor { get; set; }

        public Color ForeColor { get; set; }
    }
}
