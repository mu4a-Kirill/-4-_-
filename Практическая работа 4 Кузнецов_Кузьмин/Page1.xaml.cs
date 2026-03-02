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

namespace Практическая_работа_4_Кузнецов_Кузьмин
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = double.Parse(XTextBox.Text);
                double y = double.Parse(YTextBox.Text);
                double z = double.Parse(ZTextBox.Text);

                if (z < -1 || z > 1)
                {
                    MessageBox.Show("Значение Z должно быть в диапазоне [-1, 1] для арксинуса.", "Ошибка");
                    return;
                }

                double cubeRootX = Math.Pow(x, 1.0 / 3.0);
                double xPowerYPlus2 = Math.Pow(x, y + 2);
                double arcsinZ = Math.Asin(z);
                double arcsinZSquare = arcsinZ * arcsinZ;
                double absXY = Math.Abs(x - y);
                double underSqrt = 10 * (cubeRootX + xPowerYPlus2) * (arcsinZSquare - absXY);

                if (underSqrt < 0)
                {
                    MessageBox.Show("Подкоренное выражение не может быть отрицательным.", "Ошибка");
                    return;
                }

                double beta = Math.Sqrt(underSqrt);
                ResultTextBox.Text = beta.ToString("F3");
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числа.", "Ошибка ввода");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка");
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            XTextBox.Clear();
            YTextBox.Clear();
            ZTextBox.Clear();
            ResultTextBox.Clear();
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
}