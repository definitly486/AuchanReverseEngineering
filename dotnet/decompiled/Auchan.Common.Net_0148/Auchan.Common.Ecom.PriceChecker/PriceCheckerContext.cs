using System.Threading.Tasks;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Extensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Ecom.PriceChecker;

public class PriceCheckerContext : IPriceCheckerContext
{
	private const string PRICE_CHECKER_CONTEXT_PREFERENCES = "PriceCheckerContextPreferences";

	private const string PRICE_CHECKER_STORE = "PriceCheckerStore";

	private const string PRICE_CHECKER_REGION_ID = "PriceCheckerRegionId";

	private Store? _savedStore;

	private long? _regionId;

	private bool _savedStoreLoaded;

	private bool _regionIdLoaded;

	public Store? SavedStore
	{
		get
		{
			if (!_savedStoreLoaded)
			{
				_savedStore = ((!RegionId.HasValue) ? null : PreferencesEx.Get<Store>("PriceCheckerStore", "PriceCheckerContextPreferences"));
				_savedStoreLoaded = true;
			}
			return _savedStore;
		}
	}

	public long? RegionId
	{
		get
		{
			if (!_regionIdLoaded)
			{
				long num = Preferences.Get("PriceCheckerRegionId", long.MinValue, "PriceCheckerContextPreferences");
				_regionId = ((num == long.MinValue) ? ((long?)null) : new long?(num));
				_regionIdLoaded = true;
			}
			return _regionId;
		}
	}

	public void SaveStore(Store store)
	{
		_savedStore = store;
		_regionId = store.City.EcomId;
		_savedStoreLoaded = true;
		_regionIdLoaded = true;
		PreferencesEx.Set("PriceCheckerStore", store, "PriceCheckerContextPreferences");
		Preferences.Set("PriceCheckerRegionId", _regionId.Value, "PriceCheckerContextPreferences");
	}

	public void ResetIfRegionChanged(long onlineRegionId)
	{
		if (RegionId.HasValue && RegionId != onlineRegionId)
		{
			Clear();
		}
	}

	public Task CleanDeinitialize()
	{
		Clear();
		return Task.CompletedTask;
	}

	private void Clear()
	{
		_savedStore = null;
		_regionId = null;
		_savedStoreLoaded = true;
		_regionIdLoaded = true;
		Preferences.Clear("PriceCheckerContextPreferences");
	}
}
