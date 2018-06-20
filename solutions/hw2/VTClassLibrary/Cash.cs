using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTClassLibrary
{
    public class Cash
    {
        [Key]
        public int CashID { get; set; }

        public int RUB1 { get; set; }
        public int RUB2 { get; set; }
        public int RUB5 { get; set; }
        public int RUB10 { get; set; }
        public int RUB50 { get; set; }
        public int RUB100 { get; set; }
        public int RUB500 { get; set; }
        public int RUB1000 { get; set; }
    }
}
