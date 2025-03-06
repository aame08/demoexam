using Demo.Models;
using Demo.Services;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;

namespace Demo.Views
{
    /// <summary>
    /// Логика взаимодействия для AddPartner.xaml
    /// </summary>
    public partial class AddPartner : Page
    {
        public AddPartner()
        {
            InitializeComponent();
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        // Проверка на валидность почты
        private bool isValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            try
            {
                var mailAddress = new MailAddress(email);

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
        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbType.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип партнёра.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Введите имя партнёра.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbSurnameDirector.Text))
            {
                MessageBox.Show("Введите фамилию директора.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbNameDirector.Text))
            {
                MessageBox.Show("Введите имя директора.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbPatronymicDirector.Text))
            {
                MessageBox.Show("Введите отчество директора.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!isValidEmail(tbEmail.Text))
            {
                MessageBox.Show("Введите корректный email.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(tbPhone.Text))
            {
                MessageBox.Show("Введите корректный номер телефона.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbIndexAddress.Text))
            {
                MessageBox.Show("Введите индекс адреса.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbLocalityAddress.Text))
            {
                MessageBox.Show("Введите населённый пункт адреса.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbCityAddress.Text))
            {
                MessageBox.Show("Введите город адреса.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tbStreetAddress.Text))
            {
                MessageBox.Show("Введите улицу адреса.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(tbHomeAddress.Text))
            {
                MessageBox.Show("Введите корректный номер дома.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(tbInn.Text))
            {
                MessageBox.Show("Введите корректный ИНН.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsDigitsOnly(tbRating.Text))
            {
                MessageBox.Show("Введите корректный рейтинг.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var newPartner = new Partner
                {
                    TypePartner = (cbType.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    NamePartner = tbName.Text,
                    DirectorSurname = tbSurnameDirector.Text,
                    DirectorName = tbNameDirector.Text,
                    DirectorPatronymic = tbPatronymicDirector.Text,
                    EmailPartner = tbEmail.Text,
                    PhomeNumber = tbPhone.Text,
                    AddressIndex = int.Parse(tbIndexAddress.Text),
                    AddressLocality = tbLocalityAddress.Text,
                    AddressCity = tbCityAddress.Text,
                    AddressStreet = tbStreetAddress.Text,
                    AddressHome = tbHomeAddress.Text,
                    InnPartner = tbInn.Text,
                    RatingPartner = int.Parse(tbRating.Text)
                };

                var result = PartnersService.AddPartner(newPartner);
                if (result)
                {
                    MessageBox.Show("Партнер добавлен.");
                    MainWindow.mainWindow.DisplayPartners();
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при добавлении партнера. Проверьте введенные данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при добавлении партнера. Проверьте введенные данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Очищение поля
        private void TextBoxEmpty(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox) { textBox.Text = string.Empty; }
        }
    }
}
