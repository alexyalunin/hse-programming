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

namespace VendingTerminal
{
    public partial class CashAcceptor : Window
    {
        VendingMachineModel vm;

        public CashAcceptor(VendingMachineModel _vm)
        {
            InitializeComponent();
            vm = _vm;
        }

        private void cashButton_Click(object sender, RoutedEventArgs e)
        {
            string text = (sender as Button).Content.ToString();
            int amount = int.Parse(text);
            vm.UpdateCash(amount);
            vm.ChangeCredit(amount);
        }

    }
}
