using System;
using BlockchainExchangeAPI;
using BlockchainExchangeAPI.Responses;
using BlockchainExchangeAPI.Responses.Authenticated;
using BlockchainExchangeAPI.Models;

namespace ConsoleApp
{
	class Program
	{
		public static string APISecretKey = "";

        public static ConnectionHandler client = new ConnectionHandler();

		static void Main(string[] args)
		{

			//client.Connect(APISecretKey);
			client.Connect();

			client.SubscribeHearbeat(); // Subscribe to anonymous channel
            client.SubscribePrices("BTC-USD", GranularityValues.FiveMinutes); // Subscribe to anonymous channel
            //client.UnsubscribePrices("BTC-USD"); // Unsubscribe to anonymous channel

            client.OnAuthorisationEvent += AuthorizationEvent;
            client.OnHeartbeatEvent += HeartbeatEvent;
            client.OnBalanceEvent += BalanceEvent;
            client.OnOrderBookL2Event += OrderBookL2Event;
            client.OnOrderBookL3Event += OrderBookL3Event;
            client.OnPriceEvent += PriceEvent;
            client.OnSymbolEvent += SymbolEvent;
            client.OnTickerEvent += TickerEvent;
            client.OnTradesEvent += TradesEvent;
            client.OnTradingEvent += TradingEvent;

            client.RunAsync().Wait();

        }

        /* Creating order example */
        //CreateNewOrderRequest orderRequest  = new CreateNewOrderRequest
        //{
        //    ClOrdID = "My order",
        //    ExecInst = "ALO",
        //    OrderQty = 0.1,
        //    orderType = OrderType.Limit,
        //    Price = 8800,
        //    Side = SideType.Sell,
        //    Symbol = "BTC-EUR",
        //    TimeInForce = TimeInForceType.GoodTillCancel
        //};

        //client.CreateOrder(orderRequest);



        public static void HeartbeatEvent(object sender, HeartbeatResponse response)
		{
			Console.WriteLine($"\nWe got a heartbeat! {response.Channel} {response.Event} {response.Timestamp}");
		}

		public static void AuthorizationEvent(object sender, AuthResponse response)
		{
			if (response.Event == EventType.Subscribed)
			{
				Console.WriteLine("\n*You successfully subscribed to channel auth.");
				Console.WriteLine($"Read-only mode: {response.readOnly}\n");


                client.SubscribeBalance(); // Since we successfully subscribed to auth, we can make authentificated calls.

            }
			else if (response.Event == EventType.Rejected)
			{
				Console.WriteLine($"*Auth failed: {response.Message}. Only anonymous channels are accessible.");
			}
        }

		public static void BalanceEvent(object sender, BalanceResponse response)
		{
			switch (response.Event)
			{
				case EventType.None:	{ break; }
				case EventType.Subscribed:
				{
					Console.WriteLine("*You successfully subscribed to your balances.");
					break;
				}
				case EventType.Unsubscribed:
				{
					 Console.WriteLine($"*You successfully unsubscribed from your balances.");
					break;
				}
				case EventType.Rejected:
				{
					Console.WriteLine($"*Balance subscription failed. Server returned a message: '{response.Message}'. ");
					break;
				}
				case EventType.Snapshot:
                { 

                    Console.WriteLine("*** Balance snapshot:");
					foreach (var balance in response.Balances)
					{
						Console.WriteLine(balance.ToString());
					}
					Console.WriteLine("\ntotal_available_local: " + response.Total_available_local);
					Console.WriteLine("total_balance_local: " + response.Total_balance_local + "\n\n");
					Console.WriteLine("*** End of snapshot.\n\n");
					break;
				}
				case EventType.Updated: { break; }
				default: { break; }
			}
		}

		public static void OrderBookL2Event(object sender, OrderBookL2Response response)
        {
            if (response.Event == EventType.Subscribed)
            {
                Console.WriteLine("*You succesfully subscribed to L2 Orderbook for pair: " + response.Symbol + "\n");
            }
            else if (response.Event == EventType.Snapshot)
            {
                Console.WriteLine("*** L3 Orderbook snapshot: " + response.Symbol + "\n");
                Console.WriteLine("Asks:\n\n");
                foreach (var ask in response.Asks)
                {
					Console.WriteLine(ask.ToString());
                }
                Console.WriteLine("");
                Console.WriteLine("Bids:\n\n");
                foreach (var bid in response.Bids)
                {
                   Console.WriteLine(bid.ToString());
                }
                Console.WriteLine("*** End of snapshot.");
            }

            else if (response.Event == EventType.Updated)
            {
                Console.WriteLine("*** L2 Orderbook update: " + response.Symbol + "\n");
                Console.WriteLine("Updated asks:\n\n");

                foreach (var ask in response.Asks)
                {
                   Console.WriteLine(ask.ToString());
                }

                Console.WriteLine("");

                Console.WriteLine("Updated bids:\n\n");

                foreach (var bid in response.Bids)
                {
                    Console.WriteLine(bid.ToString());
                }

                Console.WriteLine("*** End of update.");
            }
        }

		public static void OrderBookL3Event(object sender, OrderBookL3Response response)
        {
            if (response.Event == EventType.Subscribed)
            {
                Console.WriteLine("*You succesfully subscribed to L3 Orderbook for pair: " + response.Symbol + "\n");
            }
            else if (response.Event == EventType.Snapshot)
            {

			}
               
        }
		
		public static void PriceEvent(object sender, PriceResponse response)
        {

            if (response.Event == EventType.Subscribed)
            {
                Console.WriteLine("*You succesfully subscribed to price updates for pair: " + response.Symbol);
            }
            else if (response.Event == EventType.Updated)
            {
                Console.WriteLine("*** Update on pair '" + response.Symbol + "': \n" +
                                  "Timestamp: " + response.price[0] + "\n" +
                                  "open: " + response.price[1] + "\n" +
                                  "high: " + response.price[2] + "\n" +
                                  "low: " + response.price[3] + "\n" +
                                  "close: " + response.price[4] + "\n" +
                                  "volume: " + response.price[5] + "\n" +
                                  "*** End of update. \n");

            }
			else if (response.Event == EventType.Rejected)
            {
                Console.WriteLine("*Your attempt to subscribe to price update was rejected: " + response.Message);
            }

			else if (response.Event == EventType.Unsubscribed)
			{ 
				Console.WriteLine("*You succesfully unsubscribed from price updates of pair: " + response.Symbol);	
			}

        }

        public static void SymbolEvent(object sender, SymbolsResponse response)
        {
            if (response.Event == EventType.Subscribed)
            {
                Console.WriteLine("*You succesfully subscribed to symbols. \n");
            }
            else if (response.Event == EventType.Snapshot)
            {
                Console.WriteLine("*** symbols Orderbook snapshot: \n");
               
                foreach(var sym in response.symbols)
                {
                    Console.WriteLine("Pair: " + sym.Key);
                    Console.WriteLine();
                    Console.WriteLine("auction_price = " + sym.Value.AuctionPrice);
                    Console.WriteLine("auction_size = " + sym.Value.AuctionSize);
                    Console.WriteLine("auction_time = " + sym.Value.AuctionTime);
                    Console.WriteLine("base_currency = " + sym.Value.BaseCurrency);
                    Console.WriteLine("base_currency_scale = " + sym.Value.BaseCurrencyScale);
                    Console.WriteLine("counter_currency = " + sym.Value.CounterCurrency);
                    Console.WriteLine("counter_currency_scale = " + sym.Value.CounterCurrencyScale);
                    Console.WriteLine("id = " + sym.Value.ID);
                    Console.WriteLine("imbalance = " + sym.Value.Imbalance);
                    Console.WriteLine("lot_size = " + sym.Value.LotSize);
                    Console.WriteLine("lot_size_scale = " + sym.Value.LotSizeScale);
                    Console.WriteLine("max_order_size = " + sym.Value.MaxOrderSize);
                    Console.WriteLine("max_order_size_scale = " + sym.Value.MaxOrderSizeScale);
                    Console.WriteLine("min_order_size = " + sym.Value.MinOrderSize);
                    Console.WriteLine("min_order_size_scale = " + sym.Value.MinOrderSizeScale);
                    Console.WriteLine("min_price_increment = " + sym.Value.MinPriceIncrement);
                    Console.WriteLine("min_price_increment_scale = " + sym.Value.MinPriceIncrementScale);
                    Console.WriteLine("status = " + sym.Value.Status);
                    Console.WriteLine("***");
                }

                Console.WriteLine("*** End of snapshot.");
            }

            else if (response.Event == EventType.Updated)
            {
                Console.WriteLine("*** symbols Orderbook update: \n");

                foreach (var sym in response.symbols)
                {
                    Console.WriteLine("Pair: " + sym.Key);
                    Console.WriteLine();
                    Console.WriteLine("auction_price = " + sym.Value.AuctionPrice);
                    Console.WriteLine("auction_size = " + sym.Value.AuctionSize);
                    Console.WriteLine("auction_time = " + sym.Value.AuctionTime);
                    Console.WriteLine("base_currency = " + sym.Value.BaseCurrency);
                    Console.WriteLine("base_currency_scale = " + sym.Value.BaseCurrencyScale);
                    Console.WriteLine("counter_currency = " + sym.Value.CounterCurrency);
                    Console.WriteLine("counter_currency_scale = " + sym.Value.CounterCurrencyScale);
                    Console.WriteLine("id = " + sym.Value.ID);
                    Console.WriteLine("imbalance = " + sym.Value.Imbalance);
                    Console.WriteLine("lot_size = " + sym.Value.LotSize);
                    Console.WriteLine("lot_size_scale = " + sym.Value.LotSizeScale);
                    Console.WriteLine("max_order_size = " + sym.Value.MaxOrderSize);
                    Console.WriteLine("max_order_size_scale = " + sym.Value.MaxOrderSizeScale);
                    Console.WriteLine("min_order_size = " + sym.Value.MinOrderSize);
                    Console.WriteLine("min_order_size_scale = " + sym.Value.MinOrderSizeScale);
                    Console.WriteLine("min_price_increment = " + sym.Value.MinPriceIncrement);
                    Console.WriteLine("min_price_increment_scale = " + sym.Value.MinPriceIncrementScale);
                    Console.WriteLine("status = " + sym.Value.Status);
                    Console.WriteLine("***");
                }

                Console.WriteLine("*** End of update.");
            }
        }

        public static void TickerEvent(object sender, TickerResponse response)
        {
            if (response.Event == EventType.Subscribed)
            {
                Console.WriteLine("*You succesfully subscribed to Ticker. For pair '" + response.Symbol + "'\n");
            }
            else if (response.Event == EventType.Snapshot)
            {
                Console.WriteLine("*** Ticker snaphot for pair '" + response.Symbol + "'");
                Console.WriteLine("Last trade price for pair '" + response.Symbol + "': " + response.Last_trade_price);
                Console.WriteLine("Price_24h: '" + response.Symbol + "': " + response.Price_24h);
                Console.WriteLine("Volume_24h: '" + response.Symbol + "': " + response.Volume_24h);
            }
        }

        public static void TradesEvent(object sender, TradesResponse response)
        {
            if (response.Event == EventType.Subscribed)
            {
                Console.WriteLine("*You succesfully subscribed to Trade updates. For pair '" + response.Symbol + "'\n");
            }
            else if (response.Event == EventType.Updated)
            {
                Console.WriteLine("*** New trade occurred for pair: '" + response.Symbol + "'");
                Console.WriteLine("Timestamp " + response.Timestamp);
                Console.WriteLine("Side: " + response.Side);
                Console.WriteLine("Qty: " + response.Qty);
                Console.WriteLine("Price: " + response.Price);
                Console.WriteLine("trade_id: " + response.Trade_id);
                Console.WriteLine("\n\n");
            }
        }

        public static void TradingEvent(object sender, TradingResponse response)
        {
            if (response.Event == EventType.Subscribed)
            {
                Console.WriteLine("*You succesfully subscribed to trading channel. \n");
            }
            else if (response.Event == EventType.Snapshot)
            {
                if (response.Orders.Count > 0)
                {
                    Console.WriteLine("*Here are your orders: \n");
                    foreach (var order in response.Orders)
                    {
                        Console.WriteLine("OrderID = " + order.orderID);
                        Console.WriteLine("OrderQty = " + order.OrderQty);
                        Console.WriteLine("OrderPrice = " + order.Price);
                        Console.WriteLine("OrderStatus = " + order.OrdStatus);
                    }
                }
            }
        }
	}
}
