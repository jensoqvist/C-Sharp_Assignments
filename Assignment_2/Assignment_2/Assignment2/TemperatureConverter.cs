using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class TemperatureConverter
    {

        bool exitBool = false;

        public void start()
        {
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
            Console.WriteLine("\nCelsius to Farenheit\t: 1");
            Console.WriteLine("Farenheit to Celsius\t: 2");
            Console.WriteLine("Exit\t\t\t: 0");
            
            selectOption();
        }


        public void selectOption()
        {
            ConsoleKey option;
            bool goodKey = false;
            do
            {
                Console.Write("\nSelect an option from the menu: ");
                option = Console.ReadKey().Key;
                switch (option)
                {
                    case ConsoleKey.D1: 
                        showFarenheit();
                        goodKey = true;
                        break;
                    case ConsoleKey.D2:
                        showCelsius();
                        goodKey = true;
                        break;
                    case ConsoleKey.D0:
                        exit();
                        goodKey= true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid input please try again");
                        break;
                }
           } while (!goodKey);
        }

        
        public void showFarenheit()
        {
            const int max = 100;
            Console.WriteLine("\n");
            showDegree("°C", "°F", max, 4, toFarenheit);
            backToMenu();
        }

        public double toFarenheit(double celsius)
        {
            return 9 / 5.0 * celsius + 32;
        }

        public void showCelsius()
        {
            const int max = 212;
            Console.WriteLine("\n");
            showDegree("°F", "°C", max, 10, toCelsius);
            backToMenu();

        }

        public double toCelsius(double farenheit)
        {
            return 5 / 9.0 * (farenheit - 32);
        }

        public void showDegree(string degreeNameIn, string degreeNameOut, int max, int step, Func<double, double>degreeMethod)
        {
            for(int i= 0; i<=max; i+=step) 
            {
                double degreeOut = degreeMethod(i);
                Console.WriteLine(string.Format("{0}{1} = {2:0.00}{3}", i, degreeNameIn, degreeOut, degreeNameOut));
            }
        }

        static void backToMenu()
        {
            Console.WriteLine("\nPress any key to go back to main menu.");
            Console.ReadKey();
            Console.Clear();
        }

        public void exit()
        {
            exitBool = true;
        }
    }
}
