using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment3_WpfApp
{
    public partial class MainWindow : Window
    {
        SavingsCalculator savingsCalculator = new();

        /// <summary>
        /// Method that reads all the input textboxes for the savings calculator and returns true if they are valid
        /// </summary>
        /// <returns></returns>
        private bool GetSavingsInput()
        {
            savingsCalculator.InitialDeposit = ParseDecimal(initialDepositTextBox.Text, "initial deposit", out bool boolInitial).GetValueOrDefault();
            if (!boolInitial) return false;
            savingsCalculator.MonthlyDeposit = ParseDecimal(monthlyDepositTextBox.Text, "monthly deposit", out bool boolMonthly).GetValueOrDefault();
            if (!boolMonthly) return false;
            savingsCalculator.Period = ParseInt(periodTextBox.Text, "period (number of years)", out bool boolPeriod).GetValueOrDefault();
            if (!boolPeriod) return false;
            savingsCalculator.Growth = ParseDouble(growthTextBox.Text, "yearly growth (%)", out bool boolGrowth).GetValueOrDefault();
            if (!boolGrowth) return false;
            savingsCalculator.Fees = ParseDouble(feesTextBox.Text, "yearly fees (%)", out bool boolFees).GetValueOrDefault();
            if (!boolFees) return false;
            return true;
        }

        /// <summary>
        /// Calls method to calculate then displays savings results
        /// </summary>
        private void DisplaySavingsResults()
        {
            decimal amountPaid = savingsCalculator.CalculateAmountPaid();
            var finalBalanceAndFees = savingsCalculator.CalculateFinalBalance();
            decimal finalBalance = finalBalanceAndFees.Item1;
            decimal totalFees = finalBalanceAndFees.Item2;
            decimal amountEarned = finalBalance - amountPaid;
            amountPaidTextBox.Text = amountPaid.ToString();
            finalBalanceTextBox.Text = finalBalance.ToString("#.##");
            amountEarnedTextBox.Text = amountEarned.ToString("#.##");
            totalFeesTextBox.Text = totalFees.ToString("#.##");
        }

        #region parser methods for decimal/int/double
        /// <summary>
        /// Method that returns decimal if valid input otherwise shows error message
        /// </summary>
        /// <param name="textIn"></param>
        /// <param name="inputBox"></param>
        /// <param name="decimalBool"></param>
        /// <returns></returns>
        public decimal? ParseDecimal(string textIn, string inputBox, out bool decimalBool)
        {

            decimalBool = decimal.TryParse(textIn, out decimal value);
            if (!decimalBool)
            { 
                MessageBox.Show(string.Format("Please input valid {0}", inputBox));
                return null;
            }
            return value;         
         }

        public int? ParseInt(string textIn, string inputBox, out bool intBool)
        {

            intBool = int.TryParse(textIn, out int value);
            if (!intBool)
            {
                MessageBox.Show(string.Format("Please input valid {0}", inputBox));
                return null;
            }
            return value;
        }

        public double? ParseDouble(string textIn, string inputBox, out bool doubleBool)
        {

            doubleBool = double.TryParse(textIn, out double value);
            if (!doubleBool)
            {
                MessageBox.Show(string.Format("Please input valid {0}", inputBox));
                return null;
            }
            return value;
        }
        #endregion



    }
}
