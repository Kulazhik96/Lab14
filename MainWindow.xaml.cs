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
using Lab14_Kulazhin.AssistiveWindows;

namespace Lab14_Kulazhin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // To store result.
        public static string operationResult { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        // Get calculation result.
        private void InputButton_Click(object sender, RoutedEventArgs e)
        {
            InputWindow iw = new();
            try
            {
                if (iw.ShowDialog() == true)
                {
                    operationResult = iw.CalculationResult;
                }
            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        // Insert calculation result in new window.
        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow sw = new();
            sw.ShowResult.Text = operationResult;

            sw.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
