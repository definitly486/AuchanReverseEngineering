using System;

namespace Polly.Caching;

internal sealed class GenericCacheProvider<TCacheFormat> : ISyncCacheProvider<TCacheFormat>
{
	private readonly ISyncCacheProvider _wrappedCacheProvider;

	internal GenericCacheProvider(ISyncCacheProvider nonGenericCacheProvider)
	{
		_wrappedCacheProvider = nonGenericCacheProvider ?? throw new ArgumentNullException("nonGenericCacheProvider");
	}

	(bool, TCacheFormat?) ISyncCacheProvider<TCacheFormat>.TryGet(string key)
	{
		(bool, object?) tuple = _wrappedCacheProvider.TryGet(key);
		bool item = tuple.Item1;
		object item2 = tuple.Item2;
		TCacheFormat item3 = default(TCacheFormat);
		if (item)
		{
			item3 = (TCacheFormat)item2;
		}
		return (item, item3);
	}

	void ISyncCacheProvider<TCacheFormat>.Put(string key, TCacheFormat? value, Ttl ttl)
	{
		_wrappedCacheProvider.Put(key, value, ttl);
	}
}
