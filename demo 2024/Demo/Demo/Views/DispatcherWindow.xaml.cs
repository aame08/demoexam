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
using Demo.Services;
using Demo.ViewModels;

namespace Demo.Views
{
    /// <summary>
    /// Логика взаимодействия для DispatcherWindow.xaml
    /// </summary>
    public partial class DispatcherWindow : Window
    {
        public static DispatcherWindow dispatcherWindow;
        public DispatcherWindow()
        {
            InitializeComponent();

            dispatcherWindow = this;

            DataContext = new BrowseApplications();

            var currentApplication = ApplicationService.GetApplications();
            var countApplication = currentApplication.Where(a => a.StatusApplication == "Выполнено").Count();
            tbCount.Text = countApplication.ToString();
            tbAverageTime.Text = ReportServices.GetAverageReportTime().ToString();
        }
    }
}
