using Demo2.Models;
using Demo2.Services;
using System.Windows;
using System.Windows.Controls;

namespace Demo2.Views
{
    /// <summary>
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        public EditProduct(Product product)
        {
            InitializeComponent();

            this.DataContext = product;

            cbManufacters.ItemsSource = ProductService.GetManufacters();
            cbSuppliers.ItemsSource = ProductService.GetSuppliers();
            cbTypes.ItemsSource = ProductService.GetTypes();
            var units = new List<string>() { "шт.", "уп." };
            cbUnit.ItemsSource = units;

            cbManufacters.SelectedItem = cbManufacters.Items.Cast<string>().FirstOrDefault(i => i == product.Manufacturer.ManufacturerName);
            cbSuppliers.SelectedItem = cbSuppliers.Items.Cast<string>().FirstOrDefault(i => i == product.Supplier.SupplierName);
            cbTypes.SelectedItem = cbTypes.Items.Cast<string>().FirstOrDefault(i => i == product.Type.TypeName);
            cbUnit.SelectedItem = cbUnit.Items.Cast<string>().FirstOrDefault(i => i == product.UnitProduct);
        }

        private bool IsDigitsOnly(string numbers)
        {
            if (string.IsNullOrEmpty(numbers) || !numbers.All(char.IsDigit))
                return false;

            return int.TryParse(numbers, out int result) && result >= 0;
        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            if (cbManufacters.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите производителя.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (cbSuppliers.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите поставщика.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (cbTypes.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип товара.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(tbArticle.Text))
            {
                MessageBox.Show("Введите артукул.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Введите название.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(tbDescription.Text))
            {
                MessageBox.Show("Введите описание.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (cbUnit.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите единицы измерения.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!IsDigitsOnly(tbCost.Text))
            {
                MessageBox.Show("Введите корректную стоимость.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!IsDigitsOnly(tbDiscount.Text))
            {
                MessageBox.Show("Введите корректную скидку.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!IsDigitsOnly(tbMaxDiscount.Text))
            {
                MessageBox.Show("Введите корректную максимальную стоимость.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!IsDigitsOnly(tbQuantity.Text))
            {
                MessageBox.Show("Введите корректное количество.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var editProduct = ProductService.EditProduct(
                    tbArticle.Text,
                    tbName.Text,
                    int.Parse(tbCost.Text),
                    int.Parse(tbDiscount.Text),
                    int.Parse(tbMaxDiscount.Text),
                    int.Parse(tbQuantity.Text),
                    tbDescription.Text,
                    cbUnit.SelectedItem as string,
                    cbManufacters.SelectedIndex + 1,
                    cbSuppliers.SelectedIndex + 1,
                    cbTypes.SelectedIndex + 1);

                if (editProduct)
                {
                    MessageBox.Show("Информация изменена.");
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close();
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

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }
    }
}
