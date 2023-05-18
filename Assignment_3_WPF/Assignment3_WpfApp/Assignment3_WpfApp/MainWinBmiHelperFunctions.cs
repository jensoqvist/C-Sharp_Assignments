using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Assignment3_WpfApp
{
    public partial class MainWindow : Window
    {
        BmiCalcultor bmiCalcultor = new BmiCalcultor();
        bool weightBool;
        bool heightInchCmBool;
        bool heightFeetBool;


        public void InitializeGuiBmi()
        {
            metricRadio.IsChecked= true;
            HeightFeetTextBox.IsEnabled= false;
        }

        /// <summary>
        /// Method to display BMI results
        /// </summary>
        public void DisplayBmiResults()
        {
            GetBmiInput();
            if (weightBool && (heightInchCmBool || heightFeetBool))
            {
                var results = bmiCalcultor.GetBmiResults();
                double bmi = results.Item1;
                double normalWeightHigh = results.Item2;
                double normalWeightLow = results.Item3;
                bmiReslutTextBox.Text = bmi.ToString("#.##");
                weightCategoryTextBox.Text = bmiCalcultor.CategoryBMI(bmi);
                ResultsHeadText();
                normalWeightTextBox.Text = NormalWeightBoxText(normalWeightLow, normalWeightHigh);
            }
            else
            {
                ClearBmiResults();
                MessageBox.Show("Please fill out weight and height in correct format", "Error");
            }
        }

        /// <summary>
        /// Sets the header for the results
        /// </summary>
        private void ResultsHeadText()
        {
            if (!string.IsNullOrEmpty(bmiCalcultor.Name))
                bmiResultsHead.Text = "Results for " + bmiCalcultor.Name;
            else
                bmiResultsHead.Text = "Results";
        }


        /// <summary>
        /// clears result textblocks
        /// </summary>
        public void ClearBmiResults()
        {
            bmiReslutTextBox.Text = null;
            weightCategoryTextBox.Text = null;
            normalWeightTextBox.Text = null;
            bmiResultsHead.Text = "Results";
        }

        /// <summary>
        /// Gets input from textboxes and tries to parse them 
        /// </summary>
        public void GetBmiInput() 
        {
            bmiCalcultor.Name = NameTextBox.Text;
            weightBool = double.TryParse(WeightTextBox.Text, out double resWeight);
            bmiCalcultor.Weight = resWeight;
            heightInchCmBool = double.TryParse(HeightInchCmTextBox.Text, out double resInchCm);
            bmiCalcultor.HeightInchCm = resInchCm;
            heightFeetBool = double.TryParse(HeightFeetTextBox.Text, out double resFeet);
            bmiCalcultor.HeightFeet = resFeet;
        }


        /// <summary>
        /// Returns a string with the normal weights based on the inputed height
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        private string NormalWeightBoxText(double low, double high)
        {
            return string.Format("Normal weight should be between {0:#.##} and {1:#.##} kg", low, high);
        }

        /// <summary>
        /// Sets up GUI for selected unit
        /// </summary>
        public void UnitRadioHandler()
        {
            
            if (metricRadio.IsChecked.GetValueOrDefault())
            {
                bmiCalcultor.MetricBool = true;
                heightHeaderText.Text = "Height (cm)";
                weightHeaderText.Text = "Weight (Kg)";
                HeightFeetTextBox.IsEnabled = false;
            }
            else
            {
                bmiCalcultor.MetricBool = false;
                heightHeaderText.Text = "Height (ft and in)";
                weightHeaderText.Text = "Weight (lbs)";
                HeightFeetTextBox.IsEnabled = true;
            }
            ClearBmiResults();
        }

    }
}
