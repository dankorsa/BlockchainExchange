# BlockchainExchange
Implements Blockchain Exchange API (C#)


To get started create ConnectionHandler.

`public static ConnectionHandler client = new ConnectionHandler();`

Call Connect method to create connection:

`client.Connect();`

 or if you want to make authentificated calls:

`client.Connect(string SecretKey);`

Tell the client where you implemenented handling of events. Each channel has 1 event.

`client.OnAuthorisationEvent += AuthorizationEvent;
client.OnHeartbeatEvent += HeartbeatEvent;
client.OnBalanceEvent += BalanceEvent;
client.OnOrderBookL2Event += OrderBookL2Event;
client.OnOrderBookL3Event += OrderBookL3Event;
client.OnPriceEvent += PriceEvent;
client.OnSymbolEvent += SymbolEvent;
client.OnTickerEvent += TickerEvent;
client.OnTradesEvent += TradesEvent;
client.OnTradingEvent += TradingEvent;`

Run the client
`client.RunAsync().Wait()`

RunAsync will continiously send and receive messages. Upon received messages events will be invoked.

Here is the list of implemented calls that implemented in the ConnectionHandler.

`public void SubscribeBalance()`
`public void UnsubscribeBalance()`

`public void SubscribeL2(string symbol)`
`public void UnsubscribeL2(string symbol)`

`public void SubscribeL3(string symbol)`
`public void UnsubscribeL3(string symbol)`

`public void SubscribeHearbeat()`
`public void UnsubscribeHearbeat()`


SubscribePrices call asks for enum type GranularityValues. Possible values:

`Minute`
`FiveMinutes`
`FifteenMinutes`
`Hour`
`SixHours`
`TwentyFourHours`

`public void SubscribePrices(string symbol, GranularityValues granularity)`
`public void UnsubscribePrices(string symbol)`

`public void SubscribeSymbols()`
`public void UnsubscribeSymbols()`

`public void SubscribeTicker(string symbol)`
`public void UnsubscribeTicker()`

`public void SubscribeTrades(string symbol)`
`public void UnsubscribeTrades()`

`public void CreateOrder()`
`public void CancelOrder(string ID)`
