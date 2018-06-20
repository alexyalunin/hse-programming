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
    /// Логика взаимодействия для ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        public ProductsWindow()
        {
            InitializeComponent();
        }

        private void ViewDidLoad(object sender, RoutedEventArgs e)
        {
            using (Context context = new Context())
            {
                ReloadDataGrid(context);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            using (Context context = new Context())
            {
                try
                {
                    string cd = codeTextBox.Text;
                    string nm = nameTextBox.Text;
                    int pp = int.Parse(purchasePriceTextBox.Text);
                    int sp = int.Parse(sellingPriceTextBox.Text);

                    Product pr = new Product() { ProductCode = cd, ProductName = nm, ProductPurchasePrice = pp, ProductSellingPrice = sp };
                    context.Products.Add(pr);

                    context.SaveChanges();

                    ReloadDataGrid(context);
                }
                catch (Exception ex)
                {
                    ShowException(ex);
                }
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            using (Context context = new Context())
            {
                try
                {
                    var pr = context.Products.FirstOrDefault(p => p.ProductCode == codeTextBox.Text);

                    if (pr == null)
                    {
                        ShowException(new Exception("You can not change code of existing product"));
                        return;
                    }

                    pr.ProductName = nameTextBox.Text;
                    pr.ProductPurchasePrice = int.Parse(purchasePriceTextBox.Text);
                    pr.ProductSellingPrice = int.Parse(sellingPriceTextBox.Text);

                    context.SaveChanges();

                    ReloadDataGrid(context);
                }
                catch (Exception ex)
                {
                    ShowException(ex);
                }
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (Context context = new Context())
            {
                try
                {
                    var pr = context.Products.FirstOrDefault(p => p.ProductCode == codeTextBox.Text);

                    if (pr == null)
                    {
                        ShowException(new Exception("Product is not found in database"));
                        return;
                    }

                    if (pr.ProductVendingTerminals.Count > 0)
                    {
                        Exception ex = new Exception("You can not delete this item because it has been linked to vending terminal.");
                        ShowException(ex);
                        return;
                    }

                    context.Products.Remove(pr);

                    context.SaveChanges();

                    ReloadDataGrid(context);
                }
                catch (Exception ex)
                {
                    ShowException(ex);
                }
            }
        }

        private void productsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedProduct = productsDataGrid.SelectedItem as Product;
            if (selectedProduct == null)
                return;

            codeTextBox.Text = selectedProduct.ProductCode;
            nameTextBox.Text = selectedProduct.ProductName;
            purchasePriceTextBox.Text = selectedProduct.ProductPurchasePrice.ToString();
            sellingPriceTextBox.Text = selectedProduct.ProductSellingPrice.ToString();
        }

        private void ReloadDataGrid(Context context)
        {
            productsDataGrid.ItemsSource = context.Products.ToList();
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
