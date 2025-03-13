using Microsoft.Extensions.Primitives;
using System.Windows;
using TestDemo.Models;
using TestDemo.Services;

namespace TestDemo.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductsView.xaml
    /// </summary>
    public partial class ProductsView : Window
    {
        public static List<Product> allProducts = new List<Product>();
        public static List<Product> currentProducts = new List<Product>();
        public ProductsView()
        {
            InitializeComponent();

            tbName.Text = App.fullNameUser;

            LoadProducts();

            var sorts = new List<string>() { "Без сортировки", "По возрастанию", "По убыванию" };
            var filters = ProductsService.GetManufacters();
            filters.Insert(0, "Без фильтрации");

            cbSort.ItemsSource = sorts;
            cbFilter.ItemsSource = filters;
        }

        // Загрузка товаров
        private void LoadProducts()
        {
            var products = ProductsService.GetAllProducts();
            allProducts = products;
            currentProducts = allProducts;

            DisplayProducts(allProducts);
        }

        // Отображение товаров
        private void DisplayProducts(List<Product> products)
        {
            lvProducts.Items.Clear();

            foreach (var product in products)
            {
                UCProduct productItem = new UCProduct(product);
                lvProducts.Items.Add(productItem);
            }
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
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

        private void cbFilter_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbFilter.SelectedItem != "Без фильтрации")
            {
                currentProducts = currentProducts
                    .Where(p => p.IdManufacterNavigation.NameManufacter == cbFilter.SelectedItem as string)
                    .ToList();
            }

            else { currentProducts = allProducts; }

            DisplayProducts(currentProducts);
        }
    }
}
