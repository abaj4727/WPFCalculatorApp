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

namespace WpfDatabidingSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentInput = "";
        private string firstOperand = "";
        private string secondOperand = "";
        private string operation = "";
        private bool isNewInput = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button=sender as Button;
            if(isNewInput)
            {
                currentInput=button.Content.ToString();
                isNewInput = false;
            }
            else
            {
                currentInput += button.Content.ToString();
            }
            UpdateDisplay(currentInput);

        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (!string.IsNullOrEmpty(currentInput))
            {
                firstOperand = currentInput;
                operation = button.Content.ToString();
                isNewInput = true;
            }

        }
        private void UpdateDisplay(string text)
        {
            // Assuming you have a TextBlock for the display, e.g., Name="Display"
            txtInput.Text = text;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            currentInput = "";
            firstOperand = "";
            secondOperand = "";
            operation = "";
            UpdateDisplay(" ");
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(firstOperand) && !string.IsNullOrEmpty(currentInput) && !string.IsNullOrEmpty(operation))
            {
                secondOperand = currentInput;

                double num1 = double.Parse(firstOperand);
                double num2 = double.Parse(secondOperand);
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "÷":
                        result = num2 != 0 ? num1 / num2 : 0; // Handle division by zero.
                        break;
                }

                currentInput = result.ToString();
                UpdateDisplay(currentInput);

                // Reset for next operation
                firstOperand = "";
                secondOperand = "";
                operation = "";
                isNewInput = true;
            }
        }
    }
}
