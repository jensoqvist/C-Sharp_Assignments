using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Assignment3_WpfApp
{
    public partial class MainWindow : Window
    {

        private bool ageBool = false;
        BmrCalculator bmrCalculator = new();


        private void DisplayBmrResults()
        {
            
            bool validInput = GetBmrResults();
            if (validInput) 
            {
                double weight = bmiCalcultor.Weight;
                double height = bmiCalcultor.HeightInchCm;
                double bmr = bmrCalculator.CalculateBmr(weight, height);
                double bmrActivity = bmrCalculator.CalculateWeeklyBmr(bmr);
                bmrResultsTextBox.Text = (
                    string.Format("Your BMR Results is:\n\n") +
                    string.Format("Your BMR (calories/day): {0}\n\n", bmr) +
                    string.Format("To maintain weight: {0}\n", bmrActivity) +
                    string.Format("To lose 0.5Kg per week: {0}\n", bmrActivity - 500) +
                    string.Format("To lose 1Kg per week: {0}\n", bmrActivity - 1000) +
                    string.Format("To gain 0.5Kg per week: {0}\n", bmrActivity + 500) +
                    string.Format("To gain 1Kg per week: {0}\n", bmrActivity + 1000)
                                          );
            }

        }


        public bool GetBmrResults()
        {
            bool validInput = false;
            GetBmiInput();
            GetAge();
            if (!(GenderRadioHandling() && ActivityRadioHandling()))
                return validInput;
            if (!(weightBool && (heightInchCmBool || heightFeetBool))) // Makes sure height and weight is filled out in the bmi calculator
            {
                MessageBox.Show("Please fill out height and weight in the BMI Calculator");
                return validInput;
            }
            else if (!ageBool) //Checks if age were inputed correctly
                {
                    MessageBox.Show("Please input your age");
                    return validInput;
                }
            else
                validInput = true;
            return validInput;
        }

        public bool GenderRadioHandling()
        {
            bool valid = true;
            if (femaleGenderRadio.IsChecked.GetValueOrDefault())
                bmrCalculator.GenderValue = 0;
            else if (maleGenderRadio.IsChecked.GetValueOrDefault())
                bmrCalculator.GenderValue = 1;
            else if (nonbinaryGenderRadio.IsChecked.GetValueOrDefault())
                bmrCalculator.GenderValue = 2;
            else if (prefernotGenderRadio.IsChecked.GetValueOrDefault())
                bmrCalculator.GenderValue = 3;
            else
            {
                MessageBox.Show("Please select gender");
                valid = false;
            }
            return valid;

        }

        

        public bool ActivityRadioHandling()
        {

            bool valid = true;
            if (weeklySedentaryActivieRadio.IsChecked.GetValueOrDefault())
                bmrCalculator.WeeklyActivityValue = 0;
            else if (weeklyLightActivieRadio.IsChecked.GetValueOrDefault())
                bmrCalculator.WeeklyActivityValue = 1;
            else if (weeklyModerateActivieRadio.IsChecked.GetValueOrDefault())
                bmrCalculator.WeeklyActivityValue = 2;
            else if (weeklyVeryActiveRadio.IsChecked.GetValueOrDefault())
                bmrCalculator.WeeklyActivityValue = 3;
            else if (weeklyExtraActiveRadio.IsChecked.GetValueOrDefault())
                bmrCalculator.WeeklyActivityValue = 4;
            else
            {
                MessageBox.Show("Please select weekly activity");
                valid = false;
            }
            return valid;
        }


        public void GetAge()
        {
            ageBool = int.TryParse(ageTextBox.Text, out int res);
            bmrCalculator.Age = res;
        }

    }
}
