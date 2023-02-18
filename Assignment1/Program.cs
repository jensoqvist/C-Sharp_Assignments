namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrepareConsoleLook();

            Pet pet = new Pet();
            pet.Start();

            nextPart();

            Album album = new Album();
            album.Start();

            nextPart();

            TicketSeller ticketSeller = new TicketSeller();
            ticketSeller.Start();

            Console.WriteLine("Press Enter to exit!");
            Console.ReadLine();
        }

        static void nextPart()
        {
            Console.WriteLine();
            Console.WriteLine("Press Enter to start next part");
            Console.ReadLine();
            for (int i = 1; i < 10; i += 2)
            {
                Console.Write(i);
            }
        }

        static void PrepareConsoleLook()
        {
            //Arrange console window
            Console.BackgroundColor= ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Black;
            Console.Title= "KIDS' FAIR";
        }
    }
}