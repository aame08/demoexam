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
    /// Логика взаимодействия для EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window
    {
        public static EditOrder editOrder;
        public EditOrder()
        {
            InitializeComponent();

            editOrder = this;

            DataContext = new BrowseProduct();
        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В процессе...");
        }
    }
}
