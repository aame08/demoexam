using Demo2.Models;
using Demo2.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Demo2.Views
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        private List<Order> allOrders = new List<Order>();
        private List<Order> currentOrders = new List<Order>();
        public ManagerWindow()
        {
            InitializeComponent();

            tbNameUser.Text = App.nameUser;

            var filters = new List<string>() { "Все диапазоны", "0-10%", "10-14%", "15% и более" };
            cbFilter.ItemsSource = filters;
            cbFilter.SelectedIndex = 0;

            var sorts = new List<string> { "Без сортировки", "По возрастанию", "По убыванию" };
            cbSort.ItemsSource = sorts;
            cbSort.SelectedIndex = 0;

            LoadOrders();
        }

        private void LoadOrders()
        {
            var orders = ProductService.GetOrders();
            allOrders = orders;
            currentOrders = allOrders;

            DisplayOrders(allOrders);
        }

        private void DisplayOrders(List<Order> orders)
        {
            dgOrders.Items.Clear();

            foreach (var order in orders)
            {
                dgOrders.Items.Add(order);
            }
        }

        private void HighlightRows()
        {
            foreach (var item in dgOrders.Items)
            {
                var order = item as Order;
                if (order != null)
                {
                    var row = dgOrders.ItemContainerGenerator.ContainerFromItem(order) as DataGridRow;
                    if (row != null)
                    {
                        if (order.Orderproducts.All(op => op.ArticleNumberProductNavigation.QuantityInStockProduct > 3))
                        {
                            row.Background = new SolidColorBrush(Color.FromRgb(32, 178, 170));
                        }
                        else if (order.Orderproducts.Any(op => op.ArticleNumberProductNavigation.QuantityInStockProduct == 0))
                        {
                            row.Background = new SolidColorBrush(Color.FromRgb(255, 140, 0));
                        }
                    }
                }
            }
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedFilter = cbFilter.SelectedItem as string;
            if (selectedFilter != "Все диапазоны")
            {
                switch (selectedFilter)
                {
                    case "0-10%":
                        currentOrders = currentOrders.Where(o => o.TotalDiscount >= 0 && o.TotalDiscount < 10).ToList();
                        break;
                    case "10-14%":
                        currentOrders = currentOrders.Where(o => o.TotalDiscount >= 10 && o.TotalDiscount < 15).ToList();
                        break;
                    case "15% и более":
                        currentOrders = currentOrders.Where(o => o.TotalDiscount >= 15).ToList();
                        break;
                }
            }
            else { currentOrders = allOrders; }

            DisplayOrders(currentOrders);
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSort = cbSort.SelectedItem as string;
            if (selectedSort != "Без сортировки")
            {
                switch (selectedSort)
                {
                    case "По возрастанию":
                        currentOrders = currentOrders.OrderBy(o => o.TotalAmount).ToList();
                        break;
                    case "По убыванию":
                        currentOrders = currentOrders.OrderByDescending(o => o.TotalAmount).ToList();
                        break;
                }
            }
            else { currentOrders = allOrders; }

            DisplayOrders(currentOrders);
        }

        private void dgOrders_Loaded(object sender, RoutedEventArgs e)
        {
            HighlightRows();
        }
    }
}
