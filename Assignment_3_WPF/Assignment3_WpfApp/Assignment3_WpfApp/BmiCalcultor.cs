using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Assignment3_WpfApp
{
    internal class BmiCalcultor
    {

        #region Propertys
        public string Name { get; set; } = string.Empty;
        public double HeightInchCm { get; set; }
        public double HeightFeet { get; set; }
        public double Weight { get; set; }
        public bool MetricBool { get; set; } = true;
        #endregion


        /// <summary>
        /// Runs methods that calculates BMI and high/low normal weight
        /// </summary>
        /// <returns></returns>
        public (double, double, double) GetBmiResults()
        {
            double height = SetHeight();
            double factor = UnitFactor();
            double bmi = CalculateBMI(height, factor);
            double low = CalcNormalWeight(height, factor, 18.50);
            double high = CalcNormalWeight(height, factor, 24.9);
            return (bmi, high, low);
        }


        /// <summary>
        /// Method that returns factor for metric/imperial calculations
        /// </summary>
        /// <returns></returns>
        private double UnitFactor()
        {
            if (MetricBool)
                return 10000.0; //Input in cm not m
            else 
                return 703.0;
        }

        /// <summary>
        /// Returns height in just inches or cm
        /// </summary>
        /// <returns></returns>
        private double SetHeight()
        {
            if (MetricBool)
                return HeightInchCm;
            else
                return HeightFeet * 12 + HeightInchCm;
            ;
        }

        /// <summary>
        /// BMI calculation
        /// </summary>
        /// <returns></returns>
        public double CalculateBMI (double height, double factor)
        {                     
            return factor * Weight / Math.Pow(height, 2);
        }

        /// <summary>
        /// Method that returns the weight category of the inputed BMI
        /// </summary>
        /// <param name="bmi"></param>
        /// <returns></returns>
        public string CategoryBMI(double bmi)
        {
            string category = string.Empty;
            switch (bmi) 
            {
                case < 18.5:
                    category = "Underweight";
                    break;
                case < 24.9:
                    category = "Normal weight";
                    break;
                case < 29.9:
                    category = "Overweight (Pre-obesity)";
                    break;
                case < 34.9:
                    category = "Overweight (Obesity class I)";
                    break;
                case < 39.9:
                    category = "Overweight (Obesity class II)";
                    break;
                default:
                    category = "Overweight (Obesity class III)";
                    break;

            }
            return category;
        }

        public double CalcNormalWeight(double height, double factor, double bmi)
        {
            return Math.Pow(height, 2) * bmi / factor ;
        }

    }
}
