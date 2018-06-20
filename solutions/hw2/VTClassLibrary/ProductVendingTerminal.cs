using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTClassLibrary
{
    public class ProductVendingTerminal
    {
        [Key, Column(Order = 0)]
        public string ProductCode { get; set; }
        [Key, Column(Order = 1)]
        public int VTId { get; set; }

        public virtual Product Product { get; set; }
        public virtual VendingTerminal VendingTerminal { get; set; }

        public int Amount { get; set; }
    }
}
