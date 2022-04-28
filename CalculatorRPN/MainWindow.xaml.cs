using CalculatorRPN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CalculatorRPN
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            txtInputExpression.Text += obj.Content;
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            txtInputExpression.Text = string.Empty;
        }

        private void Result(object sender, RoutedEventArgs e)
        {
            string s = "(2+3*2/2)/2";
            CalculatorReversePolishNotation RPN = new CalculatorReversePolishNotation();
            RPN.ToExpressionRPN(s);
            //TokenParser.GetTokenExpression(s);
        }
    }
}
