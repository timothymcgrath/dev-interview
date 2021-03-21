using System;

namespace VectorVest.Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new StockPriceGenerator();

            // TODO: Add an event handler to generator.PriceUpdated to process each tick

            generator.Start();




            Console.ReadLine();
        }
    }
}
