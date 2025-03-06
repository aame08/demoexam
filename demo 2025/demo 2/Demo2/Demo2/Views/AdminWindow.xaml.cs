using Demo2.Models;
using Demo2.Services;
using System.Windows;
using System.Windows.Controls;

namespace Demo2.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private List<Product> allProducts = new List<Product>();
        private List<Product> currentProducts = new List<Product>();

        public AdminWindow()
        {
            InitializeComponent();

            tbNameUser.Text = App.nameUser;

            LoadProducts();

            var filters = new List<string>() { "Все диапазоны", "0-9,99%", "10-14,99%", "15% и более" };
            cbFilter.ItemsSource = filters;
            cbFilter.SelectedIndex = 0;

            var sorts = new List<string> { "Без сортировки", "По возрастанию", "По убыванию" };
            cbSort.ItemsSource = sorts;
            cbSort.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            var products = ProductService.GetProducts();
            allProducts = products;
            currentProducts = allProducts;

            DisplayProducts(allProducts);
        }

        public void DisplayProducts(List<Product> products)
        {
            dgProduct.Items.Clear();

            foreach (var product in products)
            {
                dgProduct.Items.Add(product);
            }

        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = tbSearch.Text;
            if (!string.IsNullOrEmpty(search))
            {
                currentProducts = currentProducts.Where(p => p.NameProduct.ToLower().Contains(search.ToLower())).ToList();
            }
            else { currentProducts = allProducts; }

            DisplayProducts(currentProducts);
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedFilter = cbFilter.SelectedItem as string;
            if (selectedFilter != "Все диапазоны")
            {
                switch (selectedFilter)
                {
                    case "0-9,99%":
                        currentProducts = currentProducts.Where(p => p.DiscountAmountProduct >= 0 && p.DiscountAmountProduct < 10).ToList();
                        break;
                    case "10-14,99%":
                        currentProducts = currentProducts.Where(p => p.DiscountAmountProduct >= 10 && p.DiscountAmountProduct < 15).ToList();
                        break;
                    case "15% и более":
                        currentProducts = currentProducts.Where(p => p.DiscountAmountProduct >= 15).ToList();
                        break;
                }
            }
            else { currentProducts = allProducts; }

            DisplayProducts(currentProducts);
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSort = cbSort.SelectedItem as string;
            if (selectedSort != "Без сортировки")
            {
                switch (selectedSort)
                {
                    case "По возрастанию":
                        currentProducts = currentProducts.OrderBy(p => p.CostProduct).ToList();
                        break;
                    case "По убыванию":
                        currentProducts = currentProducts.OrderByDescending(p => p.CostProduct).ToList();
                        break;
                }
            }
            else { currentProducts = allProducts; }

            DisplayProducts(currentProducts);
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
            this.Close();
        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = dgProduct.SelectedItem as Product;
            EditProduct editProduct = new EditProduct(selectedProduct);
            editProduct.Show();
            this.Close();
        }
    }
}
