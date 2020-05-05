using System.Collections.Generic;
using BlockchainExchangeAPI.Models;
using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Responses
{
    public class SymbolsResponse : BaseResponse
    {
		[JsonProperty(PropertyName = "symbols")]
		public Dictionary<string, Symbol> symbols = new Dictionary<string, Symbol>();
    }
}
