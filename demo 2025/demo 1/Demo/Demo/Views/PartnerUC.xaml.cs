using Demo.Models;
using System.Windows;
using System.Windows.Controls;

namespace Demo.Views
{
    /// <summary>
    /// Логика взаимодействия для PartnerUC.xaml
    /// </summary>
    public partial class PartnerUC : UserControl
    {
        public Partner Partner { get; private set; }
        public PartnerUC(Partner partner)
        {
            InitializeComponent();

            Partner = partner;
            this.DataContext = partner;

            var discount = partner.GetDiscount();
            tbDiscount.Text = $"Скидка: {discount}%";
        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            var partner = this.DataContext as Partner;
            MainWindow.mainWindow.frame.Visibility = Visibility.Visible;
            MainWindow.mainWindow.frame.Navigate(new EditPartner(partner));
        }
    }
}
