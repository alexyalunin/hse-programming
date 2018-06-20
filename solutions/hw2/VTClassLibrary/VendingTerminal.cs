using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTClassLibrary
{
    public class VendingTerminal
    {
        [Key]
        public int VTId { get; set; }
        public string VTLocation { get; set; }
        public int VTCredit { get; set; }

        public virtual Cash Cash { get; set; }
        public virtual ICollection<ProductVendingTerminal> ProductVendingTerminals { get; set; }
    }
}
