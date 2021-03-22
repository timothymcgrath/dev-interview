using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VectorVest.Interview
{
    public class StockPriceGenerator
    {

        private readonly Random _random;
        private readonly List<string> _stocks;

        public delegate void StockPriceEventHandler(object sender, StockPriceEventArgs e);
        public event StockPriceEventHandler PriceUpdated;

        public StockPriceGenerator()
        {
            _random = new Random();
            _stocks = new List<string> { "AAPL", "MSFT", "GOOG", "IBM", "NFLX" };
        }

        public void Start()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        var stock = _random.Next(1, _stocks.Count());
                        var price = _random.Next(100, 200);

                        if (PriceUpdated is not null)
                        {
                            PriceUpdated(this, new StockPriceEventArgs(_stocks[stock], price));
                        }

                        await Task.Delay(250);
                    }
                    catch (Exception)
                    {
                        // Swallow any errors.
                    }
                }
            });
        }
    }

    public class StockPriceEventArgs : EventArgs
    {
        public StockPriceEventArgs(string symbol, decimal price)
        {
            Symbol = symbol;
            Price = price;
        }

        public string Symbol;
        public decimal Price;
    }
}
