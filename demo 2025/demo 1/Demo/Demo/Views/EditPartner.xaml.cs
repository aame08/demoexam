using Demo.Models;
using Demo.Services;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;

namespace Demo.Views
{
    /// <summary>
    /// Логика взаимодействия для EditPartner.xaml
    /// </summary>
    public partial class EditPartner : Page
    {
        public static string oldEmailPartner;
        public EditPartner(Partner partner)
        {
            InitializeComponent();

            this.DataContext = partner;
            oldEmailPartner = partner.EmailPartner;

            // Отображение типа партнера
            cbType.SelectedItem = cbType.Items.Cast<ComboBoxItem>().FirstOrDefault(i => i.Content.ToString() == partner.TypePartner);
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        // Проверка на валидность почты
        private bool isValidEmail(string email, string existingEmail)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            try
            {
                var mailAddress = new MailAddress(email);

                if (email == existingEmail)
                {
                    return true;
                }

                var service = new PartnersService();
                return service.ExistingEmail(email);
            }
            catch (FormatException)
            {
                return false;
            }
        }
        // Проверка, чтобы строка состояла из цифер
        private bool IsDigitsOnly(string numbers)
        {
            if (string.IsNullOrEmpty(numbers) || !numbers.All(char.IsDigit))
                return false;

            return int.TryParse(numbers, out int result) && result >= 0;
        }
        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            if (cbType.SelectedIndex == -1)
            {
                MessageBox.Show("Проверьте тип партнера.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Проверьте наименование партнера.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbSurnameDirector.Text))
            {
                MessageBox.Show("Проверьте фамилию директора.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbNameDirector.Text))
            {
                MessageBox.Show("Проверьте имя директора.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbPatronymicDirector.Text))
            {
                MessageBox.Show("Проверьте отчество директора.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!isValidEmail(tbEmail.Text, oldEmailPartner))
            {
                MessageBox.Show("Проверьте корректный email.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(tbPhone.Text))
            {
                MessageBox.Show("Проверьте корректный номер телефона.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbIndexAddress.Text))
            {
                MessageBox.Show("Проверьте индекс адреса.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbLocalityAddress.Text))
            {
                MessageBox.Show("Проверьте населённый пункт адреса.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbCityAddress.Text))
            {
                MessageBox.Show("Проверьте город адреса.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbStreetAddress.Text))
            {
                MessageBox.Show("Проверьте улицу адреса.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(tbHomeAddress.Text))
            {
                MessageBox.Show("Проверьте корректный номер дома.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(tbInn.Text))
            {
                MessageBox.Show("Проверьте корректный ИНН.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(tbRating.Text))
            {
                MessageBox.Show("Проверьте корректный рейтинг.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var result = PartnersService.EditPartner(
                    int.Parse(tbID.Text),
                    (cbType.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    tbName.Text,
                    tbSurnameDirector.Text,
                    tbNameDirector.Text,
                    tbPatronymicDirector.Text,
                    tbEmail.Text,
                    tbPhone.Text,
                    int.Parse(tbIndexAddress.Text),
                    tbLocalityAddress.Text,
                    tbCityAddress.Text,
                    tbStreetAddress.Text,
                    tbHomeAddress.Text,
                    tbInn.Text,
                    int.Parse(tbRating.Text)
                );

                if (result)
                {
                    MessageBox.Show("Информация изменена.");
                    MainWindow.mainWindow.DisplayPartners();
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Ошибка при изменении информации.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении информации.");
            }
        }
    }
}
