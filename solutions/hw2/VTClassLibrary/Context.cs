using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTClassLibrary
{
    public class Context : DbContext
    {
        public Context() : base("VTDatabase")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<VendingTerminal> VendingTerminals { get; set; }
        public DbSet<DaySellingStatistics> DailySellingStatistics { get; set; }
        public DbSet<ProductVendingTerminal> ProductVendingTerminals { get; set; }
        public DbSet<Cash> CashHolders { get; set; }
    }

}
