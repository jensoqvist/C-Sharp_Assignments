using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Pet
    {
        private string name = string.Empty;
        private int age;
        private bool isFemale;
        private string strIsFemale = string.Empty;

        public void Start()
        {
            ReadInput();
            DisplayResult();
        }

        public void ReadInput()
        {
            ReadName();
            ReadAge();           
            do
            {
                ReadIsFemale();
            } while ((strIsFemale != "y") && (strIsFemale != "n")); //Loop if input for strIsFemale is not 'y' or 'n'
        }

        public void ReadName() 
        {
            Console.WriteLine("What is the name of your pet?");
            name = Console.ReadLine();
        }

        public void ReadAge()
        {
            Console.WriteLine("What is " + name + "´s age?");
            string strAge = Console.ReadLine();
            age = int.Parse(strAge);
        }

        public void ReadIsFemale()
        {
            Console.WriteLine("Is your pet female? (y/n)");
            strIsFemale = Console.ReadLine().ToLower(); // ToLower() 
            if (strIsFemale == "y") 
            {
                isFemale= true;
            }
            else if (strIsFemale == "n")
            {
                isFemale= false;
            }
            else 
            {
                Console.WriteLine("Please answer with 'y' or 'n'");
            }

        }

        public void DisplayResult()
        {
            string strPluses = new String('+', 32);
            string gender = "girl";
            if(isFemale == false)
            {
                gender = "boy";
            }
            Console.WriteLine(strPluses);
            Console.WriteLine("Name: " + name + " Age: " + age);
            Console.WriteLine(name + " is a good " + gender + "!");
            Console.WriteLine(strPluses);
        }


    }
}
