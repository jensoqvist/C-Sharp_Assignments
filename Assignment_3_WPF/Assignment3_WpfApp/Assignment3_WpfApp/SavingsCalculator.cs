using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_WpfApp
{
    internal class SavingsCalculator
    {
        #region Propertys
        public decimal InitialDeposit { get; set; }
        public decimal MonthlyDeposit { get; set; }
        public int Period { get; set; }
        public double Growth { get; set; }
        public double Fees { get; set; }
        #endregion


        public decimal CalculateAmountPaid()
        {
            return InitialDeposit + MonthlyDeposit * 12 * Period;
        }

        public (decimal, decimal) CalculateFinalBalance() 
        {
            double monthlyGrowth = ((Growth / 100) / 12) ;
            double monthlyFee = ((Fees / 100) / 12);
            int numOfMonths = Period * 12;
            decimal balance =  InitialDeposit;
            decimal totalFees = 0;
            

            for (int i = 1; i <= numOfMonths; i++) 
            {
                decimal monthlyEarning = (balance) * (decimal) monthlyGrowth;
                decimal fee = balance * (decimal) monthlyFee;
                balance += monthlyEarning + MonthlyDeposit;
                totalFees += fee;
                balance -= fee;
                
            }
            return (balance, totalFees);
        }


    }


}
