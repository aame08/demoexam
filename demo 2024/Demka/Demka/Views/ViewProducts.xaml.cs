using Demka.Models;
using Demka.Services;
using Demka.ViewsModels;
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

namespace Demka.Views
{
    /// <summary>
    /// Логика взаимодействия для ViewProducts.xaml
    /// </summary>
    public partial class ViewProducts : Window
    {
        public static ViewProducts viewProducts;
        public ViewProducts()
        {
            InitializeComponent();

            viewProducts = this;

            DataContext = new BrowseProduct();
        }
    }
}
