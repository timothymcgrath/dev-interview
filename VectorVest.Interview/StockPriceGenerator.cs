using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VectorVest.Interview
{
    public class StockPriceGenerator
    {

        private readonly Random _random;
        private readonly IEnumerable<int> _stocks;

        public delegate void StockPriceEventHandler(object sender, StockPriceEventArgs e);
        public event StockPriceEventHandler PriceUpdated;

        public StockPriceGenerator()
        {
            _random = new Random();
            _stocks = new List<int> { 1, 2, 3, 4, 5 };
        }

        public void Start()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        var stockId = _random.Next(_stocks.First(), _stocks.Last());
                        var price = _random.Next(100, 200);

                        if (PriceUpdated is not null)
                        {
                            PriceUpdated(this, new StockPriceEventArgs(new StockPrice(stockId, price)));
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
        public StockPriceEventArgs(StockPrice stockPrice)
        {
            StockPrice = stockPrice;
        }

        public StockPrice StockPrice { get; set; }
    }

    public class StockPrice
    {
        public StockPrice(int stockId, decimal price)
        {
            StockId = stockId;
            Price = price;
        }

        public int StockId;
        public decimal Price;
    }
}
