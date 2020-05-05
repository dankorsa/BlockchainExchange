using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Requests
{
    class OrderBookRequest : BaseRequest
    {
		[JsonProperty(PropertyName = "symbol")]
        public string Symbol = "";
    }
}
