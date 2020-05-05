using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using BlockchainExchangeAPI.Models;

namespace BlockchainExchangeAPI.Requests
{
    public class PriceRequest : BaseRequest
    {
		[JsonProperty(PropertyName = "symbol")]
        public string Symbol = "";

		[JsonProperty(PropertyName = "granularity")]
		[JsonConverter(typeof(StringEnumConverter))]
        public GranularityValues Granularity = GranularityValues.None;
    }
}
