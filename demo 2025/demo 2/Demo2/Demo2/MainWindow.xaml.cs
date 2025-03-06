using Demo2.Services;
using Demo2.Views;
using System.Windows;

namespace Demo2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void bGuest_Click(object sender, RoutedEventArgs e)
    {
        ProductView productView = new ProductView();
        productView.Show();
        this.Close();
    }

    private void bEnter_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(tbLogin.Text) || !string.IsNullOrEmpty(tbPassword.Password))
        {
            var user = UsersService.LoginUser(tbLogin.Text, tbPassword.Password);
            if (user != null)
            {
                App.currentUser = user;
                App.nameUser = user.SurnameUser + " " + user.NameUser + " " + user.PatronymicUser;

                switch (user.RoleUser)
                {
                    case 1:
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close();
                        break;
                    case 2:
                        ProductView productView = new ProductView();
                        productView.Show();
                        this.Close();
                        break;
                    case 3:
                        ManagerWindow managerWindow = new ManagerWindow();
                        managerWindow.Show();
                        this.Close();
                        break;
                }

            }
            else
            {
                MessageBox.Show("Данные введены неправильно.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        else
        {
            MessageBox.Show("Не все поля заполнены.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}