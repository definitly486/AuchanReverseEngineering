using System;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Home;
using Auchan.Common.Profile;

namespace Auchan.Common.Notifications;

public class NotificationsApplicationStateObserver : IApplicationStateObserver, IViewModelStateObserver
{
	private readonly NotificationsCounterService _counterService;

	private bool _inBackground;

	private Type? _currentScreenType;

	public NotificationsApplicationStateObserver(NotificationsCounterService counterService)
	{
		_counterService = counterService;
	}

	public void OnViewModelResumed(ScreenViewModel vm)
	{
		_currentScreenType = vm.GetType();
	}

	public void OnResumed()
	{
		if (_inBackground)
		{
			_inBackground = false;
			if (_currentScreenType == typeof(HomeViewModel) || _currentScreenType == typeof(ProfileViewModel))
			{
				_counterService.RefreshInBackground();
			}
		}
	}

	public void OnPaused()
	{
		_inBackground = true;
	}
}
