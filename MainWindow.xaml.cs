using System;
using System.Windows;
using System.Windows.Controls;

namespace TriangleTypeChecker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            string inputA = One.Text;
            string inputB = Two.Text;
            string inputC = Three.Text;

            // Проверка на пустой ввод или некорректный ввод
            if (!TryParseInput(inputA, out double a) ||
                !TryParseInput(inputB, out double b) ||
                !TryParseInput(inputC, out double c))
            {
                ResultTextBlock.Text = "Ошибка ввода";
                return;
            }

            // Проверка условий существования треугольника
            string result = CheckTriangleExistence(a, b, c);
            ResultTextBlock.Text = result;
        }

        private bool TryParseInput(string input, out double value)
        {
            // Если пустое значение или символы, возвращаем false
            return double.TryParse(input, out value);
        }

        private string CheckTriangleExistence(double a, double b, double c)
        {
            // Проверим, все ли стороны положительные
            if (a <= 0 && b <= 0 && c <= 0)
            {
                return "Треугольник не существует";
            }
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return "Треугольник не существует";
            }

            // Проверка условия существования треугольника
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                return " Треугольник не существует";
            }

            // Проверка на равносторонний треугольник
            if (a == b && b == c)
            {
                return "Равносторонний треугольник";
            }

            // Проверка на равнобедренный треугольник
            if (a == b || b == c || a == c)
            {
                return "Равнобедренный треугольник";
            }

            // Если все стороны разные
            return "Разносторонний треугольник";
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.StartsWith("Сторона"))
            {
                textBox.Text = string.Empty;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrEmpty(textBox.Text))
            {
                if (textBox.Name == "One")
                {
                    textBox.Text = "Сторона A";
                }
                else if (textBox.Name == "Two")
                {
                    textBox.Text = "Сторона B";
                }
                else if (textBox.Name == "Three")
                {
                    textBox.Text = "Сторона C";
                }
            }
        }
    }
}