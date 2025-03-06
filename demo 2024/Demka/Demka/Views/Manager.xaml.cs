using Demka.Services;
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
using Demka.ViewsModels;

namespace Demka.Views
{
    /// <summary>
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        public static Manager manager;
        public Manager()
        {
            InitializeComponent();

            manager = this;

            DataContext = new BrowseProduct();

            dgOrders.ItemsSource = OrderServices.GetOrder();
        }

        private void bEditData_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В процессе...");
        }
    }
}
