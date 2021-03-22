# dev-interview

The goal is to write a small Console app that receives stock price updates from a pre-built generator. 

Every 5 seconds, the app should output the number of price updates each stock receieved.

So, for example, if in the previous 5 seconds, AAPL updated twice and NFLX updated 3 times, it should output:

AAPL: 2
NFLX: 3


## StockPriceGenerator

The StockPriceGenerator class already exists. It will publish random price values for 5 stocks. It has an event, 
PriceUpdated, that will fire every time a stock price update occurs and will contain an EventArgs with a 
Symbol (as a string) and a new Price (as a decimal).

Call .Start() on the generator to begin the stream of price updates.