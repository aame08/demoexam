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
    /// Логика взаимодействия для EditApplication.xaml
    /// </summary>
    public partial class EditApplication : Window
    {
        public static EditApplication editApplication;
        public EditApplication(Demo.Models.Application selectApplication)
        {
            InitializeComponent();

            editApplication = this;

            DataContext = new BrowseApplications();

            tbID.Text = selectApplication.IdApplication.ToString();
            cbStatus.SelectedItem = selectApplication.StatusApplication.ToString();
        }
    }
}
