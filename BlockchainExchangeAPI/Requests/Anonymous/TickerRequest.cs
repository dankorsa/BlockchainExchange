using BlockchainExchangeAPI.Models;
using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Requests
{
    public class TickerRequest : BaseRequest
    {
        public TickerRequest()
        {
            Channel = ChannelType.Ticker;
        }

		[JsonProperty(PropertyName = "symbol")]
        public string Symbol = "";
    }
}
