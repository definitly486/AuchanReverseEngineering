using System;
using System.Collections.Generic;

namespace Auchan.Common.Common;

internal sealed class DataBroker : IDataBroker
{
	private readonly Dictionary<Guid, object> _data = new Dictionary<Guid, object>();

	public int RecordsCount
	{
		get
		{
			lock (_data)
			{
				return _data.Count;
			}
		}
	}

	public BrokerToken Push(BrokeredParameter data)
	{
		return new BrokerToken
		{
			Token = PushPrivate(data)
		};
	}

	private Guid PushPrivate(object data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		Guid guid = Guid.NewGuid();
		lock (_data)
		{
			_data[guid] = data;
			return guid;
		}
	}

	public T Pop<T>(BrokerToken token) where T : BrokeredParameter
	{
		return (T)Pop(token.Token);
	}

	private object Pop(Guid token)
	{
		lock (_data)
		{
			if (_data.TryGetValue(token, out object value))
			{
				_data.Remove(token);
				return value;
			}
		}
		throw new ArgumentException("Your token is not valid or you already received data.", "token");
	}
}
