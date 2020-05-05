using BlockchainExchangeAPI.Models;

namespace BlockchainExchangeAPI.Requests
{
    public class HeartbeatRequest : BaseRequest
    {
        public HeartbeatRequest()
        {
            Channel = ChannelType.Heartbeat;
        }
    }
}
