using Demka.Services;
using Demka.ViewsModels;
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

namespace Demka.Views
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public static Admin admin;
        public Admin()
        {
            InitializeComponent();

            admin = this;

            DataContext = new BrowseProduct();

            //dgProduct.ItemsSource = ProductServices.GetProducts();
            //dgOrders.ItemsSource = OrderServices.GetOrder();
        }

        //private void bEditData_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("В процессе...");
        //}

        private void bEditOrder_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В процессе...");
        }
    }
}
