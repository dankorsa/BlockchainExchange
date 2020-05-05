using BlockchainExchangeAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace BlockchainExchangeAPI.Requests
{
    public class CreateNewOrderRequest : BaseRequest
    {
        public CreateNewOrderRequest()
        {
            Channel = ChannelType.Trading;
            Action = ActionType.NewOrderSingle;
        }

        [JsonProperty(PropertyName = "clOrdID")]
        public string ClOrdID = "Order-" +DateTime.Now.ToShortTimeString();

		[JsonProperty(PropertyName = "symbol")]
        public string Symbol = "";

        [JsonProperty(PropertyName = "ordType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderType orderType = OrderType.None;

        [JsonProperty(PropertyName = "timeInForce")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TimeInForceType TimeInForce = TimeInForceType.None;

        [JsonProperty(PropertyName = "side")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SideType Side = SideType.None;

        [JsonProperty(PropertyName = "orderQty")]
        public double OrderQty = -0.01;

        [JsonProperty(PropertyName = "price")]
        public double Price = -0.01;


        [JsonProperty(PropertyName = "execInst")]
        public string ExecInst = "ALO";

    }
}
