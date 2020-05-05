using System;
using BlockchainExchangeAPI.Models;
using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Responses
{
    public class TradesResponse : BaseResponse
    {
		[JsonProperty(PropertyName = "symbol")]
        public string Symbol = "";

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp = DateTime.Now;

        [JsonProperty(PropertyName = "side")]
        public SideType Side = SideType.None;

        [JsonProperty(PropertyName = "qty")]
        public double Qty = -0.1;

        [JsonProperty(PropertyName = "price")]
        public double Price = -0.1;

        [JsonProperty(PropertyName = "trade_id")]
        public string Trade_id = "";

    }
}
