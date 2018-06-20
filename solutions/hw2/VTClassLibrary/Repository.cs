using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTClassLibrary
{
    public class Repository
    {
        private static Repository instance;

        public List<Product> products;
        public List<Cash> caches;
        public List<VendingTerminal> vendingTerminals;
        public List<DaySellingStatistics> daySellingStatistics;
        public List<ProductVendingTerminal> productVendingTerminals;

        public static Repository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Repository();
                }
                return instance;
            }
        }

        private Repository() {
            using (Context context = new Context())
            {
                var pr1 = new Product { ProductCode = "MARS", ProductName = "Mars", ProductPurchasePrice = 50, ProductSellingPrice = 55 };
                var pr2 = new Product { ProductCode = "SNKS", ProductName = "Snickers", ProductPurchasePrice = 45, ProductSellingPrice = 57 };
                var pr3 = new Product { ProductCode = "MLCK", ProductName = "Milckey Way", ProductPurchasePrice = 44, ProductSellingPrice = 56 };
                var pr4 = new Product { ProductCode = "COLA", ProductName = "Coca-cola", ProductPurchasePrice = 35, ProductSellingPrice = 38 };
                var pr5 = new Product { ProductCode = "PEPS", ProductName = "Pepsi", ProductPurchasePrice = 30, ProductSellingPrice = 39 };
                var pr6 = new Product { ProductCode = "FANT", ProductName = "Fanta", ProductPurchasePrice = 36, ProductSellingPrice = 40 };
                var pr7 = new Product { ProductCode = "LAYS", ProductName = "LAYS", ProductPurchasePrice = 40, ProductSellingPrice = 44 };
                var pr8 = new Product { ProductCode = "PRNG", ProductName = "Pringles", ProductPurchasePrice = 41, ProductSellingPrice = 45 };
                var pr9 = new Product { ProductCode = "DRTS", ProductName = "Doritos", ProductPurchasePrice = 42, ProductSellingPrice = 46 };

                products = new List<Product>
                {
                    pr1, pr2, pr3, pr4, pr5, pr6, pr7, pr8, pr9
                };

                var c1 = new Cash
                {
                    CashID = 1,
                    RUB1 = 10,
                    RUB2 = 10,
                    RUB5 = 10,
                    RUB10 = 10,
                    RUB50 = 50,
                    RUB100 = 12,
                    RUB500 = 10,
                    RUB1000 = 10
                };
                var c2 = new Cash
                {
                    CashID = 2,
                    RUB1 = 10,
                    RUB2 = 8,
                    RUB5 = 42,
                    RUB10 = 10,
                    RUB50 = 50,
                    RUB100 = 12,
                    RUB500 = 10,
                    RUB1000 = 10,
                };
                var c3 = new Cash
                {
                    CashID = 3,
                    RUB1 = 10,
                    RUB2 = 105,
                    RUB5 = 13,
                    RUB10 = 54,
                    RUB50 = 51,
                    RUB100 = 12,
                    RUB500 = 54,
                    RUB1000 = 10
                };

                caches = new List<Cash>
                {
                    c1, c2, c3
                };


                var vt1 = new VendingTerminal
                {
                    VTId = 1,
                    VTCredit = 50,
                    VTLocation = "Kirpichnaya 33",
                    Cash = c1
                };
                var vt2 = new VendingTerminal
                {
                    VTId = 2,
                    VTCredit = 40,
                    VTLocation = "Betonnaya 34",
                    Cash = c2
                };
                var vt3 = new VendingTerminal
                {
                    VTId = 3,
                    VTCredit = 66,
                    VTLocation = "Derevyannaya 35",
                    Cash = c3
                };

                vendingTerminals = new List<VendingTerminal>
                {
                    vt1, vt2, vt3
                };


                var d1_1 = new DaySellingStatistics
                {
                    DayProductId = 1,
                    VendingTerminal = vt1,
                    Product = pr1,
                    Day = DateTime.Today.AddDays(-5),
                    Amount = 5
                };
                var d1_2 = new DaySellingStatistics
                {
                    DayProductId = 2,
                    VendingTerminal = vt1,
                    Product = pr2,
                    Day = DateTime.Today.AddDays(-5),
                    Amount = 7
                };
                var d1_3 = new DaySellingStatistics
                {
                    DayProductId = 3,
                    VendingTerminal = vt1,
                    Product = pr3,
                    Day = DateTime.Today.AddDays(-5),
                    Amount = 9
                };
                var d2_1 = new DaySellingStatistics
                {
                    DayProductId = 4,
                    VendingTerminal = vt2,
                    Product = pr2,
                    Day = DateTime.Today.AddDays(-5),
                    Amount = 5
                };
                var d2_2 = new DaySellingStatistics
                {
                    DayProductId = 5,
                    VendingTerminal = vt2,
                    Product = pr6,
                    Day = DateTime.Today.AddDays(-5),
                    Amount = 3
                };
                var d2_3 = new DaySellingStatistics
                {
                    DayProductId = 6,
                    VendingTerminal = vt2,
                    Product = pr8,
                    Day = DateTime.Today.AddDays(-5),
                    Amount = 12
                };
                var d3_1 = new DaySellingStatistics
                {
                    DayProductId = 7,
                    VendingTerminal = vt3,
                    Product = pr5,
                    Day = DateTime.Today.AddDays(-5),
                    Amount = 11
                };
                var d3_2 = new DaySellingStatistics
                {
                    DayProductId = 8,
                    VendingTerminal = vt3,
                    Product = pr7,
                    Day = DateTime.Today.AddDays(-5),
                    Amount = 5
                };
                var d3_3 = new DaySellingStatistics
                {
                    DayProductId = 9,
                    VendingTerminal = vt3,
                    Product = pr9,
                    Day = DateTime.Today.AddDays(-5),
                    Amount = 2
                };

                var d4_1 = new DaySellingStatistics
                {
                    DayProductId = 1,
                    VendingTerminal = vt1,
                    Product = pr1,
                    Day = DateTime.Today.AddDays(-4),
                    Amount = 5
                };
                var d4_2 = new DaySellingStatistics
                {
                    DayProductId = 2,
                    VendingTerminal = vt1,
                    Product = pr2,
                    Day = DateTime.Today.AddDays(-4),
                    Amount = 7
                };
                var d4_3 = new DaySellingStatistics
                {
                    DayProductId = 3,
                    VendingTerminal = vt1,
                    Product = pr3,
                    Day = DateTime.Today.AddDays(-4),
                    Amount = 9
                };
                var d5_1 = new DaySellingStatistics
                {
                    DayProductId = 4,
                    VendingTerminal = vt2,
                    Product = pr2,
                    Day = DateTime.Today.AddDays(-4),
                    Amount = 5
                };
                var d5_2 = new DaySellingStatistics
                {
                    DayProductId = 5,
                    VendingTerminal = vt2,
                    Product = pr6,
                    Day = DateTime.Today.AddDays(-4),
                    Amount = 3
                };
                var d5_3 = new DaySellingStatistics
                {
                    DayProductId = 6,
                    VendingTerminal = vt2,
                    Product = pr8,
                    Day = DateTime.Today.AddDays(-4),
                    Amount = 12
                };
                var d6_1 = new DaySellingStatistics
                {
                    DayProductId = 7,
                    VendingTerminal = vt3,
                    Product = pr5,
                    Day = DateTime.Today.AddDays(-4),
                    Amount = 11
                };
                var d6_2 = new DaySellingStatistics
                {
                    DayProductId = 8,
                    VendingTerminal = vt3,
                    Product = pr7,
                    Day = DateTime.Today.AddDays(-4),
                    Amount = 5
                };
                var d6_3 = new DaySellingStatistics
                {
                    DayProductId = 9,
                    VendingTerminal = vt3,
                    Product = pr9,
                    Day = DateTime.Today.AddDays(-4),
                    Amount = 2
                };

                daySellingStatistics = new List<DaySellingStatistics>
                {
                    d1_1, d1_2, d1_3, d2_1, d2_2, d2_3, d3_1, d3_2, d3_3, d4_1, d4_2, d4_3, d5_1, d5_2, d5_3, d6_1, d6_2, d6_3
                };

                ProductVendingTerminal pvt1 = new ProductVendingTerminal() { Product = pr1, VendingTerminal = vt1, Amount = 5 };
                ProductVendingTerminal pvt2 = new ProductVendingTerminal() { Product = pr2, VendingTerminal = vt1, Amount = 8 };
                ProductVendingTerminal pvt3 = new ProductVendingTerminal() { Product = pr3, VendingTerminal = vt1, Amount = 2 };
                ProductVendingTerminal pvt4 = new ProductVendingTerminal() { Product = pr4, VendingTerminal = vt2, Amount = 0 };
                ProductVendingTerminal pvt5 = new ProductVendingTerminal() { Product = pr5, VendingTerminal = vt2, Amount = 3 };
                ProductVendingTerminal pvt6 = new ProductVendingTerminal() { Product = pr6, VendingTerminal = vt2, Amount = 12 };
                ProductVendingTerminal pvt7 = new ProductVendingTerminal() { Product = pr7, VendingTerminal = vt3, Amount = 3 };
                ProductVendingTerminal pvt8 = new ProductVendingTerminal() { Product = pr8, VendingTerminal = vt3, Amount = 0 };
                ProductVendingTerminal pvt9 = new ProductVendingTerminal() { Product = pr9, VendingTerminal = vt3, Amount = 8 };

                productVendingTerminals = new List<ProductVendingTerminal>
                {
                    pvt1, pvt2, pvt3, pvt4, pvt5, pvt6, pvt7, pvt8, pvt9
                };

                if ((new Context()).Products.Count() < 1)
                {
                    UploadDataToContext();
                }
            }
        }

        private void UploadDataToContext()
        {
            using (Context context = new Context())
            {
                foreach (Product pr in products)
                {
                    context.Products.Add(pr);
                }

                foreach (Cash c in caches)
                {
                    context.CashHolders.Add(c);
                }

                foreach (VendingTerminal vt in vendingTerminals)
                {
                    context.VendingTerminals.Add(vt);
                }

                foreach (DaySellingStatistics dss in daySellingStatistics)
                {
                    context.DailySellingStatistics.Add(dss);
                }

                foreach (ProductVendingTerminal pvt in productVendingTerminals)
                {
                    context.ProductVendingTerminals.Add(pvt);
                }

                context.SaveChanges();
            }
        }

    }
}
