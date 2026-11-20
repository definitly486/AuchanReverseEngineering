using System;
using Auchan.Common.Common;
using Auchan.Common.Ecom;

namespace Auchan.Common.Addresses;

public class AddressApplicationStateObserver : IApplicationStateObserver
{
	private readonly Lazy<IEcomContext> _ecomContext;

	public AddressApplicationStateObserver(Lazy<IEcomContext> ecomContext)
	{
		_ecomContext = ecomContext;
	}

	public void OnResumed()
	{
		_ecomContext.Value.NotifyAppResumed();
	}
}
