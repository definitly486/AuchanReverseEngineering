using System;
using System.Threading.Tasks;
using Auchan.Common.Profile.Stores.Models;

namespace Auchan.Common.Profile.Stores.Services;

public interface IFullStoreFilterService
{
	FullStoreFilterModel Filter { get; }

	IObservable<bool> OnChangeFilterIcon { get; }

	bool IsServicesChanged { get; }

	void SetRegion(int regionId, string regionName);

	void SetService(bool isChecked, int serviceId);

	void SetStoreType(StoreType storeType);

	void Apply(bool isFilterIconChange = true);

	void ReloadServices();

	void ClearAll();

	void ClearServices();

	Task SetDefault();

	void SetCurrentIcon();
}
