using System;
using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Responses
{
    public class HeartbeatResponse : BaseResponse
    {
		[JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp = DateTime.MinValue;
    }
}
