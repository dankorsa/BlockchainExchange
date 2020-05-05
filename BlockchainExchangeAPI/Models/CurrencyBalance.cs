using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Models
{
	[JsonObject]
    public class CurrencyBalance
    {
		[JsonProperty("currency")]
        public string Currency { get; set; }

		[JsonProperty("balance")]
        public double Balance { get; set; }

		[JsonProperty("available")]
        public double Available { get; set; }

		[JsonProperty("balance_local")]
        public double BalanceLocal { get; set; }

		[JsonProperty("available_local")]
        public double AvailableLocal { get; set; }

		[JsonProperty("rate")]
        public double Rate { get; set; }

		public override string ToString() => $"Currency: {Currency} | Balance: {Balance} | Available: {Available} | Balance local: {BalanceLocal} | Available local: {AvailableLocal}";
    }
}
