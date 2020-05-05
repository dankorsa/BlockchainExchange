using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlockchainExchangeAPI.Models;
using BlockchainExchangeAPI.Requests;
using BlockchainExchangeAPI.Responses;
using BlockchainExchangeAPI.Json;
using BlockchainExchangeAPI.Responses.Authenticated;
using BlockchainExchangeAPI.Requests.Authenticated;

namespace BlockchainExchangeAPI
{
    public class ConnectionHandler
    {
		private const string ConnectionURI = "wss://ws.prod.blockchain.info/mercury-gateway/v1/ws";
        private const string HeaderName = "origin";
		private const string HeaderURL = "https://exchange.blockchain.com";

		private const int TimeOutMiliseconds = 5000;
		private CancellationTokenSource cancellationToken;

        private Queue<string> MessageQueue = new Queue<string>();
		private ClientWebSocket socket = new ClientWebSocket();

		private JsonHandler jsonHandler;

		public event EventHandler<AuthResponse> OnAuthorisationEvent;
		public event EventHandler<OrderBookL3Response> OnOrderBookL3Event;
		public event EventHandler<OrderBookL2Response> OnOrderBookL2Event;
		public event EventHandler<PriceResponse> OnPriceEvent;
		public event EventHandler<BalanceResponse> OnBalanceEvent;
		public event EventHandler<HeartbeatResponse> OnHeartbeatEvent;
		public event EventHandler<SymbolsResponse> OnSymbolEvent;
        public event EventHandler<TickerResponse> OnTickerEvent;
        public event EventHandler<TradesResponse> OnTradesEvent;
        public event EventHandler<TradingResponse> OnTradingEvent;

        public ConnectionHandler()
        {
			jsonHandler = new JsonAdapter();
        }

		// Anonymous connection 
		public void Connect()
		{
			Connect(null, null);
		}

		// Authenticated connection
		public void Connect(string SecretKey)
		{ 
			Connect(SecretKey, null);
		}

		public void Connect(string SecretKey, EventHandler<AuthResponse> connectionResponse)
		{
			if (SecretKey != null)
			{ 
				AuthRequest auth = new AuthRequest
				{
					Token = SecretKey,
					Action = ActionType.Subscribe
				};
				OnAuthorisationEvent += connectionResponse;
				AddMessageToQueue(auth);
			}
			ConnectSocketAsync().Wait();
		}

        public void SubscribeBalance()
		{
            BalanceRequest br = new BalanceRequest
            {
                Action = ActionType.Subscribe
            };
			AddMessageToQueue(br);
		}

        public void UnsubscribeBalance()
        {
        BalanceRequest br = new BalanceRequest
        {
            Action = ActionType.Unsubscribe
        };
            AddMessageToQueue(br);
        }

        public void SubscribeL2(string symbol)
		{
			OrderBookRequest l2 = new OrderBookRequest
            {
                Action = ActionType.Subscribe,
                Channel = ChannelType.L2,
                Symbol = symbol
            };
			AddMessageToQueue(l2);
		}

		public void UnsubscribeL2(string symbol)
		{
			OrderBookRequest l2 = new OrderBookRequest
            {
                Action = ActionType.Unsubscribe,
                Channel = ChannelType.L2,
                Symbol = symbol
            };
			AddMessageToQueue(l2);
		}

		public void SubscribeL3(string symbol)
		{
			OrderBookRequest l3 = new OrderBookRequest
            {
                Action = ActionType.Subscribe,
                Channel = ChannelType.L3,
                Symbol = symbol
            };
			AddMessageToQueue(l3);
		}

		public void UnsubscribeL3(string symbol)
		{
			OrderBookRequest l3 = new OrderBookRequest
            {
                Action = ActionType.Unsubscribe,
                Channel = ChannelType.L3,
                Symbol = symbol
            };
			AddMessageToQueue(l3);
		}

		public void SubscribeHearbeat()
		{
			HeartbeatRequest hb = new HeartbeatRequest
			{
				Action = ActionType.Subscribe
            };
			AddMessageToQueue(hb);
		}

		public void UnsubscribeHearbeat()
		{
			HeartbeatRequest hb = new HeartbeatRequest
			{
				Action = ActionType.Unsubscribe
            };
			AddMessageToQueue(hb);
		}

		public void SubscribePrices(string symbol, GranularityValues granularity)
		{
			PriceRequest pr = new PriceRequest
            {
				Channel = ChannelType.Prices,
				Action = ActionType.Subscribe,
                Symbol = symbol,
				Granularity = granularity
			};
			AddMessageToQueue(pr);
		}

		public void UnsubscribePrices(string symbol)
		{
			PriceRequest pr = new PriceRequest
            {
				Channel = ChannelType.Prices,
				Action = ActionType.Unsubscribe,
                Symbol = symbol
			};
			AddMessageToQueue(pr);
		}

		public void SubscribeSymbols()
		{
			SymbolsRequest sr = new SymbolsRequest
			{
				Channel = ChannelType.Symbols,
				Action = ActionType.Subscribe
			};
			AddMessageToQueue(sr);
		}

		public void UnsubscribeSymbols()
		{
			SymbolsRequest sr = new SymbolsRequest
			{
				Channel = ChannelType.Symbols,
				Action = ActionType.Unsubscribe
			};
			AddMessageToQueue(sr);
		}

		public void SubscribeTicker(string symbol)
		{
			TickerRequest tr = new TickerRequest
			{
				Channel = ChannelType.Ticker,
				Action = ActionType.Subscribe,
				Symbol = symbol
			};
			AddMessageToQueue(tr);
		}

		public void UnsubscribeTicker()
		{
			TickerRequest tr = new TickerRequest
			{
				Channel = ChannelType.Ticker,
				Action = ActionType.Unsubscribe
			};
			AddMessageToQueue(tr);
		}

		public void SubscribeTrades(string symbol)
		{
			TradesRequest tr = new TradesRequest
			{
				Channel = ChannelType.Trades,
				Action = ActionType.Subscribe,
				Symbol = symbol
			};
			AddMessageToQueue(tr);
		}

		public void UnsubscribeTrades()
		{
			TradesRequest tr = new TradesRequest
			{
				Channel = ChannelType.Trades,
				Action = ActionType.Unsubscribe
			};
			AddMessageToQueue(tr);
		}

        public void SubscribeTrading()
        {
            TradingRequest tr = new TradingRequest
            {
                Channel = ChannelType.Trading,
                Action = ActionType.Subscribe
            };
            AddMessageToQueue(tr);
        }

        public void UnsubscribeTrading()
        {
            TradingRequest tr = new TradingRequest
            {
                Channel = ChannelType.Trading,
                Action = ActionType.Unsubscribe
            };
            AddMessageToQueue(tr);
        }

        public void CreateOrder(CreateNewOrderRequest order)
		{
            AddMessageToQueue(order);
        }

		public void CancelOrder(string OrderId)
		{
            CancelOrderRequest cancel = new CancelOrderRequest
            {
                OrderID = OrderId
            };

            AddMessageToQueue(cancel);

        }

		private async Task ConnectSocketAsync()
		{
			socket.Options.SetRequestHeader(HeaderName, HeaderURL);
			if (cancellationToken == null) cancellationToken = new CancellationTokenSource(TimeOutMiliseconds);
			await socket.ConnectAsync(new Uri(ConnectionURI), cancellationToken.Token);
		}

        public async Task RunAsync()
        {
			try
			{
				do
				{
					while (MessageQueue.Count > 0)
					{
						await SendAsync(MessageQueue.Dequeue());
					}
					await ReceiveAsync();
				} while (true);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR - {ex.Message}");
			}
		} 

		private void AddMessageToQueue(BaseRequest request)
		{
			string message = jsonHandler.Encode<BaseRequest>(request);
			MessageQueue.Enqueue(message);
		}

		private async Task SendAsync(string data)
		{
			var encoded = Encoding.UTF8.GetBytes(data);
			var buffer = new ArraySegment<Byte>(encoded, 0, encoded.Length);

			await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
		}

		private async Task ReceiveAsync()
		{
			var buffer = new ArraySegment<byte>(new byte[2048]);

			WebSocketReceiveResult result;

			using (var ms = new MemoryStream())
			{
				do
				{
					result = await socket.ReceiveAsync(buffer, CancellationToken.None);
					ms.Write(buffer.Array, buffer.Offset, result.Count);
				} while (!result.EndOfMessage);

				ms.Seek(0, SeekOrigin.Begin);
				using (var reader = new StreamReader(ms, Encoding.UTF8))
				{
					BaseResponse response = DeserializeMessage(await reader.ReadToEndAsync());

					if (response != null)
					{
						switch (response.Channel)
						{
							case ChannelType.None:		{ throw new NotImplementedException(); }
							case ChannelType.Heartbeat: { OnHeartbeatEvent?.Invoke(		this,	(HeartbeatResponse)response);	break; }
							case ChannelType.L2:		{ OnOrderBookL2Event?.Invoke(	this,	(OrderBookL2Response)response); break; }
							case ChannelType.L3:		{ OnOrderBookL3Event?.Invoke(	this,	(OrderBookL3Response)response); break; }
							case ChannelType.Prices:	{ OnPriceEvent?.Invoke(			this,	(PriceResponse)response);		break; }
							case ChannelType.Symbols:	{ OnSymbolEvent?.Invoke(		this,	(SymbolsResponse)response);		break; }
							case ChannelType.Ticker:	{ OnTickerEvent?.Invoke(		this,	(TickerResponse)response);		break; }
							case ChannelType.Trades:	{ OnTradesEvent?.Invoke(		this,	(TradesResponse)response);		break; }
							case ChannelType.Auth:		{ OnAuthorisationEvent?.Invoke(	this,	(AuthResponse)response);		break; }
							case ChannelType.Balances:	{ OnBalanceEvent?.Invoke(		this,	(BalanceResponse)response);		break; }
							case ChannelType.Trading:	{ OnTradingEvent?.Invoke(		this,	(TradingResponse)response);		break; }
							default:					{ throw new NotImplementedException(); }
						}
					}
				}
			}
		}

		private BaseResponse DeserializeMessage(string Message)
		{
			try
			{
				BaseResponse headerResponse = jsonHandler.Decode<BaseResponse>(Message);

				switch (headerResponse.Channel)
				{
					case ChannelType.None:		{ throw new NotImplementedException(); }
					case ChannelType.Heartbeat: { return jsonHandler.Decode<HeartbeatResponse>(Message); }
					case ChannelType.L2:		{ return jsonHandler.Decode<OrderBookL2Response>(Message); }
					case ChannelType.L3:		{ return jsonHandler.Decode<OrderBookL3Response>(Message); }
					case ChannelType.Prices:	{ return jsonHandler.Decode<PriceResponse>(Message); }
					case ChannelType.Symbols:	{ return jsonHandler.Decode<SymbolsResponse>(Message); }
					case ChannelType.Ticker:	{ return jsonHandler.Decode<TickerResponse>(Message); }
					case ChannelType.Trades:	{ return jsonHandler.Decode<TradesResponse>(Message); }
					case ChannelType.Auth:		{ return jsonHandler.Decode<AuthResponse>(Message); }
					case ChannelType.Balances:	{ return jsonHandler.Decode<BalanceResponse>(Message); }
					case ChannelType.Trading:	{ return jsonHandler.Decode<TradingResponse>(Message); }
					default:					{ return headerResponse; }
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR - { ex.Message }");
				return null;
			}
		}
	}
}
