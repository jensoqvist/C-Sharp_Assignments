using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class FunFeatures
    {

        private string name = string.Empty;
        private string email = string.Empty;

        public void Start()
        {
            Introduction();

            do
            {
                Console.WriteLine("\n **** FORTUNE TELLER **** ");
                predictDay();
                Console.WriteLine(("\n ---- strenght lenght ---- ").ToUpper());
                stringLenght();

            } while (runAgain("fun"));

        }

        /// <summary>
        /// Introduction
        /// </summary>
        public void Introduction()
        {


            Console.WriteLine("Hello my name is Jens and I´m a student of the VT2023 semester!\n");
            Console.WriteLine("Let me know about yourself!");
            string firstName = getName("first");
            string lastName = getName("last");
            name = string.Format("{0}, {1}", lastName.ToUpper(), firstName);
            getEmail();
            Console.WriteLine("Hi " + name + " nice to meet you");
            Console.WriteLine(string.Format("Your email is {0}", email));


        }

        /// <summary>
        /// Method that gets part of a full name from user and returns it.
        /// </summary>
        /// <param name="nameFirstLast"></param>
        /// <returns></returns>
        public string getName(string nameFirstLast)
        {
            Console.Write(string.Format("Your {0} name please: ", nameFirstLast));
            string name = Console.ReadLine();
            return name;
        }

        /// <summary>
        /// Gets users e-mail adress
        /// </summary>
        public void getEmail()
        {
            Console.Write("Your email please: ");
            email = Console.ReadLine();
        }


        /// <summary>
        /// Method that predicts the users day
        /// </summary>
        /// <returns></returns>
        public void predictDay() 
        { 
            int num = getNum();
            switch (num)
            {
                case 1:
                    Console.WriteLine("Keep calm on Mondays! You can fall apart!");
                    break;
                case 2:
                case 3:
                    Console.WriteLine("Tuesdays and Wednesdays break your heart!");
                    break;
                case 4:
                    Console.WriteLine("Thursday is your lucky day, don't wait for Friday!");
                    break;
                case 5:
                    Console.WriteLine("Friday, you are in love!");
                    break;
                case 6:
                    Console.WriteLine("Saturday, do nothing and do plenty of it!");
                    break;
                case 7:
                    Console.WriteLine("And Sunday always comes too soon!");
                    break;
                default: 
                    Console.WriteLine("No day? is a good day but it doesn't exist!");
                    break;
            } 
        }

        /// <summary>
        /// Method to check if given number is an integer and call method to check the value
        /// </summary>
        /// <returns></returns>
        public int getNum() 
        {
            bool goodNumBool = false;
            int number;
            do
            {
                Console.Write("Input an integer between 1 and 7 please: ");
                goodNumBool = int.TryParse(Console.ReadLine(), out number);
                if (!goodNumBool)
                {
                    Console.WriteLine("You did not input an integer");
                }
                goodNumBool = checkValue(number);
            } while (!goodNumBool);
            return number;
        }


        /// <summary>
        /// Method to check if an integer has a value between 1 and 7
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool checkValue(int number)
        {
            if (number >= 1 && number <= 7)
                return true;
            else
            {
                Console.WriteLine("The integer you put in did not have a value between 1 and 7");
                return false;
            }

        }

        /// <summary>
        /// method used in do-while to give user option to break loop
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public bool runAgain(string part)
        {

            ConsoleKey answer;
            bool answerBool = false;
            Console.Write(string.Format("\nWasn't this fun! Do you want to run the {0} part again? (y/n) ", part));
            answer = Console.ReadKey().Key;
            Console.WriteLine();
            if (answer == ConsoleKey.Y)
            {
                answerBool = true;
            }
            return answerBool;
                
        }

        public void stringLenght()
        {
            Console.WriteLine("Enter a string: ");
            string inputString = Console.ReadLine();
            Console.WriteLine(inputString.ToUpper());
            Console.WriteLine("The string contains " + inputString.Length + " characters!");
        }



    }
}
