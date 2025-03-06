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
using Demka.Models;
using Demka.Services;
using Demka.Views;
using Demka.ViewsModels;

namespace Demka.Views
{
    /// <summary>
    /// Логика взаимодействия для Ticket.xaml
    /// </summary>
    public partial class Ticket : Window
    {
        public static Ticket ticket;
        public Ticket()
        {
            InitializeComponent();

            ticket = this;
        }

        //private void bOK_Click(object sender, RoutedEventArgs e)
        //{
        //    ViewProducts viewProducts = new ViewProducts();
        //    viewProducts.Show();
        //    this.Close();
        //}
    }
}
