using Demo3.Models;
using System.Windows.Controls;

namespace Demo3.Views
{
    /// <summary>
    /// Логика взаимодействия для UCProduct.xaml
    /// </summary>
    public partial class UCProduct : UserControl
    {
        public Product Product { get; private set; }
        public UCProduct(Product product)
        {
            InitializeComponent();

            Product = product;
            this.DataContext = product;
        }
    }
}
