using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Part2
{
    internal class Guitar
    {
        private string name = string.Empty;
        private string color = string.Empty;
        private int numStrings;
        private double price;
        DateTime curDateTime = DateTime.Now;

        public void Start()
        {
            getName();
            getColor();
            getStrings();
            getPrice();
            display();
        }

        public void getName()
        {
            Console.WriteLine("What is your favourite guitar?");
            name = Console.ReadLine();
        }

        public void getColor()
        {
            Console.WriteLine("What color is the guitar?");
            color = Console.ReadLine();
        }

        public void getStrings()
        {
            Console.WriteLine("How many strings does the guitar have?");
            numStrings = int.Parse(Console.ReadLine());
        }

        public void getPrice()
        {
            Console.WriteLine("How much does the guitar cost?");
            price = double.Parse(Console.ReadLine());
        }

        public void display()
        {
            Console.WriteLine("Your favouríte guitar is a " + color + " " + name + " with " + numStrings + " strings with the price " + price);
            Console.WriteLine("Current date and time is: " + curDateTime.ToString());
        }

    }
}
