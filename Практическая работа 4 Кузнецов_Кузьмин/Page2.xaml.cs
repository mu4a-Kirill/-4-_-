using System;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;

namespace Практическая_работа_4_Кузнецов_Кузьмин
{
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        public double CalculateG(double x, double b, string funcType)
        {
            double f;
            switch (funcType)
            {
                case "sh":
                    f = Math.Sinh(x);
                    break;
                case "square":
                    f = x * x;
                    break;
                case "exp":
                    f = Math.Exp(x);
                    break;
                default:
                    throw new ArgumentException("Неизвестный тип функции", nameof(funcType));
            }

            double xb = x * b;
            double g;

            if (xb > 0.5 && xb < 10)
                g = Math.Exp(f - Math.Abs(b));
            else if (xb > 0.1 && xb < 0.5)
                g = Math.Sqrt(Math.Abs(f) + Math.Abs(b));
            else
                g = 2 * f * f;

            return g;
        }

        private double ParseDouble(string text)
        {
            string s = text.Replace(',', '.');
            return double.Parse(s, CultureInfo.InvariantCulture);
        }

        private string GetSelectedFunction()
        {
            if (ShRadio.IsChecked == true) return "sh";
            if (SquareRadio.IsChecked == true) return "square";
            return "exp";
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = ParseDouble(XTextBox.Text);
                double b = ParseDouble(BTextBox.Text);
                string func = GetSelectedFunction();

                double g = CalculateG(x, b, func);
                ResultTextBox.Text = g.ToString("F3");
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числа (используйте . или ,).", "Ошибка ввода");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            XTextBox.Clear();
            BTextBox.Clear();
            ResultTextBox.Clear();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }
    }
}