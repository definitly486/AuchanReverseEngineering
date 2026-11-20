using Auchan.Common.Base;
using Auchan.Common.Profile.Stores.Models;

namespace Auchan.Common.Profile.Stores;

public class StoreDetailsServicesItemViewModel : BaseItemViewModel
{
	public string NameText { get; }

	public string IconPath { get; }

	public StoreDetailsServicesItemViewModel(FullStoreServiceModel service)
	{
		NameText = service.Name;
		IconPath = service.Icon;
	}
}
