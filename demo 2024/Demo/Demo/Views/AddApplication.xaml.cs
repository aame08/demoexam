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
using Demo.ViewModels;

namespace Demo.Views
{
    /// <summary>
    /// Логика взаимодействия для AddApplication.xaml
    /// </summary>
    public partial class AddApplication : Window
    {
        public static AddApplication addApplication;
        public bool isInputEnabled = false;
        public bool isInputEnabled1 = false;
        public AddApplication()
        {
            InitializeComponent();

            addApplication = this;

            DataContext = new BrowseApplications();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Формат даты добавления: ГГГГ-ММ-ДД.");
        }

        private void toggleButton_Click(object sender, RoutedEventArgs e)
        {
            isInputEnabled = !isInputEnabled;
            tbEquipment.IsEnabled = isInputEnabled;
        }

        private void toggleButton1_Click(object sender, RoutedEventArgs e)
        {
            isInputEnabled1 = !isInputEnabled1;
            tbMalfunction.IsEnabled = isInputEnabled1;
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            cbPerformer.SelectedIndex = -1;
            tbPhoneCustomer.Text = string.Empty;
            tbDate.Text = string.Empty;
            cbEquipment.SelectedIndex = -1;
            isInputEnabled = false;
            tbEquipment.Text = string.Empty;
            tbEquipment.IsEnabled = false;
            cbMalfunction.SelectedIndex = -1;
            isInputEnabled1 = false;
            tbMalfunction.Text = string.Empty;
            tbMalfunction.IsEnabled = false;
            tbDescription.Text = string.Empty;
            cbPriority.SelectedIndex = -1;
        }
    }
}
