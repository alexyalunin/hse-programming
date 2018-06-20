using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingTerminal
{
    public class VendingMachine
    {
        public static VendingMachine instance;

        public int credit { get; set; }
        public List<Item> items { get; set; }
        public Cash cash { get; set; }
    }
}
