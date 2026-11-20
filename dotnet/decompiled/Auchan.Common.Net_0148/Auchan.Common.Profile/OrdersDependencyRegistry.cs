using Auchan.Common.Common.Location;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.Profile.Orders;
using Auchan.Common.Profile.Orders.Models;
using Auchan.Common.Profile.Orders.Services;
using DryIoc;

namespace Auchan.Common.Profile;

internal static class OrdersDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.AddRefitClient<IOrdersApi, AuthTokenHeaderMessageHandler>();
		registrator.AddRefitClient<IOrderCancellationReasonsApi>();
		registrator.RegisterMany<LocationPermissionService>(Reuse.Singleton);
		registrator.Register<IOrderCancellationReasonsService, OrderCancellationReasonsService>(Reuse.Singleton);
		registrator.Register<IOrdersService, OrdersService>(Reuse.Singleton);
		registrator.Register<IOrdersRepository, OrdersRepository>(Reuse.Singleton);
		registrator.Register<ILocationService, LocationService>(Reuse.Singleton);
		registrator.Register<IAddToOrderButtonItemViewModel, AddToOrderButtonItemViewModel>();
		registrator.Register<OrderItemProductItemViewModel>();
		registrator.Register<OrderItemViewModel>();
		registrator.Register<HomeOrderItemViewModel>();
		registrator.Register<OrderDetailProductItemViewModel>();
		registrator.Register<PickupPointOrdersChecker>();
		registrator.Register<IOrderDetailsParameterFactory, OrderDetailsParameterFactory>();
		registrator.Register<RepeatOrderProductItemViewModel>();
		registrator.Register<RepeatOrderService>();
		registrator.Register<AdditionalOrderProductItem>();
		registrator.Register<ICallToCourierItemViewModel, CallToCourierItemViewModel>();
	}
}
