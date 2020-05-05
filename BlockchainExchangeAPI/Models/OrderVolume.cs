using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Models
{
	[JsonObject]
    public class OrderVolume
    {
		[JsonProperty("px")]
        public double PX = -0.01;
		[JsonProperty("qty")]
        public double QTY = -0.01;
		[JsonProperty("num")]
        public double NUM = 0;

		public override string ToString() => $"Order number: {NUM} | Quantity: {QTY} | Price level: {PX}";
	}
}
