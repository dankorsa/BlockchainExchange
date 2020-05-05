using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Models
{
	[JsonObject]
    public class Order
    {
		[JsonProperty("px")]
        public double PX = -0.01;
		[JsonProperty("qty")]
        public double QTY = -0.01;
		[JsonProperty("id")]
        public string ID = "0";

		public override string ToString() => $"Order id: {ID} | Price: {PX} | Quantity: {QTY} ";
    }
}
