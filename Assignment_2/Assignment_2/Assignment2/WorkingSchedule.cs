using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class WorkingSchedule
    {

        bool exitBool = false;



        public void start()
        {

            // do-while loop because itshould loop at least once
            do
            {
                mainMenu();
            }while(!exitBool);
        }


        public void mainMenu()
        {
            string lines = new String('-', 48);
            Console.WriteLine(lines);
            Console.WriteLine("\n\t\tmain menu".ToUpper());
            Console.WriteLine();
            Console.WriteLine(lines);
            Console.WriteLine("\nList of Weekends to work\t: 1");
            Console.WriteLine("List of nights to work\t\t: 2");
            Console.WriteLine("Exit\t\t\t\t: 0");

            selectOption();
        }

        /// <summary>
        /// Method to let user select option. Uses Do-while loop becouse it should loop at least once and until user put in correct input
        /// </summary>
        public void selectOption()
        {
            bool goodKey = false;
            do
            {
                Console.Write("\nSelect an option from the menu: ");
                switch (goodOption())
                {
                    case 1:
                        weeksToWork("weekends", 3);
                        goodKey = true;
                        break;
                    case 2:
                        weeksToWork("nights", 2);
                        goodKey = true;
                        break;
                    case 0:
                        exit();
                        goodKey = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid input please try again");
                        break;
                }
            } while (!goodKey);
        }

        /// <summary>
        /// Cheking userinput with the help of TryParse
        /// </summary>
        /// <returns></returns>
        private int goodOption()
        {
            bool parseBool = false;
            int optionInt;
            do
            {
                var option = Console.ReadKey();
                parseBool = int.TryParse(option.KeyChar.ToString(), out optionInt);

            }while(!parseBool);
            return optionInt;

        }


        /// <summary>
        /// Method that displays users shedule. Uses for-loop because start and end is known, step is given by users selection. 
        /// </summary>
        /// <param name="selection"></param>
        /// <param name="weekNum"></param>
        public void weeksToWork(string selection, int weekNum)
        {
            Console.WriteLine(string.Format("\nYou work {0} the following weeks: ", selection));
            for(int i= 1; i<=52; i+=weekNum)
            {
                Console.WriteLine("Week " + i);
            }
            backToMenu();
        }

        /// <summary>
        /// Method that pauses until users gives input, then clears the console.
        /// </summary>
        static void backToMenu()
        {
            Console.WriteLine("\nPress any key to go back to main menu.");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Method for exiting run
        /// </summary>
        public void exit()
        {
            exitBool = true;
        }




    }
}
