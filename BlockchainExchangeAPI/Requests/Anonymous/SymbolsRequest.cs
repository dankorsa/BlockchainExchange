using BlockchainExchangeAPI.Models;

namespace BlockchainExchangeAPI.Requests
{
    public class SymbolsRequest : BaseRequest
    {
        public SymbolsRequest()
        {
            Channel = ChannelType.Symbols;
        }
    }
}
