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
    /// Логика взаимодействия для VendingTerminalsWindow.xaml
    /// </summary>
    public partial class VendingTerminalsWindow : Window
    {
        public VendingTerminalsWindow()
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
                    int id = int.Parse(idTextBox.Text);
                    string loc = locationTextBox.Text;

                    VendingTerminal pr = new VendingTerminal() { VTId = id, VTLocation = loc};
                    context.VendingTerminals.Add(pr);

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
                    var id = int.Parse(idTextBox.Text);
                    var vt = context.VendingTerminals.FirstOrDefault(p => p.VTId == id);

                    if (vt == null)
                    {
                        ShowException(new Exception("You can not change id of existing vending terminal"));
                        return;
                    }

                    vt.VTLocation = locationTextBox.Text;
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
                    var id = int.Parse(idTextBox.Text);
                    var vt = context.VendingTerminals.FirstOrDefault(p => p.VTId == id);

                    if (vt == null)
                    {
                        ShowException(new Exception("Vending terminal is not found in database"));
                        return;
                    }

                    context.VendingTerminals.Remove(vt);

                    context.SaveChanges();

                    ReloadDataGrid(context);
                }
                catch (Exception ex)
                {
                    ShowException(ex);
                }
            }
        }

        private void vendingTerminalsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedVendingTerminal = vendingTerminalsDataGrid.SelectedItem as VendingTerminal;
            if (selectedVendingTerminal == null)
                return;

            idTextBox.Text = selectedVendingTerminal.VTId.ToString();
            locationTextBox.Text = selectedVendingTerminal.VTLocation;
        }

        private void ReloadDataGrid(Context context)
        {
            using (context)
            {
                vendingTerminalsDataGrid.ItemsSource = context.VendingTerminals.ToList();
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
