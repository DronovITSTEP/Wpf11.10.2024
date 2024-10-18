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

namespace Wpf11._10._2024.Part2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, int> fuelPrices;
        private Dictionary<CheckBox, TextBox> productsCounts;
        private Dictionary<TextBox, TextBox> countsPrices;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void fuels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fuelPrice != null)
            {
                var item = fuels.SelectedItem as ComboBoxItem;
                fuelPrice.Text = fuelPrices[item.Content.ToString()]
                    .ToString();

                if (!string.IsNullOrEmpty(valText.Text))
                {
                    int v, res = 0;
                    if (int.TryParse(valText.Text, out v))
                    {
                        var item1 = fuels.SelectedItem as ComboBoxItem;
                        res = v * fuelPrices[item1.Content.ToString()];
                    }
                    if ((bool)val.IsChecked)
                        resAZS.Text = res.ToString();
                }
                resTotal.Text = getResultTotal(double.Parse(resAZS.Text),
                   double.Parse(resCafe.Text)).ToString();
            }
        }
        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (valText != null && sumText != null)
            {
                valText.IsEnabled = (bool)val.IsChecked;
                sumText.IsEnabled = (bool)sum.IsChecked;

                if (valText.IsEnabled)
                {
                    valText_TextChanged(sender, e as TextChangedEventArgs);
                }
                if (sumText.IsEnabled)
                {
                    sumText_TextChanged(sender, e as TextChangedEventArgs);
                }
            }

        }
        private void valText_TextChanged(object sender, TextChangedEventArgs e)
        {
            int v, res = 0;
            if (int.TryParse(valText.Text, out v))
            {
                var item = fuels.SelectedItem as ComboBoxItem;
                res = v * fuelPrices[item.Content.ToString()];
            }

            resAZS.Text = res.ToString();
            resTotal.Text = getResultTotal(res, double.Parse(resCafe.Text)).ToString();
        }
        private void sumText_TextChanged(object sender, TextChangedEventArgs e)
        {
            int v = 0;
            int.TryParse(sumText.Text, out v);
            resAZS.Text = v.ToString();
            resTotal.Text = getResultTotal(double.Parse(resAZS.Text),
                double.Parse(resCafe.Text)).ToString();
        }
        private void product_Checked(object sender, RoutedEventArgs e)
        {
            var product = sender as CheckBox;
            setReadOnly(product, !(bool)product.IsChecked);
            resCafe.Text = getResultCafe().ToString();
        }
        private void count_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (resCafe != null)
            {
                resCafe.Text = getResultCafe().ToString();
                resTotal.Text = getResultTotal(double.Parse(resAZS.Text),
                    double.Parse(resCafe.Text)).ToString();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("С карты списано: " + resTotal.Text);
            // передача данных через конструктор
            /*Order order = new Order((fuels.SelectedItem as ComboBoxItem)
                .Content
                .ToString());
            order.Show();*/

            // передача данных через метод Show
            /*Order order = new Order("");           
            order.Show(resAZS.Text);*/

            // передача данных через свойство
            Order order = new Order("");
            order.PriceAzs = resAZS.Text;
            order.Show();
        }
        private double getResultCafe()
        {
            double res = 0;
            if (productsCounts != null)
            {
                foreach (var count in productsCounts.Values)
                {
                    if (count.IsReadOnly == false
                        && !string.IsNullOrEmpty(count.Text))
                    {
                        res += int.Parse(count.Text) *
                            double.Parse(countsPrices[count].Text);
                    }
                }
            }
            return res;
        }
        private void setReadOnly(CheckBox check, bool isReadOnly)
        {
            productsCounts[check].IsReadOnly = isReadOnly;
        }
        private double getResultTotal(double sumAzs, double sumCafe)
        {
            return sumAzs + sumCafe;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            resAZS.Text = "0";
            resCafe.Text = "0";
            resTotal.Text = "0";

            fuelPrices = new Dictionary<string, int>
            {
                ["АИ-92"] = 57,
                ["АИ-95"] = 75,
                ["Дизель"] = 64
            };
            productsCounts = new Dictionary<CheckBox, TextBox>
            {
                [product1] = count1,
                [product2] = count2,
                [product3] = count3,
                [product4] = count4,
            };
            countsPrices = new Dictionary<TextBox, TextBox>
            {
                [count1] = price1,
                [count2] = price2,
                [count3] = price3,
                [count4] = price4
            };

            var item = fuels.SelectedItem as ComboBoxItem;
            fuelPrice.Text = fuelPrices[item.Content.ToString()]
                .ToString();

            radioButton_Checked(sender, e);
        }
        private void ColorBtn_Checked(object sender, RoutedEventArgs e)
        {
            var colorBtn = sender as RadioButton;

            if ((bool)colorBtn.IsChecked && colorBtn != null)
            {
                if (colorBtn.Content.ToString() == "Розовый")
                    Background = Brushes.LightPink;
                else if (colorBtn.Content.ToString() == "Индиго")
                    Background = Brushes.Indigo;
                else if (colorBtn.Content.ToString() == "Бисквит")
                    Background = Brushes.Bisque;
            }
            else
                Background = Brushes.White;
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }

}
