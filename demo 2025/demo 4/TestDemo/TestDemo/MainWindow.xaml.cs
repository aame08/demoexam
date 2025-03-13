using System.Windows;
using TestDemo.Services;
using TestDemo.Views;

namespace TestDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void bCancel_Click(object sender, RoutedEventArgs e)
    {
        tbLogin.Text = string.Empty;
        tbPassword.Password = string.Empty;
    }

    private void bLogin_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(tbLogin.Text) && !string.IsNullOrEmpty(tbPassword.Password))
        {
            var user = UsersService.Login(tbLogin.Text, tbPassword.Password);
            if (user != null)
            {
                App.currentUser = user;
                App.fullNameUser = user.SurnameUser + " " + user.NameUser + " " + user.PatronymicUser;

                var roleUser = UsersService.GetNameRole(user);

                ProductsView productsView = new ProductsView();
                AdminWindow adminWindow = new AdminWindow();

                switch (roleUser)
                {
                    case "Администратор":
                        this.Close();
                        adminWindow.Show();
                        break;
                    case "Клиент":
                        this.Close();
                        productsView.Show();
                        break;
                    case "Менеджер":
                        this.Close();
                        productsView.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Пользователь не был найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        else
        {
            MessageBox.Show("Не все поля заполнены.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}