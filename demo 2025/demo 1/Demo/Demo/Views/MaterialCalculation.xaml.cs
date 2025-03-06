using Demo.Services;
using System.Windows;
using System.Windows.Controls;

namespace Demo.Views
{
    /// <summary>
    /// Логика взаимодействия для MaterialCalculation.xaml
    /// </summary>
    public partial class MaterialCalculation : Page
    {
        public MaterialCalculation()
        {
            InitializeComponent();

            LoadProducts();
            LoadMaterials();
        }
        private void LoadProducts()
        {
            var products = ProductsService.GetProductTypes();
            cbProductType.ItemsSource = products;
            cbProductType.DisplayMemberPath = "NameProductType";
            cbProductType.SelectedValuePath = "IdProductType";
        }
        private void LoadMaterials()
        {
            var materials = ProductsService.GetMaterialTypes();
            cbMaterial.ItemsSource = materials;
            cbMaterial.DisplayMemberPath = "NameMaterialType";
            cbMaterial.SelectedValuePath = "IdMaterialType";
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void bCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int typeId = (int)cbProductType.SelectedValue;
                int materialId = (int)cbMaterial.SelectedValue;
                int quantity = int.Parse(tbQuantity.Text);
                double param1 = double.Parse(tbParam1.Text);
                double param2 = double.Parse(tbParam2.Text);

                int result = ProductsService.CalculateMaterial(typeId, materialId, quantity, param1, param2);

                if (result == -1)
                {
                    MessageBox.Show("Неверные данные или отсутствуют необходимые записи.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show($"Необходимое количество материала: {result} единиц.");
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при расчете. Проверьте введенные данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
