using BlockchainExchangeAPI.Models;

namespace BlockchainExchangeAPI.Requests
{
    public class BalanceRequest : BaseRequest
    {
        public BalanceRequest ()
        {
            Channel = ChannelType.Balances;
        }
    }
}
