using BlockchainExchangeAPI.Models;
using Newtonsoft.Json;

namespace BlockchainExchangeAPI.Requests
{
    public class AuthRequest : BaseRequest
    {
        public AuthRequest()
        {
            Channel = ChannelType.Auth;
        }

		[JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}
