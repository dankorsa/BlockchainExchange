using BlockchainExchangeAPI.Models;

namespace BlockchainExchangeAPI.Requests
{
    class TradingRequest : BaseRequest
    {
        public TradingRequest()
        {
            Channel = ChannelType.Trading;
        }
    }
}
