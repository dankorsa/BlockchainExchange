using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace BlockchainExchangeAPI.Models
{
    public class MyOrder
    {
        public string orderID = "";

        [JsonProperty(PropertyName = "clOrdID")]
        public string ClOrdID = "";

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol = "";

        [JsonProperty(PropertyName = "side")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SideType Side = SideType.None;

        [JsonProperty(PropertyName = "ordType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderType orderType = OrderType.None;

        [JsonProperty(PropertyName = "orderQty")]
        public double OrderQty = -0.01;

        [JsonProperty(PropertyName = "leavesQty")]
        public double LeavesQty = -0.01;

        [JsonProperty(PropertyName = "cumQty")]
        public double CumQty = -0.01;

        [JsonProperty(PropertyName = "AvgPx")]
        public double avgPx = -0.01;

        [JsonProperty(PropertyName = "ordStatus")]
        public OrderStatus OrdStatus = OrderStatus.None;
        

        [JsonProperty(PropertyName = "timeInForce")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TimeInForceType TimeInForce = TimeInForceType.None;

        [JsonProperty(PropertyName = "text")]
        public string Text = "";

        [JsonProperty(PropertyName = "execType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ExecutionType ExecType = ExecutionType.None;

        [JsonProperty(PropertyName = "execID")]
        public string ExecID = "";

        [JsonProperty(PropertyName = "transactTime")]
        public DateTime TransactTime = DateTime.MinValue;

        [JsonProperty(PropertyName = "msgType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderMessageType MsgType = OrderMessageType.None;


        [JsonProperty(PropertyName = "lastPx")]
        public double LastPx = -0.01;

        [JsonProperty(PropertyName = "lastShares")]
        public double LastShares = -0.01;

        [JsonProperty(PropertyName = "tradeId")]
        public string TradeId = "";

        [JsonProperty(PropertyName = "price")]
        public double Price = -0.01;

        [JsonProperty(PropertyName = "minQty")]
        public double MinQty = -0.01;

        [JsonProperty(PropertyName = "fee")]
        public double Fee = -0.01;
    }
}
