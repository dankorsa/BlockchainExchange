using System.Collections.Generic;
using BlockchainExchangeAPI.Models;
using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Responses
{
    public class OrderBookL3Response : BaseResponse
    {
		[JsonProperty(PropertyName = "symbol")]
        public string Symbol = "";

		[JsonProperty(PropertyName = "bids")]
        public List<Order> Bids = new List<Order>();

		[JsonProperty(PropertyName = "asks")]
        public List<Order> Asks = new List<Order>();
    }
}
