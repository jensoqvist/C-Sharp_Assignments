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

namespace Assignment3_WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {

            InitializeComponent();
            InitializeGuiBmi();
            

        }

        #region BMI Calculator
        private void BMICalculatorButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayBmiResults(); //MainWin BMI Helper function


        }

        private void UnitRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UnitRadioHandler(); //MainWin BMI Helper function
        }



        #endregion BMI calc


        #region BMR Calculator
        private void bmrCalcButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayBmrResults();

        }




        #endregion

        #region Savings Calculator
        private void savingsCalcButton_Click(object sender, RoutedEventArgs e)
        {
            bool input = GetSavingsInput();
            DisplaySavingsResults();

        }



        #endregion
    }
}
