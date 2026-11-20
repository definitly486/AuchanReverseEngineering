using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Analytics.YandexAppMetrica;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Common;

public class ApplicationStateManager : IApplicationStateManager
{
	public const string LastUserActivityTimeCacheKey = "last_user_activity_time";

	private readonly IEnumerable<IApplicationStateObserver> _observers;

	public event Action? OnStartCallback;

	public event Action? OnResumedCallback;

	public event Action? OnPausedCallback;

	public ApplicationStateManager(IEnumerable<IApplicationStateObserver> observers)
	{
		_observers = observers;
	}

	public async Task StartAsync()
	{
		Preferences.Remove("last_user_activity_time");
		this.OnStartCallback?.Invoke();
		await Task.WhenAll(_observers.Select((IApplicationStateObserver i) => i.StartAsync()));
	}

	public async Task OnResumedAsync()
	{
		AppMetrica.WarmStartWatch.Start();
		this.OnResumedCallback?.Invoke();
		await Task.WhenAll(_observers.Select((IApplicationStateObserver i) => i.OnResumedAsync()));
	}

	public async Task DidBecomeActiveAsync()
	{
		await Task.WhenAll(_observers.Select((IApplicationStateObserver i) => i.DidBecomeActiveAsync()));
	}

	public async Task OnPausedAsync()
	{
		Preferences.Set("last_user_activity_time", DateTime.UtcNow);
		this.OnPausedCallback?.Invoke();
		await Task.WhenAll(_observers.Select((IApplicationStateObserver i) => i.OnPausedAsync()));
	}
}
