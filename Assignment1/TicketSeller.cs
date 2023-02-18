namespace Assignment1
{
    internal class TicketSeller
    {
        private string name = string.Empty;
        private double price = 100;
        private int numOfAdults;
        private int numOfChildren;

        public void Start()
        {
            getInput();
            displayResult();
        }

        public void getInput()
        {
            readName();
            numOfAdults = getNum("adults");
            numOfChildren = getNum("children");
        }

        public void readName()
        {
            Console.WriteLine("Your name please:");
            name = Console.ReadLine();
        }

        int getNum(string type)
        {
            Console.WriteLine("Number of " + type + ":");
            string numOf = Console.ReadLine();
            return int.Parse(numOf);
        }

        double calculateTotal()
        {
            return price * 0.75 * numOfChildren + price * numOfAdults;
        }

        public void displayResult()
        {
            Console.WriteLine("+++ Your receipt +++");
            Console.WriteLine("+++ Amount to pay = " + calculateTotal());
            Console.WriteLine();
            Console.WriteLine("+++ Thank You " + name + " and please come back! +++");
        }
    }
}
