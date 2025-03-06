using Demka.Models;
using Demka.Services;
using Demka.ViewsModels;
using Microsoft.Win32;
using System.Windows;

namespace Demka.Views
{
    /// <summary>
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        public static EditProduct editProduct;
        public EditProduct(Product selectProduct)
        {
            InitializeComponent();

            editProduct = this;

            DataContext = new BrowseProduct();

            tbProductArticleNumber.Text = selectProduct.ProductArticleNumber;
            tbCategory.Text = ProductServices.GetCategoryById(selectProduct.CategoryId);
            tbProductName.Text = selectProduct.ProductName;
            tbUnit.Text = selectProduct.ProductUnit;
            tbManufacturer.Text = ProductServices.GetManufacturerById(selectProduct.ManufacturerId);
            cbDelivery.SelectedItem = ProductServices.GetDeliveryById(selectProduct.DeliveryId);
            tbProductDescription.Text = selectProduct.ProductDescription;
            tbImage.Text = selectProduct.ProductPhoto;
            tbProductCost.Text = selectProduct.ProductCost.ToString();
            tbQuantity.Text = selectProduct.ProductQuantityInStock.ToString();
            tbProductDiscountAmount.Text = selectProduct.ProductMaxDiscountAmount.ToString();
            tbCurrentDiscount.Text = selectProduct.ProductDiscountAmount.ToString();
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
    }
}
