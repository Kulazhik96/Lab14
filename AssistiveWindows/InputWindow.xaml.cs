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

namespace Lab14_Kulazhin.AssistiveWindows
{
    /// <summary>
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        // Fields.
        private Point start;
        private Point end;
        private Line line;
        public string CalculationResult { get; set; }

        public InputWindow()
        {
            InitializeComponent();
        }

        // Calculate result.
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.DialogResult = true;

                start = GetDataFromTextBox(FirstPointInput);
                end = GetDataFromTextBox(SecondPointInput);
                line = new(start, end);

                double length = line.GetLength();
                double coef = line.GetCoefficient();
                string result = "";

                if ((bool)CoefCheckBox.IsChecked && (bool)LengthCheckBox.IsChecked)
                {
                    result = $"Line's coefficient is: {coef}\n" +
                             $"Line's length is: {length}";
                }
                else if ((bool)CoefCheckBox.IsChecked)
                {
                    result = $"Line's coefficient is: {coef}";
                }
                else if ((bool)LengthCheckBox.IsChecked)
                {
                    result = $"Line's length is: {length}";
                }
                else throw new InvalidOperationException("Choose an operation!");

                CalculationResult = result;
                MessageBox.Show("Calculated!\nClick 'Show' button to see the result!");
            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Assistive.
        private Point GetDataFromTextBox(TextBox box)
        {
            string[] temp = box.Text.Split(';');

            if (temp.Length != 2)
                throw new ArgumentException("Incorrect input coordinates!");

            double x = ParseDouble(temp[0]);
            double y = ParseDouble(temp[1]);

            return new(x, y);
        }

        private double ParseDouble(string text)
        {
            if (!double.TryParse(text, out double result))
            {
                throw new ArgumentException("Incorrect coordinates!");
            }

            return result;
        }
    }
}
