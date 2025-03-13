using System.Windows;
using TestDemo.Models;
using TestDemo.Services;

namespace TestDemo.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public static List<Product> allProducts = new List<Product>();
        public static List<Product> currentProducts = new List<Product>();

        public AdminWindow()
        {
            InitializeComponent();

            tbName.Text = App.fullNameUser;

            LoadProducts();

            var sorts = new List<string>() { "Без сортировки", "По возрастанию", "По убыванию" };

            cbSort.ItemsSource = sorts;
        }

        private void LoadProducts()
        {
            var products = ProductsService.GetAllProducts();
            allProducts = products;

            DisplayProducts(allProducts);
        }

        private void DisplayProducts(List<Product> products)
        {
            dgProducts.ItemsSource = products;
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = dgProducts.SelectedItem as Product;
            EditProduct editProduct = new EditProduct(selectedProduct);
            editProduct.Show();
            this.Close();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            this.Close();
            addProduct.Show();
        }

        private void tbSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                currentProducts = currentProducts
                    .Where(p => p.NameProduct.ToLower().Contains(tbSearch.Text.ToLower()))
                    .ToList();
            }
            else { currentProducts = allProducts; }

            DisplayProducts(currentProducts);
        }

        private void cbSort_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbSort.SelectedItem != "Без сортировки")
            {
                switch (cbSort.SelectedItem as string)
                {
                    case "По возрастанию":
                        currentProducts = currentProducts
                            .OrderBy(p => p.DisplayedPrice).ToList();
                        break;
                    case "По убыванию":
                        currentProducts = currentProducts
                            .OrderByDescending(p => p.DisplayedPrice).ToList();
                        break;
                }
            }

            else { currentProducts = allProducts; }

            DisplayProducts(currentProducts);
        }
    }
}
