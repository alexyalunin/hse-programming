using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VTClassLibrary;

namespace VMManagementSystem
{
    /// <summary>
    /// Логика взаимодействия для ReportsWindow.xaml
    /// </summary>
    public partial class ReportsWindow : Window
    {
        public ReportsWindow()
        {
            InitializeComponent();
        }

        private void oneProductMissing_Click(object sender, RoutedEventArgs e)
        {
            using (Context context = new Context())
            {
                var result = from pvt in context.ProductVendingTerminals
                             where pvt.Amount == 0
                             select pvt.VendingTerminal;
                
                string text = "";
                foreach (var res in result)
                {
                    VendingTerminal vt = res as VendingTerminal;
                    if (vt != null)
                    {
                        text += $"Vending Terminal ID: {vt.VTId}, Location: {vt.VTLocation} \n";
                    }
                }
                resultTextBox.Text = text;
            }
        }
        
        private void totalProfit_Click(object sender, RoutedEventArgs e)
        {
            using (Context context = new Context())
            {
                try
                {
                    int month = int.Parse(monthTextBox.Text);
                    int year = int.Parse(yearTextBox.Text);

                    var result = from dss in context.DailySellingStatistics
                                 where dss.Day.Month == month
                                 && dss.Day.Year == year
                                 group (dss.Product.ProductSellingPrice - dss.Product.ProductPurchasePrice) * dss.Amount by dss.VendingTerminal.VTId into pr
                                 orderby pr.Sum() descending
                                 select new { VendingTerminal = pr.Key, SalesValue = pr.Sum() };

                    var text = "";
                    foreach (var res in result)
                    {
                        if (res != null)
                        {
                            text += $"Vending Terminal ID: {res.VendingTerminal}, Profit: {res.SalesValue} \n";
                        }
                    }
                    resultTextBox.Text = text;
                }
                catch (Exception ex)
                {
                    ShowException(ex);
                }
                
            }
        }
        
        private void leastSoldProducts_Click(object sender, RoutedEventArgs e)
        {
            using (Context context = new Context())
            {
                try
                {
                    int month = int.Parse(monthTextBox.Text);
                    int year = int.Parse(yearTextBox.Text);

                    var result = (from dss in context.DailySellingStatistics
                                  where dss.Day.Month == month
                                  && dss.Day.Year == year
                                  group (dss.Product.ProductSellingPrice - dss.Product.ProductPurchasePrice) * dss.Amount by dss.Product.ProductCode into pr
                                  orderby pr.Sum()
                                  select new { ProfuctCode = pr.Key, SalesValue = pr.Sum() }).Take(5);

                    var text = "";
                    foreach (var res in result)
                    {
                        if (res != null)
                        {
                            text += $"Product ID: {res.ProfuctCode}, Profit: {res.SalesValue} \n";
                        }
                    }
                    resultTextBox.Text = text;
                }
                catch (Exception ex)
                {
                    ShowException(ex);
                }
            }
        }

        private void ShowException(Exception ex)
        {
            MessageBoxResult result = MessageBox.Show(ex.Message.ToString(), "Oops", MessageBoxButton.OK);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

    }
}
