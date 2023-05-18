using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_WpfApp
{
    internal class BmrCalculator
    {
        #region Propertys
        public int Age { get; set; }

        public string Gender { get; set; } = string.Empty;

        public int GenderValue { get; set; }

        public int WeeklyActivityValue { get; set; }


        #endregion




        /// <summary>
        /// Returns calculated BMR
        /// </summary>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public double CalculateBmr(double weight, double height)
        {
            double bmr;
            bmr = 10 * weight + 6.25 * height - 5 * Age - GenderFactor();
            return bmr;
        }

        public double CalculateWeeklyBmr(double bmr)
        {
            return bmr * WeeklyActivityFactor();
        }

        /// <summary>
        /// method that returns factor for selected gender
        /// </summary>
        /// <returns></returns>
        public int GenderFactor()
        {
            int factor;
            switch (GenderValue)
            {
                case (int) GenderEnum.Female:
                    factor = -161;
                    break;
                case (int) GenderEnum.Male:
                    factor = 5;
                    break;  
                default:
                    factor = 0;
                    break;

            }
            return factor;
        }

        /// <summary>
        /// method that returns factor for selected weekly activity
        /// </summary>
        /// <returns></returns>
        public double WeeklyActivityFactor()
        {
            var factor = WeeklyActivityValue switch
            {
                (int)WeeklyActivityEnum.Sedentary => 1.2,
                (int)WeeklyActivityEnum.Lightly => 1.375,
                (int)WeeklyActivityEnum.Moderatly => 1.55,
                (int)WeeklyActivityEnum.Very => 1.725,
                (int)WeeklyActivityEnum.Extra => 1.9,
                _ => 0,
            };
            return factor;
        }

    }
}
