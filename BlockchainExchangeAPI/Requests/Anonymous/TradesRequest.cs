using BlockchainExchangeAPI.Models;
using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Requests
{
    public class TradesRequest : BaseRequest
    {
        public TradesRequest()
        {
            Channel = ChannelType.Trades;
        }

		[JsonProperty(PropertyName = "symbol")]
        public string Symbol = "";
    }
}
