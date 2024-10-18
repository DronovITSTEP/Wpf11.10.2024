using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Wpf11._10._2024.Part2
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        private string _priceAzs;
        public string PriceAzs {get;set;}
        public Order(string fuel)
        {
            InitializeComponent();

            //order.Text = fuel;
            DataContext = this;
        }

        public void Show(string text)
        {
            order.Text = text;
            Show();
        }
    }
}
