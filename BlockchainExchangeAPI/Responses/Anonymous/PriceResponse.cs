using BlockchainExchangeAPI.Models;
using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Responses
{
    public class PriceResponse : BaseResponse
    {
        public CandleStickPrice[] price;

		[JsonProperty(PropertyName = "symbol")]
        public string Symbol = "";
    }
}
