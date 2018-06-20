using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTClassLibrary
{
    public class DaySellingStatistics
    {
        [Key]
        public int DayProductId { get; set; }
        public DateTime Day { get; set; }
        public VendingTerminal VendingTerminal { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}
