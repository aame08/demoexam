using System.Windows.Controls;
using TestDemo.Models;

namespace TestDemo.Views
{
    /// <summary>
    /// Логика взаимодействия для UCProduct.xaml
    /// </summary>
    public partial class UCProduct : UserControl
    {
        public UCProduct(Product product)
        {
            InitializeComponent();

            this.DataContext = product;
        }
    }
}
