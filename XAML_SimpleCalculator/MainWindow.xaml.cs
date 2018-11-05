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

namespace XAML_SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_click(object sender, RoutedEventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
            {
                textBox_Result.Clear();
            }

            Button button = (Button)sender;
            if (button.Content.ToString() == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                {
                    textBox_Result.Text = textBox_Result.Text + button.Content;
                }
            }
            else
            {
                textBox_Result.Text = textBox_Result.Text + button.Content;
            }

            isOperationPerformed = false;
        }

        private void operator_click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operationPerformed = button.Content.ToString();
            resultValue = Double.Parse(textBox_Result.Text);
            labelCurrentOperation.Content = resultValue + " " + operationPerformed;
            isOperationPerformed = true;
        }

        private void clear_entry(object sender, RoutedEventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void clear_All(object sender, RoutedEventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;
            labelCurrentOperation.Content = "";
        }

        private void equals_click(object sender, RoutedEventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    textBox_Result.Text = (resultValue + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (resultValue - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (resultValue * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (resultValue / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
