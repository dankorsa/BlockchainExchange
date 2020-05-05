using System.Runtime.Serialization;

namespace BlockchainExchangeAPI.Models
{
    public enum ChannelType
    {
		[EnumMember(Value = "")]
        None,
        [EnumMember(Value = "heartbeat")]
        Heartbeat,
        [EnumMember(Value = "l2")]
        L2,
        [EnumMember(Value = "l3")]
        L3,
        [EnumMember(Value = "prices")]
        Prices,
        [EnumMember(Value = "symbols")]
        Symbols,
        [EnumMember(Value = "ticker")]
        Ticker,
        [EnumMember(Value = "trades")]
        Trades,
        [EnumMember(Value = "auth")]
        Auth,
        [EnumMember(Value = "balances")]
        Balances,
        [EnumMember(Value = "trading")]
        Trading
    }

    public enum EventType
    {
		[EnumMember(Value = "")]
        None,
        [EnumMember(Value = "subscribed")]
        Subscribed,
        [EnumMember(Value = "unsubscribed")]
        Unsubscribed,
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "snapshot")]
        Snapshot,
        [EnumMember(Value = "updated")]
        Updated
    }

    public enum ActionType
    {
		[EnumMember(Value = "")]
        None,
        [EnumMember(Value = "subscribe")]
        Subscribe,
        [EnumMember(Value = "unsubscribe")]
        Unsubscribe,
        [EnumMember(Value = "NewOrderSingle")]
        NewOrderSingle,
        [EnumMember(Value = "CancelOrderRequest")]
        CancelOrderRequest
    }

    public enum GranularityValues : uint
	{
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "60")]
		Minute				= 60,
		[EnumMember(Value = "300")]
		FiveMinutes			= 300,
		[EnumMember(Value = "900")]
		FifteenMinutes		= 900,
		[EnumMember(Value = "3600")]
		Hour				= 3600,
		[EnumMember(Value = "21600")]
		SixHours			= 21600,
		[EnumMember(Value = "86400")]
		TwentyFourHours		= 86400
	}

    public enum SymbolStatus
    {
        [EnumMember(Value = "open")]
        Open,
        [EnumMember(Value = "close")]
        Close,
        [EnumMember(Value = "closed")]
        Closed,
        [EnumMember(Value = "suspend")]
        Suspend,
        [EnumMember(Value = "halt")]
        Halt,
        [EnumMember(Value = "halt-freeze")]
        Halt_Freeze,
        [EnumMember(Value = "")]
        None
    }

    public enum SideType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "sell")]
        Sell,
        [EnumMember(Value = "buy")]
        Buy
    }

    public enum OrderType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "market")]
        Market,
        [EnumMember(Value = "limit")]
        Limit,
        [EnumMember(Value = "stop")]
        Stop,
        [EnumMember(Value = "stopLimit")]
        StopLimit
    }

    public enum OrderStatus
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "open")]
        Open,
        [EnumMember(Value = "rejected")]
        Rejected,
        [EnumMember(Value = "cancelled")]
        Cancelled,
        [EnumMember(Value = "filled")]
        Filled,
        [EnumMember(Value = "partial")]
        Partial,
        [EnumMember(Value = "expired")]
        Expired

    }

    public enum TimeInForceType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "GTC")]
        GoodTillCancel,
        [EnumMember(Value = "GTD")]
        GoodTillDate,
        [EnumMember(Value = "FOK")]
        FillorKill,
        [EnumMember(Value = "IOC")]
        ImmediateOrCancel
    }

    public enum OrderMessageType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "8")]
        ExecutionReport,
        [EnumMember(Value = "9")]
        OrderCancelRejected
    }


    public enum ExecutionType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "0")]
        New,
        [EnumMember(Value = "4")]
        Cancelled,
        [EnumMember(Value = "C")]
        Expired,
        [EnumMember(Value = "8")]
        Rejected,
        [EnumMember(Value = "F")]
        PartiallFill,
        [EnumMember(Value = "H")]
        TradeBreak,
        [EnumMember(Value = "I")]
        OrderStatus,
    }

}
