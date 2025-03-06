using Demka.ViewsModels;
using Microsoft.Win32;
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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public static AddProduct addProduct;
        public AddProduct()
        {
            InitializeComponent();

            addProduct = this;

            DataContext = new BrowseProduct();
        }

        private void bImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.Filter = "Изображения (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (FD.ShowDialog() == true)
            {
                tbImage.Text = FD.FileName;
            }
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            tbProductArticleNumber.Text = string.Empty;
            cbCategory.SelectedIndex = -1;
            tbProductName.Text = string.Empty;
            cbManufacturer.SelectedIndex = -1;
            cbDelivery.SelectedIndex = -1;
            tbProductDescription.Text = string.Empty;
            tbImage.Text = string.Empty;
            tbProductCost.Text = string.Empty;
            tbQuantity.Text = string.Empty;
            tbProductDiscountAmount.Text = string.Empty;
            tbCurrentDiscount.Text = string.Empty;
            rbPacking.IsChecked = false;
            rbPiece.IsChecked = false;
        }
    }
}
