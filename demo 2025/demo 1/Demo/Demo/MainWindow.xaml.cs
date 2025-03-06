using Demo.Models;
using Demo.Services;
using Demo.Views;
using System.Windows;
using System.Windows.Controls;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        public MainWindow()
        {
            InitializeComponent();

            mainWindow = this;

            DisplayPartners();
        }

        // Заполнение ListView UserControl'ами с информацией о партнерах
        public void DisplayPartners()
        {
            var partners = PartnersService.GetPartners();
            foreach (var partner in partners)
            {
                PartnersListView.Items.Add(new PartnerUC(partner));
            }
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            frame.Visibility = Visibility.Visible;
            frame.NavigationService.Navigate(new AddPartner());
        }

        private void bHistory_Click(object sender, RoutedEventArgs e)
        {
            if (PartnersListView.SelectedItem is PartnerUC selectedUC && selectedUC.Partner != null)
            {
                var selectedPartner = selectedUC.Partner;
                frame.Visibility = Visibility.Visible;
                frame.NavigationService.Navigate(new SalesHistory(selectedPartner.IdPartner));
            }
            else
            {
                MessageBox.Show("Выберите партнёра для просмотра истории.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void bCalculation_Click(object sender, RoutedEventArgs e)
        {

            frame.Visibility = Visibility.Visible;
            frame.NavigationService.Navigate(new MaterialCalculation());

        }

        private void frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Content is Page page)
            {
                this.Title = page switch
                {
                    AddPartner => "Добавление нового парнёра",
                    EditPartner => "Редактирование данных парнёра",
                    SalesHistory => "История продаж",
                    MaterialCalculation => "Расчет материалов",
                    _ => "Главная форма"
                };
            }
        }
    }
}