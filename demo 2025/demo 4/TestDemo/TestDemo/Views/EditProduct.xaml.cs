using System.Windows;
using TestDemo.Models;
using TestDemo.Services;

namespace TestDemo.Views
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

            cbManufacters.ItemsSource = ProductsService.GetManufacters();
            cbSuppliers.ItemsSource = ProductsService.GetSuppliers();
            cbCategories.ItemsSource = ProductsService.GetCategories();

            // Отображение производителя, поставщика и категории товара в ComboBox
            cbManufacters.SelectedItem = cbManufacters.Items.Cast<string>().FirstOrDefault(i => i == product.IdManufacterNavigation.NameManufacter);
            cbSuppliers.SelectedItem = cbSuppliers.Items.Cast<string>().FirstOrDefault(i => i == product.IdSupplierNavigation.NameSupplier);
            cbCategories.SelectedItem = cbCategories.Items.Cast<string>().FirstOrDefault(i => i == product.IdCategoryNavigation.NameCategory);
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            this.Close();
            adminWindow.Show();
        }

        private bool IsDigitOnly(string numbers)
        {
            if (string.IsNullOrEmpty(numbers) || !numbers.All(char.IsDigit))
                return false;

            return int.TryParse(numbers, out int result) && result >= 0;
        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Название невалиднo.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (string.IsNullOrEmpty(tbCost.Text) && !IsDigitOnly(tbCost.Text))
            {
                MessageBox.Show("Цена невалидна.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (string.IsNullOrEmpty(tbDesc.Text))
            {
                MessageBox.Show("Описание невалиднo.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (string.IsNullOrEmpty(tbNowDiscount.Text) && !IsDigitOnly(tbNowDiscount.Text))
            {
                MessageBox.Show("Действующая скидка невалидна.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (string.IsNullOrEmpty(tbMaxDiscount.Text) && !IsDigitOnly(tbMaxDiscount.Text))
            {
                MessageBox.Show("Максимальная скидка невалидна.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (string.IsNullOrEmpty(tbQuantity.Text) && !IsDigitOnly(tbQuantity.Text))
            {
                MessageBox.Show("Количество товара невалидно.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (cbManufacters.SelectedIndex == -1)
            {
                MessageBox.Show("Производитель не выбран.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (cbSuppliers.SelectedIndex == -1)
            {
                MessageBox.Show("Поставщик не выбран.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (cbCategories.SelectedIndex == -1)
            {
                MessageBox.Show("Категория не выбрана.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            try
            {
                var editingProduct = new Product
                {
                    ArticleProduct = tbArticle.Text,
                    NameProduct = tbName.Text,
                    UnitProduct = "шт.",
                    CostProduct = int.Parse(tbCost.Text),
                    MaxDiscount = int.Parse(tbMaxDiscount.Text),
                    IdManufacter = cbManufacters.SelectedIndex + 1,
                    IdSupplier = cbSuppliers.SelectedIndex + 1,
                    IdCategory = cbCategories.SelectedIndex + 1,
                    NowDiscount = int.Parse(tbNowDiscount.Text),
                    QuantityProduct = int.Parse(tbQuantity.Text),
                    DescProduct = tbDesc.Text,
                    ImageProduct = null
                };

                var result = ProductsService.EditingProduct(editingProduct);
                if (result)
                {
                    MessageBox.Show("Информация о товара обновлена.");

                    AdminWindow adminWindow = new AdminWindow();
                    this.Close();
                    adminWindow.Show();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при редактировании товара.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при редактировании товара.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
