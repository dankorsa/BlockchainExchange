using System;
using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Models
{
    public class CandleStickPrice
    {
		[JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp = DateTime.MinValue;

		[JsonProperty(PropertyName = "open")]
        public double Open = -0.1;

		[JsonProperty(PropertyName = "high")]
        public double High = -0.1;

		[JsonProperty(PropertyName = "low")]
        public double Low = -0.1;

		[JsonProperty(PropertyName = "close")]
        public double Close = -0.1;

		[JsonProperty(PropertyName = "volume")]
        public double Volume = -0.1;

		public override string ToString() => $"{Timestamp}: Open: {Open} | High: {High} | Low: {Low} | Close: {Close} | Volume: {Volume}";
    }
}