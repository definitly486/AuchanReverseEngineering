using Auchan.Common.Ecom.CtmShelves.Models;
using Auchan.Common.Ecom.CtmShelves.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using DryIoc;

namespace Auchan.Common.Ecom.CtmShelves;

internal static class DependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.AddRefitClient<ICtmShelvesApi, AuthTokenHeaderMessageHandler>();
		registrator.Register<ICtmShelvesService, CtmShelvesService>();
		registrator.Register<ShelfItemViewModel>();
		registrator.Register<CtmShelfAnalyticsActions>();
		registrator.Register<CtmLink>();
	}
}
