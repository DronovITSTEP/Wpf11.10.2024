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

namespace Wpf11._10._2024
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Canvas.SetLeft(textBox,
                this.Width / 2 - textBox.Width / 2);
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Так держать!");
        }

        private void btnNo_MouseMove(object sender, MouseEventArgs e)
        {
            Canvas canvas = btnNo.Parent as Canvas;
            Random rnd = new Random();
            double maxX = canvas.ActualWidth - btnNo.ActualWidth;
            double maxY = canvas.ActualHeight - btnNo.ActualHeight;

            double newX = rnd.NextDouble() * maxX;
            double newY = rnd.NextDouble() * maxY;

            Canvas.SetLeft(btnNo, newX);
            Canvas.SetTop(btnNo, newY);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Title = $"X = {e.GetPosition(this).X} Y = {e.GetPosition(this).Y} Width = {textBox.Width}";
        }
    }
}
