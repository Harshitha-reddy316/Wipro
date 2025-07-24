using System;
namespace ConsoleApp1
{
    class StockUpdates
    {
        private string stockName;
        private string stockSymbol;
        private double previousClosingPrice;
        private double currentClosingPrice;


        public StockUpdates(string name, string symbol, double previousPrice, double currentPrice)
        {
            stockName = name;
            stockSymbol = symbol;
            previousClosingPrice = previousPrice;
            currentClosingPrice = currentPrice;
        }
        public double GetChangePercentage()
        {
            double change = currentClosingPrice - previousClosingPrice;
            return (change / previousClosingPrice) * 100;
        }
        public void Display()
        {
            Console.WriteLine($"Stock: {stockName} ({stockSymbol})");
            Console.WriteLine($"Previous Closing Price: ₹{previousClosingPrice}");
            Console.WriteLine($"Current Closing Price : ₹{currentClosingPrice}");
            Console.WriteLine($"Percentage Change     : {GetChangePercentage():F2}%");
        }

        // Main method for testing
        static void Main()
        {
            StockUpdates s = new StockUpdates("TCS", "TCS.NS", 3500.00, 3675.50);
            s.Display();
        }
    }
}
