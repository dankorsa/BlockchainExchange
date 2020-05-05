using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Responses
{
    public class TickerResponse : BaseResponse
    {
		[JsonProperty(PropertyName = "symbol")]
        public string Symbol = "";


        [JsonProperty(PropertyName = "price_24h")]
        public double Price_24h = -0.1;


        [JsonProperty(PropertyName = "volume_24h")]
        public double Volume_24h = -0.1;


        [JsonProperty(PropertyName = "last_trade_price")]
        public double Last_trade_price = -0.1;
    }
}
