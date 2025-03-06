using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Demo.Models;
using Demo.ViewModels;

namespace Demo.Views
{
    /// <summary>
    /// Логика взаимодействия для ExecuteApplication.xaml
    /// </summary>
    public partial class ExecuteApplication : Window
    {
        public static ExecuteApplication executeApplication;
        public bool isInputEnabled = false;
        public ExecuteApplication(Demo.Models.Application selectApplication)
        {
            InitializeComponent();

            executeApplication = this;

            DataContext = new BrowseApplications();

            tbID.Text = selectApplication.IdApplication.ToString();
        }

        private void toggleButton_Click(object sender, RoutedEventArgs e)
        {
            isInputEnabled = !isInputEnabled;
            tbSpapePartsName.IsEnabled = isInputEnabled;
        }
    }
}
