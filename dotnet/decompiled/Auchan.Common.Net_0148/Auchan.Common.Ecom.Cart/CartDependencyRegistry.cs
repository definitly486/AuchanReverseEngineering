using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using DryIoc;

namespace Auchan.Common.Ecom.Cart;

public class CartDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.Register<Cart>(Reuse.Singleton);
		registrator.Register<CashbackLimitNotifier>(Reuse.Singleton);
		registrator.Register<IApplicationStateObserver, CashbackLimitNotifier>();
		registrator.Register<RemoteCartService>();
		registrator.Register<ICheckoutService, CheckoutService>();
		registrator.Register<CheckoutService>();
		registrator.Register<PaymentUrlHelper>();
		registrator.AddRefitClient<ICheckoutApi, AuthTokenHeaderMessageHandler>();
		registrator.AddRefitClient<ICheckoutApiV2, AuthTokenHeaderMessageHandler>();
	}
}
