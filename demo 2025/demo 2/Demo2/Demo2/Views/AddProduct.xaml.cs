﻿using Demo2.Models;
using Demo2.Services;
using System.Windows;

namespace Demo2.Views
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();

            cbManufacters.ItemsSource = ProductService.GetManufacters();
            cbSuppliers.ItemsSource = ProductService.GetSuppliers();
            cbTypes.ItemsSource = ProductService.GetTypes();

            var units = new List<string>() { "шт.", "уп." };
            cbUnit.ItemsSource = units;
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }

        private bool IsDigitsOnly(string numbers)
        {
            if (string.IsNullOrEmpty(numbers) || !numbers.All(char.IsDigit))
                return false;

            return int.TryParse(numbers, out int result) && result >= 0;
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
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
                var newProduct = new Product
                {
                    ArticleNumberProduct = tbArticle.Text,
                    NameProduct = tbName.Text,
                    UnitProduct = cbUnit.SelectedItem as string,
                    CostProduct = int.Parse(tbCost.Text),
                    DiscountAmountProduct = int.Parse(tbDiscount.Text),
                    MaxDiscountProduct = int.Parse(tbMaxDiscount.Text),
                    ManufacturerId = cbManufacters.SelectedIndex + 1,
                    SupplierId = cbSuppliers.SelectedIndex + 1,
                    TypeId = cbTypes.SelectedIndex + 1,
                    QuantityInStockProduct = int.Parse(tbQuantity.Text),
                    DescriptionProduct = tbDescription.Text,
                    PhotoProduct = null
                };

                var result = ProductService.AddProduct(newProduct);
                if (result)
                {
                    MessageBox.Show("Продукт добавлен.");
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при добавлении товара. Проверьте введенные данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при добавлении товара. Проверьте введенные данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
