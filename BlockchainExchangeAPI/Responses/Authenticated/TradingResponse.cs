using System.Collections.Generic;
using BlockchainExchangeAPI.Models;
using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Responses.Authenticated
{
    public class TradingResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "orders")]
        public List<MyOrder> Orders = new List<MyOrder>();
    }
}
