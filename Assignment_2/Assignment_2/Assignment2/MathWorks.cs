using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class MathWorks
    {

        public void start() 
        {
            multiplicationTables();

            do
            {

                Console.WriteLine("\n\nLets calculate the sum of all numbers in between two integers!");
                var numbers = getOrderedNums();
                int num1 = numbers.Item1;
                int num2 = numbers.Item2;
                Console.WriteLine(new String('-', 48));
                sumOfNumbers(num1, num2);

                //print even nums
                printNums(num1, num2, "even");

                //print odd nums
                printNums(num1, num2, "odd");

                squareRoots(num1, num2);
            }while(new FunFeatures().runAgain("math"));
        }

        /// <summary>
        /// Prints out multiplication tables up to the number 12
        /// </summary>
        public void multiplicationTables() 
        {
            Console.WriteLine("\t * * * * * * * * *  \tmultiplication tables\t * * * * * * * * *  ".ToUpper());
            for (int i = 1; i <= 12; i++)
            {
                for (int j = 1; j <=12 ; j++)
                {
                    Console.Write(i * j + "\t");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Gives the sum of all the numbers between two given integers
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        public void sumOfNumbers(int num1, int num2) 
        {
            
            int result = 0;
            for (int i = num1; i <= num2; i++)
                result += i;
            
            Console.WriteLine(string.Format("\nThe sum of the numbers from {0} to {1} is ", num1, num2) + result);
        }

        /// <summary>
        /// Gets two integers by calling method getOneNumber twice, returns them ordered sizewise
        /// </summary>
        /// <returns></returns>
        public (int, int) getOrderedNums() 
        {
            int num1 = getOneNumber("first");
            int num2 = getOneNumber("second");
            return orderNums(num1, num2);

        }

        /// <summary>
        /// Asks user to input one integer
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        public int getOneNumber(string place) 
        {
            bool goodNumBool = false;
            int number;
            
            do
            {
                Console.Write(string.Format("Input the {0} integer please: ", place));
                goodNumBool = int.TryParse(Console.ReadLine(), out number);
                if (!goodNumBool)
                {
                    Console.WriteLine("You did not input an integer");
                }
            } while (!goodNumBool);
            return number;
        }


        /// <summary>
        /// Orders two numbers, if num1 is bigger than num2 they change places
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public (int, int) orderNums(int num1, int num2)
        {
            if (num1 > num2)
            {
                num1 = num1 + num2;
                num2 = num1 - num2;
                num1 = num1 - num2;
            }
            return (num1, num2);
        }

        /// <summary>
        /// Method that prints even or odd numbers
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="evenOdd"></param>
        /// <param name="evenOddString"></param>
        public void printNums(int num1, int num2, string evenOddString)
        { 
            Console.WriteLine(string.Format("\nThe {0} numbers between {1} and {2} is: ", evenOddString, num1, num2));
            for(int i= num1; i <= num2; i++) 
            { 
                if (i % 2 == 0 && evenOddString == "even") 
                { 
                    Console.Write(i + "\t");
                }
                else if(i % 2 != 0 && evenOddString == "odd")
                {
                    Console.Write(i + "\t");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Calculates the square roots between two inegers
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        public void squareRoots(int num1, int num2) 
        { 
            Console.WriteLine("\n\n\t\t * * * * * * square roots * * * * * *".ToUpper());
            for(int i= num1; i<= num2; i++) 
            { 
                Console.Write(string.Format("Sqrt ({0} to {1})\t", num1, num2));
                for(int j = i; j<= num2; j++)
                {
                    Console.Write(Math.Sqrt((double) j).ToString("0.##") + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
