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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VTClassLibrary;

namespace VMManagementSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository rep;

        public MainWindow()
        {
            InitializeComponent();
            rep = Repository.Instance;
        }

        private void workWithProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductsWindow pw = new ProductsWindow();
            pw.Show();
        }

        private void workWithVendingTerminal_Click(object sender, RoutedEventArgs e)
        {
            VendingTerminalsWindow vtw = new VendingTerminalsWindow();
            vtw.Show();
        }

        private void viewReports_Click(object sender, RoutedEventArgs e)
        {
            ReportsWindow rw = new ReportsWindow();
            rw.Show();
        }

    }
}
