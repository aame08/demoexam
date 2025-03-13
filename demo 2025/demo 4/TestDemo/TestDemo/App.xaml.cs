using System.Windows;
using TestDemo.Models;

namespace TestDemo;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    // Сохранение текущего пользователя
    public static User? currentUser;
    public static string fullNameUser;
}

