namespace Auchan.Common.Common;

public interface IDataBroker
{
	T Pop<T>(BrokerToken token) where T : BrokeredParameter;

	BrokerToken Push(BrokeredParameter data);
}
