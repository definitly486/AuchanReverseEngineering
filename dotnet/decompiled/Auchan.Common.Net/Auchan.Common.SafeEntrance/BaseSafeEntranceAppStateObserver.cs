using System;
using Auchan.Common.Common;
using Auchan.Common.SafeEntrance.Managers;

namespace Auchan.Common.SafeEntrance;

public abstract class BaseSafeEntranceAppStateObserver : IApplicationStateObserver
{
	private readonly Lazy<ISafeEntranceManager> _safeEntranceManager;

	protected BaseSafeEntranceAppStateObserver(Lazy<ISafeEntranceManager> safeEntranceManager)
	{
		_safeEntranceManager = safeEntranceManager;
	}

	public void OnPaused()
	{
		_safeEntranceManager.Value.MarkBackgroundTransitionForSafeEntrance();
	}

	public void OnResumed()
	{
		_safeEntranceManager.Value.MarkForegroundTransitionForSafeEntrance();
		if (_safeEntranceManager.Value.ShouldShowEnterPinCode())
		{
			ShowEnterPinPageIfNeeded();
		}
	}

	protected abstract void ShowEnterPinPageIfNeeded();
}
