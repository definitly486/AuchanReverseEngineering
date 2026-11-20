using System;
using System.Threading.Tasks;
using Auchan.Common.Analytics.YandexAppMetrica.DataStores;
using Auchan.Common.Common;
using Auchan.Common.PersonalCabinet;

namespace Auchan.Common.Profile.WaitList;

public class WaitListApplicationStateObserver : IApplicationStateObserver
{
	private readonly Lazy<IUserContext> _userContext;

	private readonly Lazy<WaitListProducts> _waitListProducts;

	private readonly Lazy<ScreenDataStore> _screenDataStore;

	public WaitListApplicationStateObserver(Lazy<WaitListProducts> waitListProducts, Lazy<IUserContext> userContext, Lazy<ScreenDataStore> screenDataStore)
	{
		_userContext = userContext;
		_waitListProducts = waitListProducts;
		_screenDataStore = screenDataStore;
	}

	public async Task OnResumedAsync()
	{
		if (_userContext.Value.Authorized && _screenDataStore.Value.GetCurrentScreenViewModelType()?.GetType() != typeof(WaitListViewModel))
		{
			await _waitListProducts.Value.UpdateBadge();
		}
	}
}
