using System.Collections.Generic;
using BlockchainExchangeAPI.Models;
using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Responses
{
    public class BalanceResponse : BaseResponse
    {
		[JsonProperty(PropertyName = "balances")]
        public List<CurrencyBalance> Balances = new List<CurrencyBalance>();

        [JsonProperty(PropertyName = "total_available_local")]
        public double Total_available_local = -0.01;

        [JsonProperty(PropertyName = "total_balance_local")]
        public double Total_balance_local = -0.01;

    }
}
