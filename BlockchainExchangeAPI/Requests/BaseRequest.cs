using BlockchainExchangeAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlockchainExchangeAPI.Requests
{
    public class BaseRequest
    {
		[JsonProperty(PropertyName = "action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionType Action = ActionType.None;

		[JsonProperty(PropertyName = "channel")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ChannelType Channel = ChannelType.None;

    }
}
