using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlockchainExchangeAPI.Models
{
    public class Symbol
    {
		[JsonProperty(PropertyName = "base_currency")]
        public string BaseCurrency = "";

		[JsonProperty(PropertyName = "base_currency_scale")]
        public double BaseCurrencyScale = -0.1;

		[JsonProperty(PropertyName = "counter_currency")]
        public string CounterCurrency = "";

		[JsonProperty(PropertyName = "counter_currency_scale")]
        public double CounterCurrencyScale = -0.1;

		[JsonProperty(PropertyName = "min_price_increment")]
        public double MinPriceIncrement = -0.1;

		[JsonProperty(PropertyName = "min_price_increment_scale")]
        public double MinPriceIncrementScale = -0.1;

		[JsonProperty(PropertyName = "min_order_size")]
        public double MinOrderSize = -0.1;

		[JsonProperty(PropertyName = "min_order_size_scale")]
        public double MinOrderSizeScale = -0.1;

		[JsonProperty(PropertyName = "max_order_size")]
        public double MaxOrderSize = -0.1;

		[JsonProperty(PropertyName = "max_order_size_scale")]
        public double MaxOrderSizeScale = -0.1;

		[JsonProperty(PropertyName = "lot_size")]
        public double LotSize = -0.1;

		[JsonProperty(PropertyName = "lot_size_scale")]
        public double LotSizeScale = -0.1;



		[JsonProperty(PropertyName = "status")]
        [JsonConverter(typeof(StringEnumConverter))]
		public SymbolStatus Status;



		[JsonProperty(PropertyName = "id")]
        public double ID = -0.1;

		[JsonProperty(PropertyName = "auction_price")]
        public double AuctionPrice = -0.1;
        
		[JsonProperty(PropertyName = "auction_size")]
		public double AuctionSize = -0.1;

		[JsonProperty(PropertyName = "auction_time")]
        public string AuctionTime = "";

		[JsonProperty(PropertyName = "imbalance")]
        public double Imbalance = -0.1;
    }
}
