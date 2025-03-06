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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Demka.Views
{
    /// <summary>
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Page
    {
        public Captcha()
        {
            InitializeComponent();

            countSymbol = random.Next(5, 8);
            UpdateCapcha();
        }

        public static Random random = new Random();
        public static int countSymbol = 6;

        private bool isLocked = false;

        private void Timer_Tick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
        }

        private void BlockAuthorization()
        {
            MessageBoxResult result = MessageBox.Show("Подождите 10 секунд \nи попробуйте снова.");
            isLocked = true;
            Thread.Sleep(1000);
            isLocked = false;
        }

        private void bGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (tbCaptcha.Text == text)
            {
                this.Visibility = Visibility.Hidden;
                MessageBox.Show("Успешно.");
                isLocked = false;
            }
            else
            {
                isLocked = true;
            }
            if (isLocked == true)
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(10);
                timer.Tick += Timer_Tick;
                timer.Start();

                BlockAuthorization();
            }
        }
        string text;
        public void GenerateSymbol()
        {
            string alp = "1234567890ABCDEFGHIJKLNOPQRSTUVWXYZ";
            for (int i = 0; i < countSymbol; i++)
            {
                string symbol = alp.ElementAt(random.Next(0, alp.Length)).ToString();
                TextBlock textBlock = new TextBlock();
                textBlock.Text = symbol;
                textBlock.FontSize = random.Next(10, 20);
                textBlock.RenderTransform = new RotateTransform(random.Next(-45, 45));
                textBlock.Margin = new Thickness(10, 0, 10, 0);
                Stack.Children.Add(textBlock);
                text += symbol;
            }
        }
        public void GenerateNoise(int noise)
        {
            for (int i = 0; i < noise; i++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Fill = new SolidColorBrush(
                    Color.FromArgb(
                        (byte)random.Next(100, 256),
                        (byte)random.Next(100, 256),
                        (byte)random.Next(100, 256),
                        (byte)random.Next(100, 256)));
                ellipse.Height = ellipse.Width = random.Next(20, 50);
                canvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, random.Next(20, 250));
                Canvas.SetTop(ellipse, random.Next(100, 150));
            }

            for (int i = 0; i < noise; i++)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Fill = new SolidColorBrush(
                    Color.FromArgb(
                        (byte)random.Next(100, 256),
                        (byte)random.Next(100, 256),
                        (byte)random.Next(100, 256),
                        (byte)random.Next(100, 256)));
                rectangle.Height = rectangle.Width = random.Next(20, 50);
                canvas.Children.Add(rectangle);
                Canvas.SetLeft(rectangle, random.Next(20, 250));
                Canvas.SetTop(rectangle, random.Next(100, 150));

            }
        }
        public void UpdateCapcha()
        {
            Stack.Children.Clear();
            canvas.Children.Clear();
            GenerateSymbol();
            GenerateNoise(100);
        }
    }
}
