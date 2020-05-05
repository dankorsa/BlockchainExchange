using BlockchainExchangeAPI.Models;
using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Requests.Authenticated
{
    public class CancelOrderRequest : BaseRequest
    {
       public CancelOrderRequest()
        {
            Action = ActionType.CancelOrderRequest;
            Channel = ChannelType.Trading;
        }

        [JsonProperty(PropertyName = "orderID")]
        public string OrderID = "";
    }
}
