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

namespace VendingTerminal
{
    public partial class MainWindow : Window
    {
        VendingMachineModel vm = new VendingMachineModel();
        
        public MainWindow()
        {
            InitializeComponent();
            vm.OnClicksUpdated += UpdateView;
            vm.FeedbackDelegate += ShowMessageBox;

            vm.GetVendingMashineInfo();
        }

        private void ViewDidLoad(object sender, RoutedEventArgs e)
        {
            UpdateView();
            var billAcceptor = new CashAcceptor(vm);
            billAcceptor.Show();
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            vm.GiveChange(VendingMachine.instance.credit);
        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            var item = itemsListView.SelectedItem as Item;
            if (item != null)
            {
                vm.BuyItem(item);
            }
        }

        private void UpdateView()
        {
            itemsListView.ItemsSource = null;
            itemsListView.ItemsSource = VendingMachine.instance.items;
            creditTextBlock.Text = $"Credit: {VendingMachine.instance.credit} RUB";
        }

        private void ShowMessageBox(string _text)
        {
            MessageBoxResult result = MessageBox.Show(_text, "Oops", MessageBoxButton.OK);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

    }
}
