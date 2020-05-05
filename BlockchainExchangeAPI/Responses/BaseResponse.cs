using BlockchainExchangeAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlockchainExchangeAPI.Responses
{
    public class BaseResponse
    {
		[JsonProperty(PropertyName = "seqnum")]
        public long Seqnum = 0;

		[JsonProperty(PropertyName = "event")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EventType Event = EventType.None;

		[JsonProperty(PropertyName = "channel")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ChannelType Channel = ChannelType.None;

		[JsonProperty(PropertyName = "text")]
        public string Message = "";

        public bool HasErrors { get { return !Message.Equals(""); } }
    }
}
