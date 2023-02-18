namespace Assignment2
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "Strings, selection and iterations in C#";
            FunFeatures funFeatures = new FunFeatures();
            funFeatures.Start();
            continueToNext();

            Console.Title = "Let's work with numbers";
            MathWorks math = new MathWorks();
            math.start();
            continueToNext();

            TemperatureConverter temperatureConverter = new TemperatureConverter();
            temperatureConverter.start();
            continueToNext();


            WorkingSchedule workingSchedule = new WorkingSchedule();
            workingSchedule.start();

            Console.Clear();
            Console.WriteLine("Have a nice rest of the day, press any key to exit");
            Console.ReadKey();
        }

        /// <summary>
        /// Ask user to press any key to continue to next part of program.
        /// </summary>
        static void continueToNext()
        {
            
            Console.WriteLine("\n\nPress any key to continue to next part");
            Console.ReadKey();
            Console.Clear();

        }
    }
}