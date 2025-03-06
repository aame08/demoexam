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
    /// Логика взаимодействия для PerformerView.xaml
    /// </summary>
    public partial class PerformerView : Window
    {
        public static PerformerView performerView;
        public PerformerView()
        {
            InitializeComponent();

            performerView = this;

            DataContext = new BrowseApplications();
        }
    }
}
