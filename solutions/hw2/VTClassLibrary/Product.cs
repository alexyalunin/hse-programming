using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTClassLibrary
{
    public class Product
    {
        [Key]
        [StringLength(4)]
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int ProductSellingPrice { get; set; }
        public int ProductPurchasePrice { get; set; }

        public virtual ICollection<ProductVendingTerminal> ProductVendingTerminals { get; set; }
    }
}
