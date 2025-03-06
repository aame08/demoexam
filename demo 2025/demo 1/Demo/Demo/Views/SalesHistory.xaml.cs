using Demo.Models;
using Demo.Services;
using System.Windows;
using System.Windows.Controls;

namespace Demo.Views
{
    /// <summary>
    /// Логика взаимодействия для SalesHistory.xaml
    /// </summary>
    public partial class SalesHistory : Page
    {
        private List<PartnersProduct> historyList = new List<PartnersProduct>();
        public SalesHistory(int partnerId)
        {
            InitializeComponent();

            LoadHistory(partnerId);
        }

        private void LoadHistory(int partnerId)
        {
            var history = PartnersService.GetSalesHistory(partnerId);
            historyList = history;
            DisplayHistory(historyList);
        }
        private void DisplayHistory(List<PartnersProduct> list)
        {
            dgProducts.Items.Clear();
            foreach (var product in list)
            {
                dgProducts.Items.Add(product);
            }
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
