using System.Collections.Generic;
using BlockchainExchangeAPI.Models;
using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Responses
{
    public class OrderBookL2Response : BaseResponse
    {
		[JsonProperty(PropertyName = "symbol")]
        public string Symbol = "";

		[JsonProperty(PropertyName = "bids")]
        public List<OrderVolume> Bids = new List<OrderVolume>();

		[JsonProperty(PropertyName = "asks")]
        public List<OrderVolume> Asks = new List<OrderVolume>();
    }
}
